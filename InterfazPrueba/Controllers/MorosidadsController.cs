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

namespace InterfazPrueba.Views.UIMorosidad
{
    public class MorosidadsController : Controller
    {
        LogicaCrudMorosidad LogicaCrudMorosidad = new LogicaCrudMorosidad();
        LogicaCRUD logicaEstudiantes = new LogicaCRUD();

        // GET: Morosidads
        public ActionResult Index(EstudiantesMorosidadesVM EMVM)
        {
            //  IQueryable<string> EstudianteQuery = (IQueryable<string>)logicaEstudiantes.ListarEstudiantes().OrderBy(m => m.nombre).Select(m => m.nombre);
            //   EBVM.Estudiantes = new SelectList(EstudianteQuery.Distinct().ToList());
            EMVM.Morosidades = LogicaCrudMorosidad.ListarMorosidades();

            //List<Estudiante> estudiantes = new List<Estudiante>();

            foreach (var item in EMVM.Morosidades)
            {
                item.Estudiantes = logicaEstudiantes.BuscarEstudiante(item.id_estudiante);
            }

            return View(EMVM);
        }

        // GET: Morosidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morosidad morosidad = LogicaCrudMorosidad.MorosidadPorId(id.Value);
            if (morosidad == null)
            {
                return HttpNotFound();
            }
            return View(morosidad);
        }

        // GET: Morosidads/Create
        public ActionResult Create()
        {
            ViewData["EstudianteIDMorosidad"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre");
            ViewBag.SemestreMorosidad = new SelectList(new List<string> { "2023A", "2023B" });
            return View();
        }

        // POST: Morosidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,semestre,dias_retraso,monto_debido,Estudiantes")] Morosidad morosidad)
        {
            if (ModelState.IsValid)
            {
                LogicaCrudMorosidad.insertarMorosidad(morosidad);
                return RedirectToAction("Index");
            }
          
            return View(morosidad);
        }

        // GET: Morosidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morosidad morosidad = LogicaCrudMorosidad.MorosidadPorId(id.Value);
            if (morosidad == null)
            {
                return HttpNotFound();
            }
            ViewData["EstudianteIDMorosidadMod"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre", morosidad.id_estudiante);
            ViewBag.SemestreMorosidadMod = new SelectList(new List<string> { "2023A", "2023B" }, morosidad.semestre);
           // ViewData["Semestre"] = new SelectList(new List<string> { "2023A", "2023B" } , morosidad.semestre);

            return View(morosidad);
        }

        // POST: Morosidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_morosidad,id_estudiante,semestre,dias_retraso,monto_debido")] Morosidad morosidad)
        {
            if (ModelState.IsValid)
            {
                LogicaCrudMorosidad.actualizarMorosidad(morosidad);
                return RedirectToAction("Index");
            }
           /* ViewBag.Semestre = new SelectList(new List<string> { "2023A", "2023B" }, morosidad.semestre);
            ViewData["EstudianteID"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre", morosidad.id_estudiante);*/

            return View(morosidad);
        }

        // GET: Morosidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morosidad morosidad = LogicaCrudMorosidad.MorosidadPorId(id.Value);
            if (morosidad == null)
            {
                return HttpNotFound();
            }
            return View(morosidad);
        }

        // POST: Morosidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogicaCrudMorosidad.eliminarMorosidad(id);
            return RedirectToAction("Index");
        }

    }
}
