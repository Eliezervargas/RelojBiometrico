using System;
using System.ComponentModel.DataAnnotations;

namespace RelojBio.ViewModel
{
    public class DescansoViewModel
    {
        [Display(Name = "Codigo")]
        public int BreakID { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Desde")]
        public System.DateTime Start { get; set; }

        [Display(Name = "Hasta")]
        public System.DateTime End { get; set; }

        [Display(Name = "Pagado")]
        public bool Deduct { get; set; }

        [Display(Name = "Descontar")]
        public Nullable<bool> AutoDeduct { get; set; }

        [Display(Name = "Descanso (mins)")]
        public Nullable<int> DeductMinute { get; set; }

        [Display(Name = "Debe Checar")]
        public Nullable<bool> NeedCheck { get; set; }

        public int Tipo { get; set; }

    }
}