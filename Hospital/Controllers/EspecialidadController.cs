using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class EspecialidadController : Controller
    {
        // GET: Especialidad
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult obtenerEspecialidad(int id = 0)
        {
            Entities model = new Entities();
            var dato = (from e in model.ESPECIALIDAD where e.ID == id select e).First();
            return Json(dato);
        }

        public ActionResult obtenerEspecialidades(string nombre = "")
        {
            Entities model = new Entities();
            if (nombre == "")
            {
                var datos = (from e in model.ESPECIALIDAD where e.VISIBLE == true select e).ToList();
                return Json(datos);
            }
            else
            {
                var datos = (from e in model.ESPECIALIDAD where e.NOMBRE.Contains(nombre) && e.VISIBLE == true select e).ToList();
                return Json(datos);
            }
        }

        public ActionResult agregarEspecialidad(string nombre)
        {
            Entities model = new Entities();
            ESPECIALIDAD especialidad = new ESPECIALIDAD();
            especialidad.NOMBRE = nombre;
            especialidad.VISIBLE = true;
            model.ESPECIALIDAD.Add(especialidad);
            model.SaveChanges();
            return Json(especialidad);
        }

        public ActionResult modificarEspecialidad(int id, string nombre, bool visible)
        {
            Entities model = new Entities();
            var especialidad = (from e in model.ESPECIALIDAD where e.ID == id select e).First();
            especialidad.NOMBRE = nombre;
            especialidad.VISIBLE = visible;
            model.SaveChanges();
            return Json(especialidad);
        }
    }
}