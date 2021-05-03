using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Alkemy.Models
{
    public class Materia
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreMateria { get; set; }

        [Required]
        public int Horario { get; set; }

        [Required]        
        public int CupMax { get; set; }

        public int IdProfesor { get; set; }
    }
}