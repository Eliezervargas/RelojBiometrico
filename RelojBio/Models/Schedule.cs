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
    
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            this.Department = new HashSet<Department>();
            this.Employee = new HashSet<Employee>();
            this.ScheduleDetails = new HashSet<ScheduleDetails>();
        }
    
        public int ScheduleID { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public bool CycleAvailable { get; set; }
        public Nullable<bool> IsPublic { get; set; }
        public Nullable<bool> CycleIncludeWeekend { get; set; }
        public Nullable<bool> CycleIncludeHoliday { get; set; }
        public Nullable<int> CycleType { get; set; }
        public Nullable<int> CycleParameter { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public string Remark { get; set; }
        public string AuditUserIns { get; set; }
        public System.DateTime AuditDateIns { get; set; }
        public string AuditStationIns { get; set; }
        public string AuditUserUpd { get; set; }
        public Nullable<System.DateTime> AuditDateUpd { get; set; }
        public string AuditStationUpd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleDetails> ScheduleDetails { get; set; }
    }
}