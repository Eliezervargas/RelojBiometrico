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
    
    public partial class Company1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company1()
        {
            this.CompanyModule = new HashSet<CompanyModule>();
            this.UserCompany = new HashSet<UserCompany>();
        }
    
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Credential { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompanyModule> CompanyModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCompany> UserCompany { get; set; }
    }
}
