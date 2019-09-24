using RelojBio.Models;
using RelojBio.ViewModel;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class DispositivosController : Controller
    {

        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {

                var ListDispositivo = wdb.Terminal.ToList();

                return View(ListDispositivo);

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


                    var OVMDispositivos = new DispositivosViewModel
                    {


                    };

                    return View(OVMDispositivos);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Dispositivos");

            }

        }

        [HttpPost]
        public ActionResult Create(DispositivosViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoDispositivos = wdb.Terminal.OrderByDescending(a => a.TerminalID).FirstOrDefault();
                    int wId = OUltimoDispositivos.TerminalID + 1;

                    var ODispositivos = new Terminal
                    {
                        TerminalID = wId,
                        Number = wId,
                        Name = Omodelo.Name,
                        ConnectPwd = Omodelo.ConnectPwd,
                        Type = Omodelo.Type,
                        Faces = Omodelo.Faces,
                        Port = Omodelo.Port,
                        TcpIp = Omodelo.TcpIp,
                        IsActive = Omodelo.IsActive,
                        AuditDateIns = DateTime.Now,
                        AuditStationIns = Environment.MachineName,
                        AuditUserIns = User.Identity.Name

                    };
                    wdb.Terminal.Add(ODispositivos);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Dispositivos Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Dispositivos");
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
                    var ODispositivos = wdb.Terminal.Where(a => a.TerminalID == Id).FirstOrDefault();



                    var OVMDispositivos = new DispositivosViewModel
                    {

                        TerminalID = ODispositivos.TerminalID,
                        Name = ODispositivos.Name,
                        ConnectPwd = ODispositivos.ConnectPwd,
                        Type = ODispositivos.Type,
                        Faces = 0,
                        Port = 0,
                        TcpIp = ODispositivos.TcpIp,
                        IsActive = true

                    };

                    return View(OVMDispositivos);
                }

            }

            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Dispositivos");

            }


        }

        [HttpPost]
        public ActionResult Edit(DispositivosViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var ODispositivos = wdb.Terminal.Where(a => a.TerminalID == Omodelo.TerminalID).FirstOrDefault();

                    ODispositivos.TerminalID = Omodelo.TerminalID;
                    ODispositivos.Number = Omodelo.TerminalID;
                    ODispositivos.Name = Omodelo.Name;
                    ODispositivos.Faces = Omodelo.Faces;
                    ODispositivos.Port = Omodelo.Port;
                    ODispositivos.Type = Omodelo.Type;
                    ODispositivos.ConnectPwd = Omodelo.ConnectPwd;
                    ODispositivos.IsActive = Omodelo.IsActive;

                    wdb.Entry(ODispositivos).State = EntityState.Modified;
                    wdb.SaveChanges();

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "El Dispositivo Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Dispositivos");
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
                    var ODispositivos = wdb.Terminal.Where(a => a.TerminalID == Id).FirstOrDefault();

                    wdb.Terminal.Remove(ODispositivos);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Dispositivo Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Dispositivos");

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
                return RedirectToAction("Index", "Dispositivos");

            }
        }



    }
}