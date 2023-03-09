using CronOfertaOferta.Models;
using Microsoft.EntityFrameworkCore;

namespace CronOfertaOferta.Context
{
    public class IntermedioCtx : DbContext
    {
        public IntermedioCtx()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public IntermedioCtx(DbContextOptions<IntermedioCtx> options)
        : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        }
        public virtual DbSet<IntermediaOfertaCanal> InOfertaCanal { get; set; } = null!;
        public virtual DbSet<IntermediaOferta> InOferta { get; set; } = null!;
        public virtual DbSet<Auditoria> Auditoria { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Host=db-yacuruna-instance-1.cmve4mtw7ic2.us-east-1.rds.amazonaws.com;Database=postgres;Username=admyacuruna;Password=Yacuruna1234*;Port=5432
                //optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("CONNECTION_AWS"));
               //optionsBuilder.UseNpgsql("Host=dev-autocontrataciones-instance-1.cn9rsmshytg1.us-east-1.rds.amazonaws.com;Database=contrataciones;Username=yacutech3;Password=VvyskBoZ3AGpKaPC;Port=5432");

                var conection = Environment.GetEnvironmentVariable("CONNECTION_AWS");
                optionsBuilder.UseNpgsql(conection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntermediaOfertaCanal>(entity =>
            {
                entity.ToTable("CRM_OFERTA_CANAL");
                entity.HasKey(x => x.ofci_cod_oferta_canal);
                entity.Property(x => x.ofci_cod_oferta_canal).UseIdentityColumn();
            });
            modelBuilder.Entity<IntermediaOferta>(entity =>
            {
                entity.ToTable("CRM_OFERTA");
                entity.HasKey(x => x.ofti_cod_oferta);
                entity.Property(x => x.ofti_cod_oferta).UseIdentityColumn();
            });
            modelBuilder.Entity<Auditoria>(entity =>
            {
                entity.ToTable("ADT_SINCRONIZACION");
                entity.HasKey(x => x.ADT_COD);
                entity.Property(x => x.ADT_COD).UseIdentityColumn();
            });
        }

    }
}
