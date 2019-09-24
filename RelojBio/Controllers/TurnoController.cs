using RelojBio.Models;
using RelojBio.ViewModel;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class TurnoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListTurnos = wdb.Schedule.OrderByDescending(a => a.ScheduleID).ToList();

                return View(ListTurnos);
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OVMTurno = new TurnoViewModel();
                    return View(OVMTurno);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Turno");

            }

        }


        [HttpPost]
        public ActionResult Create(TurnoViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoTurno = wdb.Schedule.OrderByDescending(a => a.ScheduleID).FirstOrDefault();
                    int wId = OUltimoTurno.ScheduleID + 1;

                    var OTurno = new Schedule
                    {
                        ScheduleID = wId,
                        Name = Omodelo.Name,
                        AuditDateIns = DateTime.Now,
                        AuditStationIns = Environment.MachineName,
                        AuditUserIns = User.Identity.Name

                    };
                    wdb.Schedule.Add(OTurno);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Turno Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Turno");
                }

            }
            catch (DbEntityValidationException e)
            {
                var errorMessages = e.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(e.Message, " El error de validacion es: ", fullErrorMessage);

                OMensaje.Tipo = "Error";
                OMensaje.Msg = exceptionMessage;
                Session["Mensaje"] = OMensaje;

                return View(Omodelo);
            }
        }


        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OTurno = wdb.Schedule.Where(a => a.ScheduleID == Id).FirstOrDefault();

                    var OVMTurno = new TurnoViewModel
                    {
                        ScheduleID = OTurno.ScheduleID,
                        Name = OTurno.Name
                    };

                    return View(OVMTurno);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Turno");

            }


        }


        [HttpPost]
        public ActionResult Edit(TurnoViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OTurno = wdb.Schedule.Where(a => a.ScheduleID == Omodelo.ScheduleID).FirstOrDefault();

                    OTurno.Name = Omodelo.Name;
                    OTurno.AuditUserUpd = User.Identity.Name;
                    OTurno.AuditDateUpd = DateTime.Now;
                    OTurno.AuditStationUpd = Environment.MachineName;

                    wdb.Entry(OTurno).State = EntityState.Modified;
                    wdb.SaveChanges();

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "El Turno Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Turno");
                }

            }
            catch (DbEntityValidationException e)
            {
                var errorMessages = e.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(e.Message, " El error de validacion es: ", fullErrorMessage);

                OMensaje.Tipo = "Error";
                OMensaje.Msg = exceptionMessage;
                Session["Mensaje"] = OMensaje;

                return View(Omodelo);


            }


        }

        [HttpGet]
        public ActionResult Eliminar(int Id)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OTurno = wdb.Schedule.Where(a => a.ScheduleID == Id).FirstOrDefault();

                    wdb.Schedule.Remove(OTurno);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Turno Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Turno");

                }

            }
            catch (DbEntityValidationException e)
            {
                var errorMessages = e.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);

                var exceptionMessage = string.Concat(e.Message, " El error de validacion es: ", fullErrorMessage);

                OMensaje.Tipo = "Error";
                OMensaje.Msg = exceptionMessage;
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Turno");

            }
        }
    }
}