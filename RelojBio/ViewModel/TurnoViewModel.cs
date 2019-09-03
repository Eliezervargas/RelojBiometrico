using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelojBio.ViewModel
{
    public class TurnoViewModel
    {
        [Display(Name = "Codigo")]
        public int ScheduleID { get; set; }

        [Display(Name = "Descripción")]
        public string Name { get; set; }


    }
}