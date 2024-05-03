using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfazPrueba.Logica
{
    public class LogicaCRUDPagos
    {
        ApiPagosWS.API_GestionPagos pagos = new ApiPagosWS.API_GestionPagos();
        
        public List<Models.Pagos> ListarPagos ()
        {
            List<Models.Pagos> listaPagos = new List<Models.Pagos>();
            var pagosWS = pagos.Listar();
            foreach (var pagoWS in pagosWS)
            {
                    Models.Pagos pago = new Models.Pagos();
                    pago.id_pago = pagoWS.id_pago;
                    pago.cod_pago = pagoWS.cod_pago;
                    pago.id_estudiante = pagoWS.id_estudiante;
                    pago.fecha_pago = pagoWS.fecha_pago;
                    pago.monto = pagoWS.saldo;
                    pago.semestre = pagoWS.semestre;
                    pago.estado = pagoWS.estado;
                    listaPagos.Add(pago);
            }
            return listaPagos;
        }

        public Models.Pagos PagoPorId(int id)
        {
            var pagoWS = pagos.leerPorId(id);
            Models.Pagos pago = new Models.Pagos();
            pago.id_pago = pagoWS.id_pago;
            pago.id_estudiante = pagoWS.id_estudiante;
            pago.fecha_pago = pagoWS.fecha_pago;
            pago.monto = pagoWS.saldo;
            pago.semestre = pagoWS.semestre;
            pago.estado = pagoWS.estado;
            return pago;
        }

        public void insertarPago(Models.Pagos pago)
        {
            ApiPagosWS.Pagos pagoWS = new ApiPagosWS.Pagos();
            pagoWS.id_estudiante = pago.id_estudiante;
            pagoWS.fecha_pago = pago.fecha_pago;
            pagoWS.saldo = pago.monto;
            pagoWS.semestre = pago.semestre;
            pagoWS.estado = pago.estado;
            pagos.Insertar(pagoWS);
        }

        public bool actualizarPago(Models.Pagos pago)
        {
            ApiPagosWS.Pagos pagoWS = new ApiPagosWS.Pagos();
            pagoWS.id_pago = pago.id_pago;
            pagoWS.id_estudiante = pago.id_estudiante;
            pagoWS.fecha_pago = pago.fecha_pago;
            pagoWS.saldo = pago.monto;
            pagoWS.semestre = pago.semestre;
            pagoWS.estado = pago.estado;
            return pagos.Actualizar(pagoWS);
        }

        public bool eliminarPago(int id)
        {
            return pagos.Eliminar(id);
        }

        public Models.Pagos listarPagoPorId (int id)
        {
            return ListarPagos().FirstOrDefault(p => p.id_pago == id);
        }

        public List<Models.Pagos> ListarPagosPorEstudiante(string id)
        {
            return ListarPagos().Where(p => p.id_estudiante == id).ToList();
        }
    }
}