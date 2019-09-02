using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RelojBio.ViewModel
{
    public class DepartamentosViewModel
    {

        [Display(Name = "Codigo")]
        public int DepartmentID { get; set; }
        [Display(Name = "Descripcion")]
        public string Name { get; set; }
        [Display(Name = "Empresa")]
        public int CompanyID { get; set; }
        [Display(Name = "Turno")]
        public int ScheduleID { get; set; }

        //Llenar Combos
        public SelectList ListaEmpresa { get; set; }
        public SelectList ListaTurno { get; set; }


    }
}