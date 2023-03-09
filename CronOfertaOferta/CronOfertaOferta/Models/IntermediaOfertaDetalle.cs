using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CronOfertaOferta.Models
{
    /*
     * CREATE TABLE PE_WINET_CRM_AUTOCONTRATACION.CRM.CRM_OFERTA_DETALLE (
	OFDI_COD_OFERTA_DETALLE bigint IDENTITY(1,1) NOT NULL,
	OFTI_COD_OFERTA bigint NULL,
	PROI_COD_PRODUCTO bigint NULL,
	OFDI_MONEDA int NULL,
	OFDD_PRECIO decimal(9,6) NULL,
	OFDI_PLAZO int NULL,
	OFDI_CUOTAS int NULL,
	OFDI_CANTIDAD_MIN int NULL,
	OFDI_CANTIDAD_MAX int NULL,
	OFDV_COD_TIPO_RENTA char(2) COLLATE Modern_Spanish_CI_AS NULL,
	OFDD_DESCUENTO decimal(9,6) NULL,
	OFDI_MESES int NULL,
	OFDI_ACTIVACION_ATRIBUTOS int DEFAULT 0 NULL,
	OFTI_EST_REGISTRO int NULL,
	OFTV_USUARIO_CREACION varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	OFTD_FECHA_CREACION datetime NULL,
	OFDB_OBLIGATORIO bit NULL,
	OFDV_TIPO_PRODUCTO char(2) COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK__CRM_OFER__E558EC554DD2100F PRIMARY KEY (OFDI_COD_OFERTA_DETALLE)
);
     */

    [Table("CRM_OFERTA_DETALLE")]
    public class IntermediaOfertaDetalle
    {
		[Key]


    public long ofdi_cod_oferta_detalle { get; set; }
    public long proi_cod_producto { get; set; }
    public long ofti_cod_oferta { get; set; }
    public int ofdb_obligatorio { get; set; }
    public int ofdi_moneda { get; set; } 
    public decimal ofdd_precio { get; set; }
	public int ofdi_plazo { get; set; }
    public int ofdi_cuotas { get; set; } 
    public int ofdi_cantidad_min { get; set; } 
    public int ofdi_cantidad_max { get; set; } 
    public string? ofdv_cod_tipo_renta { get; set; }
	public decimal ofdd_descuento  { get; set; }
    public int ofdi_meses  { get; set; }
    public int ofdi_activacion_atributos  { get; set; }
	public int ofti_est_registro  { get; set; }
    public string? oftv_usuario_creacion { get; set; }
	public DateTime oftd_fecha_creacion  { get; set; }
	
      

    }
}
