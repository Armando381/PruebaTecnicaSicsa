//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
namespace PruebaTecnicaSICSA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage ="El campo es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Description { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public int CategoryId { get; set; }
    
        public virtual category category { get; set; }
    }
}
