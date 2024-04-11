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

namespace InterfazPrueba.Views.UIBecas
{
    public class Becas_Ayudas_FinancierasController : Controller
    {
        logicaCRUDBecas logicaCRUDBecas = new logicaCRUDBecas();
        LogicaCacheEstudiantes logicaCacheEstudiantes = new LogicaCacheEstudiantes();
        logicaCacheBecas logicaCacheBecas = new logicaCacheBecas();

        // GET: Becas_Ayudas_Financieras
        public ActionResult Index(EstudiantesBecasVM EBVM, int?page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 100; // Cantidad de elementos por página


            // Obtener la lista de becas de la lógica de negocio
            var becasList = logicaCacheBecas.ListarBecasCache().ToList();

            if (!string.IsNullOrEmpty(EBVM.TipoBecaSeleccionado))
            {
                becasList = becasList.Where(e => e.tipo_beca.Equals(EBVM.TipoBecaSeleccionado)).ToList();
            }

            // Obtener los IDs de los estudiantes asociados a las becas
            var idsEstudiantes = becasList.Select(beca => beca.id_estudiante).Distinct().ToList();

            // Obtener todos los estudiantes asociados a las becas en una sola consulta
            var estudiantesDict = logicaCacheEstudiantes.ListarCacheEstudiantePorIds(idsEstudiantes)
                .ToDictionary(estudiante => estudiante.id_estudiante);

            // Asignar los estudiantes correspondientes a las becas
            foreach (var beca in becasList)
            {
                Estudiante estudiante;
                if (estudiantesDict.TryGetValue(beca.id_estudiante, out estudiante))
                {
                    beca.Estudiantes = estudiante;
                }
            }

            /*
            foreach (var beca in becasList)
            {
                beca.Estudiantes = logicaCacheEstudiantes.ListarCacheEstudiantePorId(beca.id_estudiante);
            }*/

            if (!string.IsNullOrEmpty(EBVM.NombreEstudianteBuscado))
            {
                becasList = becasList.Where(e => e.Estudiantes != null && e.Estudiantes.nombre.Contains(EBVM.NombreEstudianteBuscado)).ToList();
            }

            // Paginar la lista de becas
            var becasPaged = becasList.ToPagedList(pageNumber, pageSize);

            // Crear el ViewModel y asignar la lista paginada de becas
            var viewModel = new EstudiantesBecasVM
            {
                Becas = becasPaged
                // Aquí puedes asignar otras propiedades si es necesario
            };

            return View(viewModel);

        }

        // GET: Becas_Ayudas_Financieras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becas_Ayudas_Financieras becas_Ayudas_Financieras = logicaCacheBecas.ListarCacheBecaPorId(id.Value);
            if (becas_Ayudas_Financieras == null)
            {
                return HttpNotFound();
            }
            return View(becas_Ayudas_Financieras);
        }

        // GET: Becas_Ayudas_Financieras/Create
        public ActionResult Create()
        {
            ViewData["EstudianteIDBecas"] = new SelectList(logicaCacheEstudiantes.ListarEstudiantesCache(), "id_estudiante", "nombre");
            // Preparando el ViewBag para tipo_beca
            ViewBag.TipoBecaEnBecas = new SelectList(new List<string> { "Necesidad", "Merito", "Investigacion" });

            // Preparando el ViewBag para semestre
            ViewBag.SemestreBecas = new SelectList(new List<string> { "2023A", "2023B" });
            return View();
        }

        // POST: Becas_Ayudas_Financieras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,tipo_beca,monto,semestre")] Becas_Ayudas_Financieras becas_Ayudas_Financieras)
        {
            if (ModelState.IsValid)
            {
                logicaCRUDBecas.insertarBeca(becas_Ayudas_Financieras);
                logicaCacheBecas.ActualizarBecasCache();
                return RedirectToAction("Index");
            }
            // Repetir la lógica de ViewBag en caso de retorno por validación fallida.
            /*ViewBag.TipoBecaEnBecas = new SelectList(new List<string> { "Necesidad", "Merito", "Investigacion" }, becas_Ayudas_Financieras.tipo_beca);
            ViewBag.SemestreBecas = new SelectList(new List<string> { "2023A", "2023B" }, becas_Ayudas_Financieras.semestre);
            ViewData["EstudianteID"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre", becas_Ayudas_Financieras.id_estudiante);*/
            return View(becas_Ayudas_Financieras);
        }

        // GET: Becas_Ayudas_Financieras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becas_Ayudas_Financieras becas_Ayudas_Financieras = logicaCacheBecas.ListarCacheBecaPorId(id.Value);
            if (becas_Ayudas_Financieras == null)
            {
                return HttpNotFound();
            }

            ViewBag.SemestreBecasMod = new SelectList(new List<string> { "2023A", "2023B" }, becas_Ayudas_Financieras.semestre);
            ViewBag.TipoBecaEnBecasMod = new SelectList(new List<string> { "Necesidad", "Merito", "Investigacion" }, becas_Ayudas_Financieras.tipo_beca);
            ViewData["EstudianteIDBecasMod"] = new SelectList(logicaCacheEstudiantes.ListarEstudiantesCache(), "id_estudiante", "nombre");
            return View(becas_Ayudas_Financieras);
        }

        // POST: Becas_Ayudas_Financieras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_beca,id_estudiante,tipo_beca,monto,semestre")] Becas_Ayudas_Financieras becas_Ayudas_Financieras)
        {
            if (ModelState.IsValid)
            {
                logicaCRUDBecas.actualizarBeca(becas_Ayudas_Financieras);
                logicaCacheBecas.ActualizarBecasCache();
                return RedirectToAction("Index");
            }
         //   ViewBag.TipoBeca = new SelectList(new List<string> { "Necesidad", "Merito", "Investigacion" },becas_Ayudas_Financieras.tipo_beca);

            // Preparando el ViewBag para semestre
           // ViewBag.Semestre = new SelectList(new List<string> { "2023A", "2023B" }, becas_Ayudas_Financieras.semestre);

            ViewData["EstudianteIDBecasModificar"] = new SelectList(logicaCacheEstudiantes.ListarEstudiantesCache(), "id_estudiante", "nombre", becas_Ayudas_Financieras.id_estudiante);
            return View(becas_Ayudas_Financieras);
        }

        // GET: Becas_Ayudas_Financieras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Becas_Ayudas_Financieras becas_Ayudas_Financieras = logicaCacheBecas.ListarCacheBecaPorId(id.Value);
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
            logicaCRUDBecas.eliminarBeca(id);
            logicaCacheBecas.ActualizarBecasCache();
            return RedirectToAction("Index");
        }

    }
}
