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
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult obtenerPaciente(int id = 0)
        {
            Entities model = new Entities();
            var dato = (from m in model.PACIENTE where m.ID == id select m).First();
            return Json(dato);
        }

        public ActionResult obtenerPacientes(string nombre = "", string apellido = "")
        {
            Entities model = new Entities();
            List<PACIENTE> datos = new List<PACIENTE>();
            if (nombre == "" && apellido == "")
            {
                datos = (from p in model.PACIENTE where p.VISIBLE == true select p).ToList();
            }
            else
            {
                if (nombre != "")
                {
                    datos = (from p in model.PACIENTE where p.NOMBRE.Contains(nombre) && p.VISIBLE == true select p).ToList();
                }
                if (apellido != "")
                {
                    if (datos.Count == 0)
                    {
                        datos = (from p in model.PACIENTE where p.NOMBRE.Contains(apellido) && p.VISIBLE == true select p).ToList();
                    }
                    else
                    {
                        datos = datos.Where(paciente => paciente.APELLIDO.Contains(apellido)).ToList();
                    }
                }
            }
            return Json(datos);
        }

        public ActionResult agregarPaciente(string nombre, string apellido, string fechaNacimiento, string sexo, string direccion, string telefono, string correo)
        {
            Entities model = new Entities();
            PACIENTE paciente = new PACIENTE();
            paciente.NOMBRE = nombre;
            paciente.APELLIDO = apellido;
            paciente.FECHA_NACIMIENTO = Convert.ToDateTime(fechaNacimiento);
            paciente.SEXO = sexo;
            paciente.DIRECCION = direccion;
            paciente.TELEFONO = telefono;
            paciente.CORREO_ELECTRONICO = correo;
            paciente.VISIBLE = true;
            model.PACIENTE.Add(paciente);
            model.SaveChanges();
            return Json(paciente);
        }

        public ActionResult modificarPaciente(int id, string nombre, string apellido, string fechaNacimiento, string sexo, string direccion, string telefono, string correo, bool visible)
        {
            Entities model = new Entities();
            var paciente = (from m in model.PACIENTE where m.ID == id select m).First();
            paciente.NOMBRE = nombre;
            paciente.APELLIDO = apellido;
            paciente.FECHA_NACIMIENTO = Convert.ToDateTime(fechaNacimiento);
            paciente.SEXO = sexo;
            paciente.DIRECCION = direccion;
            paciente.TELEFONO = telefono;
            paciente.CORREO_ELECTRONICO = correo;
            paciente.VISIBLE = visible;
            model.SaveChanges();
            return Json(paciente);
        }
    }
}