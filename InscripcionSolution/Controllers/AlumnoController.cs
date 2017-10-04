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
            InscripcionContext DB = new InscripcionContext();
            //List<Estudiante> listEstudiante = DB.Estudiante.Where(a => a.edad > 18).ToList();
            List<Estudiante> listEstudiante = DB.Estudiante.ToList();
            return View(listEstudiante);
        }
    }
}