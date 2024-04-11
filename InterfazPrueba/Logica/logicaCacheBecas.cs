using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class logicaCacheBecas
    {
        ApiBecasWS.API_GestionBecas beca = new ApiBecasWS.API_GestionBecas();
        private ObjectCache cache = MemoryCache.Default;

        private TimeSpan cacheDuration = TimeSpan.FromMinutes(40);

        public List<Models.Becas_Ayudas_Financieras> ListarBecasCache()
        {
            string cacheKey = "becasCache";
            var becasCache = cache[cacheKey] as List<Models.Becas_Ayudas_Financieras>;

            if (becasCache == null)
            {
                becasCache = beca.Listar().Select(apiBeca => new Models.Becas_Ayudas_Financieras
                {
                    id_beca = apiBeca.id_beca,
                    id_estudiante = apiBeca.id_estudiante,
                    tipo_beca = apiBeca.tipo_beca,
                    monto = apiBeca.monto,
                    semestre = apiBeca.semestre
                }).OrderByDescending(e => e.id_beca).ToList();

                cache.Set(cacheKey, becasCache, DateTimeOffset.UtcNow.AddMinutes(40));
            }
            return becasCache.OrderByDescending(x => x.id_beca).ToList();

        }

        public Models.Becas_Ayudas_Financieras ListarCacheBecaPorId(int id)
        {
            return ListarBecasCache().FirstOrDefault(e => e.id_beca == id);
        }

        public Models.Becas_Ayudas_Financieras ListarCacheBecaPorTipo(string tipo)
        {
            return ListarBecasCache().FirstOrDefault(e => e.tipo_beca == tipo);
        }

        private void ActualizarCache<T>(string cacheKey, Func<List<T>> obtenerDatosDesdeApi)
        {
            var datosActualizados = obtenerDatosDesdeApi();
            cache.Set(cacheKey, datosActualizados, DateTimeOffset.UtcNow.AddMinutes(40));
        }

        public void ActualizarBecasCache()
        {
            ActualizarCache("becasCache", () => beca.Listar().Select(apiBeca => new Models.Becas_Ayudas_Financieras
            {
                id_beca = apiBeca.id_beca,
                id_estudiante = apiBeca.id_estudiante,
                tipo_beca = apiBeca.tipo_beca,
                monto = apiBeca.monto,
                semestre = apiBeca.semestre
            }).ToList());
        }
    }
}