using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CronOfertaOferta.Models
{
    /*
     * CREATE TABLE PE_WINET_CRM_AUTOCONTRATACION.CRM.CRM_OFERTA (
	OFTI_COD_OFERTA bigint IDENTITY(1,1) NOT NULL,
	OFTV_NOMBRE varchar(200) COLLATE Modern_Spanish_CI_AS NULL,
	CAMI_COD_CAMPANA bigint NULL,
	PAQI_COD_PAQUETE bigint NULL,
	OFTV_ESTADO char(2) COLLATE Modern_Spanish_CI_AS NULL,
	OFTD_INICIO_VIGENCIA date NULL,
	OFTD_FIN_VIGENCIA date NULL,
	OFTD_FLAG_VIGENCIA int NULL,
	OFTI_EST_REGISTRO int NULL,
	OFTV_USUARIO_CREACION varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	OFTD_FECHA_CREACION datetime NULL,
	OFTV_PLAZO varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
	OFTI_VELOCIDAD_PROMO int NULL,
	OFTI_DURACION_VELOCIDAD_PROMOCION varchar(5) COLLATE Modern_Spanish_CI_AS NULL,
	OFTI_FLAG_DUPLICADA int NULL,
	CONSTRAINT PK__CRM_OFER__4A374C0DDC0BCAFE PRIMARY KEY (OFTI_COD_OFERTA)
);

     */
    [Table("CRM_OFERTA")]
    public class IntermediaOferta
    {
        [Key]
        public long? ofti_cod_oferta { get; set; }
        public string? oftv_nombre { get; set; }
        public long? cami_cod_campana { get; set; }
        public long? paqi_cod_paquete { get; set; }
        public string? oftv_estado { get; set; }
        public DateTime? oftd_inicio_vigencia { get; set; }
        public DateTime? oftd_fin_vigencia { get; set; }
        public int? oftd_flag_vigencia { get; set; }
        public int? ofti_est_registro { get; set; }
        public string? oftv_usuario_creacion { get; set; }
        public DateTime? oftd_fecha_creacion { get; set; }
        public string? oftv_plazo { get; set; }
        public int? ofti_velocidad_promo { get; set; }
        public string? ofti_duracion_velocidad_promocion { get; set; }
        public int? ofti_flag_duplicada { get; set; }
    }
}