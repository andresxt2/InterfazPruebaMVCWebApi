using InterfazPrueba.ApiEstudiantesWS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Models
{
    public class Becas_Ayudas_Financieras
    {
        [Required]
        [Key]
        public int id_beca { get; set; }
        public string id_estudiante { get; set; }
        public string tipo_beca { get; set; }
        public decimal monto { get; set; }
        public string semestre { get; set; }
        public Nullable<bool> borrado_logico { get; set; }
        public Nullable<System.DateTime> fecha_borrado_logico { get; set; }

        public Estudiante Estudiantes { get; set; }
    }
}