using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio02_Ejercicio2.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe escribir al menos 3 caracteres")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El nombre debe comenzar con mayúscula y solo puede contener letras y espacios.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe escribir al menos 3 caracteres")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El apellido debe comenzar con mayúscula y solo puede contener letras y espacios.")]
        public string Apellido { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Contratación")]
        [Required(ErrorMessage = "La fecha de contratación es requerida")]
        public DateTime FechaContratacion { get; set; }

        [Required(ErrorMessage = "El puesto es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe escribir al menos 3 caracteres")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El puesto debe comenzar con mayúscula y solo puede contener letras y espacios.")]
        public string Puesto { get; set; }

        public ICollection<Asignacion>? Asignaciones { get; set; }
    }
}