//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alkemy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class Subjects
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Subject_Name { get; set; }
        [Required]
        public int Schedule { get; set; }
        [Required]
        public int Quota_Max { get; set; }
        public int IdTeacher { get; set; }
    
        public virtual Teachers Teachers { get; set; }
    }
}