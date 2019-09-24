using RelojBio.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RelojBio.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name = "Codigo")]
        public int RoleID { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        public List<Option> LisOpciones { get; set; }

        public List<RoleOption> LisOpcionesSeleccionados { get; set; }

        [Display(Name = "Opciones")]
        public List<int> LisCodigoOpcionesSeleccionados { get; set; }

    }
}