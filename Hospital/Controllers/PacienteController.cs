using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class PacienteController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult obtenerPaciente(int id)
        {
            Entities model = new Entities();
            var dato = (from m in model.PACIENTE where m.ID == id select m).First();
            return Json(dato);
        }

        public ActionResult obtenerPacientes(int id = 0)
        {
            Entities model = new Entities();
            if (id == 0)
            {
                var datos = (from m in model.PACIENTE where m.VISIBLE == true select m).ToList();
                return Json(datos);
            }
            else
            {
                var datos = (from m in model.PACIENTE where m.ID == id && m.VISIBLE == true select m).ToList();
                return Json(datos);
            }
        }

        public ActionResult agregarPaciente(string nombre, string apellido, DateTime fechaNacimiento, string sexo, string direccion, string telefono, string correo)
        {
            Entities model = new Entities();
            PACIENTE paciente = new PACIENTE();
            paciente.NOMBRE = nombre;
            paciente.APELLIDO = apellido;
            paciente.CORREO_ELECTRONICO = correo;
            paciente.FECHA_NACIMIENTO = fechaNacimiento;
            paciente.SEXO = sexo;
            paciente.DIRECCION = direccion;
            paciente.TELEFONO = telefono;
            paciente.VISIBLE = true;
            model.PACIENTE.Add(paciente);
            model.SaveChanges();
            return Json(paciente);
        }

        public ActionResult modificarPaciente(int id, string nombre, string apellido, DateTime fechaNacimiento, string sexo, string direccion, string telefono, string correo, bool visible)
        {
            Entities model = new Entities();
            var paciente = (from m in model.PACIENTE where m.ID == id select m).First();
            paciente.NOMBRE = nombre;
            paciente.APELLIDO = apellido;
            paciente.CORREO_ELECTRONICO = correo;
            paciente.FECHA_NACIMIENTO = fechaNacimiento;
            paciente.SEXO = sexo;
            paciente.DIRECCION = direccion;
            paciente.TELEFONO = telefono;
            paciente.VISIBLE = visible;
            model.SaveChanges();
            return Json(paciente);
        }
    }
}