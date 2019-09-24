using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RelojBio.ViewModel
{
    public class ControlAsistenciaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Id")]
        public int EmployeeId { get; set; }

        [Display(Name = "Cedula")]
        public int EmployeePin { get; set; }

        [Display(Name = "Nombre")]
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }

        [Display(Name = "Departamento")]
        public string DepartmentName { get; set; }

        [Display(Name = "Fecha")]
        public DateTime PunchTime { get; set; }
        public int PunchTimeInt { get; set; }

        [Display(Name = "Dia")]
        public string DayNames { get; set; }
        public int ScheduleId { get; set; }

        [Display(Name = "Horario")]
        public string ScheduleName { get; set; }
        public int ShiftId { get; set; }
        public string ShiftIdName { get; set; }

        [Display(Name = "Hor. Ent.")]
        public int EntryTime { get; set; }

        [Display(Name = "Hor. Sal.")]
        public int OutputTime { get; set; }
        public int LunchID { get; set; }

        [Display(Name = "Alm/Des")]
        public int EntryTimeLunch { get; set; }

        [Display(Name = "Alm/Fuer")]
        public int OutputTimeLunch { get; set; }
        public int DinnerID { get; set; }
        public int EntryTimeDinner { get; set; }
        public int OutputTimeDinner { get; set; }

        [Display(Name = "Reg. Ent.")]
        public int CheckIn { get; set; }

        [Display(Name = "Reg. Sal.")]
        public int CheckOut { get; set; }
        public int CheckInLunch { get; set; }
        public int CheckOutLunch { get; set; }
        public int CheckInDinner { get; set; }
        public int CheckOutDinner { get; set; }
        public int LateCome { get; set; }
        public int LateTime { get; set; }
        public int EarlyOut { get; set; }
        public int EarlyTime { get; set; }

        [Display(Name = "Ausente")]
        public string Absent { get; set; }

        [Display(Name = "Permiso")]
        public int Permission { get; set; }

        [Display(Name = "Descripcion")]
        public int PermissionName { get; set; }

        [Display(Name = "Hrs. Normal")]
        public int NormalHours { get; set; }

        [Display(Name = "Rec. Noc.")]
        public int NightSurcharge { get; set; }

        [Display(Name = "Hrs. Supl.")]
        public int SupplementaryHours { get; set; }
        public int Hours100 { get; set; }
        public int TotalWorked { get; set; }
        public int TotalAssisted { get; set; }
        public int TotalWorkPermit { get; set; }
        public int TotalPermitNoWorked { get; set; }
        public int DiasRest { get; set; }
        public int LunchDeductminute { get; set; }
        public int TotalLunch { get; set; }
        public int TotalOutLunch { get; set; }
        public int DinnerDeductminute { get; set; }
        public int TotalDinner { get; set; }
        public int TotalOutDinner { get; set; }

        [Display(Name = "Salario")]
        public decimal USDHourlyWage { get; set; }

        [Display(Name = "USD Rec. Noc.")]
        public decimal USDRecNocturno { get; set; }

        [Display(Name = "USD Sumpl.")]
        public decimal USDSuplementarias { get; set; }

        [Display(Name = "USD 100%")]
        public decimal USD100 { get; set; }

        [Display(Name = "USD Multa")]
        public decimal USDMulta { get; set; }

        [Display(Name = "USD Total")]
        public decimal USDTotal { get; set; }

        [Display(Name = "Dias Trabajados")]
        public int WorkedDays { get; set; }
        public int ShiftTypeId { get; set; }
        public string ShiftTypeName { get; set; }
        public int BeforeStart { get; set; }
        public int AfterEnd { get; set; }
        public int MinuteBeforeStart { get; set; }
        public int MinuteAfterEnd { get; set; }
        public string IdentificationNumber { get; set; }
        public bool EarnOvertime { get; set; }

    }
}