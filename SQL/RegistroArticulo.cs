using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articulo;

namespace SQL
{
    
    public class RegistroArticulo
    {
        public List <Articulos> listar(string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion as Marca, IdCategoria, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id")
        {
            List<Articulos> lista = new List<Articulos>();
            AccesoDatos sql = new AccesoDatos();        
            try
            {
          
                sql.prepararConsulta(consulta);
                sql.realizarConsulta();

                while (sql.Lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)sql.Lector["Id"];
                    aux.Codigo = (string)sql.Lector["Codigo"];
                    aux.Nombre = (string)sql.Lector["Nombre"];
                    aux.Descripcion = (string)sql.Lector["Descripcion"]; 
                    aux.Marca = new Caracteristica();
                    aux.Marca.Id = (int)sql.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)sql.Lector["Marca"];
                    aux.Categoria = new Caracteristica();
                    aux.Categoria.Id = (int)sql.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)sql.Lector["Categoria"];
                    aux.UrlImagen = (string)sql.Lector["ImagenUrl"];
                    aux.Precio = (decimal)sql.Lector["Precio"];
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

        public void agregar(Articulos aux)
        {
            AccesoDatos sql = new AccesoDatos();
            try
            {
                sql.cambiarParametro("@Codigo", aux.Codigo);
                sql.cambiarParametro("@Nombre", aux.Nombre);
                sql.cambiarParametro("@Descripcion", aux.Descripcion);
                sql.cambiarParametro("@IdMarca", aux.Marca.Id);
                sql.cambiarParametro("@IdCategoria", aux.Categoria.Id);
                sql.cambiarParametro("@ImagenUrl", aux.UrlImagen);
                sql.cambiarParametro("Precio",aux.Precio);
                sql.prepararConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio)");
                sql.ejecutarCambio();
                sql.cerrarConexion();

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public void modificar(Articulos aux)
        {
            AccesoDatos sql = new AccesoDatos();

            try
            {
                sql.cambiarParametro("@Id", aux.Id);
                sql.cambiarParametro("@Codigo",aux.Codigo);
                sql.cambiarParametro("@Nombre",aux.Nombre);
                sql.cambiarParametro("@Descripcion", aux.Descripcion);
                sql.cambiarParametro("@IdMarca",aux.Marca.Id);
                sql.cambiarParametro("@IdCategoria",aux.Categoria.Id);
                sql.cambiarParametro("@ImagenUrl", aux.UrlImagen);
                sql.cambiarParametro("@Precio", aux.Precio);
                sql.prepararConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl = @ImagenUrl, Precio = @Precio where Id=@Id");
                sql.ejecutarCambio();
                sql.cerrarConexion();
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            AccesoDatos sql = new AccesoDatos();
            try
            {
                sql.cambiarParametro("@Id", id);
                sql.prepararConsulta("delete ARTICULOS where Id=@Id");
                sql.ejecutarCambio();
                sql.cerrarConexion();

            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulos>filtrar(string campo, string criterio, string filtro)
        {
            List<Articulos> lista ;
            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, IdMarca, M.Descripcion as Marca, IdCategoria, C.Descripcion as Categoria, ImagenUrl, Precio from ARTICULOS A, MARCAS M, CATEGORIAS C Where A.IdMarca = M.Id and A.IdCategoria = C.Id and ";
                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Marca":
                        consulta += "M.Descripcion like '%" + criterio + "%'";
                        break;
                    case "Categoria":
                        consulta += "C.Descripcion like '%" + criterio + "%'";
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "Precio >" + filtro;
                                break;
                            case "Menor a":
                                consulta += "Precio <" + filtro;
                                break;
                            default:
                                consulta += "Precio =" + filtro;
                                break;
                        }
                        break;
                }

                return lista = listar(consulta);
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
