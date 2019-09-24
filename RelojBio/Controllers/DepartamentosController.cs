using RelojBio.Models;
using RelojBio.ViewModel;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class DepartamentosController : Controller
    {
        // GET: Departamentos
        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {

                var ListDepartamentos = wdb.Department.ToList();

                return View(ListDepartamentos);

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


                    var ListEmpresa = wdb.Company.ToList();
                    var ListTur = wdb.Schedule.ToList();

                    var OVMDepartamentos = new DepartamentosViewModel
                    {
                        ListaEmpresa = new SelectList(ListEmpresa, "CompanyID", "Name"),
                        ListaTurno = new SelectList(ListTur, "ScheduleID", "Name"),

                    };

                    return View(OVMDepartamentos);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Departamentos");

            }

        }


        [HttpPost]
        public ActionResult Create(DepartamentosViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoDepartaCode = wdb.Department.OrderByDescending(a => a.DepartmentID).FirstOrDefault();
                    int wCode = (OUltimoDepartaCode.Code) + 1;


                    var ODepartamentoNuevo = new Department
                    {
                        Code = wCode,
                        DepartmentID = wCode,
                        Name = Omodelo.Name,
                        CompanyID = Omodelo.CompanyID,
                        ScheduleID = Omodelo.ScheduleID

                    };
                    wdb.Department.Add(ODepartamentoNuevo);
                    wdb.SaveChanges();



                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Departamento Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Departamentos");
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


                    var ListEmpresa = wdb.Company.ToList();
                    var ListTur = wdb.Schedule.ToList();


                    Omodelo.ListaEmpresa = new SelectList(ListEmpresa, "CompanyID", "Name");
                    Omodelo.ListaTurno = new SelectList(ListTur, "ScheduleID", "Name");


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
                    var ODepartamento = wdb.Department.Where(a => a.DepartmentID == Id).FirstOrDefault();

                    var ListEmpresa = wdb.Company.ToList();
                    var ListTur = wdb.Schedule.ToList();


                    var OVMDepartamento = new DepartamentosViewModel
                    {
                        DepartmentID = ODepartamento.DepartmentID,

                        Name = ODepartamento.Name,
                        CompanyID = ODepartamento.CompanyID,
                        ScheduleID = ODepartamento.ScheduleID,

                        ListaEmpresa = new SelectList(ListEmpresa, "CompanyID", "Name"),
                        ListaTurno = new SelectList(ListTur, "ScheduleID", "Name"),


                    };

                    return View(OVMDepartamento);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Departamentos");

            }


        }


        [HttpPost]
        public ActionResult Edit(DepartamentosViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OEMDepata = wdb.Department.Where(a => a.DepartmentID == Omodelo.DepartmentID).FirstOrDefault();

                    OEMDepata.Name = Omodelo.Name;
                    OEMDepata.CompanyID = Omodelo.CompanyID;
                    OEMDepata.ScheduleID = Omodelo.ScheduleID;


                    wdb.Entry(OEMDepata).State = EntityState.Modified;
                    wdb.SaveChanges();



                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Departamento Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Departamentos");
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


                    var ListEmpresa = wdb.Company.ToList();
                    var ListTur = wdb.Schedule.ToList();


                    Omodelo.ListaEmpresa = new SelectList(ListEmpresa, "CompanyID", "Name");
                    Omodelo.ListaTurno = new SelectList(ListTur, "ScheduleID", "Name");


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
                    var ODepartamento = wdb.Department.Where(a => a.DepartmentID == Id).FirstOrDefault();

                    wdb.Department.Remove(ODepartamento);
                    wdb.SaveChanges();

                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Departamento Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Departamentos");

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
                return RedirectToAction("Index", "Departamentos");

            }
        }


    }
}