using Microsoft.EntityFrameworkCore;
using Processo.WebApi.Model;

namespace Processo.WebApi.Data
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Beneficio> Beneficios { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Movimentacao> Movimentacaos { get; set; }
        public DbSet<TipoBeneficio> TiposBeneficio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beneficiario>().ToTable("Beneficiario");
            modelBuilder.Entity<Beneficio>().ToTable("Beneficio");
            modelBuilder.Entity<Documento>().ToTable("Documento");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Movimentacao>().ToTable("Movimentacao");
            modelBuilder.Entity<TipoBeneficio>().ToTable("TipoBeneficio");
        }
    }
}
