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
            //InscripcionContext DB = new InscripcionContext();
            using (var db = new InscripcionContext()) // con el Using se evita dejar conexiones a la Bd abiertas
            {
                return View(db.Estudiante.ToList());
            }
            //List<Estudiante> listEstudiante = DB.Estudiante.Where(a => a.edad > 18).ToList();
            //List<Estudiante> listEstudiante = DB.Estudiante.ToList();
            
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
    }
}