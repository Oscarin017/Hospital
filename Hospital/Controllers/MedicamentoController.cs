using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class MedicamentoController : Controller
    {
        // GET: Medicamento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult obtenerMedicamento(int id)
        {
            Entities model = new Entities();
            var dato = (from m in model.MEDICAMENTO where m.ID == id select m).First();
            return Json(dato);
        }

        public ActionResult obtenerMedicamentos(string nombre)
        {
            Entities model = new Entities();
            if (nombre == "")
            {
                var datos = (from m in model.MEDICAMENTO where m.VISIBLE == true select m).ToList();
                return Json(datos);
            }
            else
            {
                var datos = (from m in model.MEDICAMENTO where m.NOMBRE.Contains(nombre) && m.VISIBLE == true select m).ToList();
                return Json(datos);
            }
        }

        public ActionResult agregarMedicamento(string nombre, string observaciones)
        {
            Entities model = new Entities();
            MEDICAMENTO medicamento = new MEDICAMENTO();
            medicamento.NOMBRE = nombre;
            medicamento.OBSERVACIONES = observaciones;
            medicamento.VISIBLE = true;
            model.MEDICAMENTO.Add(medicamento);
            model.SaveChanges();
            return Json(medicamento);
        }

        public ActionResult modificarMedicamento(int id, string nombre, string observaciones, bool visible)
        {
            Entities model = new Entities();
            var medicamento = (from m in model.MEDICAMENTO where m.ID == id select m).First();
            medicamento.NOMBRE = nombre;
            medicamento.OBSERVACIONES = observaciones;
            medicamento.VISIBLE = visible;
            model.SaveChanges();
            return Json(medicamento);
        }
    }
}