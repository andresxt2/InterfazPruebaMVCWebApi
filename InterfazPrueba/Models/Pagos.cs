using InterfazPrueba.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Models
{
    public class Pagos
    {
        [Required]
        [Key]
        public int id_pago { get; set; }
        public int id_estudiante { get; set; }
        public System.DateTime fecha_pago { get; set; }
        public decimal monto { get; set; }
        public string semestre { get; set; }
        public string estado { get; set; }
        public Nullable<bool> borrado_logico { get; set; }
        public Nullable<System.DateTime> fecha_borrado_logico { get; set; }

        public virtual Estudiantes Estudiantes { get; set; }
    }
}