using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Entities.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public required string Titulo { get; set; }
        [Required]
        [ForeignKey("Autor")]
        public int AutorId { get; set; }

        [Required]
        [ForeignKey("Editorial")]
        public int EditorialId { get; set; }

        public DateTime FechaLanzamiento { get; set; }
    
        public Autor? Autor { get; set; }
        public Editorial? Editorial { get; set; }
    }
}
