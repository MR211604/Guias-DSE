using Microsoft.EntityFrameworkCore;

namespace GestionPersonasAPI.Models
{
    public class PersonasDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Persona> Personas { get; set; }
    }
}