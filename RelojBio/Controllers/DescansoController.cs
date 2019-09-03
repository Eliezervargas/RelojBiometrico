using RelojBio.Models;
using RelojBio.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class DescansoController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListDescanso = wdb.Break.OrderByDescending(a => a.BreakID).ToList();

                return View(ListDescanso);
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
                    var OVMDescanso = new DescansoViewModel
                    {
                        Tipo = 2
                    };
                    return View(OVMDescanso);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Descanso");

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

                    var OUltimoDescanso = wdb.Break.OrderByDescending(a => a.BreakID).FirstOrDefault();
                    int wId = OUltimoDescanso.BreakID + 1;

                    var ODescanso = new Break
                    {
                        BreakID = wId,
                        Name = Omodelo.Name,
                        AuditDateIns = DateTime.Now,
                        AuditStationIns = Environment.MachineName,
                        AuditUserIns = User.Identity.Name

                    };
                    wdb.Break.Add(ODescanso);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Descanso Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Descanso");
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
                    var ODescanso = wdb.Break.Where(a => a.BreakID == Id).FirstOrDefault();
                    int wTipo = 1;
                    if(ODescanso.Deduct == true)
                    {
                        wTipo = 1;
                    }else if(ODescanso.AutoDeduct == true){
                        wTipo = 2;
                    }else {
                        wTipo = 3;
                    }

                    var OVMDescanso = new DescansoViewModel
                    {
                        BreakID = ODescanso.BreakID,
                        Name = ODescanso.Name,
                        Start = ODescanso.Start,
                        End = ODescanso.End,
                        DeductMinute = ODescanso.DeductMinute,
                        Tipo = wTipo
                    };

                    return View(OVMDescanso);
                }

            }

            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Descanso");

            }


        }


        [HttpPost]
        public ActionResult Edit(DescansoViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var ODescanso = wdb.Break.Where(a => a.BreakID == Omodelo.BreakID).FirstOrDefault();

                    ODescanso.Name = Omodelo.Name;
                    ODescanso.AuditUserUpd = User.Identity.Name;
                    ODescanso.AuditDateUpd = DateTime.Now;
                    ODescanso.AuditStationUpd = Environment.MachineName;
                    if(Omodelo.Tipo == 1)
                    {
                        ODescanso.Deduct = true;
                        ODescanso.AutoDeduct = false;
                        ODescanso.NeedCheck = false;
                    }
                    else if(Omodelo.Tipo == 2)
                    {
                        ODescanso.Deduct = false;
                        ODescanso.AutoDeduct = true;
                        ODescanso.NeedCheck = false;
                    }
                    else
                    {
                        ODescanso.Deduct = false;
                        ODescanso.AutoDeduct = false;
                        ODescanso.NeedCheck = true;
                    }
                    wdb.Entry(ODescanso).State = EntityState.Modified;
                    wdb.SaveChanges();

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "El Descanso Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Descanso");
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
                    var ODescanso = wdb.Break.Where(a => a.BreakID == Id).FirstOrDefault();

                    wdb.Break.Remove(ODescanso);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Descanso Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Descanso");

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
                return RedirectToAction("Index", "Descanso");

            }
        }
    }
}