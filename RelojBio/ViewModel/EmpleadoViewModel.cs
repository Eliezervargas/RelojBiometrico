using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelojBio.ViewModel
{
    public class EmpleadoViewModel
    {
        [Display(Name = "Empleado Id")]
        public int EmpleadoId { get; set; }

        [Display(Name = "Codigo")]
        public string Code { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Nro Empleado")]
        public int Pin { get; set; }

        [Display(Name = "Departamento")]
        public int DepartamentoID { get; set; }

        [Display(Name = "Turno")]
        public Nullable<int> ScheduleID { get; set; }

        [Display(Name = "Sueldo")]
        public Nullable<decimal> Salary { get; set; }

        [Display(Name = "Identificación")]
        public string IdentificationNumber { get; set; }

        [Display(Name = "Gana Horas Extras")]
        public bool EarnOvertime { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Fecha Empleo")]
        public DateTime HireDate { get; set; }

        [Display(Name = "Dirección Principal")]
        public string MainAddress { get; set; }

        [Display(Name = "Dirección Alternativa")]
        public string AlternateAddress { get; set; }

        [Display(Name = "Pais")]
        public Nullable<int> CountryID { get; set; }

        [Display(Name = "Ciudad")]
        public Nullable<int> CityID { get; set; }

        [Display(Name = "Estado")]
        public Nullable<int> StateID { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Telefono")]
        public string CardNumber { get; set; }

        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }

        [Display(Name = "Codigo Postal")]
        public string PostalCode { get; set; }

        [Display(Name = "Dirección")]
        public string EmergencyAddress { get; set; }

        [Display(Name = "Nombre")]
        public string EmergencyName { get; set; }

        [Display(Name = "Telef. Principal")]
        public string MainEmergencyPhone { get; set; }

        [Display(Name = "Telef. Alterno")]
        public string AlternateEmergencyPhone { get; set; }

        [Display(Name = "Titulo")]
        public string Title { get; set; }
        public Nullable<decimal> HourlyRate { get; set; }

        [Display(Name = "Genero")]
        public string Gender { get; set; }

        [Display(Name = "Cumpleaño")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Fecha Despido")]
        public DateTime FireDate { get; set; }

        [Display(Name = "Razon")]
        public string FireReason { get; set; }

        //Estos son las lista para llenar los combos
        public SelectList ListaDepartamento { get; set; }

        public SelectList ListaTurno { get; set; }

        public SelectList ListaPais { get; set; }

        public SelectList ListaEstado { get; set; }

        public SelectList ListaCiudad { get; set; }

        public SelectList ListaGenero { get; set; }


    }
}