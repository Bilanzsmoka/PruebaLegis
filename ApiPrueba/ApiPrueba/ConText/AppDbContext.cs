using ApiPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.ConText
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proovedor> Provedor { get; set; }

        public DbSet<ProductoProovedor> productoProveedor { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoProovedor>().HasKey(p => new { p.ProductoId, p.ProovedorId });
        }
    }
}
