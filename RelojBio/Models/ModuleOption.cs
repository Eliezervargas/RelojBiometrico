//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RelojBio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ModuleOption
    {
        public int ModuleOptionID { get; set; }
        public int ModuleID { get; set; }
        public int OptionID { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Module Module { get; set; }
        public virtual Option Option { get; set; }
    }
}
