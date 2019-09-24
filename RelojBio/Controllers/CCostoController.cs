using RelojBio.Models;
using RelojBio.ViewModel;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class CCostoController : Controller
    {
        // GET: CCosto
        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {

                var ListCCosto = wdb.CostCenter.ToList();

                return View(ListCCosto);

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


                    var OVMCCosto = new CCostoViewModel
                    {


                    };

                    return View(OVMCCosto);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "CCosto");

            }

        }

        [HttpPost]
        public ActionResult Create(CCostoViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoCCosto = wdb.CostCenter.OrderByDescending(a => a.CostCenterID).FirstOrDefault();
                    int wId = OUltimoCCosto.CostCenterID + 1;

                    var OCCosto = new CostCenter
                    {
                        CostCenterID = wId,
                        Code = Omodelo.Code,
                        Name = Omodelo.Name,
                        Description = Omodelo.Description,
                        IsActive = Omodelo.IsActive,
                        AuditDateIns = DateTime.Now,
                        AuditStationIns = Environment.MachineName,
                        AuditUserIns = User.Identity.Name

                    };
                    wdb.CostCenter.Add(OCCosto);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Centro Costo Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "CCosto");
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
                    var OCCosto = wdb.CostCenter.Where(a => a.CostCenterID == Id).FirstOrDefault();



                    var OVMCCosto = new CCostoViewModel
                    {
                        CostCenterID = OCCosto.CostCenterID,
                        Code = OCCosto.Code,
                        Name = OCCosto.Name,
                        Description = OCCosto.Description,
                        IsActive = OCCosto.IsActive
                    };

                    return View(OVMCCosto);
                }

            }

            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "CCosto");

            }


        }

        [HttpPost]
        public ActionResult Edit(CCostoViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OCCosto = wdb.CostCenter.Where(a => a.CostCenterID == Omodelo.CostCenterID).FirstOrDefault();

                    OCCosto.CostCenterID = Omodelo.CostCenterID;
                    OCCosto.Code = Omodelo.Code;
                    OCCosto.Name = Omodelo.Name;
                    OCCosto.Description = Omodelo.Description;
                    OCCosto.IsActive = Omodelo.IsActive;

                    wdb.Entry(OCCosto).State = EntityState.Modified;
                    wdb.SaveChanges();

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "El Centro Costo Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "CCosto");
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
                    var OCCosto = wdb.CostCenter.Where(a => a.CostCenterID == Id).FirstOrDefault();

                    wdb.CostCenter.Remove(OCCosto);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Centro Costo Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "CCosto");

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
                return RedirectToAction("Index", "CCosto");

            }
        }

    }
}