using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CronOfertaOferta.Models
{
    /*
     * CREATE TABLE PE_WINET_CRM_AUTOCONTRATACION.CRM.CRM_OFERTA_CANAL (
	OFCI_COD_OFERTA_CANAL int IDENTITY(1,1) NOT NULL,
	OFTI_COD_OFERTA bigint NULL,
	OFCC_COD_CANAL_VENTA char(2) COLLATE Modern_Spanish_CI_AS NULL,
	OFCI_ESTADO_REGISTRO int NULL,
	OFCV_USUARIO_CREACION varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	OFCD_FECHA_CREACION datetime NULL,
	CONSTRAINT PK_OFERTA_CANAL PRIMARY KEY (OFCI_COD_OFERTA_CANAL)
);
     */

    [Table("CRM_OFERTA_CANAL")]
    public class IntermediaOfertaCanal
    {
        [Key]

        public int? ofci_cod_oferta_canal { get; set; }
        public long? ofti_cod_oferta { get; set; }
        public string? ofcc_cod_canal_venta { get; set; }
        public int? ofci_estado_registro { get; set; }
        public string? ofcv_usuario_creacion { get; set; }
        public DateTime? ofcd_fecha_creacion { get; set; }

    }
}
