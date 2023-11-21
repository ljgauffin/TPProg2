using Fabrica.datos;
using Fabrica.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;


namespace Fabrica.Datos
{
    public class PedidoDao : IPedidoDao
    {
        public bool CrearPedido(Pedido pedido)
        {
            bool ok = true;
            SqlConnection cnn = DBHelper.GetInstancia().GetConnection();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", pedido.NombreCliente);
                cmd.Parameters.AddWithValue("@cuit", pedido.CuitCliente);
                cmd.Parameters.AddWithValue("@correo", pedido.CorreoCliente);
                cmd.Parameters.AddWithValue("@fecha", pedido.FechaEntrega);

                //parámetro de salida:
                SqlParameter pOut = new SqlParameter();
                pOut.ParameterName = "@pedidoId";
                pOut.DbType = DbType.Int32;
                pOut.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pOut);
                cmd.ExecuteNonQuery();

                int pedidoNro = (int)pOut.Value;

                SqlCommand cmdDetalle;
                
                foreach (DetallePedido detalle in pedido.Detalle)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@pedido", pedidoNro);
                    cmdDetalle.Parameters.AddWithValue("@producto", detalle.Product.id);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                    
                    cmdDetalle.ExecuteNonQuery();

                    
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }


        public List<Pedido> ObtenerPedidos(DateTime desde, DateTime hasta, int estadoId, int? id)
        {
            List<Pedido> lista = new List<Pedido>();

            if (id == null)
            {
               lista =  ConsultarPedidos(desde, hasta, estadoId);

            }
            else
            {
                lista = ConsultarPedido(id);

            }


            return lista;
            
        }

        private List<Pedido> ConsultarPedido(int? id)
        {
            throw new NotImplementedException();
        }

        private List<Pedido> ConsultarPedidos(DateTime desde, DateTime hasta, int estadoId)
        {
            List <Parametro> parametros = new List<Parametro>();
            string sp  = "SP_CONSULTAR_PEDIDOS";
            parametros.Add(new Parametro("@desde", desde));
            parametros.Add(new Parametro("@hasta", hasta));
            parametros.Add(new Parametro("@estado", estadoId));


            DataTable tabla = DBHelper.GetInstancia().Consultar(sp, parametros);
            List<Pedido> lista = new List<Pedido>();

            foreach (DataRow row in tabla.Rows)
            {

                lista.Add(new Pedido()
                {
                    Id = Convert.ToInt32(row["id"]),
                    NombreCliente = row["NombreCliente"].ToString(),
                    CuitCliente = row["CuitCliente"].ToString(),
                    CorreoCliente = row["CorreoCliente"].ToString(),
                    FechaPedido = Convert.ToDateTime(row["FechaPedido"].ToString()),
                    FechaEntrega = Convert.ToDateTime(row["FechaEntrega"].ToString()),
                    Estado = new Estado() { Id = Convert.ToInt32(row["Estado_id"]), Nombre= row["NombreEstado"].ToString(), }


                }) ;
            }

            return lista;
        }


        public List<DetallePedido> ObtenerDetalle(int id)
        {
            List<DetallePedido> lista = new List<DetallePedido> ();

            List<Parametro> parametros = new List<Parametro>();
            string sp = "SP_CONSULTAR_DETALLE_PEDIDO";
            parametros.Add(new Parametro("@id", id));
           


            DataTable tabla = DBHelper.GetInstancia().Consultar(sp, parametros);
           

            foreach (DataRow row in tabla.Rows)
            {

                lista.Add(new DetallePedido()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Product = new Producto() { id = Convert.ToInt32(row["Producto_id"]), Nombre = row["NombreProducto"].ToString() },
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    Precio = (float)Convert.ToDecimal(row["Precio"].ToString()),
                    Costo = (float)Convert.ToDecimal(row["Costo"].ToString())

                });
            }

            return lista;
        }


        public bool CambiarEstado(Pedido pedido)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                string sp = "SP_CAMBIAR_ESTADO_PEDIDO";
                parametros.Add(new Parametro("@pedidoId", pedido.Id));
                parametros.Add(new Parametro("@estadoId", pedido.Estado.Id));
                


                DBHelper.GetInstancia().Consultar(sp, parametros);
               

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
