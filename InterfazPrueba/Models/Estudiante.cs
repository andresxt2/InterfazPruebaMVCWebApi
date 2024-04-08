using InterfazPrueba.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Models
{
    public class Estudiante
    {
        [Required]
        [Key]
        public int id_estudiante { get; set; }


        public string ci_estudiante { get; set; }
        public string nombre { get; set; }
        public string correo_electronico { get; set; }
        public string programa_academico { get; set; }
        public string estado_matricula { get; set; }
        public Nullable<bool> borrado_logico { get; set; }
        public Nullable<System.DateTime> fecha_borrado_logico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Becas_Ayudas_Financieras> Becas_Ayudas_Financieras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Morosidad> Morosidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Pagos> Pagos { get; set; }
    }
}