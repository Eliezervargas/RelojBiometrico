using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RelojBio.Models;
using RelojBio.ViewModel;

namespace RelojBio.Controllers
{
    public class LoginRegistroController : Controller
    {
        // GET: LoginRegistro
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.IsLogin = true;
            var Omodelo = new LoginRegistroViewModel();
            return View(Omodelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginRegistroViewModel OModelo)
        {
            var OMensaje = new Mensaje();
            ViewBag.IsLogin = true;

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OUsuario = wdb.User.Where(a => a.Login == OModelo.Login).FirstOrDefault();
                    if (OUsuario != null)
                    {
                        if(OUsuario.Password == OModelo.Password)
                        {
                            OMensaje.Tipo = "Exito";
                            OMensaje.Msg = "Bienvenido al Sistema Biometrico";
                            Session["Mensaje"] = OMensaje;

                            int Timeout = 200; 
                            var Ticket = new FormsAuthenticationTicket(OModelo.Login, false, Timeout);
                            string encrypted = FormsAuthentication.Encrypt(Ticket);
                            var cookies = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted)
                            {
                                Expires = DateTime.Now.AddMinutes(Timeout),
                                HttpOnly = true
                            };
                            Response.Cookies.Add(cookies);

                            var OusuarioCompannia = wdb.UserCompany.Where(a => a.UserID == OUsuario.UserID).FirstOrDefault();
                            var ListUsuarioRol = wdb.UserRole.Where(a => a.UserID == OUsuario.UserID).ToList();
                            var ListRolOpciones = new List<List<RoleOption>>();

                            foreach (var Rol in ListUsuarioRol)
                            {
                                var ListOpciones = wdb.RoleOption.Where(a => a.RoleID == Rol.RoleID).ToList();
                                ListRolOpciones.Add(ListOpciones);
                            }

                            Session["UserId"] = OUsuario.UserID;
                            Session["UserName"] = OUsuario.FullName;

                            if (OusuarioCompannia != null)
                                Session["Compannia"] = OusuarioCompannia.CompanyID;

                            if (ListRolOpciones != null)
                                Session["ListOpciones"] = ListRolOpciones;

                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            OMensaje.Tipo = "Error";
                            OMensaje.Msg = "Usuario y Contraseña no Coinciden. Favor Verificar";
                        }
                    }
                    else
                    {
                        OMensaje.Tipo = "Error";
                        OMensaje.Msg = "El Usuario no Existe!!";
                    }
                }

                Session["Mensaje"] = OMensaje;
                return View(OModelo);

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString() ;
                Session["Mensaje"] = OMensaje;
                return View(OModelo);

            }

        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["UserId"] = null;
            Session["UserName"] = null;
            Session["Compannia"] = null;
            Session["Rol"] = null;

            return RedirectToAction("Index", "LoginRegistro");
        }

    }
}