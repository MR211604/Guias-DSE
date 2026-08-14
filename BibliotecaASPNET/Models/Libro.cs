using System.ComponentModel.DataAnnotations;

namespace BibliotecaASPNET.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de publicación")]
        public DateTime FechaPublicacion { get; set; }

        public int AutorId { get; set; }
        public Autor? Autor { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
