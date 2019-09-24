using System;
using System.ComponentModel.DataAnnotations;

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