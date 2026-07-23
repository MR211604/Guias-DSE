using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio02_Ejercicio2.Models
{
    public class Asignacion
    {
        public int AsignacionId { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        public int ProyectoId { get; set; }
        public Proyecto? Proyecto { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Asignación")]
        public DateTime FechaAsignacion { get; set; }

        [StringLength(50)]
        public string Rol { get; set; }
    }
}