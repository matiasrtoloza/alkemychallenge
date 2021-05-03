using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Alkemy.Models;

namespace Alkemy.Models
{
    public class MateriaDetalleViewModel
    {
        [Required]
        [StringLength(50)]
        public string Materia { get; set; }

        [Required]        
        public int Horario { get; set; }

        [Required]
        [StringLength(50)]
        public string Profesor { get; set; }
       
        [Required]        
        public int CupMax { get; set; }

        
        public string List { get; set; }


    }
}