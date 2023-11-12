using Dominio.Datos;
using Fabrica.datos;
using Fabrica.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fabrica.Datos
{
    public class EstadoDAO : IEstadoDao
    {
    

        public List<Estado> ObtenerEstados()
        {
            List <Parametro> parametros = new List<Parametro>();
            string sp  = "SP_CONSULTAR_ESTADOS";
               
            DataTable tabla = DBHelper.GetInstancia().Consultar(sp, parametros);
            List<Estado> lista = new List<Estado>();

            foreach (DataRow row in tabla.Rows)
            {
                
                lista.Add(new Estado()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nombre = row["Nombre"].ToString()

                });
            }

            return lista;
        }
    }
}
