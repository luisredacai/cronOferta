using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CronOfertaOferta.Models
{
    public class Auditoria
    {

        [Key]
        public int ADT_COD { get; set; }
        public Boolean SINC_COMPLETA { get; set; }

        public DateTime SINC_FECHA_REGISTRO { get; set; }
        public string? SINC_TABLE { get; set; }
    }
}
