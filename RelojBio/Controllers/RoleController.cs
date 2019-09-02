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
    public class RoleController : Controller
    {
        // GET: Role
        [HttpGet]
        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListRoles = wdb.Role.OrderByDescending(a => a.RoleID).ToList();

                return View(ListRoles);
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
                    var ListOpciones = wdb.Option.Where(a => a.CodeTop != null).ToList();
                    var OVMRole = new RoleViewModel
                    {
                        LisOpciones = ListOpciones
                    };
                    return View(OVMRole);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Role");

            }

        }


        [HttpPost]
        public ActionResult Create(RoleViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoRole = wdb.Role.OrderByDescending(a => a.RoleID).FirstOrDefault();
                    int wId = OUltimoRole.RoleID + 1;

                    var ORole = new Role
                    {
                        RoleID = wId,
                        Description = Omodelo.Description,
                        IsActive = Omodelo.IsActive

                    };
                    wdb.Role.Add(ORole);
                    wdb.SaveChanges();

                    foreach (var item in Omodelo.LisCodigoOpcionesSeleccionados)
                    {
                        var OExiste = wdb.RoleOption.Where(a => a.RoleID == ORole.RoleID && a.OptionID == item).FirstOrDefault();
                        if (OExiste == null)
                        {
                            var OUltimoRoleOption = wdb.RoleOption.OrderByDescending(a => a.RoleOptionID).FirstOrDefault();
                            int wID = OUltimoRoleOption.RoleID + 1;

                            var ORoleOption = new RoleOption
                            {
                                RoleOptionID = wID,
                                RoleID = wId,
                                OptionID = item

                            };
                            wdb.RoleOption.Add(ORoleOption);
                            wdb.SaveChanges();

                        }
                    }


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Rol Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Role");
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
                    var ORole = wdb.Role.Where(a => a.RoleID == Id).FirstOrDefault();
                    var ListOpciones = wdb.Option.Where(a => a.CodeTop != null).ToList();
                    var ListOpcionesSeleccionadas = wdb.RoleOption.Where(a => a.RoleID == Id).ToList();

                    var OVMRole = new RoleViewModel
                    {
                        RoleID = ORole.RoleID,
                        Description = ORole.Description,
                        IsActive = ORole.IsActive,
                        LisOpciones = ListOpciones,
                        LisOpcionesSeleccionados = ListOpcionesSeleccionadas
                        
                    };

                 


                    return View(OVMRole);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Role");

            }


        }


        [HttpPost]
        public ActionResult Edit(RoleViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var ORole = wdb.Role.Where(a => a.RoleID == Omodelo.RoleID).FirstOrDefault();

                    ORole.Description = Omodelo.Description;
                    ORole.IsActive = Omodelo.IsActive;

                    wdb.Entry(ORole).State = EntityState.Modified;
                    wdb.SaveChanges();

                    foreach (var item in Omodelo.LisCodigoOpcionesSeleccionados)
                    {
                        var OExiste = wdb.RoleOption.Where(a => a.RoleID == ORole.RoleID && a.OptionID == item).FirstOrDefault();
                        if (OExiste == null)
                        {
                            var OUltimoRoleOption = wdb.RoleOption.OrderByDescending(a => a.RoleOptionID).FirstOrDefault();
                            int wID = OUltimoRoleOption.RoleOptionID + 1;

                            var ORoleOption = new RoleOption
                            {
                                RoleOptionID = wID,
                                RoleID = Omodelo.RoleID,
                                OptionID = item

                            };
                            wdb.RoleOption.Add(ORoleOption);
                            wdb.SaveChanges();

                        }
                    }


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "El Rol Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Role");
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
                    var ORole = wdb.Role.Where(a => a.RoleID == Id).FirstOrDefault();

                    wdb.Role.Remove(ORole);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Rol Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Role");

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
                return RedirectToAction("Index", "Role");

            }
        }

    }
}