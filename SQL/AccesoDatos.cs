using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL
{
     
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand cmd; 
        private SqlDataReader lector;

        public SqlDataReader Lector 
        {  
            get { return lector;}
        }

        public AccesoDatos()
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            cmd = new SqlCommand();
        }

        public void prepararConsulta(string consulta)
        {

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = consulta;
        }

        public void realizarConsulta()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                lector = cmd.ExecuteReader();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if(lector != null)
            {
                lector.Close();
                conexion.Close();
            }
        }

        public void cambiarParametro(string parametro, object valor)
        {
            cmd.Parameters.AddWithValue(parametro, valor);
        }

        public void ejecutarCambio()
        {
            cmd.Connection = conexion;
            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
