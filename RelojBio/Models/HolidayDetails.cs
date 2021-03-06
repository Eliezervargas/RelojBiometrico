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
    
    public partial class HolidayDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HolidayDetails()
        {
            this.HolidayCompany = new HashSet<HolidayCompany>();
            this.HolidayDepartment = new HashSet<HolidayDepartment>();
            this.HolidayEmployee = new HashSet<HolidayEmployee>();
        }
    
        public int HolidayDetailsID { get; set; }
        public int HolidayTypeID { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<decimal> Hours { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<int> Year { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> CountType { get; set; }
        public bool IsActive { get; set; }
        public string AuditUserIns { get; set; }
        public System.DateTime AuditDateIns { get; set; }
        public string AuditStationIns { get; set; }
        public string AuditUserUpd { get; set; }
        public Nullable<System.DateTime> AuditDateUpd { get; set; }
        public string AuditStationUpd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HolidayCompany> HolidayCompany { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HolidayDepartment> HolidayDepartment { get; set; }
        public virtual HolidayType HolidayType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HolidayEmployee> HolidayEmployee { get; set; }
    }
}
