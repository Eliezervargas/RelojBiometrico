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
    
    public partial class Break
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Break()
        {
            this.BreakShift = new HashSet<BreakShift>();
        }
    
        public int BreakID { get; set; }
        public string Name { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime End { get; set; }
        public bool Deduct { get; set; }
        public Nullable<bool> AutoDeduct { get; set; }
        public Nullable<int> DeductMinute { get; set; }
        public Nullable<int> MaxLong { get; set; }
        public Nullable<int> MinLong { get; set; }
        public Nullable<int> OvercountPaycode { get; set; }
        public Nullable<bool> Overcount { get; set; }
        public Nullable<bool> NeedCheck { get; set; }
        public string Remark { get; set; }
        public string AuditUserIns { get; set; }
        public System.DateTime AuditDateIns { get; set; }
        public string AuditStationIns { get; set; }
        public string AuditUserUpd { get; set; }
        public Nullable<System.DateTime> AuditDateUpd { get; set; }
        public string AuditStationUpd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BreakShift> BreakShift { get; set; }
    }
}