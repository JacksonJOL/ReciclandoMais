using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReciclaMais.Models;

namespace ReciclaMais.Data
{
    
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //  DbSets personalizados
        public DbSet<Contribuinte> Contribuintes { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Message> Messages { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Material>().ToTable("Materiais");
        }
    }
}



