using InscripcionSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InscripcionSolution.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                //InscripcionContext DB = new InscripcionContext();
                using (var db = new InscripcionContext()) // con el Using se evita dejar conexiones a la Bd abiertas
                {

                    List<Estudiante> listEstudiante = db.Estudiante.Where(a => a.Edad > 18).ToList();

                    //List<Estudiante> listEstudiante = DB.Estudiante.ToList();
                    //return View(listEstudiante);
                    return View(db.Estudiante.ToList());
                }
                
                
            }
            catch (Exception)
            {

                throw;
            }
            
            
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiante e)
        {
            if(!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new InscripcionContext())
                {
                    e.FechaNacimiento = DateTime.Now;
                    db.Estudiante.Add(e);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al Intentar Registrar al Alumno Nuevo - " + ex.Message);
                return View();
            }
            
        }

        [HttpGet]
        public  ActionResult Editar(int id)
        {
            try
            {
                using (var db = new InscripcionContext())
                {                   
                    Estudiante est = db.Estudiante.Find(id);
                    return View(est);
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Estudiante e)
        {
            try
            {
                if (!ModelState.IsValid)
                        return View();
                
                using (var db = new InscripcionContext())
                {
                    Estudiante est = db.Estudiante.Find(e.Id);
                    est.Nombre = e.Nombre;
                    est.Apellido = e.Apellido;
                    est.Edad = e.Edad;
                    est.Sexo = e.Sexo;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpGet]
        public  ActionResult Detalles(int id)
        {
            if (!ModelState.IsValid)
                return View();

            
            try
            {
                using (var db = new InscripcionContext())
                {
                    Estudiante est = db.Estudiante.Find(id);
                    return View(est);
                }
            }
            catch (Exception ex)
            {

                throw;
            }            
            
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                using (var db = new InscripcionContext())
                {
                    Estudiante est = db.Estudiante.Find(id);
                    db.Estudiante.Remove(est);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}