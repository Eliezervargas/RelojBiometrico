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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.DayDetails = new HashSet<DayDetails>();
            this.DaySummary = new HashSet<DaySummary>();
            this.HolidayEmployee = new HashSet<HolidayEmployee>();
            this.ManualDialing = new HashSet<ManualDialing>();
            this.Permision = new HashSet<Permision>();
            this.Signing = new HashSet<Signing>();
        }
    
        public int EmployeeID { get; set; }
        public int DepartmentID { get; set; }
        public Nullable<int> ScheduleID { get; set; }
        public int Pin { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public string MainAddress { get; set; }
        public string AlternateAddress { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> FireDate { get; set; }
        public string FireReason { get; set; }
        public string MainEmergencyPhone { get; set; }
        public string AlternateEmergencyPhone { get; set; }
        public string EmergencyName { get; set; }
        public string EmergencyAddress { get; set; }
        public string CardNumber { get; set; }
        public Nullable<int> CountryID { get; set; }
        public Nullable<int> CityID { get; set; }
        public Nullable<int> StateID { get; set; }
        public string PostalCode { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> HourlyRate { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> BirthDay { get; set; }
        public Nullable<int> OperationMode { get; set; }
        public string Remark { get; set; }
        public string AuditUserIns { get; set; }
        public Nullable<System.DateTime> AuditDateIns { get; set; }
        public string AuditStationIns { get; set; }
        public string AuditUserUpd { get; set; }
        public Nullable<System.DateTime> AuditDateUpd { get; set; }
        public string AuditStationUpd { get; set; }
        public string IdentificationNumber { get; set; }
        public Nullable<bool> EarnOvertime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DayDetails> DayDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DaySummary> DaySummary { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HolidayEmployee> HolidayEmployee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManualDialing> ManualDialing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permision> Permision { get; set; }
        public virtual Schedule Schedule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Signing> Signing { get; set; }
        public virtual Department Department { get; set; }
    }
}
