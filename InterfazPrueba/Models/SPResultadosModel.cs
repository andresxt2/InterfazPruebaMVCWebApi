using InterfazPrueba.APIResultadosWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Models
{
    public class SPResultadosModel
    {
        public List<ReporteEstadoPagos_Result> EstadoPagos { get; set; }
        public List<ReporteMorosidadPorPrograma_Result> MorosidadPorPrograma { get; set; }

        // Constructor sin parámetros si necesitas inicializar las listas u otros componentes
        public SPResultadosModel()
        {
            EstadoPagos = new List<ReporteEstadoPagos_Result>();
            MorosidadPorPrograma = new List<ReporteMorosidadPorPrograma_Result>();
        }
    }
}