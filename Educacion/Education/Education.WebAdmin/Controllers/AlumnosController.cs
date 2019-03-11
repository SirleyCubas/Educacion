using Education.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebAdmin.Controllers
{
    public class AlumnosController : Controller
    {
        AlumnosBL _alumnosBL;
        CategoriasBL _categoriasBL;

        public AlumnosController()
        {
            _alumnosBL = new AlumnosBL();
            _categoriasBL = new CategoriasBL();
        }


        // GET: Alumnos
        public ActionResult Index()
        {
            var listadeAlumnos = _alumnosBL.ObtenerAlumnos();
            return View(listadeAlumnos);
        }
        public ActionResult Crear()
        {
           var nuevoAlumno = new Alumno();
            var Categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(Categorias, "Id", "Descripcion");
            new SelectList(Categorias,"ID","Descripcion");

            return View(nuevoAlumno);
        }


        [HttpPost]
        public ActionResult Crear(Alumno alumno, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (alumno.CategoriaId==0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(alumno);
                }

                if (imagen != null)
                {
                    alumno.UrlImagen = GuardarImagen(imagen);
                }

                _alumnosBL.GuardarAlumno(alumno);
                return RedirectToAction("Index");
            }
            var Categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(Categorias, "Id", "Descripcion");
            new SelectList(Categorias, "ID", "Descripcion");

            return View(alumno);
        }

        public ActionResult Editar(int id)
        {
           var alumno = _alumnosBL.ObtenerAlumno(id);
            var categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId =
                new SelectList(categorias, "Id", "Descripcion", alumno.CategoriaId);
            return View(alumno);
        }

        [HttpPost]
        public ActionResult Editar(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                if (alumno.CategoriaId == 0)
                {
                    ModelState.AddModelError("CategoriaId", "Seleccione una Categoria");
                    return View(alumno);
                }
                _alumnosBL.GuardarAlumno(alumno);
                return RedirectToAction("Index");
            }
            var Categorias = _categoriasBL.ObtenerCategorias();

            ViewBag.CategoriaId = new SelectList(Categorias, "Id", "Descripcion");
            new SelectList(Categorias, "ID", "Descripcion");

            return View(alumno);
        }

        public ActionResult Detalle(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);
            return View(alumno);
        }

        public ActionResult Eliminar(int id)
        {
            var alumno = _alumnosBL.ObtenerAlumno(id);
            

            return View(alumno);
        }

        [HttpPost]
        public ActionResult Eliminar(Alumno alumno)
        {
            _alumnosBL.EliminarAlumno(alumno.Id);
            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);
            return "/Imagenes/" + imagen.FileName;
        }

       
    }
}