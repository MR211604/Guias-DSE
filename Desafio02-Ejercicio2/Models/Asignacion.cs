using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio02_Ejercicio2.Models
{
    public class Asignacion
    {
        public int AsignacionId { get; set; }

        [Required(ErrorMessage = "El empleado es requerido")]
        public int EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        [Required(ErrorMessage = "El proyecto es requerido")]
        public int ProyectoId { get; set; }
        public Proyecto? Proyecto { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Asignación")]
        [Required(ErrorMessage = "La fecha de asignación es requerida")]
        public DateTime FechaAsignacion { get; set; }

        [Required(ErrorMessage = "El rol es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Debe escribir al menos 3 caracteres")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El rol debe comenzar con mayúscula y solo puede contener letras y espacios.")]
        public string Rol { get; set; }
    }
}