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

namespace InterfazPrueba.Views.UIMorosidad
{
    public class MorosidadesController : Controller
    {
       LogicaCrudMorosidad LogicaCrudMorosidad = new LogicaCrudMorosidad();
        LogicaCacheEstudiantes logicaCacheEstudiantes = new LogicaCacheEstudiantes();
        logicaCacheMorosidades logicaCacheMorosidades = new logicaCacheMorosidades();

        // GET: Morosidads
        public ActionResult Index(EstudiantesMorosidadesVM EMVM, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 100; // Cantidad de elementos por página

            // Suponiendo que LogicaCrudMorosidad.ListarMorosidades() devuelve una lista o puede ser convertida a IQueryable
            var morosidadesList = logicaCacheMorosidades.ListarMorosidadesCache();

            // Obtener todos los IDs de estudiante únicos de las morosidades
            var idsEstudiantes = morosidadesList.Select(m => m.id_estudiante).Distinct().ToList();

            // Obtener todos los estudiantes asociados a estos IDs
            var estudiantesDict = logicaCacheEstudiantes.ListarCacheEstudiantePorIds(idsEstudiantes)
                .ToDictionary(est => est.ci_estudiante);

            // Asignar estudiantes a cada morosidad
            foreach (var morosidad in morosidadesList)
            {
                if (estudiantesDict.TryGetValue(morosidad.id_estudiante, out var estudiante))
                {
                    morosidad.Estudiantes = estudiante;
                }
            }


            /*foreach (var morosidad in morosidadesList)
            {
                morosidad.Estudiantes = logicaCacheEstudiantes.ListarCacheEstudiantePorId(morosidad.id_estudiante);
            }*/

            if (!string.IsNullOrEmpty(EMVM.NombreEstudianteBuscado))
            {
                morosidadesList = morosidadesList.Where(e => e.Estudiantes != null && e.Estudiantes.nombre.Contains(EMVM.NombreEstudianteBuscado)).ToList();
            }

            // Convertir la lista a una versión paginada
            var morosidadesPaged = morosidadesList.ToPagedList(pageNumber, pageSize);


            // Crear el ViewModel
            var viewModel = new EstudiantesMorosidadesVM
            {
                Morosidades = morosidadesPaged
                // Asigna otras propiedades si es necesario
            };

            return View(viewModel);
        }

        // GET: Morosidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morosidad morosidad = logicaCacheMorosidades.ListarCacheMorosidadPorId(id.Value);
            if (morosidad == null)
            {
                return HttpNotFound();
            }
            return View(morosidad);
        }

        // GET: Morosidads/Create
        public ActionResult Create()
        {
            ViewData["EstudianteIDMorosidad"] = new SelectList(logicaCacheEstudiantes.ListarEstudiantesCache(), "ci_estudiante", "nombre");
            ViewBag.SemestreMorosidad = new SelectList(new List<string> { "2023A", "2023B" });
            return View();
        }

        // POST: Morosidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,semestre,dias_retraso,monto_debido")] Morosidad morosidad)
        {
            if (ModelState.IsValid)
            {
                LogicaCrudMorosidad.insertarMorosidad(morosidad);
                logicaCacheMorosidades.ActualizarMorosidadesCache();
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
            Morosidad morosidad = logicaCacheMorosidades.ListarCacheMorosidadPorId(id.Value);
            if (morosidad == null)
            {
                return HttpNotFound();
            }
            ViewData["EstudianteIDMorosidadMod"] = new SelectList(logicaCacheEstudiantes.ListarEstudiantesCache(), "id_estudiante", "nombre", morosidad.id_estudiante);
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
                logicaCacheMorosidades.ActualizarMorosidadesCache();
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
            Morosidad morosidad = logicaCacheMorosidades.ListarCacheMorosidadPorId(id.Value);
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
            logicaCacheMorosidades.ActualizarMorosidadesCache();
            return RedirectToAction("Index");
        }

    }
}
