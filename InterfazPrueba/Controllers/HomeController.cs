using InterfazPrueba.Logica;
using InterfazPrueba.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InterfazPrueba.Controllers
{
    public class HomeController : Controller
    {
        private LogicaResultados logicaResultados = new LogicaResultados();
        LogicaCachePagos logicaCachePagos = new LogicaCachePagos();
        LogicaCacheEstudiantes logicaCacheEstudiantes = new LogicaCacheEstudiantes();
        LogicaCRUDPagos logicaCRUDPagos = new LogicaCRUDPagos();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Resultados()
        {
            var estadoPagos = logicaResultados.ListarEstadoPagos();
            var morosidadPorPrograma = logicaResultados.ListarMorosidadPorPrograma();

            var model = new SPResultadosModel
            {
                // Suponiendo que tienes un ViewModel que pueda contener estas listas
                EstadoPagos = estadoPagos,
                MorosidadPorPrograma = morosidadPorPrograma
            };

            return View(model);
        }

        public ActionResult PagarSemestre()
        {
            // Verificar si TempData contiene los pagos pendientes y pasar a ViewBag
            if (TempData["PagosPendientes"] != null && TempData["InfoEstudiante"] != null)
            {
                ViewBag.PagosPendientes = TempData["PagosPendientes"];
                //ViewBag.InfoEstudiante = JsonConvert.DeserializeObject<Estudiante>(TempData["InfoEstudiante"].ToString());
                // Verificar si la información del estudiante está en formato JSON y deserializar si es necesario
                if (TempData["InfoEstudiante"] is string infoEstudianteJson)
                {
                    ViewBag.InfoEstudiante = JsonConvert.DeserializeObject<Estudiante>(infoEstudianteJson);
                }
                else
                {
                    ViewBag.InfoEstudiante = TempData["InfoEstudiante"];
                }
            }

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PagarSemestre(Pagos pago)
        {
            if (ModelState.IsValid)
            {
                var pagosPendientes = logicaCachePagos.ListarCachePendientes(pago.id_estudiante);
                var estudiantePagoPendiente = logicaCacheEstudiantes.ListarCacheEstudiantePorId(pago.id_estudiante);
                // Guardar los pagos pendientes en TempData para pasarlos a otra acción
                TempData["PagosPendientes"] = pagosPendientes;
                TempData["InfoEstudiante"] = JsonConvert.SerializeObject(estudiantePagoPendiente);


                // Redirigir a PagarSemestre
                return RedirectToAction("PagarSemestre");
            }

            // Si hay un problema, retorna la misma vista con los datos ingresados
            return View(pago);
        }



        public ActionResult CargarPagos()
        {
            // Obtener los datos de TempData
            var pagosPendientes = TempData["PagosPendientes"] as List<InterfazPrueba.Models.Pagos>;
            var infoEstudiante = TempData["InfoEstudiante"] as InterfazPrueba.Models.Estudiante;

            //Enviar banca

            // Actualizar el estado de los pagos a procesado
            foreach (var pago in pagosPendientes)
            {
                pago.estado = "procesado";
                logicaCRUDPagos.actualizarPago(pago);
            }
            logicaCachePagos.ActualizarPagosCache();
            TempData["PagosPendientes"] = null;
            TempData["InfoEstudiante"] = null;


            return RedirectToAction("PagarSemestre");
        }

        public ActionResult Secciones ()
        {
            return View();
        }

        public ActionResult Cart()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GuardarCompra(string zapatosData, string subtotalData, string cedula)
        {
                // Obtener la cédula del localStorage
               // string cedula = System.Web.HttpContext.Current.Session["cedula"] as string;

                if (string.IsNullOrEmpty(cedula))
                {
                    // Manejar el caso en que no se haya guardado la cédula en el localStorage
                    return Json(new { success = false, message = "No se encontró la cédula en el localStorage" });
            }
            else
            {
                var estudiante = logicaCacheEstudiantes.ListarCacheEstudiantePorId(cedula);
                if (estudiante == null)
                {
                    // Manejar el caso en que no se haya encontrado el estudiante
                    return Json(new { success = false, message = "No se encontró el estudiante con la cédula proporcionada" });
                }
            }

                // Deserializar los datos del carrito
                var pagos = JsonConvert.DeserializeObject<List<Pagos>>(zapatosData);
                decimal subtotal = Convert.ToDecimal(subtotalData);

                // Crear una lista para almacenar los pagos
                List<Pagos> pagosGuardados = new List<Pagos>();

                // Crear un nuevo pago para cada elemento del carrito
                foreach (var pago in pagos)
                {
                    // Asignar la cédula al pago
                    pago.id_estudiante = cedula;
                    pago.fecha_pago = System.DateTime.Now; // Asignar la fecha actual
                    pago.estado = "pendiente"; // Estado quemado como pendiente, puedes cambiarlo según tus necesidades
                    // Agregar el pago a la lista de pagos guardados
                    logicaCRUDPagos.insertarPago(pago);
                    pagosGuardados.Add(pago);
                }

                // Limpiar el localStorage después de procesar la compra
                System.Web.HttpContext.Current.Session.Remove("semestres");
                System.Web.HttpContext.Current.Session.Remove("precio");
                System.Web.HttpContext.Current.Session.Remove("cedula");

                // Devolver una respuesta al cliente si es necesario
                return Json(new { success = true, message = "Compra guardada correctamente", pagos = pagosGuardados });
            

        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}