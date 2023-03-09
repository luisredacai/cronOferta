using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CronOfertaOferta.Models;
using Microsoft.EntityFrameworkCore;


namespace CronOfertaOferta.Context
{
    public class WinCtx : DbContext
    {
        public WinCtx() { }
        public WinCtx(DbContextOptions<WinCtx> options)
        : base(options)
        {
        }

        public virtual DbSet<IntermediaOfertaCanal> CrmOfertaCanal { get; set; }
        public virtual DbSet<IntermediaOferta> CrmOferta { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=10.1.2.10;Initial Catalog=PE_WINET_CRM_AUTOCONTRATACION;User ID=appwincrm;Password=#1BxS8w8kf;encrypt=true;trustServerCertificate=true");

            var conection = Environment.GetEnvironmentVariable("CONNECTION_WINCRM");
            optionsBuilder.UseSqlServer(conection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntermediaOfertaCanal>(entity =>
            {
                entity.ToTable("CRM_OFERTA_CANAL", "CRM");
            });
            modelBuilder.Entity<IntermediaOferta>(entity =>
            {
                entity.ToTable("CRM_OFERTA", "CRM");
            });
        }
    }
}
