using RelojBio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RelojBio.ViewModel
{
    public class HorarioViewModel
    {
        [Display(Name = "Codigo")]
        public int ShiftID { get; set; }

        [Display(Name = "Nombre Corto")]
        public string Code { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Tipo")]
        public int ShiftTypeID { get; set; }

        [Display(Name = "Color")]
        public Nullable<int> Color { get; set; }


        [Display(Name = "Flexible")]
        public Nullable<bool> Flexible { get; set; }

        [Display(Name = "Hora Inicial")]
        public Nullable<System.DateTime> Start { get; set; }

        [Display(Name = "Hora Final")]
        public Nullable<System.DateTime> End { get; set; }

        [Display(Name = "Rango Inicial")]
        public Nullable<System.DateTime> RangeStartIni { get; set; }

        [Display(Name = "Rango Inicial")]
        public Nullable<System.DateTime> RangeStartFin { get; set; }

        [Display(Name = "Rango Final")]
        public Nullable<System.DateTime> RangeEndIni { get; set; }

        [Display(Name = "Rango Final")]
        public Nullable<System.DateTime> RangeEndFin { get; set; }

        [Display(Name = "Antes de Entrar")]
        public bool AllowBefore { get; set; }

        [Display(Name = "minutos")]
        public Nullable<int> BeforeStart { get; set; }

        [Display(Name = "Despues de Salir")]
        public Nullable<int> AfterEnd { get; set; }

        [Display(Name = "Minutos")]
        public bool AllowAfter { get; set; }

        [Display(Name = "Contar Retardo")]
        public bool Late { get; set; }

        [Display(Name = "Contar despues de")]
        public Nullable<int> LateCome { get; set; }

        [Display(Name = "Contar Salidas tempranas")]
        public bool Early { get; set; }

        [Display(Name = "Salidas Temprano")]
        public Nullable<int> EarlyOut { get; set; }

        [Display(Name = "Salidas Temprano")]
        public Nullable<int> EarlyCome { get; set; }


        public List<Break> ListaDescanso { get; set; }

        public List<BreakShift> ListDescansoSeleccionados { get; set; }

        [Display(Name = "Descanso")]
        public List<int> ListDescansoCodigoSeleccionados { get; set; }

        public SelectList ListaTipo { get; set; }


    }
}