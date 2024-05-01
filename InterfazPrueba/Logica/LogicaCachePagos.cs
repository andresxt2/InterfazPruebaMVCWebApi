using InterfazPrueba.ApiPagosWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class LogicaCachePagos
    {
        ApiPagosWS.API_GestionPagos pago = new API_GestionPagos();
        private ObjectCache cache = MemoryCache.Default;
        private TimeSpan cacheDuration = TimeSpan.FromMinutes(40);

        public List<Models.Pagos> ListarPagosCache()
        {
            string cacheKey = "pagosCache";
            var pagosCache = cache[cacheKey] as List<Models.Pagos>;

            if (pagosCache == null)
            {
                pagosCache = pago.Listar().Select(apiPago => new Models.Pagos
                {
                    id_pago = apiPago.id_pago,
                    cod_pago = apiPago.cod_pago,
                    id_estudiante = apiPago.id_estudiante,
                    fecha_pago = apiPago.fecha_pago,
                    monto = apiPago.saldo,
                    semestre = apiPago.semestre,
                    estado = apiPago.estado
                }).OrderByDescending(e => e.id_pago).ToList();

                cache.Set(cacheKey, pagosCache, DateTimeOffset.UtcNow.AddMinutes(40));
            }
            return pagosCache.OrderByDescending(x => x.id_pago).ToList();
        }

        public Models.Pagos ListarCachePagoPorId(int id)
        {
            return ListarPagosCache().FirstOrDefault(e => e.id_pago == id);
        }

        public Models.Pagos ListarCachePagoPorEstado(string estado)
        {
            return ListarPagosCache().FirstOrDefault(e => e.estado == estado);
        }

        public List <Models.Pagos> ListarCachePendientes(string cedula)
        {
            return ListarPagosCache().Where(e => e.estado == "pendiente" && e.id_estudiante == cedula).ToList();
        }


        private void ActualizarCache<T>(string cacheKey, Func<List<T>> obtenerDatosDesdeApi)
        {
            var datosActualizados = obtenerDatosDesdeApi();
            cache.Set(cacheKey, datosActualizados, DateTimeOffset.UtcNow.AddMinutes(40));
        }

        public void ActualizarPagosCache()
        {
            ActualizarCache("pagosCache", () => pago.Listar().Select(apiPago => new Models.Pagos
            {
                id_pago = apiPago.id_pago,
                id_estudiante = apiPago.id_estudiante,
                cod_pago = apiPago.cod_pago,
                fecha_pago = apiPago.fecha_pago,
                monto = apiPago.saldo,
                semestre = apiPago.semestre,
                estado = apiPago.estado
            }).OrderByDescending(e => e.id_pago).ToList());
        }

    }
}