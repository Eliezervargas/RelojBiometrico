using System.ComponentModel.DataAnnotations;

namespace RelojBio.ViewModel
{
    public class CCostoViewModel
    {

        [Display(Name = "Codigo")]
        public int CostCenterID { get; set; }

        [Display(Name = "Nombre Corto")]
        public string Code { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Observación")]
        public string Description { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

    }
}