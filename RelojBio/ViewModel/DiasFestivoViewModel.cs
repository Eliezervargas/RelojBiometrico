using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RelojBio.ViewModel
{
    public class DiasFestivoViewModel
    {

        [Display(Name = "ID")]
        public int HolidayTypeID { get; set; }

        [Display(Name = "Codigo")]
        public int Code { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Fecha")]
        public DateTime StartDate { get; set; }

    }
}