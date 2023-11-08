using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Datos
{
    public class DBHelper
    {
        private static DBHelper instancia = null;
        private SqlConnection conexion;
        
        private DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=localhost\\SQLEXPRESS; Initial Catalog=Fabrica;user id =sa; password=test;TrustServerCertificate=True");
        }
        
        public static DBHelper GetInstancia()
        {
            if (instancia == null)
                instancia = new DBHelper();
            return instancia;
        }

        public SqlConnection GetConnection()
        {
            return conexion;
        }


        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;   
        }
    }
}
