using System.ComponentModel.DataAnnotations;

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