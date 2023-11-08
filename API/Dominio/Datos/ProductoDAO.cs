using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class ProductoDAO : IProductoDato
    {
        

        //public bool CrearOrden(OrdenProduccion equipo)
        //{
        //    bool aux = true;
        //    SqlConnection conexion = DBHelper.GetInstancia().GetConnection();
        //    SqlTransaction t = null;
        //    try
        //    {
        //        conexion.Open();
        //        t = conexion.BeginTransaction();
        //        SqlCommand cmd = new SqlCommand("SP_INSERTAR_MAESTRO", conexion, t);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlParameter p = new SqlParameter("@nro_orden", SqlDbType.Int);
        //        p.Direction = System.Data.ParameterDirection.Output;
        //        cmd.Parameters.Add(p);
        //        cmd.Parameters.AddWithValue("@fecha", equipo.Fecha);
        //        cmd.Parameters.AddWithValue("@modelo", equipo.Modelo);
        //        cmd.Parameters.AddWithValue("@estado", equipo.Estado);
        //        cmd.Parameters.AddWithValue("@cantidad", equipo.Cantidad);
        //        cmd.ExecuteNonQuery();

        //        int nroOrden = (int)p.Value;

        //        foreach (DetalleOrden det in equipo.ListaDetalles)
        //        {
        //            SqlCommand cmd2 = new SqlCommand("SP_INSERTAR_DETALLE", conexion, t);
        //            cmd2.CommandType = CommandType.StoredProcedure;
        //            cmd2.Parameters.AddWithValue("@nro_orden", nroOrden);
        //            cmd2.Parameters.AddWithValue("@id", det.Id);
        //            cmd2.Parameters.AddWithValue("@componente", det.Componente.Codigo);
        //            cmd2.Parameters.AddWithValue("@cantidad", det.Cantidad);
        //            cmd2.ExecuteNonQuery();

        //        }
        //        t.Commit();
        //    }
        //    catch(Exception ex)
        //    {
        //        if(t != null)
        //        {
        //            aux = false;
        //            t.Rollback();
        //        }
        //    }
        //    finally
        //    {
        //        if(conexion != null && conexion.State == ConnectionState.Open)
        //        {
        //            conexion.Close();
        //        }
        //    }


        //    return aux;
        //}

        public List<Producto> ObtenerProductos()
        {
            DataTable tabla = DBHelper.GetInstancia().Consultar("CONSULTAR_PRODUCTOS");
            List<Producto> lista = new List<Producto>();

            foreach (DataRow row in tabla.Rows)
            {
                
                lista.Add(new Producto()
                {
                    id = Convert.ToInt32(row["id"]),
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Nombre"].ToString(),
                    Imagen = row["Imagen"].ToString(),
                    Precio = (float)Convert.ToDecimal(row["Precio"].ToString()),
                    Costo = (float)Convert.ToDecimal(row["Costo"].ToString())

                });
            }

            return lista;
        }
    }
}
