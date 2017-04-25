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

        public ActionResult obtenerDoctor(int id = 0)
        {
            Entities model = new Entities();
            var dato = (from d in model.DOCTOR where d.ID == id select d).First();
            return Json(dato);
        }

        public ActionResult obtenerEspecialidadesDoctor(int id = 0)
        {
            Entities model = new Entities();
            var datos = (from de in model.DOCTOR_ESPECIALIDAD where de.ID_DOCTOR == id && de.VISIBLE == true select de).ToList();
            return Json(datos);
        }

        public ActionResult obtenerEspecialidad(int id = 0)
        {
            Entities model = new Entities();
            var dato = (from e in model.ESPECIALIDAD where e.ID == id select e).ToList();
            return Json(dato);
        }

        public ActionResult obtenerDoctores(string nombre = "", string apellido = "", string sexo = "0", int especialidad = 0)
        {
            Entities model = new Entities();
            List<DOCTOR> datos = new List<DOCTOR>();
            if (nombre == "" && apellido == "" && sexo == "0" && especialidad == 0)
            {
                datos = (from d in model.DOCTOR where d.VISIBLE == true select d).ToList();
            }
            else
            {
                if (nombre != "")
                {
                    datos = (from d in model.DOCTOR where d.NOMBRE.Contains(nombre) && d.VISIBLE == true select d).ToList();
                }
                if (apellido != "")
                {
                    if (datos.Count == 0)
                    {
                        datos = (from d in model.DOCTOR where d.NOMBRE.Contains(apellido) && d.VISIBLE == true select d).ToList();
                    }
                    else
                    {
                        datos = datos.Where(doctor => doctor.APELLIDO.Contains(apellido)).ToList();
                    }
                }
                if (sexo != "0")
                {
                    if (datos.Count == 0)
                    {
                        datos = (from d in model.DOCTOR where d.SEXO == sexo && d.VISIBLE == true select d).ToList();
                    }
                    else
                    {
                        datos = datos.Where(doctor => doctor.SEXO == sexo).ToList();
                    }
                }
                if (especialidad != 0)
                {
                    if (datos.Count == 0)
                    {

                        datos = (from de in model.DOCTOR_ESPECIALIDAD join doctor in model.DOCTOR on de.ID_DOCTOR equals doctor.ID where de.ID_ESPECIALIDAD == especialidad select doctor).ToList();
                    }
                    else
                    {
                        datos = (from de in model.DOCTOR_ESPECIALIDAD join doctor in datos on de.ID_DOCTOR equals doctor.ID where de.ID_ESPECIALIDAD == especialidad select doctor).ToList();
                    }
                }
            }
            return Json(datos);

        }

        public ActionResult obtenerEspecialidades(string nombre)
        {
            Entities model = new Entities();
            List<ESPECIALIDAD> datos = new List<ESPECIALIDAD>();
            if (nombre == "")
            {
                datos = (from e in model.ESPECIALIDAD where e.VISIBLE == true select e).ToList();
            }
            else
            {
                datos = (from e in model.ESPECIALIDAD where e.NOMBRE.Contains(nombre) && e.VISIBLE == true select e).ToList();
            }

            return Json(datos);
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
            foreach (int i in especialidades)
            {
                DOCTOR_ESPECIALIDAD de = new DOCTOR_ESPECIALIDAD();
                ESPECIALIDAD especialidad = (from e in model.ESPECIALIDAD where e.ID == i select e).First();
                de.ID_DOCTOR = doctor.ID;
                de.ID_ESPECIALIDAD = especialidad.ID;
                de.VISIBLE = true;
                model.DOCTOR_ESPECIALIDAD.Add(de);
            }
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