using Microsoft.EntityFrameworkCore;
using Examen22_08_25.Entidades;

namespace Examen22_08_25.Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<GrupoMusica> GruposMusica { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
