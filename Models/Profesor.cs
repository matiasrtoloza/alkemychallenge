using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alkemy.Models
{
    public class Profesor
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
       
        public int Dni { get; set; }
        public bool Estado { get; set; }
    }
}