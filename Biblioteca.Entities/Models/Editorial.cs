using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Biblioteca.Entities.Models
{
    public class Editorial
    {
        [Key]
        public int Id { get; set; }

        public required string Nombre { get; set; }
    }
}
