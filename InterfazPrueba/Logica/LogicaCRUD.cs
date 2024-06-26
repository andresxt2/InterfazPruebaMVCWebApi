﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InterfazPrueba.Logica
{
    public class LogicaCRUD
    {
        ApiEstudiantesWS.API_GestionEstudiantes estudiantes = new ApiEstudiantesWS.API_GestionEstudiantes();

        public List<Models.Estudiante> ListarEstudiantes()
        {
            List<Models.Estudiante> listaEstudiantes = new List<Models.Estudiante>();
            var estudiantesWS = estudiantes.Listar();
            int contador = 0;
            foreach (var estudianteWS in estudiantesWS)
            {
                if (contador < 1000)
                {
                    Models.Estudiante estudiante = new Models.Estudiante();
                    estudiante.ci_estudiante = estudianteWS.id_estudiante;
                    estudiante.nombre = estudianteWS.nombres;
                    estudiante.correo_electronico = estudianteWS.correo_electronico;
                    estudiante.programa_academico = estudianteWS.programa_academico;
                    estudiante.estado_matricula = estudianteWS.estado_matricula;
                    listaEstudiantes.Add(estudiante);
                }
                else
                {
                    break;
                }
                contador++;
            }
            return listaEstudiantes;
        }

        public Models.Estudiante BuscarEstudiante(string id)
        {
            var estudianteWS = estudiantes.leerPorId(id);
            Models.Estudiante estudiante = new Models.Estudiante();
            estudiante.ci_estudiante = estudianteWS.id_estudiante;
            estudiante.nombre = estudianteWS.nombres;
            estudiante.correo_electronico = estudianteWS.correo_electronico;
            estudiante.programa_academico = estudianteWS.programa_academico;
            estudiante.estado_matricula = estudianteWS.estado_matricula;
            return estudiante;
        }
        
        /*
          public List <Models.Estudiante> Paginacion(int pagina = 1, int tamanoPagina = 100)
            {
                var estudiantesWs = estudiantes.ListarPaginado(pagina, tamanoPagina, null);
                List<Models.Estudiante> listaEstudiantes = new List<Models.Estudiante>();
                int contador = 0;
                foreach (var estudianteWs in estudiantesWs.Items)
                {
                    Models.Estudiante estudiante = new Models.Estudiante();
                    estudiante.id_estudiante = estudiantesWs.Items[contador].id_estudiante;
                    estudiante.ci_estudiante = estudiantesWs.Items[contador].ci_estudiante;
                    estudiante.nombre = estudiantesWs.Items[contador].nombre;
                    estudiante.correo_electronico = estudiantesWs.Items[contador].correo_electronico;
                    estudiante.programa_academico = estudiantesWs.Items[contador].programa_academico;
                    estudiante.estado_matricula = estudiantesWs.Items[contador].estado_matricula;
                    listaEstudiantes.Add(estudiante);
                    contador++;
                }
                return listaEstudiantes;       
            }*/

        public void crearEstudiante(Models.Estudiante estudiante)
        {
            ApiEstudiantesWS.Estudiantes estudianteWS = new ApiEstudiantesWS.Estudiantes();
            estudianteWS.id_estudiante = estudiante.ci_estudiante;
            estudianteWS.nombres = estudiante.nombre;
            estudianteWS.apellidos = estudiante.apellido;
            estudianteWS.correo_electronico = estudiante.correo_electronico;
            estudianteWS.programa_academico = estudiante.programa_academico;
            estudianteWS.estado_matricula = estudiante.estado_matricula;
            //estudianteWS.borrado_logico = false;
            estudiantes.Insertar(estudianteWS);
        }

        public bool actualizarEstudiante(Models.Estudiante estudiante)
        {
            ApiEstudiantesWS.Estudiantes estudianteWS = new ApiEstudiantesWS.Estudiantes();
            estudianteWS.id_estudiante = estudiante.ci_estudiante;
            estudianteWS.nombres = estudiante.nombre;
            estudianteWS.apellidos = estudiante.apellido;
            estudianteWS.correo_electronico = estudiante.correo_electronico;
            estudianteWS.programa_academico = estudiante.programa_academico;
            estudianteWS.estado_matricula = estudiante.estado_matricula;
            //estudianteWS.borrado_logico = false;
            return estudiantes.Actualizar(estudianteWS);
        }

        public bool EliminarEstudiante(string id)
        {
            return estudiantes.Eliminar(id);
        }

    }
}