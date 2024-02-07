using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articulo;

namespace SQL
{
    public class RegistroCategoria
    {
        public List<Caracteristica> listar()
        {
            List<Caracteristica> lista = new List<Caracteristica>();
            AccesoDatos sql = new AccesoDatos();
            try
            {
                sql.prepararConsulta("select Id, Descripcion from CATEGORIAS");
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
