using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelojBio.ViewModel
{
    public class ControlMarcacionViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Codigo")]
        public int EmployeeId { get; set; }

        [Display(Name = "Nombre")]
        public string EmployeeName { get; set; }

        [Display(Name = "Documento")]
        public int EmployeePin { get; set; }

        [Display(Name = "Codigo Departamento")]
        public int DepartmentId { get; set; }

        [Display(Name = "Nombre Departamento")]
        public string DepartmentName { get; set; }

        [Display(Name = "Dias")]
        public string DayNames { get; set; }

        [Display(Name = "Fecha Hora")]
        public DateTime PunchDate { get; set; }
        public int WorkCodeID { get; set; }
        public int PunchTypeID { get; set; }
        public string DescripPunchType { get; set; }
        public int WorkStateID { get; set; }

        [Display(Name = "Verificacion")]
        public string DescripWorkstate { get; set; }
        public int? TerminalID { get; set; }
        public string TerminalName { get; set; }
        public string IdentificationNumber { get; set; }
        public int PunchID { get; set; }


    }
}