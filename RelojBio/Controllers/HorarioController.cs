using RelojBio.Models;
using RelojBio.ViewModel;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace RelojBio.Controllers
{
    public class HorarioController : Controller
    {
        // GET: Horario
        [HttpGet]
        public ActionResult Index()
        {

            using (RELOJBIOEntities wdb = new RELOJBIOEntities())
            {
                var ListHorarios = wdb.Shift.OrderByDescending(a => a.ShiftID).ToList();

                return View(ListHorarios);
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
                    var ListTipo = wdb.ShiftType.ToList();
                    var ListDescanso = wdb.Break.ToList();

                    var OVMHorario = new HorarioViewModel
                    {
                        ListaTipo = new SelectList(ListTipo, "ShiftTypeID", "Description"),
                        ListaDescanso = ListDescanso

                    };
                    return View(OVMHorario);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;
                return RedirectToAction("Index", "Horario");

            }

        }


        [HttpPost]
        public ActionResult Create(HorarioViewModel Omodelo)
        {

            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {

                    var OUltimoHorario = wdb.Shift.OrderByDescending(a => a.ShiftID).FirstOrDefault();
                    int wId = OUltimoHorario.ShiftID + 1;

                    var OHorario = new Shift
                    {
                        ShiftID = wId,
                        Code = Omodelo.Code,
                        Name = Omodelo.Name,
                        ShiftTypeID = Omodelo.ShiftTypeID,
                        Color = Omodelo.Color,
                        Flexible = Omodelo.Flexible,
                        Start = Omodelo.Start,
                        End = Omodelo.End,
                        RangeStartIni = Omodelo.RangeStartIni,
                        RangeStartFin = Omodelo.RangeStartFin,
                        RangeEndIni = Omodelo.RangeEndIni,
                        RangeEndFin = Omodelo.RangeEndFin,
                        AllowBefore = Omodelo.AllowBefore,
                        BeforeStart = Omodelo.BeforeStart,
                        AfterEnd = Omodelo.AfterEnd,
                        AllowAfter = Omodelo.AllowAfter,
                        Late = Omodelo.Late,
                        LateCome = Omodelo.LateCome,
                        Early = Omodelo.Early,
                        EarlyOut = Omodelo.EarlyOut,
                        EarlyCome = Omodelo.EarlyCome,

                    };
                    wdb.Shift.Add(OHorario);
                    wdb.SaveChanges();

                    foreach (var item in Omodelo.ListDescansoCodigoSeleccionados)
                    {
                        var OExiste = wdb.BreakShift.Where(a => a.ShiftID == OHorario.ShiftID && a.BreakID == item).FirstOrDefault();
                        if (OExiste == null)
                        {
                            var OUltimoHorarioDescanso = wdb.BreakShift.OrderByDescending(a => a.BreakShiftID).FirstOrDefault();
                            int wID = OUltimoHorarioDescanso.BreakShiftID + 1;

                            var OHorarioDescanso = new BreakShift
                            {
                                BreakShiftID = wID,
                                ShiftID = wId,
                                BreakID = item

                            };
                            wdb.BreakShift.Add(OHorarioDescanso);
                            wdb.SaveChanges();

                        }
                    }


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Horario Creado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Horario");
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
                    var OHorario = wdb.Shift.Where(a => a.ShiftID == Id).FirstOrDefault();

                    var ListTipo = wdb.ShiftType.ToList();
                    var ListDescanso = wdb.Break.ToList();
                    var ListDescansoSeleccionada = wdb.BreakShift.ToList();

                    var OVMHorario = new HorarioViewModel
                    {
                        ShiftID = OHorario.ShiftID,
                        Code = OHorario.Code,
                        Name = OHorario.Name,
                        ShiftTypeID = OHorario.ShiftTypeID,
                        Color = OHorario.Color,
                        Flexible = OHorario.Flexible,
                        Start = OHorario.Start,
                        End = OHorario.End,
                        RangeStartIni = OHorario.RangeStartIni,
                        RangeStartFin = OHorario.RangeStartFin,
                        RangeEndIni = OHorario.RangeEndIni,
                        RangeEndFin = OHorario.RangeEndFin,
                        AllowBefore = Convert.ToBoolean(OHorario.AllowBefore ?? false),
                        BeforeStart = OHorario.BeforeStart,
                        AfterEnd = OHorario.AfterEnd,
                        AllowAfter = Convert.ToBoolean(OHorario.AllowAfter ?? false),
                        Late = Convert.ToBoolean(OHorario.Late ?? false),
                        LateCome = OHorario.LateCome,
                        Early = Convert.ToBoolean(OHorario.Early ?? false),
                        EarlyOut = OHorario.EarlyOut,
                        EarlyCome = OHorario.EarlyCome,
                        ListaTipo = new SelectList(ListTipo, "ShiftTypeID", "Description"),
                        ListaDescanso = ListDescanso,
                        ListDescansoSeleccionados = ListDescansoSeleccionada

                    };




                    return View(OVMHorario);
                }

            }
            catch (Exception e)
            {
                OMensaje.Tipo = "Error";
                OMensaje.Msg = e.ToString();
                Session["Mensaje"] = OMensaje;

                return RedirectToAction("Index", "Horario");

            }


        }


        [HttpPost]
        public ActionResult Edit(HorarioViewModel Omodelo)
        {
            var OMensaje = new Mensaje();

            try
            {
                using (RELOJBIOEntities wdb = new RELOJBIOEntities())
                {
                    var OHorario = wdb.Shift.Where(a => a.ShiftID == Omodelo.ShiftID).FirstOrDefault();

                    OHorario.Code = Omodelo.Code;
                    OHorario.Name = Omodelo.Name;
                    OHorario.ShiftTypeID = Omodelo.ShiftTypeID;
                    OHorario.Color = Omodelo.Color;
                    OHorario.Flexible = Omodelo.Flexible;
                    OHorario.Start = Omodelo.Start;
                    OHorario.End = Omodelo.End;
                    OHorario.RangeStartIni = Omodelo.RangeStartIni;
                    OHorario.RangeStartFin = Omodelo.RangeStartFin;
                    OHorario.RangeEndIni = Omodelo.RangeEndIni;
                    OHorario.RangeEndFin = Omodelo.RangeEndFin;
                    OHorario.AllowBefore = Omodelo.AllowBefore;
                    OHorario.BeforeStart = Omodelo.BeforeStart;
                    OHorario.AfterEnd = Omodelo.AfterEnd;
                    OHorario.AllowAfter = Omodelo.AllowAfter;
                    OHorario.Late = Omodelo.Late;
                    OHorario.LateCome = Omodelo.LateCome;
                    OHorario.Early = Omodelo.Early;
                    OHorario.EarlyOut = Omodelo.EarlyOut;
                    OHorario.EarlyCome = Omodelo.EarlyCome;


                    wdb.Entry(OHorario).State = EntityState.Modified;
                    wdb.SaveChanges();

                    foreach (var item in Omodelo.ListDescansoCodigoSeleccionados)
                    {
                        var OExiste = wdb.BreakShift.Where(a => a.ShiftID == OHorario.ShiftID && a.BreakID == item).FirstOrDefault();
                        if (OExiste == null)
                        {
                            var OUltimoHorarioDescanso = wdb.BreakShift.OrderByDescending(a => a.BreakShiftID).FirstOrDefault();
                            int wID = OUltimoHorarioDescanso.BreakShiftID + 1;

                            var OHorarioDescanso = new BreakShift
                            {
                                BreakShiftID = wID,
                                ShiftID = OHorario.ShiftID,
                                BreakID = item

                            };
                            wdb.BreakShift.Add(OHorarioDescanso);
                            wdb.SaveChanges();

                        }
                    }

                    var ListEliminarDescansosHorarios = wdb.BreakShift.Where(a => a.ShiftID == Omodelo.ShiftID && !Omodelo.ListDescansoCodigoSeleccionados.Any(w => a.BreakID == w)).ToList();

                    foreach (var item in ListEliminarDescansosHorarios)
                    {
                        wdb.BreakShift.Remove(item);
                        wdb.SaveChanges();
                    }



                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "El Horario Fue Modificado con exito";
                    Session["Mensaje"] = OMensaje;

                    return RedirectToAction("Index", "Horario");
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
                    var oHorario = wdb.Shift.Where(a => a.ShiftID == Id).FirstOrDefault();

                    var ListHorarioDescanso = wdb.BreakShift.Where(a => a.ShiftID == Id).ToList();

                    foreach (var item in ListHorarioDescanso)
                    {
                        var OHorarioDescanso = wdb.BreakShift.Where(a => a.BreakShiftID == item.BreakShiftID).FirstOrDefault();
                        wdb.BreakShift.Remove(OHorarioDescanso);
                        wdb.SaveChanges();
                    }


                    wdb.Shift.Remove(oHorario);
                    wdb.SaveChanges();


                    OMensaje.Tipo = "Exito";
                    OMensaje.Msg = "Horario Eliminado con exito";
                    Session["Mensaje"] = OMensaje;
                    return RedirectToAction("Index", "Horario");

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
                return RedirectToAction("Index", "Horario");

            }
        }

    }
}