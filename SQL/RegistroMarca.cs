using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articulo;

namespace SQL
{
    public class RegistroMarca
    {
        public List<Caracteristica> listar()
        {
            AccesoDatos sql = new AccesoDatos();
            List<Caracteristica> lista = new List<Caracteristica>();
            try
            {
                sql.prepararConsulta("select Id, Descripcion from MARCAS");
                sql.realizarConsulta();
                while(sql.Lector.Read())
                {
                    Caracteristica aux = new Caracteristica();
                    aux.Id = (int)sql.Lector["Id"];
                    aux.Descripcion = (string)sql.Lector["Descripcion"];
                    lista.Add(aux);
                }

                return lista;
            }catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sql.cerrarConexion();
            }
        }
    }
}
