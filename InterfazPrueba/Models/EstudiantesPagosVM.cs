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
        public List<Pagos> Pagos { get; set; }

        public List<Estudiante> EstudiantesList { get; set; }
    }
}