using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult obtenerDoctor(int id)
        {
            Entities model = new Entities();
            var dato = (from m in model.DOCTOR where m.ID == id select m).First();
            return Json(dato);
        }

        public ActionResult obtenerDoctores(string nombre)
        {
            Entities model = new Entities();
            if (nombre == "")
            {
                var datos = (from m in model.DOCTOR where m.VISIBLE == true select m).ToList();
                return Json(datos);
            }
            else
            {
                var datos = (from m in model.DOCTOR where m.NOMBRE.Contains(nombre) && m.VISIBLE == true select m).ToList();
                return Json(datos);
            }
        }

        public ActionResult agregarDoctor(string nombre, string apellido, string cedula, DateTime fechaNacimiento, string sexo, string direccion, string telefono, int[] especialidades)
        {
            Entities model = new Entities();
            DOCTOR doctor = new DOCTOR();
            doctor.NOMBRE = nombre;
            doctor.APELLIDO = apellido;
            doctor.CEDULA = cedula;
            doctor.FECHA_NACIMIENTO = fechaNacimiento;
            doctor.SEXO = sexo;
            doctor.DIRECCION = direccion;
            doctor.TELEFONO = telefono;
            doctor.VISIBLE = true;
            model.DOCTOR.Add(doctor);
            model.SaveChanges();
            return Json(doctor);
        }

        public ActionResult modificarDoctor(int id, string nombre, string apellido, string cedula, DateTime fechaNacimiento, string sexo, string direccion, string telefono, int[] especialidades, bool visible)
        {
            Entities model = new Entities();
            var doctor = (from m in model.DOCTOR where m.ID == id select m).First();
            doctor.NOMBRE = nombre;
            doctor.APELLIDO = apellido;
            doctor.CEDULA = cedula;
            doctor.FECHA_NACIMIENTO = fechaNacimiento;
            doctor.SEXO = sexo;
            doctor.DIRECCION = direccion;
            doctor.TELEFONO = telefono;
            doctor.VISIBLE = visible;
            model.SaveChanges();
            return Json(doctor);
        }
    }
}