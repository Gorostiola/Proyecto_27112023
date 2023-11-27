using BussUsuarios;
using EntityUsuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Personas.Controllers
{
    public class HomeController : Controller
    {
        BUsuarios Buss = new BUsuarios();

        // GET: Home
        public ActionResult Index()
        {

            try
            {
                List<EUsuarios> list = Buss.Obtener();
                return View(list);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View(new List<EUsuarios>());
            }
            
        }

        //Get
        public ActionResult Agregar()
        {
            return View();
        }


        [HttpPost] //Se ocupa SobreCarga, para que sepa cual es la vista y cual es el que va a mandar la informacion
        public ActionResult Agregar(EUsuarios us)
        {
            try
            {
                Buss.Agregar(us);
                TempData["mensaje"] = $"Se agrego correctamente {us.NombreCompleto}";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }



        //////////////
        public ActionResult Eliminar(int id)
        {
            try
            {
                EUsuarios eb = Buss.ObtenerId(id);
                Buss.Eliminar(eb);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }


        public ActionResult EditarGet(int id)
        {
            try
            {
                EUsuarios eb = Buss.ObtenerId(id);

                return View(eb);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult EditarPost(EUsuarios per)
        {
            try
            {
                Buss.Editar(per);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("EditarGet", per);

            }
        }


        public ActionResult Buscar(string valor)
        {
            try
            {
                List<EUsuarios> tabla = Buss.Buscar(valor);
                return View("Index", tabla);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index", new DataTable());
            }
        }






    }
}