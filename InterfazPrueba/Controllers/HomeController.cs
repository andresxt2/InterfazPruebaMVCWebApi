using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfazPrueba.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult WebForm()
        {
            // Lógica para procesar los datos enviados desde el formulario
            // Puedes acceder a los datos enviados a través de Request.Form o mediante parámetros del método
            // Por ejemplo: string valor = Request.Form["nombreDelCampo"];
            // O: public ActionResult WebForm(string parametro1, int parametro2)
            // Aquí puedes realizar las operaciones necesarias, como guardar en la base de datos, enviar correos electrónicos, etc.

            // Por ahora, simplemente redireccionamos a una vista de confirmación o a la página de inicio
            return View();
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