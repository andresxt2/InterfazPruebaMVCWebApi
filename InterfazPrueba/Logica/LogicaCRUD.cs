﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class LogicaCRUD
    {
        localhost.API_GestionEstudiantes estudiantes = new localhost.API_GestionEstudiantes();

        public List<Models.Estudiante> ListarEstudiantes()
        {
            List<Models.Estudiante> listaEstudiantes = new List<Models.Estudiante>();
            var estudiantesWS = estudiantes.Listar();
            int contador = 0;
            foreach (var estudianteWS in estudiantesWS)
            {
                if (contador < 20) { 
                Models.Estudiante estudiante = new Models.Estudiante();
                estudiante.id_estudiante = estudianteWS.id_estudiante;
                estudiante.ci_estudiante = estudianteWS.ci_estudiante;
                estudiante.nombre = estudianteWS.nombre;
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
        
        public Models.Estudiante BuscarEstudiante(int id)
        {
            var estudianteWS = estudiantes.leerPorId(id);
            Models.Estudiante estudiante = new Models.Estudiante();
            estudiante.id_estudiante = estudianteWS.id_estudiante;
            estudiante.ci_estudiante = estudianteWS.ci_estudiante;
            estudiante.nombre = estudianteWS.nombre;
            estudiante.correo_electronico = estudianteWS.correo_electronico;
            estudiante.programa_academico = estudianteWS.programa_academico;
            estudiante.estado_matricula = estudianteWS.estado_matricula;
            return estudiante;
        }

        public void crearEstudiante(Models.Estudiante estudiante)
        {
            localhost.Estudiantes estudianteWS = new localhost.Estudiantes();
            estudianteWS.id_estudiante = estudiante.id_estudiante;
            estudianteWS.ci_estudiante = estudiante.ci_estudiante;
            estudianteWS.nombre = estudiante.nombre;
            estudianteWS.correo_electronico = estudiante.correo_electronico;
            estudianteWS.programa_academico = estudiante.programa_academico;
            estudianteWS.estado_matricula = estudiante.estado_matricula;
            //estudianteWS.borrado_logico = false;
            estudiantes.Insertar(estudianteWS);
        }

        public bool actualizarEstudiante(Models.Estudiante estudiante)
        {
            localhost.Estudiantes estudianteWS = new localhost.Estudiantes();
            estudianteWS.id_estudiante = estudiante.id_estudiante;
            estudianteWS.ci_estudiante = estudiante.ci_estudiante;
            estudianteWS.nombre = estudiante.nombre;
            estudianteWS.correo_electronico = estudiante.correo_electronico;
            estudianteWS.programa_academico = estudiante.programa_academico;
            estudianteWS.estado_matricula = estudiante.estado_matricula;
            //estudianteWS.borrado_logico = false;
            return estudiantes.Actualizar(estudianteWS);
        }

        public bool EliminarEstudiante(int id)
        {
            return estudiantes.Eliminar(id);
        }
    }
}