using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Articulos.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion Marca, CATEGORIAS.Descripcion Categoria,ImagenUrl, Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)lector["Id"];
                    aux.codigo = (string)lector["Codigo"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.descripcion = (string)lector["Descripcion"];
                    //aux.marca = (int)lector["IdMarca"];
                    //aux.descripcionMarca = (string)lector["Marca"];
                    aux.marca = new Marca();
                    aux.marca.descripcion= (string)lector["Marca"];

                    //aux.categoria = (int)lector["IdCategoria"];
                    //aux.descripcionCategoria = (string)lector["Categoria"];
                    aux.categoria = new Categoria();
                    aux.categoria.descripcion= (string)lector["Categoria"];

                    aux.Url = (string)lector["imagenUrl"];
                    aux.precio = (decimal)lector["Precio"];
                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public Articulo buscarArticulo(Articulo articulo, int criterio)
        {

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;         


            try
            {
                
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.id, Codigo, Nombre, A.Descripcion AS DART, IdMarca, M.descripcion DMAR, IdCategoria, C.descripcion DCAT, ImagenUrl, Precio " +
                     "FROM articulos A, marcas M, categorias C " +
                    "WHERE (A.IdMarca = M.Id AND A.IdCategoria = c.Id) AND ";
  
                switch (criterio)
                {
                    case 0:
                        comando.CommandText += "A.id = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.id);
                        break;
                    case 1:
                        comando.CommandText += "Codigo = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.codigo);
                        break;
                    case 2:
                        comando.CommandText += "Nombre = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.nombre);
                        break;
                    case 3:
                        comando.CommandText += "Descripcion = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.descripcion);
                        break;
                    case 4:
                        comando.CommandText += "IdMarca = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.marca.id);
                        break;
                    case 5:
                        comando.CommandText += "IdCategoria = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.categoria.id);
                        break;
                    case 6:
                        comando.CommandText += "Precio = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.precio);
                        break;
                }

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                if(lector.Read())
                {
                    articulo.id = (int)lector["id"];
                    articulo.codigo = (string)lector["Codigo"];
                    articulo.nombre = (string)lector["Nombre"];
                    articulo.descripcion = (string)lector["DART"];
                    articulo.marca = new Marca();
                    articulo.marca.id = (int)lector["IdMarca"];
                    articulo.marca.descripcion = (string)lector["DMAR"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.id = (int)lector["IdCategoria"];
                    articulo.categoria.descripcion= (string)lector["DCAT"];
                    articulo.Url = (string)lector["imagenUrl"];
                    articulo.precio = (decimal)lector["Precio"];      
                }
                else
                {
                    articulo.id = -1;
                }
                conexion.Close();
                return articulo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Articulo> buscarArticuloXcriterio(Articulo articulo, int criterio)
        {
            List<Articulo> articulos = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.id, Codigo, Nombre, A.Descripcion AS DART, IdMarca, M.descripcion DMAR, IdCategoria, C.descripcion DCAT, ImagenUrl, Precio " +
                     "FROM articulos A, marcas M, categorias C " +
                    "WHERE (A.IdMarca = M.Id AND A.IdCategoria = c.Id) AND ";
                switch (criterio)
                {
                    case 0:
                        comando.CommandText += "A.id = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.id);
                        break;
                    case 1:
                        comando.CommandText += "Codigo = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.codigo);
                        break;
                    case 2:
                        comando.CommandText += "Nombre = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.nombre);
                        break;
                    case 3:
                        comando.CommandText += "A.Descripcion = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.descripcion);
                        break;
                    case 4:
                        comando.CommandText += "M.descripcion = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.marca.descripcion);
                        break;
                    case 5:
                        comando.CommandText += "C.descripcion = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.categoria.descripcion);
                        break;
                    case 6:
                        comando.CommandText += "Precio = @criterio";
                        comando.Parameters.AddWithValue("@criterio", articulo.precio);
                        break;
                }

                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)lector["id"];
                    aux.codigo = (string)lector["Codigo"];
                    aux.nombre = (string)lector["Nombre"];
                    aux.descripcion = (string)lector["DART"];
                    aux.marca = new Marca();
                    aux.marca.id = (int)lector["IdMarca"];
                    aux.marca.descripcion = (string)lector["DMAR"];
                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)lector["IdCategoria"];
                    aux.categoria.descripcion = (string)lector["DCAT"];
                    aux.Url = (string)lector["imagenUrl"];
                    aux.precio = (decimal)lector["Precio"];

                    articulos.Add(aux);
                }
                
                conexion.Close();
                return articulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int getMaxId()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            int maxId;
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT Id FROM ARTICULOS where Id = (SELECT MAX(Id) FROM articulos)";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                lector.Read();

                maxId = (int)lector["Id"];

                conexion.Close();
                return ++maxId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public void agregarArticulo(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO articulos(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) " +
                    "VALUES (@codigo, @Nombre, @descripcion, @marca, @categoria, @imagen, @precio)";

                comando.Parameters.AddWithValue("@codigo", articulo.codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.nombre);
                comando.Parameters.AddWithValue("@descripcion", articulo.descripcion);
                comando.Parameters.AddWithValue("@marca", articulo.marca.id);
                comando.Parameters.AddWithValue("@categoria", articulo.categoria.id);
                comando.Parameters.AddWithValue("@imagen", articulo.Url);
                comando.Parameters.AddWithValue("@precio", articulo.precio);

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void modificarArticulo(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "UPDATE articulos " +
                    "SET  Nombre = @Nombre, Descripcion = @descripcion, IdMarca = @marca, " +
                    "IdCategoria = @categoria, ImagenUrl = @imagen, Precio = @precio " +
                    "WHERE codigo = @codigo";

                comando.Parameters.AddWithValue("@codigo", articulo.codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.nombre);
                comando.Parameters.AddWithValue("@descripcion", articulo.descripcion);
                comando.Parameters.AddWithValue("@marca", articulo.marca.id);
                comando.Parameters.AddWithValue("@categoria", articulo.categoria.id);
                comando.Parameters.AddWithValue("@imagen", articulo.Url);
                comando.Parameters.AddWithValue("@precio", articulo.precio);

                comando.Connection = conexion;
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Articulo> mostrarDetalle(string id)
        {
            List<Articulo> auxiliar = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Articulos.Id, Codigo, Nombre, ARTICULOS.Descripcion, MARCAS.Descripcion Marca, CATEGORIAS.Descripcion Categoria,ImagenUrl, Precio FROM ARTICULOS INNER JOIN MARCAS ON ARTICULOS.IdMarca = MARCAS.Id INNER JOIN CATEGORIAS ON ARTICULOS.IdCategoria = CATEGORIAS.Id WHERE ARTICULOS.Id='" + id + "'");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.marca = new Marca();
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                    aux.categoria = new Categoria();
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    aux.Url = (string)datos.Lector["imagenUrl"];
                    aux.precio = (decimal)datos.Lector["Precio"];
                    auxiliar.Add(aux);
                }
                datos.cerrarConexion();
                return auxiliar;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void eliminarArticulo(string id)
        {
            List<Articulo> auxiliar = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE ARTICULOS.Id = '" + id + "' ");
                datos.ejecutarLectura();
                datos.cerrarConexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
