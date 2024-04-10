using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfazPrueba.Models
{
    public class EstudiantesMorosidadesVM
    {

        public SelectList Estudiantes { get; set; }
        public IPagedList<Morosidad> Morosidades { get; set; }

        public List<Estudiante> EstudiantesList { get; set; }
    }
}