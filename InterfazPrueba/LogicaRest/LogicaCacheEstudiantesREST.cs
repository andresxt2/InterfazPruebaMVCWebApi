using InterfazPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;

namespace InterfazPrueba.LogicaRest
{
    public class LogicaCacheEstudiantesREST
    {
        private readonly HttpClient _httpClient;
        private readonly ObjectCache _cache = MemoryCache.Default;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(40);
        private const string BaseUrl = "https://api.example.com/estudiantes"; // Reemplaza con la URL de tu API

        public LogicaCacheEstudiantesREST()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Estudiante>> ListarEstudiantesCacheAsync()
        {
            string cacheKey = "estudiantesCacheKey";
            var estudiantesCache = _cache[cacheKey] as List<Estudiante>;

            if (estudiantesCache == null)
            {
                var response = await _httpClient.GetFromJsonAsync<List<ApiEstudiante>>(BaseUrl);
                estudiantesCache = response.Select(apiEstudiante => new Estudiante
                {
                    ci_estudiante = apiEstudiante.id_estudiante,
                    nombre = apiEstudiante.nombres,
                    apellido = apiEstudiante.apellidos,
                    correo_electronico = apiEstudiante.correo_electronico,
                    programa_academico = apiEstudiante.programa_academico,
                    estado_matricula = apiEstudiante.estado_matricula
                }).ToList();

                _cache.Set(cacheKey, estudiantesCache, DateTimeOffset.UtcNow.Add(_cacheDuration));
            }

            return estudiantesCache.ToList();
        }

        public async Task<Estudiante> ListarCacheEstudiantePorIdAsync(string id)
        {
            var estudiantes = await ListarEstudiantesCacheAsync();
            return estudiantes.FirstOrDefault(e => e.ci_estudiante == id);
        }

        public async Task<Estudiante> ListarCacheEstudiantePorNombreAsync(string nombre)
        {
            var estudiantes = await ListarEstudiantesCacheAsync();
            return estudiantes.FirstOrDefault(e => e.nombre == nombre);
        }

        private async Task ActualizarCacheAsync<T>(string cacheKey, Func<Task<List<T>>> obtenerDatosDesdeApi)
        {
            var datosActualizados = await obtenerDatosDesdeApi();
            _cache.Set(cacheKey, datosActualizados, DateTimeOffset.UtcNow.Add(_cacheDuration));
        }

        public async Task ActualizarEstudiantesCacheAsync()
        {
            await ActualizarCacheAsync("estudiantesCacheKey", async () =>
            {
                var response = await _httpClient.GetFromJsonAsync<List<ApiEstudiante>>(BaseUrl);
                return response.Select(apiEstudiante => new Estudiante
                {
                    ci_estudiante = apiEstudiante.id_estudiante,
                    nombre = apiEstudiante.nombres,
                    apellido = apiEstudiante.apellidos,
                    correo_electronico = apiEstudiante.correo_electronico,
                    programa_academico = apiEstudiante.programa_academico,
                    estado_matricula = apiEstudiante.estado_matricula
                }).ToList();
            });
        }

        public async Task<List<Estudiante>> ListarCacheEstudiantePorIdsAsync(List<string> ids)
        {
            var estudiantes = await ListarEstudiantesCacheAsync();
            return estudiantes.Where(e => ids.Contains(e.ci_estudiante)).ToList();
        }
    }
}