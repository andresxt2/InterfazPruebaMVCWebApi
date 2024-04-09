using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class LogicaCrudMorosidad
    {
        ApiMorosidadWS.API_GestionMorosidad morosidades = new ApiMorosidadWS.API_GestionMorosidad();

        public List<Models.Morosidad> ListarMorosidades ()
        {
            List<Models.Morosidad> listaMorosidades = new List<Models.Morosidad>();
            var morosidadesWS = morosidades.Listar();
            int contador = 0;
            foreach (var morosidadWS in morosidadesWS)
            {
                if (contador < 20)
                {
                    Models.Morosidad morosidad = new Models.Morosidad();
                    morosidad.id_morosidad = morosidadWS.id_morosidad;
                    morosidad.id_estudiante = morosidadWS.id_estudiante;
                    morosidad.semestre = morosidadWS.semestre;
                    morosidad.dias_retraso = morosidadWS.dias_retraso;
                    morosidad.monto_debido = morosidadWS.monto_debido;
                    listaMorosidades.Add(morosidad);
                }
                else
                {
                    break;
                }
                contador++;
            }
            return listaMorosidades;
        }

        public Models.Morosidad MorosidadPorId(int id)
        {
            var morosidadWS = morosidades.leerPorId(id);
            Models.Morosidad morosidad = new Models.Morosidad();
            morosidad.id_morosidad = morosidadWS.id_morosidad;
            morosidad.id_estudiante = morosidadWS.id_estudiante;
            morosidad.semestre = morosidadWS.semestre;
            morosidad.dias_retraso = morosidadWS.dias_retraso;
            morosidad.monto_debido = morosidadWS.monto_debido;
            return morosidad;
        }

        public void insertarMorosidad(Models.Morosidad morosidad)
        {
            ApiMorosidadWS.Morosidad morosidadWS = new ApiMorosidadWS.Morosidad();
            morosidadWS.id_estudiante = morosidad.id_estudiante;
            morosidadWS.semestre = morosidad.semestre;
            morosidadWS.dias_retraso = morosidad.dias_retraso;
            morosidadWS.monto_debido = morosidad.monto_debido;
            morosidades.Insertar(morosidadWS);
        }

        public bool actualizarMorosidad(Models.Morosidad morosidad)
        {
            ApiMorosidadWS.Morosidad morosidadWS = new ApiMorosidadWS.Morosidad();
            morosidadWS.id_morosidad = morosidad.id_morosidad;
            morosidadWS.id_estudiante = morosidad.id_estudiante;
            morosidadWS.semestre = morosidad.semestre;
            morosidadWS.dias_retraso = morosidad.dias_retraso;
            morosidadWS.monto_debido = morosidad.monto_debido;
            return morosidades.Actualizar(morosidadWS);
        }

        public bool eliminarMorosidad(int id)
        {
            return morosidades.Eliminar(id);
        }
        
    }
}