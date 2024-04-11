using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class logicaCacheMorosidades
    {
        ApiMorosidadWS.API_GestionMorosidad morosidades = new ApiMorosidadWS.API_GestionMorosidad();
        private ObjectCache cache = MemoryCache.Default;

        private TimeSpan cacheDuration = TimeSpan.FromMinutes(40);

        public List<Models.Morosidad> ListarMorosidadesCache()
        {
            string cacheKey = "morosidadesCache";
            var morosidadesCache = cache[cacheKey] as List<Models.Morosidad>;

            if (morosidadesCache == null)
            {
                morosidadesCache = morosidades.Listar().Select(apiMorosidad => new Models.Morosidad
                {
                    id_morosidad = apiMorosidad.id_morosidad,
                    id_estudiante = apiMorosidad.id_estudiante,
                    semestre = apiMorosidad.semestre,
                    dias_retraso = apiMorosidad.dias_retraso,
                    monto_debido = apiMorosidad.monto_debido,
                }).OrderByDescending(e => e.id_morosidad).ToList();

                cache.Set(cacheKey, morosidadesCache, DateTimeOffset.UtcNow.AddMinutes(40));
            }
            return morosidadesCache.OrderByDescending(x => x.id_morosidad).ToList();

        }

        public Models.Morosidad ListarCacheMorosidadPorId(int id)
        {
            return ListarMorosidadesCache().FirstOrDefault(e => e.id_morosidad == id);
        }

        public Models.Morosidad ListarCacheMorosidadPorSemestre(string semestre)
        {
            return ListarMorosidadesCache().FirstOrDefault(e => e.semestre == semestre);
        }

        private void ActualizarCache<T>(string cacheKey, Func<List<T>> obtenerDatosDesdeApi)
        {
            var datosActualizados = obtenerDatosDesdeApi();
            cache.Set(cacheKey, datosActualizados, DateTimeOffset.UtcNow.AddMinutes(40));
        }

        public void ActualizarMorosidadesCache()
        {
            ActualizarCache("morosidadesCache", () => morosidades.Listar().Select(apiMorosidad => new Models.Morosidad
            {
                id_morosidad = apiMorosidad.id_morosidad,
                id_estudiante = apiMorosidad.id_estudiante,
                semestre = apiMorosidad.semestre,
                dias_retraso = apiMorosidad.dias_retraso,
                monto_debido = apiMorosidad.monto_debido,
            }).OrderByDescending(e => e.id_morosidad).ToList());
        }



    }
}