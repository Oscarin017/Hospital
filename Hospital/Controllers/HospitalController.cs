using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class HospitalController : Controller
    {
        // GET: Hospital
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult obtenerHospital(int id)
        {
            Entities model = new Entities();
            var dato = (from h in model.HOSPITAL where h.ID == id select h).First();
            return Json(dato);
        }

        public ActionResult obtenerHospitales(string nombre)
        {
            Entities model = new Entities();
            if (nombre == "")
            {
                var datos = (from h in model.HOSPITAL where h.VISIBLE == true select h).ToList();
                return Json(datos);
            }
            else
            {
                var datos = (from h in model.HOSPITAL where h.NOMBRE.Contains(nombre) && h.VISIBLE == true select h).ToList();
                return Json(datos);
            }
        }

        public ActionResult agregarHospital(string nombre, string direccion)
        {
            Entities model = new Entities();
            HOSPITAL hospital = new HOSPITAL();
            hospital.NOMBRE = nombre;
            hospital.DIRECCION = direccion;
            hospital.VISIBLE = true;
            model.HOSPITAL.Add(hospital);
            model.SaveChanges();
            return Json(hospital);
        }

        public ActionResult modificarHospital(int id, string nombre, string direccion, bool visible)
        {
            Entities model = new Entities();
            var hospital = (from m in model.HOSPITAL where m.ID == id select m).First();
            hospital.NOMBRE = nombre;
            hospital.DIRECCION = direccion;
            hospital.VISIBLE = visible;
            model.SaveChanges();
            return Json(hospital);
        }
    }
}