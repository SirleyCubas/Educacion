using System;
using System.Collections.Generic;
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
        public string NombreAlumno { get; set; }
        public double RTN { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public bool Activo { get; set; }
    }

    
}
