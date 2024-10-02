using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReciclaMais.Models;

namespace ReciclaMais.Data
{
    /* public class ApplicationDbContext : DbContext
     {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
         {
             // Apaga e recria o banco de dados automaticamente quando o DbContext é instanciado
             Database.EnsureDeleted();
             Database.EnsureCreated();
         }

         public DbSet<Material> Materiais { get; set; }
         public DbSet<Usuario> Usuarios { get; set; }

         public DbSet<Mensagem> Mensagens { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             // Configurações de mapeamento de entidades
             modelBuilder.Entity<Material>().ToTable("Materiais");
         }
     }*/
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Seus DbSets personalizados
        public DbSet<Contribuinte> Contribuintes { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Mensagem> Mensagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Chame a base para configurar o Identity
                                                // Configurações adicionais do modelo, se necessário
                                                // Configurações de mapeamento de entidades
            modelBuilder.Entity<Material>().ToTable("Materiais");
        }
    }
}



