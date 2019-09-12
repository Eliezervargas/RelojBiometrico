using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelojBio.ViewModel
{
    public class DispositivosViewModel
    {

        [Display(Name = "Codigo")]
        public int TerminalID { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Dirección")]
        public string TcpIp { get; set; }

        [Display(Name = "Puerto")]
        public int Port { get; set; }

        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Display(Name = "Modelo")]
        public int Faces { get; set; }

        [Display(Name = "Contraseña")]
        public string ConnectPwd { get; set; }
        

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }


    }
}