using Microsoft.EntityFrameworkCore;
using ReciclaMais.Models;

namespace ReciclaMais.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Apaga e recria o banco de dados automaticamente quando o DbContext é instanciado
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Material> Materiais { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações de mapeamento de entidades
            modelBuilder.Entity<Material>().ToTable("Materiais");
        }
    }


}
