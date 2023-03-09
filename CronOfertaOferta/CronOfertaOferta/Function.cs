using Amazon.Lambda.Core;
using CronOfertaOferta.Context;
using CronOfertaOferta.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CronOfertaOferta;
/// <summary>
/// 
/// </summary>
public class Function
{

    
    public class SincronizacionResponse
    {
        public string? Mensaje { get; set; }
        public bool Error { get; set; }
        public Sincronizacion? Data { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class Sincronizacion
    {
        public int cantidadTotal { get; set; }
        public int tiempoTotal { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>

    public Task<SincronizacionResponse> FunctionHandler()
    {
        
        SincronizacionResponse response = new SincronizacionResponse();
        string tableSincronizacion = "CRM_OFERTA";
        int cantidadTotal = 0;
        //DateTime init = DateTime.Now;
        DateTime init = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "America/Lima");
        List<IntermediaOferta> listaDatosNuevos = new List<IntermediaOferta>();

        //DateTime initProyecto = Convert.ToDateTime(Environment.GetEnvironmentVariable(PROYECT_INIT"));
       
        try
        {
            using (var _ctxIntermedio = new IntermedioCtx())
            using (var _ctxWin = new WinCtx())
            {
          var  initProyecto = _ctxIntermedio.Auditoria.Where(x=>x.SINC_TABLE == tableSincronizacion ).OrderBy(x=>x.SINC_FECHA_REGISTRO).FirstOrDefault();
               
                listaDatosNuevos =  (from crmlista in _ctxWin.CrmOfertaCanal
                                     join inlist in _ctxWin.CrmOferta on crmlista.ofti_cod_oferta equals inlist.ofti_cod_oferta
                                     where crmlista.ofcc_cod_canal_venta == "10"  && crmlista.ofcd_fecha_creacion >= initProyecto.SINC_FECHA_REGISTRO
                                          select inlist).ToList();

                

                foreach (IntermediaOferta item in listaDatosNuevos)
                {
                    try
                    {

                        if (_ctxIntermedio.InOferta.AsNoTracking().Any(e => e.ofti_cod_oferta == item.ofti_cod_oferta))
                        {
                            cantidadTotal++;
                            _ctxIntermedio.InOferta.Update(item);
                        }
                        else
                        {
                            cantidadTotal++;
                            _ctxIntermedio.InOferta.Add(item);
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString() + " en la direccion con codigo " + item.ofti_cod_oferta);
                       
                    }
                }

                try
                {
                    _ctxIntermedio.SaveChanges();
                    Auditoria adt = new Auditoria();
                    adt.SINC_TABLE = tableSincronizacion;
                    adt.SINC_FECHA_REGISTRO = init;
                    if (listaDatosNuevos.Count > 0)
                    {
                        adt.SINC_COMPLETA = true;
                    }
                    else
                    {
                        adt.SINC_COMPLETA = false;
                    }
                    _ctxIntermedio.Auditoria.Add(adt);
                }
                catch
                {
                    Auditoria adt = new Auditoria();
                    adt.SINC_TABLE = tableSincronizacion;
                    adt.SINC_FECHA_REGISTRO = init;
                    adt.SINC_COMPLETA = false;
                    _ctxIntermedio.Auditoria.Add(adt);
                }
                _ctxIntermedio.SaveChanges();
            }
            response.Data = new Sincronizacion()
            {
                cantidadTotal=cantidadTotal
            };
            response.Mensaje = "Succes";
            response.Error = false;
            Console.WriteLine("Sincronizacion terminada");
        }
        catch (Exception ex)
        {
            response.Data = null;
            response.Mensaje = ex.Message;
            response.Error = true;
           
        }

        return Task.FromResult(response);
      
        }
    


   

}

