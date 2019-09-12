using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RelojBio.ViewModel
{
    public class EmpresaViewModel
    {

        [Display(Name = "CompanyID")]
        public int CompanyID { get; set; }

        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Dirección Principal")]
        public string MainAddress { get; set; }

        [Display(Name = "Dirección Altenativa")]
        public string AlternateAddress { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Display(Name = "Sitio Web")]
        public string WebSite { get; set; }

        [Display(Name = "Pais")]
        public Nullable<int> CountryID { get; set; }

        [Display(Name = "Ciudad")]
        public Nullable<int> CityID { get; set; }

        [Display(Name = "Estado")]
        public Nullable<int> StateID { get; set; }


        public SelectList ListaPais { get; set; }

        public SelectList ListaEstado { get; set; }

        public SelectList ListaCiudad { get; set; }


    }
}