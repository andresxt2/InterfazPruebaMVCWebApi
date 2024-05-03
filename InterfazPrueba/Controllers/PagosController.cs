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

namespace InterfazPrueba.Views.UIPagos
{
    public class PagosController : Controller
    {
       
        LogicaCRUDPagos LogicaCRUDPagos = new LogicaCRUDPagos();
        LogicaCacheEstudiantes logicaCacheEstudiantes = new LogicaCacheEstudiantes();
        LogicaCachePagos LogicaCachePagos = new LogicaCachePagos();


        // GET: Pagos
        public ActionResult Index(EstudiantesPagosVM EPVM ,int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 100; // Cantidad de elementos por página

            var pagosList = LogicaCRUDPagos.ListarPagos(); // Asegúrate de que esto devuelve una lista


            if (!string.IsNullOrEmpty(EPVM.EstadoPagoSeleccionado))
            {
                pagosList = pagosList.Where(e => e.estado.Equals(EPVM.EstadoPagoSeleccionado)).ToList();
            }

            if (DateTime.TryParse(EPVM.FechaPagoSeleccionado, out DateTime fechaResult))
            {
                pagosList = pagosList.Where(s => s.fecha_pago == fechaResult.Date).ToList();
            }

            // Obtener todos los IDs de estudiante únicos de los pagos
            var idsEstudiantes = pagosList.Select(p => p.id_estudiante).Distinct().ToList();

            // Obtener todos los estudiantes asociados a estos IDs
            var estudiantesDict = logicaCacheEstudiantes.ListarCacheEstudiantePorIds(idsEstudiantes)
                .ToDictionary(est => est.ci_estudiante);

            // Asignar estudiantes a cada pago
            foreach (var pago in pagosList)
            {
                if (estudiantesDict.TryGetValue(pago.id_estudiante, out var estudiante))
                {
                    pago.Estudiantes = estudiante;
                }
            }


            /*foreach (var pago in pagosList)
            {
                pago.Estudiantes = logicaCacheEstudiantes.ListarCacheEstudiantePorId(pago.id_estudiante);
            }*/

            // Asegúrate de que solo se intenta acceder a la propiedad nombre si Estudiantes no es null.
            if (!string.IsNullOrEmpty(EPVM.NombreEstudianteBuscado))
            {
                pagosList = pagosList.Where(e => e.Estudiantes != null && e.Estudiantes.nombre.Contains(EPVM.NombreEstudianteBuscado)).ToList();
            }


            // Convertir la lista en una versión paginada
            var pagosPaged = pagosList.ToPagedList(pageNumber, pageSize);

            // Crear y configurar el ViewModel
            var viewModel = new EstudiantesPagosVM
            {
                Pagos = pagosPaged
                // Configura otras propiedades si es necesario
            };

            return View(viewModel);
        }

        // GET: Pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = LogicaCRUDPagos.listarPagoPorId(id.Value);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {

            var estudiantes = logicaCacheEstudiantes.ListarEstudiantesCache()
          .Select(e => new
          {
              ci_estudiante = e.ci_estudiante,
              nombreCompleto = e.nombre + " " + e.apellido // Concatenación de nombre y apellido
          }).ToList();

            ViewData["EstudianteIDPagos"] = new SelectList(estudiantes, "ci_estudiante", "nombreCompleto");
            // Preparando el ViewBag para tipo_beca
            ViewBag.EstadoPagos = new SelectList(new List<string> { "pendiente", "pagado" });

            // Preparando el ViewBag para semestre
            ViewBag.SemestrePagos = new SelectList(new List<string> { "2023A", "2023B" });
            return View();
        }

        // POST: Pagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_estudiante,fecha_pago,monto,semestre,estado")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
            //
                LogicaCRUDPagos.insertarPago(pagos);
                LogicaCachePagos.ActualizarPagosCache();
                return RedirectToAction("Index");
            }
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = LogicaCRUDPagos.listarPagoPorId(id.Value);
            if (pagos == null)
            {
                return HttpNotFound();
            }

            var estudiantes = logicaCacheEstudiantes.ListarEstudiantesCache()
       .Select(e => new
       {
           ci_estudiante = e.ci_estudiante,
           nombreCompleto = e.nombre + " " + e.apellido // Concatenación de nombre y apellido
       }).ToList();

            ViewData["EstudianteIDPagosMod"] = new SelectList(estudiantes, "ci_estudiante", "nombreCompleto", pagos.id_estudiante);

            ViewBag.EstadoPagosMod = new SelectList(new List<string> { "pendiente", "pagado" }, pagos.estado);

            // Preparando el ViewBag para semestre
            ViewBag.SemestrePagosMod = new SelectList(new List<string> { "2023A", "2023B" }, pagos.semestre);
            return View(pagos);
        }

        // POST: Pagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pago,id_estudiante,fecha_pago,monto,semestre,estado,Estudiantes")] Pagos pagos)
        {
            if (ModelState.IsValid)
            {
                LogicaCRUDPagos.actualizarPago(pagos);
                LogicaCachePagos.ActualizarPagosCache();
                return RedirectToAction("Index");
            }
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = LogicaCRUDPagos.listarPagoPorId(id.Value);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        // POST: Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogicaCRUDPagos.eliminarPago(id);
            LogicaCachePagos.ActualizarPagosCache();
            return RedirectToAction("Index");
        }

    }
}
