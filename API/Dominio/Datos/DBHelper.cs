using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using Fabrica.datos;
using System.Drawing;

namespace Fabrica.Datos
{
    //hola
    public class DBHelper
    {
        private static DBHelper instancia = null;
        private SqlConnection conexion;
        
        private DBHelper()
        {
            //conexion de pedrito
            //conexion = new SqlConnection(@"Data Source=DESKTOP-9MCMVDM\SQLEXPRESS;Initial Catalog=Fabrica;Integrated Security=True");

            //CONEXION DE TUCA
            conexion = new SqlConnection(@"Data Source = localhost; Initial Catalog = Fabrica; User ID = sa; Password = test");

            //conexion = new SqlConnection(@"Data Source=localhost\\SQLEXPRESS; Initial Catalog=Fabrica;user id =sa; password=test;TrustServerCertificate=True");
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
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();
            return tabla;   
        }

        public DataTable Consultar(string nombreSP, List<Parametro> values)
        {
            DataTable tabla = new DataTable();

            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }
            SqlCommand cmd = new SqlCommand(nombreSP, conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
            {
                foreach (Parametro oParametro in values)
                {
                    cmd.Parameters.AddWithValue(oParametro.Clave, oParametro.Valor);
                }
            }
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();

            return tabla;
        }
    }
    
}
