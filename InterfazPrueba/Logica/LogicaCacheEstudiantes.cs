using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using InterfazPrueba.ApiEstudiantesWS;

namespace InterfazPrueba.Logica
{
    public class LogicaCacheEstudiantes
    {
        ApiEstudiantesWS.API_GestionEstudiantes estudiante = new ApiEstudiantesWS.API_GestionEstudiantes();
        private ObjectCache cache = MemoryCache.Default;
        private TimeSpan cacheDuration = TimeSpan.FromMinutes(40);

        public List<Models.Estudiante> ListarEstudiantesCache()
        {
            string cacheKey = "estudiantesCacheKey";
            var estudiantesCache = cache[cacheKey] as List<Models.Estudiante>;
            if (estudiantesCache == null)
            {
                estudiantesCache = estudiante.Listar().Select(apiEstudiante => new Models.Estudiante
                {
                    id_estudiante = apiEstudiante.id_estudiante,
                    ci_estudiante = apiEstudiante.ci_estudiante,
                    nombre = apiEstudiante.nombre,
                    correo_electronico = apiEstudiante.correo_electronico,
                    programa_academico = apiEstudiante.programa_academico,
                    estado_matricula = apiEstudiante.estado_matricula
                }).ToList();

                //cache
                cache.Set(cacheKey, estudiantesCache, DateTimeOffset.UtcNow.AddMinutes(40)); // Asumiendo cacheDuration de 30 minutos

            }
            return estudiantesCache;
        }

        public Models.Estudiante ListarCacheEstudiantePorId(int id)
        {
            return ListarEstudiantesCache().FirstOrDefault(e => e.id_estudiante == id);
        }

        private void ActualizarCache<T>(string cacheKey, Func<List<T>> obtenerDatosDesdeApi)
        {
            var datosActualizados = obtenerDatosDesdeApi();
            cache.Set(cacheKey, datosActualizados, DateTimeOffset.UtcNow.AddMinutes(30)); // Asumiendo el mismo cacheDuration
        }


        public void ActualizarEstudiantesCache()
        {
            ActualizarCache("estudiantesCacheKey", () => estudiante.Listar().Select(apiEstudiante => new Models.Estudiante
            {
                id_estudiante = apiEstudiante.id_estudiante,
                ci_estudiante = apiEstudiante.ci_estudiante,
                nombre = apiEstudiante.nombre,
                correo_electronico = apiEstudiante.correo_electronico,
                programa_academico = apiEstudiante.programa_academico,
                estado_matricula = apiEstudiante.estado_matricula
            }).ToList());
        }
    }
}