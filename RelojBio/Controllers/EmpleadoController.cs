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
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]
        public ActionResult Index()
        {
            
            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListEmpleado = wdb.Employee.OrderByDescending(a=> a.EmployeeID).ToList();

                return View(ListEmpleado);
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
                    //var OEmpleado = wdb.Employee.Where(a=> a.EmployeeID == Id).FirstOrDefault();

                    var ListDepar = wdb.Department.ToList();
                    var ListTur = wdb.Schedule.ToList();
                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                    var OGenero = new Genero
                    {
                        Id = "M",
                        Nombre = "MASCULINO"
                    };
                    var OGenero2 = new Genero
                    {
                        Id = "F",
                        Nombre = "FEMENINO"
                    };
                    var ListGenero = new List<Genero>
                    {
                        OGenero,
                        OGenero2
                    };

                    var OVMEmpleado = new EmpleadoViewModel
                    {
                        ListaDepartamento = new SelectList(ListDepar, "DepartmentID", "Name"),
                        ListaTurno = new SelectList(ListTur, "ScheduleID", "Name"),
                        ListaPais = new SelectList(ListPais, "CountryID", "Name"),
                        ListaEstado = new SelectList(LisEstado, "StateID", "Name"),
                        ListaCiudad = new SelectList(ListCiudad, "CityID", "Name"),
                        ListaGenero = new SelectList(ListGenero, "Id", "Nombre"),
                    };

                    return View(OVMEmpleado);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index","Empleado");

            }

        }


        [HttpPost]
        public ActionResult Create(EmpleadoViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoEmpleadoCode = wdb.Employee.OrderByDescending(a => a.Code).FirstOrDefault();
                    string wCode = Convert.ToString(Convert.ToInt32(OUltimoEmpleadoCode.Code) + 1);
                    var OUltimoEmpleadoId = wdb.Employee.OrderByDescending(a => a.EmployeeID).FirstOrDefault();
                    int wId = OUltimoEmpleadoId.EmployeeID + 1;

                    var OEmpleadoNuevo = new Employee
                    {
                        Code = wCode,
                        EmployeeID = wId,
                        FirstName = Omodelo.Nombre,
                        LastName = Omodelo.Apellido,
                        Pin = Omodelo.Pin,
                        DepartmentID = Omodelo.DepartamentoID,
                        ScheduleID = Omodelo.ScheduleID,
                        Salary = Omodelo.Salary,
                        IdentificationNumber = Omodelo.IdentificationNumber,
                        EarnOvertime = Omodelo.EarnOvertime,
                        IsActive = Omodelo.IsActive,
                        HireDate = Omodelo.HireDate,
                        MainAddress = Omodelo.MainAddress,
                        AlternateAddress = Omodelo.AlternateAddress,
                        CountryID = Omodelo.CountryID,
                        CityID = Omodelo.CityID,
                        StateID = Omodelo.StateID,
                        Fax = Omodelo.Fax,
                        CardNumber = Omodelo.CardNumber,
                        Email = Omodelo.Email,
                        PostalCode = Omodelo.PostalCode,
                        EmergencyAddress = Omodelo.EmergencyAddress,
                        EmergencyName = Omodelo.EmergencyName,
                        MainEmergencyPhone = Omodelo.MainEmergencyPhone,
                        AlternateEmergencyPhone = Omodelo.AlternateEmergencyPhone,
                        Title = Omodelo.Title,
                        HourlyRate = Omodelo.HourlyRate,
                        Gender = Omodelo.Gender,
                        BirthDay = Omodelo.BirthDay,
                        FireDate = Omodelo.FireDate,
                        FireReason = Omodelo.FireReason,

                    };
                    wdb.Employee.Add(OEmpleadoNuevo);
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

                                string wpath = Server.MapPath("~/Imagenes/Clientes");
                                wpath = wpath + "/" + OEmpleadoNuevo.EmployeeID + ".png";

                                fileContent.SaveAs(wpath);

                            }
                        }

                    }

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Empleado Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Empleado");
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
                    //var OEmpleado = wdb.Employee.Where(a=> a.EmployeeID == Id).FirstOrDefault();

                    var ListDepar = wdb.Department.ToList();
                    var ListTur = wdb.Schedule.ToList();
                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                    var OGenero = new Genero
                    {
                        Id = "M",
                        Nombre = "MASCULINO"
                    };
                    var OGenero2 = new Genero
                    {
                        Id = "F",
                        Nombre = "FEMENINO"
                    };
                    var ListGenero = new List<Genero>
                    {
                        OGenero,
                        OGenero2
                    };

                    Omodelo.ListaDepartamento = new SelectList(ListDepar, "DepartmentID", "Name");
                    Omodelo.ListaTurno = new SelectList(ListTur, "ScheduleID", "Name");
                    Omodelo.ListaPais = new SelectList(ListPais, "CountryID", "Name");
                    Omodelo.ListaEstado = new SelectList(LisEstado, "StateID", "Name");
                    Omodelo.ListaCiudad = new SelectList(ListCiudad, "CityID", "Name");
                    Omodelo.ListaGenero = new SelectList(ListGenero, "Id", "Nombre");

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
                    var OEmpleado = wdb.Employee.Where(a => a.EmployeeID == Id).FirstOrDefault();

                    var ListDepar = wdb.Department.ToList();
                    var ListTur = wdb.Schedule.ToList();
                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                    var OGenero = new Genero
                    {
                        Id = "M",
                        Nombre = "MASCULINO"
                    };
                    var OGenero2 = new Genero
                    {
                        Id = "F",
                        Nombre = "FEMENINO"
                    };
                    var ListGenero = new List<Genero>
                    {
                        OGenero,
                        OGenero2
                    };

                    var OVMEmpleado = new EmpleadoViewModel
                    {
                        EmpleadoId = OEmpleado.EmployeeID,
                        Code = OEmpleado.Code,
                        Nombre = OEmpleado.FirstName,
                        Apellido = OEmpleado.LastName,
                        Pin = OEmpleado.Pin,
                        DepartamentoID = OEmpleado.DepartmentID,
                        ScheduleID = OEmpleado.ScheduleID,
                        Salary = OEmpleado.Salary,
                        IdentificationNumber = OEmpleado.IdentificationNumber,
                        EarnOvertime = Convert.ToBoolean(OEmpleado.EarnOvertime ?? false),
                        IsActive = OEmpleado.IsActive,
                        HireDate = Convert.ToDateTime(OEmpleado.HireDate ?? DateTime.Now),
                        MainAddress = OEmpleado.MainAddress,
                        AlternateAddress = OEmpleado.AlternateAddress,
                        CountryID = OEmpleado.CountryID,
                        CityID = OEmpleado.CityID,
                        StateID = OEmpleado.StateID,
                        Fax = OEmpleado.Fax,
                        CardNumber = OEmpleado.CardNumber,
                        Email = OEmpleado.Email,
                        PostalCode = OEmpleado.PostalCode,
                        EmergencyAddress = OEmpleado.EmergencyAddress,
                        EmergencyName = OEmpleado.EmergencyName,
                        MainEmergencyPhone = OEmpleado.MainEmergencyPhone,
                        AlternateEmergencyPhone = OEmpleado.AlternateEmergencyPhone,
                        Title = OEmpleado.Title,
                        HourlyRate = OEmpleado.HourlyRate,
                        Gender = OEmpleado.Gender,
                        BirthDay = Convert.ToDateTime(OEmpleado.BirthDay ?? DateTime.Now),
                        FireDate = Convert.ToDateTime(OEmpleado.FireDate ?? DateTime.Now),
                        FireReason = OEmpleado.FireReason,
                        ListaDepartamento = new SelectList(ListDepar, "DepartmentID", "Name"),
                        ListaTurno = new SelectList(ListTur, "ScheduleID", "Name"),
                        ListaPais = new SelectList(ListPais, "CountryID", "Name"),
                        ListaEstado = new SelectList(LisEstado, "StateID", "Name"),
                        ListaCiudad = new SelectList(ListCiudad, "CityID", "Name"),
                        ListaGenero = new SelectList(ListGenero,"Id","Nombre")

                    };

                    string wSrc = Server.MapPath("~/Imagenes/Clientes/") + OEmpleado.EmployeeID + ".png";

                    if (!System.IO.File.Exists(wSrc))
                    {
                        ViewBag.wSrc = "/Imagenes/Clientes/FondoImagenUsuario.png";
                    }
                    else
                    {
                        ViewBag.wSrc = "/Imagenes/Clientes/" + OEmpleado.EmployeeID + ".png";
                    }




                    return View(OVMEmpleado);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Empleado");

            }


        }


        [HttpPost]
        public ActionResult Edit(EmpleadoViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OEMpleado = wdb.Employee.Where(a=> a.EmployeeID == Omodelo.EmpleadoId).FirstOrDefault();

                    OEMpleado.FirstName = Omodelo.Nombre;
                    OEMpleado.LastName = Omodelo.Apellido;
                    OEMpleado.Pin = Omodelo.Pin;
                    OEMpleado.DepartmentID = Omodelo.DepartamentoID;
                    OEMpleado.ScheduleID = Omodelo.ScheduleID;
                    OEMpleado.Salary = Omodelo.Salary;
                    OEMpleado.IdentificationNumber = Omodelo.IdentificationNumber;
                    OEMpleado.EarnOvertime = Omodelo.EarnOvertime;
                    OEMpleado.IsActive = Omodelo.IsActive;
                    OEMpleado.HireDate = Omodelo.HireDate;
                    OEMpleado.MainAddress = Omodelo.MainAddress;
                    OEMpleado.AlternateAddress = Omodelo.AlternateAddress;
                    OEMpleado.CountryID = Omodelo.CountryID;
                    OEMpleado.CityID = Omodelo.CityID;
                    OEMpleado.StateID = Omodelo.StateID;
                    OEMpleado.Fax = Omodelo.Fax;
                    OEMpleado.CardNumber = Omodelo.CardNumber;
                    OEMpleado.Email = Omodelo.Email;
                    OEMpleado.PostalCode = Omodelo.PostalCode;
                    OEMpleado.EmergencyAddress = Omodelo.EmergencyAddress;
                    OEMpleado.EmergencyName = Omodelo.EmergencyName;
                    OEMpleado.MainEmergencyPhone = Omodelo.MainEmergencyPhone;
                    OEMpleado.AlternateEmergencyPhone = Omodelo.AlternateEmergencyPhone;
                    OEMpleado.Title = Omodelo.Title;
                    OEMpleado.HourlyRate = Omodelo.HourlyRate;
                    OEMpleado.Gender = Omodelo.Gender;
                    OEMpleado.BirthDay = Omodelo.BirthDay;
                    OEMpleado.FireDate = Omodelo.FireDate;
                    OEMpleado.FireReason = Omodelo.FireReason;

                    wdb.Entry(OEMpleado).State = EntityState.Modified;
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

                                string wpath = Server.MapPath("/Imagenes/Clientes");
                                wpath = wpath + "/" + OEMpleado.EmployeeID + ".png";


                                if (System.IO.File.Exists(wpath))
                                {
                                    System.IO.File.Delete(wpath);
                                }

                                fileContent.SaveAs(wpath);

                            }
                        }

                    }

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Empleado Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Empleado");
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
                    //var OEmpleado = wdb.Employee.Where(a=> a.EmployeeID == Id).FirstOrDefault();

                    var ListDepar = wdb.Department.ToList();
                    var ListTur = wdb.Schedule.ToList();
                    var ListPais = wdb.Country.ToList();
                    var LisEstado = wdb.State.ToList();
                    var ListCiudad = wdb.City.ToList();
                    var OGenero = new Genero
                    {
                        Id = "M",
                        Nombre = "MASCULINO"
                    };
                    var OGenero2 = new Genero
                    {
                        Id = "F",
                        Nombre = "FEMENINO"
                    };
                    var ListGenero = new List<Genero>
                    {
                        OGenero,
                        OGenero2
                    };

                    Omodelo.ListaDepartamento = new SelectList(ListDepar, "DepartmentID", "Name");
                    Omodelo.ListaTurno = new SelectList(ListTur, "ScheduleID", "Name");
                    Omodelo.ListaPais = new SelectList(ListPais, "CountryID", "Name");
                    Omodelo.ListaEstado = new SelectList(LisEstado, "StateID", "Name");
                    Omodelo.ListaCiudad = new SelectList(ListCiudad, "CityID", "Name");
                    Omodelo.ListaGenero = new SelectList(ListGenero, "Id", "Nombre");

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
                    var OEmpleado = wdb.Employee.Where(a => a.EmployeeID == Id).FirstOrDefault();

                    wdb.Employee.Remove(OEmpleado);
                    wdb.SaveChanges();

                    string wpath = Server.MapPath("/Imagenes/Clientes");
                    wpath = wpath + "/" + OEmpleado.EmployeeID + ".png";

                    if (System.IO.File.Exists(wpath))
                    {
                        System.IO.File.Delete(wpath);
                    }

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Empleado Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Empleado");

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
                return RedirectToAction("Index", "Empleado");

            }
        }


        #region Sin Acciones

        //[NonAction]

        //public Department GetDepartamento()
        //{

        //}

        #endregion




    }
}