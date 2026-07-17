using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio02_Ejercicio2.Models
{
    public class Proyecto
    {
        public int ProyectoId { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreProyecto { get; set; }

        public string Descripcion { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}