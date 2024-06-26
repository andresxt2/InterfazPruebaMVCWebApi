﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Data
{
    public class InterfazPruebaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public InterfazPruebaContext() : base("name=InterfazPruebaContext")
        {
        }

        public System.Data.Entity.DbSet<InterfazPrueba.Models.Estudiante> Estudiantes { get; set; }

        public System.Data.Entity.DbSet<InterfazPrueba.Models.Becas_Ayudas_Financieras> Becas_Ayudas_Financieras { get; set; }

        public System.Data.Entity.DbSet<InterfazPrueba.Models.Morosidad> Morosidads { get; set; }

        public System.Data.Entity.DbSet<InterfazPrueba.Models.Pagos> Pagos { get; set; }
    }
}
