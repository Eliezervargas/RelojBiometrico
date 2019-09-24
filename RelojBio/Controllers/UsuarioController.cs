using RelojBio.Models;
using RelojBio.ViewModel;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Role
        [HttpGet]
        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListUsuarios = wdb.User.OrderByDescending(a => a.UserID).ToList();

                return View(ListUsuarios);
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

                    var OVMUser = new UserViewModel();
                    var ListCompania = wdb.Company.ToList();
                    var ListRoles = wdb.Role.ToList();
                    OVMUser.ListCompania = ListCompania;
                    OVMUser.ListRoles = ListRoles;

                    return View(OVMUser);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Usuario");

            }

        }


        [HttpPost]
        public ActionResult Create(UserViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoUsuario = wdb.User.OrderByDescending(a => a.UserID).FirstOrDefault();
                    int wI = OUltimoUsuario.UserID + 1;
                    string wPasswordExpires = "N";
                    if (Omodelo.PasswordExpires == true)
                        wPasswordExpires = "S";

                    var OUsuario = new User
                    {
                        UserID = wI,
                        FullName = Omodelo.FullName,
                        Login = Omodelo.Login,
                        Password = Omodelo.Password,
                        PasswordExpires = wPasswordExpires,
                        DaysValidity = Omodelo.DaysValidity,
                        LastChangePassword = Omodelo.LastChangePassword,
                        IsActive = Omodelo.IsActive


                    };
                    wdb.User.Add(OUsuario);
                    wdb.SaveChanges();

                    //ahora grabo todos los roles 
                    foreach (var item in Omodelo.ListRolesCodigoSeleccionados)
                    {
                        var OExisteUserRole = wdb.UserRole.Where(a => a.UserID == OUsuario.UserID && a.RoleID == item).FirstOrDefault();
                        if (OExisteUserRole == null)
                        {
                            var OUltimoUserRole = wdb.UserRole.OrderByDescending(a => a.UserRoleID).FirstOrDefault();
                            int wId = OUltimoUserRole.UserRoleID + 1;
                            var OUserRole = new UserRole
                            {
                                UserRoleID = wId,
                                RoleID = item,
                                UserID = OUsuario.UserID
                            };
                            wdb.UserRole.Add(OUserRole);
                            wdb.SaveChanges();
                        }
                    }

                    //Grabo las empresas asociadas a ese Usuario
                    foreach (var item in Omodelo.ListCompaniaCodigoSeleccionadas)
                    {
                        var OExisteUserCompani = wdb.UserCompany.Where(a => a.UserID == OUsuario.UserID && a.CompanyID == item).FirstOrDefault();
                        if (OExisteUserCompani == null)
                        {
                            var OUltimoUserCompani = wdb.UserCompany.OrderByDescending(a => a.UserCompanyID).FirstOrDefault();
                            int wId = OUltimoUserCompani.UserCompanyID + 1;
                            var OUserCompani = new UserCompany
                            {
                                UserCompanyID = wId,
                                CompanyID = item,
                                UserID = OUsuario.UserID
                            };
                            wdb.UserCompany.Add(OUserCompani);
                            wdb.SaveChanges();
                        }
                    }


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Usuario Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Usuario");
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
                    var OUsuario = wdb.User.Where(a => a.UserID == Id).FirstOrDefault();
                    bool wPasswordExpires = false;
                    if (OUsuario.PasswordExpires == "S")
                        wPasswordExpires = true;

                    var ListCompania = wdb.Company.ToList();
                    var ListRoles = wdb.Role.ToList();
                    var ListCompaniaSeleccionadas = wdb.UserCompany.Where(a => a.UserID == OUsuario.UserID).ToList();
                    var ListRolesSeleccionados = wdb.UserRole.Where(a => a.UserID == OUsuario.UserID).ToList();


                    var OVMUsuario = new UserViewModel
                    {
                        UserID = OUsuario.UserID,
                        FullName = OUsuario.FullName,
                        Login = OUsuario.Login,
                        Password = OUsuario.Password,
                        PasswordExpires = wPasswordExpires,
                        DaysValidity = OUsuario.DaysValidity,
                        LastChangePassword = Convert.ToDateTime(OUsuario.LastChangePassword ?? DateTime.Now),
                        IsActive = OUsuario.IsActive,
                        ListCompania = ListCompania,
                        ListRoles = ListRoles,
                        ListCompaniaSeleccionadas = ListCompaniaSeleccionadas,
                        ListRolesSeleccionados = ListRolesSeleccionados

                    };




                    return View(OVMUsuario);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Usuario");

            }


        }


        [HttpPost]
        public ActionResult Edit(UserViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OUsuario = wdb.User.Where(a => a.UserID == Omodelo.UserID).FirstOrDefault();

                    string wPasswordExpires = "N";
                    if (Omodelo.PasswordExpires == true)
                        wPasswordExpires = "S";

                    OUsuario.UserID = Omodelo.UserID;
                    OUsuario.FullName = Omodelo.FullName;
                    OUsuario.Login = Omodelo.Login;
                    OUsuario.Password = Omodelo.Password;
                    OUsuario.PasswordExpires = wPasswordExpires;
                    OUsuario.DaysValidity = Omodelo.DaysValidity;
                    OUsuario.LastChangePassword = Omodelo.LastChangePassword;
                    OUsuario.IsActive = Omodelo.IsActive;

                    wdb.Entry(OUsuario).State = EntityState.Modified;
                    wdb.SaveChanges();

                    //ahora grabo todos los roles 
                    foreach (var item in Omodelo.ListRolesCodigoSeleccionados)
                    {
                        var OExisteUserRole = wdb.UserRole.Where(a => a.UserID == OUsuario.UserID && a.RoleID == item).FirstOrDefault();
                        if (OExisteUserRole == null)
                        {
                            var OUltimoUserRole = wdb.UserRole.OrderByDescending(a => a.UserRoleID).FirstOrDefault();
                            int wId = OUltimoUserRole.UserRoleID + 1;
                            var OUserRole = new UserRole
                            {
                                UserRoleID = wId,
                                RoleID = item,
                                UserID = OUsuario.UserID
                            };
                            wdb.UserRole.Add(OUserRole);
                            wdb.SaveChanges();
                        }
                    }

                    //Grabo las empresas asociadas a ese Usuario
                    foreach (var item in Omodelo.ListCompaniaCodigoSeleccionadas)
                    {
                        var OExisteUserCompani = wdb.UserCompany.Where(a => a.UserID == OUsuario.UserID && a.CompanyID == item).FirstOrDefault();
                        if (OExisteUserCompani == null)
                        {
                            var OUltimoUserCompani = wdb.UserCompany.OrderByDescending(a => a.UserCompanyID).FirstOrDefault();
                            int wId = OUltimoUserCompani.UserCompanyID + 1;
                            var OUserCompani = new UserCompany
                            {
                                UserCompanyID = wId,
                                CompanyID = item,
                                UserID = OUsuario.UserID
                            };
                            wdb.UserCompany.Add(OUserCompani);
                            wdb.SaveChanges();
                        }
                    }


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "El Usuario Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Usuario");
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
                    var OUsuario = wdb.User.Where(a => a.UserID == Id).FirstOrDefault();

                    wdb.User.Remove(OUsuario);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Usuario Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Usuario");

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
                return RedirectToAction("Index", "Usuario");

            }
        }
    }
}