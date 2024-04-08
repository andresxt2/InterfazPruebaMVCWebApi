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

namespace InterfazPrueba.Views.UIBecas
{
    public class Becas_Ayudas_FinancierasController : Controller
    {
        private InterfazPruebaContext db = new InterfazPruebaContext();
        logicaCRUDBecas logicaCRUDBecas = new logicaCRUDBecas();
        LogicaCRUD logicaEstudiantes = new LogicaCRUD();

        // GET: Becas_Ayudas_Financieras
        public ActionResult Index(EstudiantesBecasVM EBVM)
        {
          //  IQueryable<string> EstudianteQuery = (IQueryable<string>)logicaEstudiantes.ListarEstudiantes().OrderBy(m => m.nombre).Select(m => m.nombre);
         //   EBVM.Estudiantes = new SelectList(EstudianteQuery.Distinct().ToList());
            EBVM.Becas = logicaCRUDBecas.ListarBecas();

            //List<Estudiante> estudiantes = new List<Estudiante>();

            foreach (var item in EBVM.Becas)
            {
                item.Estudiantes = logicaEstudiantes.BuscarEstudiante(item.id_estudiante);
            }

            return View(EBVM);
        }

        // GET: Becas_Ayudas_Financieras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becas_Ayudas_Financieras becas_Ayudas_Financieras = db.Becas_Ayudas_Financieras.Find(id);
            if (becas_Ayudas_Financieras == null)
            {
                return HttpNotFound();
            }
            return View(becas_Ayudas_Financieras);
        }

        // GET: Becas_Ayudas_Financieras/Create
        public ActionResult Create()
        {
            ViewData["EstudianteID"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre");
            return View();
        }

        // POST: Becas_Ayudas_Financieras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,tipo_beca,monto,semestre")] Becas_Ayudas_Financieras becas_Ayudas_Financieras)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Revisa los mensajes de error para ver qué validaciones están fallando
                    Console.WriteLine(error.ErrorMessage);
                }
                // Considera también inspeccionar el valor de 'becas_Ayudas_Financieras' aquí
            }


            if (ModelState.IsValid)
            {
                logicaCRUDBecas.insertarBeca(becas_Ayudas_Financieras);
                return RedirectToAction("Index");
            }
            ViewData["EstudianteID"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre", becas_Ayudas_Financieras.id_estudiante);
            return View(becas_Ayudas_Financieras);
        }

        // GET: Becas_Ayudas_Financieras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becas_Ayudas_Financieras becas_Ayudas_Financieras = db.Becas_Ayudas_Financieras.Find(id);
            if (becas_Ayudas_Financieras == null)
            {
                return HttpNotFound();
            }
            return View(becas_Ayudas_Financieras);
        }

        // POST: Becas_Ayudas_Financieras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_beca,id_estudiante,tipo_beca,monto,semestre,borrado_logico,fecha_borrado_logico,Estudiantes")] Becas_Ayudas_Financieras becas_Ayudas_Financieras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(becas_Ayudas_Financieras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(becas_Ayudas_Financieras);
        }

        // GET: Becas_Ayudas_Financieras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becas_Ayudas_Financieras becas_Ayudas_Financieras = db.Becas_Ayudas_Financieras.Find(id);
            if (becas_Ayudas_Financieras == null)
            {
                return HttpNotFound();
            }
            return View(becas_Ayudas_Financieras);
        }

        // POST: Becas_Ayudas_Financieras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Becas_Ayudas_Financieras becas_Ayudas_Financieras = db.Becas_Ayudas_Financieras.Find(id);
            db.Becas_Ayudas_Financieras.Remove(becas_Ayudas_Financieras);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
