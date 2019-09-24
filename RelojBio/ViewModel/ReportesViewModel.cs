using RelojBio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelojBio.ViewModel
{
    public class ReportesViewModel
    {
        [Display(Name = "Departamentos")]
        public List<int> ListaCodigoDepartamentosSeleccionados { get; set; }

        public List<Department> ListaDepartamentos { get; set; }


        [Display(Name = "Empleado")]
        public int Empleado { get; set; }

        public SelectList ListaEmpleados { get; set; }

        [Display(Name = "Desde")]
        public DateTime FechaDesde { get; set; }

        [Display(Name = "Hasta")]
        public DateTime FechaHasta { get; set; }

        public int? Tipo { get; set; }
    }

}