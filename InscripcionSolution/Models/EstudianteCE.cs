using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InscripcionSolution.Models
{
    public class EstudianteCE  //Clase Auxiliar para el manejo de Data Anotations
    {                           //hace referencia a una entidad del modelo creada por entity framework
        [Required]
        [Display(Name = "Digite el Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Digite los Apellidos")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Digite la Edad")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Digite el Sexo")]
        public string Sexo { get; set; }
      
    }

    [MetadataType(typeof(EstudianteCE))]    
    public partial class Estudiante //Clase parcial para añadir mas propiedades y manejo de consultas anidadas
    {                               // hace referencia a una entidad del modelo creada por entity framework
        public String NombreCompleto {get { return Nombre + " " + Apellido; } }
    }
}