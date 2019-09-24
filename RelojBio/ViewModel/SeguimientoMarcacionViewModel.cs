using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RelojBio.ViewModel
{
    public class SeguimientoMarcacionViewModel
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

        [Display(Name = "Hora")]
        public int Punches { get; set; }

        [Display(Name = "Ins.")]
        public bool IsInserted { get; set; }

        [Display(Name = "Modif.")]
        public bool IsModified { get; set; }

        [Display(Name = "Elim.")]
        public bool IsRemoved { get; set; }

        [Display(Name = "Usu. Audi.")]
        public string AuditUser { get; set; }

        [Display(Name = "Fec. Audi.")]
        public DateTime AuditDate { get; set; }

        [Display(Name = "Estac. Audi.")]
        public string AuditStation { get; set; }

        [Display(Name = "Observación")]
        public string Observation { get; set; }


    }
}