using RelojBio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RelojBio.ViewModel
{
    public class UserViewModel
    {
        [Display(Name = "Codigo")]
        public int UserID { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName { get; set; }

        [Display(Name = "Usuario")]
        public string Login { get; set; }

        [Display(Name = "Contraeña")]
        public string Password { get; set; }

        [Display(Name = "Puede Expirar")]
        public bool PasswordExpires { get; set; }

        [Display(Name = "Dias de Vigencia")]
        public Nullable<int> DaysValidity { get; set; }

        [Display(Name = "Ultimo Cambio de Clave")]
        public DateTime LastChangePassword { get; set; }

        [Display(Name = "Estado")]
        public bool IsActive { get; set; }

        public List<Company> ListCompania { get; set; }

        public List<UserCompany> ListCompaniaSeleccionadas { get; set; }


        [Display(Name = "Asignacion de empresas")]
        public List<int> ListCompaniaCodigoSeleccionadas { get; set; }

        public List<Role> ListRoles { get; set; }

        public List<UserRole> ListRolesSeleccionados { get; set; }

        [Display(Name = "Asignacion de roles")]
        public List<int> ListRolesCodigoSeleccionados { get; set; }

    }
}