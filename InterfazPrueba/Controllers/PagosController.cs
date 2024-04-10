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
        LogicaCRUD logicaEstudiantes = new LogicaCRUD();


        // GET: Pagos

        //  IQueryable<string> EstudianteQuery = (IQueryable<string>)logicaEstudiantes.ListarEstudiantes().OrderBy(m => m.nombre).Select(m => m.nombre);
        //   EBVM.Estudiantes = new SelectList(EstudianteQuery.Distinct().ToList());
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 100; // Cantidad de elementos por página

            var pagosList = LogicaCRUDPagos.ListarPagos(); // Asegúrate de que esto devuelve una lista

            foreach (var pago in pagosList)
            {
                pago.Estudiantes = logicaEstudiantes.BuscarEstudiante(pago.id_estudiante);
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
            Pagos pagos = LogicaCRUDPagos.PagoPorId(id.Value);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            return View(pagos);
        }

        // GET: Pagos/Create
        public ActionResult Create()
        {
            ViewData["EstudianteIDPagos"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre");
            // Preparando el ViewBag para tipo_beca
            ViewBag.EstadoPagos = new SelectList(new List<string> { "Pendiente", "Parcial", "Completo" });

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
                return RedirectToAction("Index");
            }

         //   ViewData["EstudianteID"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre", pagos.id_estudiante);
            // Preparando el ViewBag para tipo_beca
           // ViewBag.Estado = new SelectList(new List<string> { "Pendiente", "Parcial", "Completo"}, pagos.estado);

            // Preparando el ViewBag para semestre
        //    ViewBag.Semestre = new SelectList(new List<string> { "2023A", "2023B" }, pagos.semestre);
            return View(pagos);
        }

        // GET: Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = LogicaCRUDPagos.PagoPorId(id.Value);
            if (pagos == null)
            {
                return HttpNotFound();
            }
            ViewData["EstudianteIDPagosMod"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre", pagos.id_estudiante);

            ViewBag.EstadoPagosMod = new SelectList(new List<string> { "Pendiente", "Parcial", "Completo" }, pagos.estado);

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
                return RedirectToAction("Index");
            }
           // ViewData["EstudianteID"] = new SelectList(logicaEstudiantes.ListarEstudiantes(), "id_estudiante", "nombre", pagos.id_estudiante);
            // Preparando el ViewBag para tipo_beca
         //   ViewBag.Estado = new SelectList(new List<string> { "Pendiente", "Parcial", "Completo" }, pagos.estado);

            // Preparando el ViewBag para semestre
           // ViewBag.Semestre = new SelectList(new List<string> { "2023A", "2023B" }, pagos.semestre);
            return View(pagos);
        }

        // GET: Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagos pagos = LogicaCRUDPagos.PagoPorId(id.Value);
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
            return RedirectToAction("Index");
        }

    }
}
