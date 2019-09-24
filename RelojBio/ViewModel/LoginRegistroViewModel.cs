using System.ComponentModel.DataAnnotations;

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