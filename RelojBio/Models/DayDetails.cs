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
    
    public partial class DayDetails
    {
        public int DayDetailsID { get; set; }
        public System.DateTime Date { get; set; }
        public int SortIndex { get; set; }
        public Nullable<System.DateTime> CheckIn { get; set; }
        public Nullable<System.DateTime> LunchIn { get; set; }
        public Nullable<System.DateTime> LunchOut { get; set; }
        public Nullable<System.DateTime> BreakIn { get; set; }
        public Nullable<System.DateTime> BreakOut { get; set; }
        public Nullable<System.DateTime> CheckOut { get; set; }
        public Nullable<System.DateTime> Hours { get; set; }
        public Nullable<System.DateTime> Worked { get; set; }
        public Nullable<System.DateTime> RoundedIn { get; set; }
        public Nullable<System.DateTime> RoundedOut { get; set; }
        public Nullable<System.DateTime> RoundWorked { get; set; }
        public string Remark { get; set; }
        public Nullable<int> ShiftID { get; set; }
        public Nullable<int> WorkCodeID { get; set; }
        public int EmployeeID { get; set; }
        public string AuditUserIns { get; set; }
        public Nullable<System.DateTime> AuditDateIns { get; set; }
        public string AuditStationIns { get; set; }
        public string AuditUserUpd { get; set; }
        public Nullable<System.DateTime> AuditDateUpd { get; set; }
        public string AuditStationUpd { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual WorkCode WorkCode { get; set; }
    }
}
