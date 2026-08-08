using DockerMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerMvc.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
DbContext(options)
    {
        public DbSet<Persona> Personas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
