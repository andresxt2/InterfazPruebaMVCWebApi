using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Models
{
    public class EstudiantesViewModelPaginacion
    {
        public List<Models.Estudiante> Estudiantes { get; set; }
        public int PaginaActual { get; set; }
        public int TamanoPagina { get; set; }

        public int TotalElementos { get; set; }
    }
}