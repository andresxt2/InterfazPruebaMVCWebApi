using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class logicaCRUDBecas
    {
        ApiBecasWS.API_GestionBecas becas = new ApiBecasWS.API_GestionBecas();

        public List<Models.Becas_Ayudas_Financieras> ListarBecas()
        {
            List<Models.Becas_Ayudas_Financieras> listaBecas = new List<Models.Becas_Ayudas_Financieras>();
            var becasWS = becas.Listar();
            foreach (var becaWS in becasWS)
            {
                    Models.Becas_Ayudas_Financieras beca = new Models.Becas_Ayudas_Financieras();
                    beca.id_beca = becaWS.id_beca;
                    beca.id_estudiante = becaWS.id_estudiante;
                    beca.tipo_beca = becaWS.tipo_beca;
                    beca.monto = becaWS.monto;
                    beca.semestre = becaWS.semestre;
                    listaBecas.Add(beca);
            }
            return listaBecas;
        }

        public Models.Becas_Ayudas_Financieras Becas_Ayudas_Financieras(int id)
        {
            var becaWS = becas.leerPorId(id);
            Models.Becas_Ayudas_Financieras beca = new Models.Becas_Ayudas_Financieras();
            beca.id_beca = becaWS.id_beca;
            beca.id_estudiante = becaWS.id_estudiante;
            beca.tipo_beca = becaWS.tipo_beca;
            beca.monto = becaWS.monto;
            beca.semestre = becaWS.semestre;
            return beca;
        }

        public void insertarBeca(Models.Becas_Ayudas_Financieras beca)
        {
            ApiBecasWS.Becas_Ayudas_Financieras becaWS = new ApiBecasWS.Becas_Ayudas_Financieras();
            becaWS.id_estudiante = beca.id_estudiante;
            becaWS.tipo_beca = beca.tipo_beca;
            becaWS.monto = beca.monto;
            becaWS.semestre = beca.semestre;
            becas.Insertar(becaWS);
        }

        public bool actualizarBeca(Models.Becas_Ayudas_Financieras beca)
        {
            ApiBecasWS.Becas_Ayudas_Financieras becaWS = new ApiBecasWS.Becas_Ayudas_Financieras();
            becaWS.id_beca = beca.id_beca;
            becaWS.id_estudiante = beca.id_estudiante;
            becaWS.tipo_beca = beca.tipo_beca;
            becaWS.monto = beca.monto;
            becaWS.semestre = beca.semestre;
            return becas.Actualizar(becaWS);
        }

        public bool eliminarBeca(int id)
        {
            return becas.Eliminar(id);
        }
    }
}