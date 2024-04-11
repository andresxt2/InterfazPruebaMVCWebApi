using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterfazPrueba.Data;
using InterfazPrueba.Logica;
using InterfazPrueba.Models;
using PagedList;

namespace InterfazPrueba.Views.UIEstudiantes
{
    public class EstudiantesController : Controller
    {
        LogicaCRUD logicaEstudiantes = new LogicaCRUD();
        LogicaCacheEstudiantes logicaCacheEstudiantes = new LogicaCacheEstudiantes();


        // GET: Estudiantes
        public ActionResult Index(int? page, string cedula, string nombre)
        {
            int pageSize = 100;
            int pageNumber = (page ?? 1);

            // Filtra los estudiantes por cédula si se proporciona un valor
            var estudiantesQuery = logicaCacheEstudiantes.ListarEstudiantesCache();

            if (!string.IsNullOrEmpty(cedula))
            {
                estudiantesQuery = estudiantesQuery.Where(e => e.ci_estudiante.Contains(cedula)).ToList();
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                estudiantesQuery = estudiantesQuery.Where(e => e.nombre.Contains(nombre)).ToList();
            }

            var estudiantes = estudiantesQuery.ToPagedList(pageNumber, pageSize);

            return View(estudiantes);
        }


        // GET: Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = logicaEstudiantes.BuscarEstudiante(id.Value);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            ViewBag.ProgramaAcademicoOptions = new SelectList(new List<string> { "Grado", "Posgrado", "Tecnologias" });
            ViewBag.EstadoMatriculaOptions = new SelectList(new List<string> { "Inactivo", "Activo", "Graduado" });
            return View();
        }

        // POST: Estudiantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,ci_estudiante,nombre,correo_electronico,programa_academico,estado_matricula")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                logicaEstudiantes.crearEstudiante(estudiante);
                logicaCacheEstudiantes.ActualizarEstudiantesCache();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = logicaEstudiantes.BuscarEstudiante(id.Value);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProgramaAcademicoOptions = new SelectList(new List<string> { "Grado", "Posgrado", "Tecnologias" }, estudiante.programa_academico);
            ViewBag.EstadoMatriculaOptions = new SelectList(new List<string> { "Inactivo", "Activo", "Graduado" }, estudiante.estado_matricula);

            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_estudiante,ci_estudiante,nombre,correo_electronico,programa_academico,estado_matricula")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                /*
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();*/
                logicaEstudiantes.actualizarEstudiante(estudiante);
                logicaCacheEstudiantes.ActualizarEstudiantesCache();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = logicaEstudiantes.BuscarEstudiante(id.Value);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            logicaEstudiantes.EliminarEstudiante(id);
            logicaCacheEstudiantes.ActualizarEstudiantesCache();
            return RedirectToAction("Index");
        }

        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
