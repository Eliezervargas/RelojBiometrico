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
    
    public partial class spShift_V2_Result
    {
        public int ShiftID { get; set; }
        public int ShiftTypeID { get; set; }
        public Nullable<bool> Flexible { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public Nullable<int> BeforeStart { get; set; }
        public Nullable<int> AfterEnd { get; set; }
        public Nullable<int> BeforeStart2 { get; set; }
        public Nullable<int> AfterEnd2 { get; set; }
        public Nullable<bool> Late { get; set; }
        public Nullable<int> LateCome { get; set; }
        public Nullable<bool> Early { get; set; }
        public Nullable<int> EarlyOut { get; set; }
        public Nullable<int> EarlyCome { get; set; }
        public Nullable<int> LateOut { get; set; }
        public Nullable<bool> ShiftRound { get; set; }
        public Nullable<int> CheckInRoundValue { get; set; }
        public Nullable<int> CheckOutRoundValue { get; set; }
        public Nullable<int> CheckInRoundDown { get; set; }
        public Nullable<int> CheckOutRoundDown { get; set; }
        public Nullable<int> Absent { get; set; }
        public Nullable<int> Color { get; set; }
        public string Remark { get; set; }
        public Nullable<bool> AllowBefore { get; set; }
        public Nullable<bool> AllowAfter { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> RangeStartIni { get; set; }
        public Nullable<System.DateTime> RangeStartFin { get; set; }
        public Nullable<System.DateTime> RangeEndIni { get; set; }
        public Nullable<System.DateTime> RangeEndFin { get; set; }
        public Nullable<bool> Monday { get; set; }
    }
}
