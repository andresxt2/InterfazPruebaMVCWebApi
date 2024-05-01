using InterfazPrueba.Logica;
using InterfazPrueba.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace InterfazPrueba.Controllers
{
    public class HomeController : Controller
    {
        private LogicaResultados logicaResultados = new LogicaResultados();
        LogicaCachePagos logicaCachePagos = new LogicaCachePagos();
        LogicaCacheEstudiantes logicaCacheEstudiantes = new LogicaCacheEstudiantes();
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
                ViewBag.InfoEstudiante = JsonConvert.DeserializeObject<Estudiante>(TempData["InfoEstudiante"].ToString());
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