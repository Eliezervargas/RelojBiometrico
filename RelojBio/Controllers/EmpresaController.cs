using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RelojBio.Models;
using RelojBio.ViewModel;

namespace RelojBio.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        [HttpGet]
        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListEmpresa = wdb.Company.OrderByDescending(a => a.CompanyID).ToList();

                return View(ListEmpresa);
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
                    

                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                    
                    var OVMEmpresa = new EmpresaViewModel
                    {
                        
                        ListaPais = new SelectList(ListPais, "CountryID", "Name"),
                        ListaEstado = new SelectList(LisEstado, "StateID", "Name"),
                        ListaCiudad = new SelectList(ListCiudad, "CityID", "Name"),
                        
                    };

                    return View(OVMEmpresa);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Empresa");

            }

        }

        [HttpPost]
        public ActionResult Create(EmpresaViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoEmpresaCode = wdb.Company.OrderByDescending(a => a.Code).FirstOrDefault();
                    string wCode = Convert.ToString(Convert.ToInt32(OUltimoEmpresaCode.Code) + 1);
                    var OUltimoEmpresaId = wdb.Company.OrderByDescending(a => a.CompanyID).FirstOrDefault();
                    int wId = OUltimoEmpresaId.CompanyID + 1;

                    var OEmpresaNuevo = new Company
                    {
                        Code = wCode,
                        CompanyID = wId,
                        Name = Omodelo.Name,
                        MainAddress = Omodelo.MainAddress,
                        AlternateAddress = Omodelo.AlternateAddress,
                        Phone = Omodelo.Phone,
                        Fax = Omodelo.Fax,
                        Email = Omodelo.Email,
                        WebSite = Omodelo.WebSite,
                        CountryID = Omodelo.CountryID,
                        CityID = Omodelo.CityID,
                        StateID = Omodelo.StateID,
                        

                    };
                    wdb.Company.Add(OEmpresaNuevo);
                    wdb.SaveChanges();


                    for (int i = 0; i < 1; i++)
                    {
                        if (Request.Files[i].ContentLength > 0)
                        {
                            var fileContent = Request.Files[i];
                            if (fileContent != null && fileContent.ContentLength > 0)
                            {
                                var stream = fileContent.InputStream;
                                var fileName = Path.GetFileName(fileContent.FileName);

                                string wpath = Server.MapPath("~/Imagenes/Company");
                                wpath = wpath + "/" + OEmpresaNuevo.CompanyID + ".png";

                                fileContent.SaveAs(wpath);

                            }
                        }

                    }

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Empresa Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Empresa");
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
                    

                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                  
                    Omodelo.ListaPais = new SelectList(ListPais, "CountryID", "Name");
                    Omodelo.ListaEstado = new SelectList(LisEstado, "StateID", "Name");
                    Omodelo.ListaCiudad = new SelectList(ListCiudad, "CityID", "Name");
                   

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
                    var OEmpresa = wdb.Company.Where(a => a.CompanyID == Id).FirstOrDefault();

                   
                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                    

                    var OVMEmpresa = new EmpresaViewModel
                    {
                        CompanyID = OEmpresa.CompanyID,
                        Code = OEmpresa.Code,
                        Name = OEmpresa.Name,
                        Phone = OEmpresa.Phone,
                        MainAddress = OEmpresa.MainAddress,
                        AlternateAddress = OEmpresa.AlternateAddress,
                        Fax = OEmpresa.Fax,
                        Email = OEmpresa.Email,
                        WebSite = OEmpresa.WebSite,
                        CountryID = OEmpresa.CountryID,
                        CityID = OEmpresa.CityID,
                        StateID = OEmpresa.StateID,
                       
                       
                        ListaPais = new SelectList(ListPais, "CountryID", "Name"),
                        ListaEstado = new SelectList(LisEstado, "StateID", "Name"),
                        ListaCiudad = new SelectList(ListCiudad, "CityID", "Name"),
                       

                    };

                    string wSrc = Server.MapPath("~/Imagenes/Company/") + OEmpresa.CompanyID + ".png";

                    if (!System.IO.File.Exists(wSrc))
                    {
                        ViewBag.wSrc = "/Imagenes/Company/FondoImagenUsuario.png";
                    }
                    else
                    {
                        ViewBag.wSrc = "/Imagenes/Company/" + OEmpresa.CompanyID + ".png";
                    }




                    return View(OVMEmpresa);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Empresa");

            }


        }

        [HttpPost]
        public ActionResult Edit(EmpresaViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OEMpresa = wdb.Company.Where(a => a.CompanyID == Omodelo.CompanyID).FirstOrDefault();

                    OEMpresa.Name = Omodelo.Name;
                    OEMpresa.MainAddress = Omodelo.MainAddress;
                    OEMpresa.AlternateAddress = Omodelo.AlternateAddress;
                    OEMpresa.Phone = Omodelo.Phone;
                    OEMpresa.Fax = Omodelo.Fax;
                    OEMpresa.Email = Omodelo.Email;
                    OEMpresa.WebSite = Omodelo.WebSite;

                    OEMpresa.CountryID = Omodelo.CountryID;
                    OEMpresa.CityID = Omodelo.CityID;
                    OEMpresa.StateID = Omodelo.StateID;
                   

                    wdb.Entry(OEMpresa).State = EntityState.Modified;
                    wdb.SaveChanges();

                    for (int i = 0; i < 1; i++)
                    {
                        if (Request.Files[i].ContentLength > 0)
                        {
                            var fileContent = Request.Files[i];
                            if (fileContent != null && fileContent.ContentLength > 0)
                            {
                                var stream = fileContent.InputStream;
                                var fileName = Path.GetFileName(fileContent.FileName);

                                string wpath = Server.MapPath("/Imagenes/Company");
                                wpath = wpath + "/" + OEMpresa.CompanyID + ".png";


                                if (System.IO.File.Exists(wpath))
                                {
                                    System.IO.File.Delete(wpath);
                                }

                                fileContent.SaveAs(wpath);

                            }
                        }

                    }

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Empresa Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Empresa");
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
                   

                    
                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                    

                   
                    Omodelo.ListaPais = new SelectList(ListPais, "CountryID", "Name");
                    Omodelo.ListaEstado = new SelectList(LisEstado, "StateID", "Name");
                    Omodelo.ListaCiudad = new SelectList(ListCiudad, "CityID", "Name");
                  

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
                    var OEmpresa = wdb.Company.Where(a => a.CompanyID == Id).FirstOrDefault();

                    wdb.Company.Remove(OEmpresa);
                    wdb.SaveChanges();

                    string wpath = Server.MapPath("/Imagenes/Company");
                    wpath = wpath + "/" + OEmpresa.CompanyID + ".png";

                    if (System.IO.File.Exists(wpath))
                    {
                        System.IO.File.Delete(wpath);
                    }

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Empresa Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Empresa");

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
                return RedirectToAction("Index", "Empresa");

            }
        }
    }
}