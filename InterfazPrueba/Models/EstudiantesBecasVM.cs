﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfazPrueba.Models
{
    public class EstudiantesBecasVM
    {
        public SelectList Estudiantes { get; set; }
        public List<Becas_Ayudas_Financieras> Becas { get; set; }

        public List<Estudiante> EstudiantesList { get; set; }

    }
}