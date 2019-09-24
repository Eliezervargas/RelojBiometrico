using RelojBio.Models;
using RelojBio.ViewModel;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class ReporteController : Controller
    {

        [HttpGet]
        public ActionResult Imprimir(int? wTipo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListaEmpleados = wdb.Employee.OrderBy(a=> a.FirstName).ToList();
                var ListaDepartamentos = wdb.Department.ToList();

                var OVMReporte = new ReportesViewModel
                {
                    ListaEmpleados = new SelectList(ListaEmpleados, "EmployeeID", "FirstName"),
                    ListaDepartamentos = ListaDepartamentos,
                    FechaDesde = DateTime.Now,
                    FechaHasta = DateTime.Now,
                    Tipo = wTipo

                };

                return View(OVMReporte);
            }
        }

        [HttpPost]
        public ActionResult Imprimir(ReportesViewModel OModelo)
        {
            switch (OModelo.Tipo)
            {
                case 1:
                    return RedirectToAction("ImprimirMarcacion", "Reporte", OModelo);
                case 2:
                    return RedirectToAction("ImprimirControlAsistencia", "Reporte", OModelo);
                case 3:
                    return RedirectToAction("ImprimirTiempoLibre", "Reporte", OModelo);
                case 4:
                    return RedirectToAction("ImprimirSeguimientoExepcion", "Reporte", OModelo);
                case 5:
                    return RedirectToAction("ImprimirSeguimientoMarcacion", "Reporte", OModelo);
                case 6:
                    return RedirectToAction("ImprimirSeguimientoFichaje", "Reporte", OModelo);
                case 7:
                    return RedirectToAction("ImprimirControlAsistenciaBN", "Reporte", OModelo);


            }
            return View();
        }


        public ActionResult ImprimirMarcacion(ReportesViewModel OModelo)
        {
            var wImprimir = new ActionAsPdf("ControlMarcacion", OModelo);
            return wImprimir;

        }

        public ActionResult ImprimirControlAsistencia(ReportesViewModel OModelo)
        {
            var wImprimir = new ActionAsPdf("ControlAsistencia");
            return wImprimir;

        }

        public ActionResult ImprimirTiempoLibre(ReportesViewModel OModelo)
        {
            var wImprimir = new ActionAsPdf("ControlTiempoLibre");
            return wImprimir;

        }

        public ActionResult ImprimirSeguimientoExepcion(ReportesViewModel OModelo)
        {
            var wImprimir = new ActionAsPdf("SeguimientoExepcion");
            return wImprimir;

        }

        public ActionResult ImprimirSeguimientoMarcacion(ReportesViewModel OModelo)
        {
            var wImprimir = new ActionAsPdf("SeguimientoMarcacion");
            return wImprimir;

        }

        public ActionResult ImprimirSeguimientoFichaje(ReportesViewModel OModelo)
        {
            var wImprimir = new ActionAsPdf("SeguimientoFichaje");
            return wImprimir;

        }

        public ActionResult ImprimirControlAsistenciaBN(ReportesViewModel OModelo)
        {
            var wImprimir = new ActionAsPdf("ControlAsistenciaBN");
            return wImprimir;

        }





        #region Logica de Cada Reporte

        public ActionResult ControlMarcacion(ReportesViewModel OModelo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                string wUsuario = User.Identity.Name;
                string wMaquina = Environment.MachineName;
                string wDesde = OModelo.FechaDesde.ToString().Substring(0,10); 
                
                string wHasta = OModelo.FechaHasta.ToString().Substring(0, 10);
                int wEmpleado = OModelo.Empleado;
                string wDepartamento = "";
                foreach (var item in OModelo.ListaCodigoDepartamentosSeleccionados)
                {
                    wDepartamento = wDepartamento + item.ToString() + ";";
                }
                if (wDepartamento == null || wDepartamento == "")
                    wDepartamento = "1;2;3;";

                List<ControlMarcacionViewModel> ListControlMarcacionViewModel = wdb.Database.SqlQuery<ControlMarcacionViewModel>("exec [AssistControl].[rptControlPunches] @User='" + wEmpleado + "',@Station='" + wMaquina + "',@Action='G',@StartDate = '" + wDesde + "', @FinalDate = '" + wHasta + "', @DepartmentId = '" + wDepartamento + "', @EmployeeId = " + wEmpleado).ToList();

                ViewBag.IsReporte = true;
                return View(ListControlMarcacionViewModel);

            }




        }

        public ActionResult ControlAsistencia(ReportesViewModel OModelo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                string wUsuario = User.Identity.Name;
                string wMaquina = Environment.MachineName;
                DateTime wDesde = OModelo.FechaDesde;
                DateTime wHasta = OModelo.FechaHasta;
                int wEmpleado = OModelo.Empleado;
                string wDepartamento = "";
                foreach (var item in OModelo.ListaCodigoDepartamentosSeleccionados)
                {
                    wDepartamento = wDepartamento + item.ToString() + ";";
                }
                if (wDepartamento == null || wDepartamento == "")
                    wDepartamento = "1;2;3;";

                List<ControlAsistenciaViewModel> ListControlAsistenciaViewModel = wdb.Database.SqlQuery<ControlAsistenciaViewModel>("exec [AssistControl].[rptControlAssistance] @User='" + wUsuario + "',@Station='" + wMaquina + "',@Action='G',@StartDate = '" + wDesde + "', @EndDate = '" + wHasta + "', @DepartmentId = '" + wDepartamento + "', @EmployeeId = "+ wEmpleado).ToList();

                ViewBag.IsReporte = true;
                return View(ListControlAsistenciaViewModel);

            }

        }

        public ActionResult ControlTiempoLibre(ReportesViewModel OModelo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                string wUsuario = User.Identity.Name;
                string wMaquina = Environment.MachineName;
                DateTime wDesde = OModelo.FechaDesde;
                DateTime wHasta = OModelo.FechaHasta;
                int wEmpleado = OModelo.Empleado;
                string wDepartamento = "";
                foreach (var item in OModelo.ListaCodigoDepartamentosSeleccionados)
                {
                    wDepartamento = wDepartamento + item.ToString() + ";";
                }
                if (wDepartamento == null || wDepartamento == "")
                    wDepartamento = "1;2;3;";

                List<ControlTiempoLibreViewModel> ListControlTiempoLibre = wdb.Database.SqlQuery<ControlTiempoLibreViewModel>("exec [AssistControl].[rptControlBreak] @User='" + wUsuario + "',@Station='" + wMaquina + "',@Action='G',@StartDate = '" + wDesde + "', @EndDate = '" + wHasta + "', @DepartmentId = '" + wDepartamento + "', @EmployeeId = "+ wEmpleado).ToList();

                ViewBag.IsReporte = true;
                return View(ListControlTiempoLibre);

            }
        }

        public ActionResult SeguimientoExepcion(ReportesViewModel OModelo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {

                string wUsuario = User.Identity.Name;
                string wMaquina = Environment.MachineName;
                DateTime wDesde = OModelo.FechaDesde;
                DateTime wHasta = OModelo.FechaHasta;
                int wEmpleado = OModelo.Empleado;
                string wDepartamento = "";
                foreach (var item in OModelo.ListaCodigoDepartamentosSeleccionados)
                {
                    wDepartamento = wDepartamento + item.ToString() + ";";
                }
                if (wDepartamento == null || wDepartamento == "")
                    wDepartamento = "1;2;3;";

                List<SeguimientoExepcionViewModel> ListSeguimientoExepcion = wdb.Database.SqlQuery<SeguimientoExepcionViewModel>("exec [AssistControl].[rptExceptionTracking] @User='" + wUsuario + "',@Station='" + wMaquina + "',@Action='G',@StartDate = '" + wDesde + "', @EndDate = '" + wHasta + "', @DepartmentId = '" + wDepartamento + "', @EmployeeId = "+ wEmpleado).ToList();

                ViewBag.IsReporte = true;
                return View(ListSeguimientoExepcion);

            }
        }


        public ActionResult SeguimientoMarcacion(ReportesViewModel OModelo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                string wUsuario = User.Identity.Name;
                string wMaquina = Environment.MachineName;
                DateTime wDesde = OModelo.FechaDesde;
                DateTime wHasta = OModelo.FechaHasta;
                int wEmpleado = OModelo.Empleado;
                string wDepartamento = "";

                foreach (var item in OModelo.ListaCodigoDepartamentosSeleccionados)
                {
                    wDepartamento = wDepartamento + item.ToString() + ";";
                }

                if (wDepartamento == null || wDepartamento == "")
                    wDepartamento = "1;2;3;";

                List<SeguimientoMarcacionViewModel> ListSeguimientoMarcacion = wdb.Database.SqlQuery<SeguimientoMarcacionViewModel>("exec [AssistControl].[rptDialTracking] @User='" + wUsuario + "',@Station='" + wMaquina + "',@Action='G',@StartDate = '" + wDesde + "', @EndDate = '" + wHasta + "', @DepartmentId = '" + wDepartamento + "',@EmployeeId = " + wEmpleado + ", @IsInserted = 1, @IsModified = 1, @IsRemoved = 1").ToList();

                ViewBag.IsReporte = true;
                return View(ListSeguimientoMarcacion);

            }
        }

        public ActionResult SeguimientoFichaje(ReportesViewModel OModelo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                string wUsuario = User.Identity.Name;
                string wMaquina = Environment.MachineName;
                DateTime wDesde = OModelo.FechaDesde;
                DateTime wHasta = OModelo.FechaHasta;
                int wEmpleado = OModelo.Empleado;
                string wDepartamento = "";
                foreach (var item in OModelo.ListaCodigoDepartamentosSeleccionados)
                {
                    wDepartamento = wDepartamento + item.ToString() + ";";
                }

                if (wDepartamento == null || wDepartamento == "")
                    wDepartamento = "1;2;3;";


                List<SeguimientoFichajeViewModel> ListSeguimientoFichaje = wdb.Database.SqlQuery<SeguimientoFichajeViewModel>("").ToList();

                ViewBag.IsReporte = true;
                return View(ListSeguimientoFichaje);

            }
        }

        public ActionResult ControlAsistenciaBN(ReportesViewModel OModelo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {

                string wUsuario = User.Identity.Name;
                string wMaquina = Environment.MachineName;
                DateTime wDesde = OModelo.FechaDesde;
                DateTime wHasta = OModelo.FechaHasta;
                int wEmpleado = OModelo.Empleado;
                string wDepartamento = "";
                foreach (var item in OModelo.ListaCodigoDepartamentosSeleccionados)
                {
                    wDepartamento = wDepartamento + item.ToString() + ";";
                }

                if (wDepartamento == null || wDepartamento == "")
                    wDepartamento = "1;2;3;";


                List<ControlAsistenciaBNViewModel> ListControlAsistenciaBN = wdb.Database.SqlQuery<ControlAsistenciaBNViewModel>("exec [AssistControl].[rptControlAssistance] @User='" + wUsuario + "',@Station='" + wMaquina + "',@Action='G',@StartDate = '" + wDesde + "', @EndDate = '" + wHasta + "', @DepartmentId = '" + wDepartamento + "', @EmployeeId = " + wEmpleado).ToList();

                ViewBag.IsReporte = true;
                return View(ListControlAsistenciaBN);

            }
        }



        #endregion



    }
}