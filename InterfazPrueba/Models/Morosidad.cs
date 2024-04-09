using InterfazPrueba.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Models
{
    public class Morosidad
    {
        [Required]
        [Key]
        public int id_morosidad { get; set; }
        public int id_estudiante { get; set; }
        public string semestre { get; set; }
        public int dias_retraso { get; set; }
        public decimal monto_debido { get; set; }

        public Estudiante Estudiantes { get; set; }
    }
}