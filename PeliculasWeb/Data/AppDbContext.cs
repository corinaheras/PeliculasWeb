using Microsoft.EntityFrameworkCore;
using PeliculasWeb.Models;

namespace PeliculasWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

       
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Actor> Actores { get; set; }
        public DbSet<Director> Directores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Relación: Cliente - Reseñas (1:N)
            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reseñas)
                .HasForeignKey(r => r.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Pelicula - Reseñas (1:N)
            modelBuilder.Entity<Reseña>()
                .HasOne(r => r.Pelicula)
                .WithMany(p => p.Reseñas)
                .HasForeignKey(r => r.PeliculaId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Pelicula - Actor (1:N)
            modelBuilder.Entity<Pelicula>()
                .HasOne(p => p.Actor)
                .WithMany(a => a.PeliculasProtagonizadas)
                .HasForeignKey(p => p.ActorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación: Pelicula - Director (1:N)
            modelBuilder.Entity<Pelicula>()
                .HasOne(p => p.Director)
                .WithMany(d => d.PeliculasDirigidas)
                .HasForeignKey(p => p.DirectorId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
