using System.ComponentModel.DataAnnotations;

namespace GestionPersonasAPI.Models
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El primer nombre es requerido.")]
        [StringLength(100, ErrorMessage = "El primer nombre no puede exceder los 100 caracteres.")]
        public string PrimerNombre { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "El segundo nombre no puede exceder los 100 caracteres.")]
        public string? SegundoNombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido.")]
        [StringLength(100, ErrorMessage = "El primer apellido no puede exceder los 100 caracteres.")]
        public string PrimerApellido { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "El segundo apellido no puede exceder los 100 caracteres.")]
        public string? SegundoApellido { get; set; }

        [Required(ErrorMessage = "El DUI es requerido.")]
        [RegularExpression(@"^\d{8}-\d{1}$", ErrorMessage = "El DUI debe tener el formato 01234567-8.")]
        public string DUI { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}