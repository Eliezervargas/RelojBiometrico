using RelojBio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class LocalidadController : Controller
    {
        // GET: Localidad
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult EstadoPais(int wCountryID)
        {
            var ListEstado = new List<State>();

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                 ListEstado = wdb.State.Where(a => a.CountryID == wCountryID).ToList();

            }
            return new JsonResult { Data = ListEstado, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult CiudadEstado(int wStateID)
        {
            var ListCiudad = new List<City>();

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                ListCiudad = wdb.City.Where(a => a.StateID == wStateID).ToList();

            }

            return new JsonResult { Data = ListCiudad, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }


    }
}