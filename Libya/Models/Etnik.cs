//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Libya.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Etnik
    {
        public int Id { get; set; }
        [Display(Name ="Etnik K�k")]
        [Required(ErrorMessage ="Bu Alan Bo� Ge�ilemez")]
        public string etnikKok { get; set; }
        [Display(Name = "Ya�an�lan �ehir")]
        [Required(ErrorMessage = "Bu Alan Bo� Ge�ilemez")]
        public string eysehiri { get; set; }
        [Display(Name = "Etnik K�k Hakk�nda")]
        [Required(ErrorMessage = "Bu Alan Bo� Ge�ilemez")]
        public string ehakkinda { get; set; }
    }
}