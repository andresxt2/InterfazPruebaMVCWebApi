using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfazPrueba.Models
{
    public class EstudiantesPagosVM
    {
        public SelectList Estudiantes { get; set; }
        public IPagedList<Pagos> Pagos { get; set; }

        public List<Estudiante> EstudiantesList { get; set; }

        public string EstadoPagoSeleccionado { get; set; }

        public string FechaPagoSeleccionado { get; set; }
    }
}