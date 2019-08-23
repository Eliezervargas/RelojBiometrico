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
    
    public partial class Terminal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Terminal()
        {
            this.Punches1 = new HashSet<Punches>();
            this.TerminalEvents = new HashSet<TerminalEvents>();
            this.TerminalParameter = new HashSet<TerminalParameter>();
        }
    
        public int TerminalID { get; set; }
        public int Number { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int ConnectType { get; set; }
        public string ConnectPwd { get; set; }
        public string DomainName { get; set; }
        public string TcpIp { get; set; }
        public Nullable<int> Port { get; set; }
        public string Serial { get; set; }
        public Nullable<int> Baudrate { get; set; }
        public string Type { get; set; }
        public Nullable<int> Users { get; set; }
        public Nullable<int> Fingerprints { get; set; }
        public Nullable<int> Punches { get; set; }
        public string Zem { get; set; }
        public Nullable<int> Kind { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Remark { get; set; }
        public Nullable<int> Faces { get; set; }
        public string AuditUserIns { get; set; }
        public System.DateTime AuditDateIns { get; set; }
        public string AuditStationIns { get; set; }
        public string AuditUserUpd { get; set; }
        public Nullable<System.DateTime> AuditDateUpd { get; set; }
        public string AuditStationUpd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Punches> Punches1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerminalEvents> TerminalEvents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerminalParameter> TerminalParameter { get; set; }
    }
}
