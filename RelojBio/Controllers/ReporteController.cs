using RelojBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelojBio.ViewModel;
using Rotativa;

namespace RelojBio.Controllers
{
    public class ReporteController : Controller
    {

       [HttpGet]
        public ActionResult Imprimir(int? wTipo)
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListaEmpleados = wdb.Employee.ToList();
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
                    return RedirectToAction("ImprimirMarcacion", "Reporte",OModelo);
                case 2:
                    return RedirectToAction("ImprimirControlAsistencia", "Reporte",OModelo);
                case 3:
                    return RedirectToAction("ImprimirTiempoLibre", "Reporte",OModelo);
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

                List<ControlMarcacionViewModel> ListControlMarcacionViewModel = wdb.Database.SqlQuery<ControlMarcacionViewModel>("exec [AssistControl].[rptControlPunches] @User='admin',@Station='DESKTOP-8LDNFUI',@Action='G',@StartDate = '24/04/2019', @FinalDate = '24/04/2019', @DepartmentId = '2;', @EmployeeId = 20").ToList();

                return View(ListControlMarcacionViewModel);

            }




        }

        public ActionResult ControlAsistencia(ReportesViewModel OModelo)
        {

            return View();
        }

        public ActionResult ControlTiempoLibre(ReportesViewModel OModelo)
        {

            return View();
        }

        public ActionResult SeguimientoExepcion(ReportesViewModel OModelo)
        {

            return View();
        }


        public ActionResult SeguimientoMarcacion(ReportesViewModel OModelo)
        {

            return View();
        }

        public ActionResult SeguimientoFichaje(ReportesViewModel OModelo)
        {

            return View();
        }

        public ActionResult ControlAsistenciaBN(ReportesViewModel OModelo)
        {

            return View();
        }



        #endregion



    }
}