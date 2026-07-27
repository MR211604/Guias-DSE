using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio02_Ejercicio2.Models
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }

        [Required(ErrorMessage = "El nombre del proyecto es requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Debe escribir al menos 3 caracteres")]
        public string NombreProyecto { get; set; }

        [StringLength(500, MinimumLength = 5, ErrorMessage = "Debe escribir al menos 5 caracteres")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        [Required(ErrorMessage = "La fecha de inicio es requerida")]
        public DateTime FechaInicio { get; set; }

        public ICollection<Asignacion>? Asignaciones { get; set; }
    }
}