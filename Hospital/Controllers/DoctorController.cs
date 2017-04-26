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

        public ActionResult obtenerDoctorEspecialidades(int id = 0)
        {
            Entities model = new Entities();
            var datos = (from de in model.DOCTOR_ESPECIALIDAD join e in model.ESPECIALIDAD on de.ID_ESPECIALIDAD equals e.ID where de.ID_DOCTOR == id && de.VISIBLE == true select new { ID = de.ID, ID_DOCTOR = de.ID_DOCTOR, ID_ESPECIALIDAD = de.ID_ESPECIALIDAD, NOMBRE = e.NOMBRE, VISIBLE = de.VISIBLE }).ToList();
            return Json(datos);
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
            model.SaveChanges();
            foreach (int id in especialidades)
            {
                DOCTOR_ESPECIALIDAD de = new DOCTOR_ESPECIALIDAD();
                de.ID_DOCTOR = doctor.ID;
                de.ID_ESPECIALIDAD = id;
                de.VISIBLE = true;
                model.DOCTOR_ESPECIALIDAD.Add(de);
            }
            model.SaveChanges();
            return Json(doctor);
        }

        public ActionResult modificarDoctor(int id, string nombre, string apellido, string cedula, DateTime fechaNacimiento, string sexo, string direccion, string telefono, bool visible, int[] doctorEspecialidades = null, bool[] visibleDoctorEspecialidades = null, int[] especialidades = null)
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
            if (doctorEspecialidades != null)
            {
                for (int iX = 0; iX < doctorEspecialidades.Length; iX++)
                {
                    int iDE = doctorEspecialidades[iX];
                    DOCTOR_ESPECIALIDAD doctorEspecialidad = (from de in model.DOCTOR_ESPECIALIDAD where de.ID == iDE select de).First();
                    doctorEspecialidad.VISIBLE = visibleDoctorEspecialidades[iX];
                }
            }
            if (especialidades != null)
            {
                foreach (int especialidad in especialidades)
                {
                    DOCTOR_ESPECIALIDAD doctorEspecialidad = new DOCTOR_ESPECIALIDAD();
                    try
                    {
                        doctorEspecialidad = (from de in model.DOCTOR_ESPECIALIDAD where de.ID_DOCTOR == doctor.ID && de.ID_ESPECIALIDAD == especialidad select de).First();
                    }
                    catch (Exception ex)
                    { }
                    doctorEspecialidad.ID_DOCTOR = doctor.ID;
                    doctorEspecialidad.ID_ESPECIALIDAD = especialidad;
                    doctorEspecialidad.VISIBLE = true;
                    if (doctorEspecialidad.ID == 0)
                    {
                        model.DOCTOR_ESPECIALIDAD.Add(doctorEspecialidad);
                    }
                }
            }
            model.SaveChanges();
            return Json(doctor);
        }
    }
}