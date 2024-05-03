using InterfazPrueba.ApiEstudiantesWS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Models
{
    public class Pagos
    {
        [Required]
        [Key]
        public int id_pago { get; set; }

        public string cod_pago { get; set; }

        [Required(ErrorMessage = "Se requiere el ID del estudiante.")]
        public string id_estudiante { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime fecha_pago { get; set; }

        [JsonProperty("precio")] // Nombre en el JSON
        public decimal monto { get; set; }

      //  public string productoID { get; set; }

        [JsonProperty("nombre")] // Nombre en el JSON
        public string semestre { get; set; }
        public string estado { get; set; }

        public Estudiante Estudiantes { get; set; }
    }
}