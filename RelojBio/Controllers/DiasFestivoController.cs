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
    public class DiasFestivoController : Controller
    {
        // GET: DiasFestivo
        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {

                //var ListDiasFestivo = wdb.HolidayType.ToList();

                //var ListDiasFestivo = wdb.HolidayType.ToList();

                //foreach (var item in ListDiasFestivo)
                //{
                //    item.HolidayDetails.Where(a => a.HolidayTypeID == item.HolidayTypeID).FirstOrDefault();
                //}

                //wdb.HolidayType.Join(wdb.HolidayDetails, s => s.HolidayTypeID, sa => sa.HolidayTypeID, (s, sa) => new { HolidayType = s, HolidayDetails = sa }).Where(ssa => ssa.asgnmt.LocationId == 1).Select(ssa => ssa.service);



                 List<DiasFestivoViewModel> ListDiasFestivo = wdb.Database.SqlQuery<DiasFestivoViewModel>("select A.HolidayTypeID, A.Code, A.Name, B.StartDate from AssistControl.HolidayType A inner join  AssistControl.HolidayDetails B ON A.HolidayTypeID = B.HolidayTypeID").ToList();

                return View(ListDiasFestivo);

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
                   

                   

                    var OVMDiasFestivo = new DiasFestivoViewModel
                    {
                      
                    };

                    return View(OVMDiasFestivo);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "DiasFestivo");

            }

        }

        [HttpPost]
        public ActionResult Create(DiasFestivoViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoDiasFestivoCode = wdb.HolidayType.OrderByDescending(a => a.Code).FirstOrDefault();
                    int wCode = (OUltimoDiasFestivoCode.Code) + 1;

                   
                    var ODiasFestivoNuevo = new HolidayType
                    {
                        Code = wCode,
                        HolidayTypeID = wCode,
                        Name = Omodelo.Name,
                        AuditDateIns = DateTime.Now,
                        AuditStationIns = Environment.MachineName,
                        AuditUserIns = User.Identity.Name




                    };
                    wdb.HolidayType.Add(ODiasFestivoNuevo);
                    wdb.SaveChanges();


                    var OUltimoDiasFestivoDetalle = wdb.HolidayDetails.OrderByDescending(a => a.HolidayDetailsID).FirstOrDefault();
                    int wCodeDetalle = (OUltimoDiasFestivoDetalle.HolidayDetailsID) + 1;


                    var ODiasFestivoDetalle = new HolidayDetails
                    {
                        HolidayDetailsID = wCodeDetalle,
                        HolidayTypeID = ODiasFestivoNuevo.HolidayTypeID,
                        StartDate = Omodelo.StartDate,
                        EndDate = Omodelo.StartDate,
                        AuditDateIns = DateTime.Now,
                        AuditStationIns = Environment.MachineName,
                        AuditUserIns = User.Identity.Name


                    };
                    wdb.HolidayDetails.Add(ODiasFestivoDetalle);
                    wdb.SaveChanges();



                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Dias Festivo Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "DiasFestivo");
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

                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                   
                    return View(Omodelo);

                }


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
                    var ODiasFestivo = wdb.HolidayType.Where(a => a.HolidayTypeID == Id).FirstOrDefault();
                    var ODiasFestivoDetalle = wdb.HolidayDetails.Where(a => a.HolidayTypeID == Id).FirstOrDefault();


                    var OVMDiasFestivo = new DiasFestivoViewModel
                    {
                        HolidayTypeID = ODiasFestivo.HolidayTypeID,
                        Name = ODiasFestivo.Name,
                        StartDate = ODiasFestivoDetalle.StartDate
                        

                };

                    return View(OVMDiasFestivo);


                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "DiasFestivo");

            }


        }

        [HttpPost]
        public ActionResult Edit(DiasFestivoViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OEMDiasFestivo = wdb.HolidayType.Where(a => a.HolidayTypeID == Omodelo.HolidayTypeID).FirstOrDefault();
                    var ODiasFestivoDetalle = wdb.HolidayDetails.Where(a => a.HolidayTypeID == Omodelo.HolidayTypeID).FirstOrDefault();

                    OEMDiasFestivo.Name = Omodelo.Name;
                    ODiasFestivoDetalle.StartDate = Omodelo.StartDate;
                    OEMDiasFestivo.AuditUserUpd = User.Identity.Name;
                    OEMDiasFestivo.AuditDateUpd = DateTime.Now;
                    OEMDiasFestivo.AuditStationUpd = Environment.MachineName;
                    ODiasFestivoDetalle.AuditUserUpd = User.Identity.Name;
                    ODiasFestivoDetalle.AuditDateUpd = DateTime.Now;
                    ODiasFestivoDetalle.AuditStationUpd = Environment.MachineName;


                    wdb.Entry(OEMDiasFestivo).State = EntityState.Modified;
                    wdb.SaveChanges();

                    wdb.Entry(ODiasFestivoDetalle).State = EntityState.Modified;
                    wdb.SaveChanges();



                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Dias Festivo Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "DiasFestivo");
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

                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    return View(Omodelo);

                }


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
                    var ODiasFestivo = wdb.HolidayType.Where(a => a.HolidayTypeID == Id).FirstOrDefault();
                    var ODiasFestivoDetalle = wdb.HolidayDetails.Where(a => a.HolidayTypeID == Id).FirstOrDefault();

                    wdb.HolidayDetails.Remove(ODiasFestivoDetalle);
                    wdb.SaveChanges();

                    wdb.HolidayType.Remove(ODiasFestivo);
                    wdb.SaveChanges();

                   
                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Dias Festivo Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "DiasFestivo");

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
                return RedirectToAction("Index", "DiasFestivo");

            }
        }

    }
}