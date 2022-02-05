using Biblioteca.Core.Domain;
using Biblioteca.Infrastructure.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Data
{
    public class BibliotecaContext : DbContextBase
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>().HasKey(c => c.Id);
            modelBuilder.Entity<Autor>().HasKey(c => c.Id);
            modelBuilder.Entity<Editorial>().HasKey(c => c.Id);

            //inicailizacion de datos 
            //modelBuilder.Entity<CuentaBancaria>().HasData(new  { Id=1, Numero="1010", Ciudad="Valleduar", Email="Email"} );
            //modelBuilder.Entity<CuentaBancaria>().HasData(new { Id = 1, Numero = "1010", Ciudad = "Valleduar", Email = "Email" });
        }
    }
}
