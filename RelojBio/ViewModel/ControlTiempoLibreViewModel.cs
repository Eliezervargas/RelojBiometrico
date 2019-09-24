using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RelojBio.ViewModel
{
    public class ControlTiempoLibreViewModel
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
        public DateTime? PunchTime { get; set; }

        public int PunchTimeInt { get; set; }


        [Display(Name = "Día")]
        public string DayNames { get; set; }

        [Display(Name = "Horario")]
        public string ScheduleName { get; set; }

        [Display(Name = "Hor. Ent.")]
        public int EntryTime { get; set; }

        [Display(Name = "Hor. Sal.")]
        public int OutputTime { get; set; }


        [Display(Name = "Reg. Ent.")]
        public int CheckIn { get; set; }

        [Display(Name = "Reg. Sal.")]
        public int CheckOut { get; set; }


        [Display(Name = "Reg. Alm")]
        public int Lounch { get; set; }


        [Display(Name = "Reg. Sal.")]
        public int LateTime { get; set; }






    }
}