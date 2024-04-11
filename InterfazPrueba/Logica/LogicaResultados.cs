using InterfazPrueba.APIResultadosWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class LogicaResultados

    {
        private API_GestionResultados apiResultados = new API_GestionResultados();

        public List<ReporteEstadoPagos_Result> ListarEstadoPagos()
        {
            // Consumir el servicio web para obtener el estado de pagos
            return apiResultados.SPReporteEstadoPagos().ToList();
        }

        public List<ReporteMorosidadPorPrograma_Result> ListarMorosidadPorPrograma()
        {
            // Consumir el servicio web para obtener la morosidad por programa
            return apiResultados.SPReporteMorosidadPorPrograma().ToList();
        }
    }
}