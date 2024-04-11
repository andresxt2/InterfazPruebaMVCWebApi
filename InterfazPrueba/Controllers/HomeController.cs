using InterfazPrueba.Logica;
using InterfazPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfazPrueba.Controllers
{
    public class HomeController : Controller
    {
        private LogicaResultados logicaResultados = new LogicaResultados();
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