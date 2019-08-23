using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelojBio.ViewModel
{
    public class LoginRegistroViewModel
    {
        [Display(Name = "Usuario")]
        public string Login { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}