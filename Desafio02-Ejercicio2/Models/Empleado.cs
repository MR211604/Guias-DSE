using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Desafio02_Ejercicio2.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Contratación")]
        public DateTime FechaContratacion { get; set; }

        [StringLength(50)]
        public string Puesto { get; set; }

        public ICollection<Asignacion> Asignaciones { get; set; }
    }
}