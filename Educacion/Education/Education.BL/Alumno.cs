using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.BL
{
    public class Alumno
    {
        public Alumno()
        {
            Activo = true;
        }
        
        public int Id { get; set; }

        [Display(Name = "NombreAlumno")]
        [Required(ErrorMessage = "Ingrese el Nombre")]
        [MinLength(6,ErrorMessage ="Ingrese por lo minimo 6 caracteres")]
        [MaxLength(8,ErrorMessage ="Ingrese como maximo 8 caracteres")]
        public string NombreAlumno { get; set; }

        [Required(ErrorMessage ="Ingrese su identificacion nacional")]
        
        public double RTN { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Display(Name ="Imagen")]
        public string UrlImagen { get; set; }
        public bool Activo { get; set; }
    }
        
}
