using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiEspeciales.Entities;

namespace ServiEspeciales.Data
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }
        public DbSet<Arl> Arl { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<ContratosLaborales> ContratosLaborales { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<NovedadesNomina> NovedadesNomina { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Arl>().ToTable("arl", "public");
            modelBuilder.Entity<Cargo>().ToTable("cargos", "public");
            modelBuilder.Entity<ContratosLaborales>().ToTable("contratoslaborales", "public");
            modelBuilder.Entity<Estado>().ToTable("estados", "public");
            modelBuilder.Entity<NovedadesNomina>().ToTable("novedadesnomina", "public");
            modelBuilder.Entity<TipoDocumento>().ToTable("tipodocumento", "public");
            modelBuilder.Entity<ContratosLaborales>().Property(m => m.fechafin).HasDefaultValue(DateTime.MinValue);
            modelBuilder.Entity<ContratosLaborales>().Property(m => m.fechainicio).HasDefaultValue(DateTime.MaxValue);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=localhost;Database=BDPruebaTecnica;Username=postgres;Password=secreto01");
    }
}
