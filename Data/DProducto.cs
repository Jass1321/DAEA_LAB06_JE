using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<Producto> productos = null;
            try
            {
                commandText = "USP_GetProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();

                Console.WriteLine(SQLHelper.Connection);
                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["idproducto"] != null ? Convert.ToInt32(reader["idproducto"]) : 0,
                            NombreProducto = reader["nombreProducto"] != null ? Convert.ToString(reader["nombreProducto"]) : string.Empty,
                            IdCategoria = reader["idCategoria"] != null ? Convert.ToInt32(reader["idCategoria"]) : 0,
                            CategoriaProducto = reader["categoriaProducto"] != null ? Convert.ToString(reader["categoriaProducto"]) : string.Empty,
                            CantidadPorUnidad = reader["cantidadPorUnidad"] != null ? Convert.ToString(reader["cantidadPorUnidad"]) : string.Empty,
                            PrecioUnidad = reader["precioUnidad"] != null ? Convert.ToInt32(reader["precioUnidad"]) : 0,
                            UnidadesEnExistencia = reader["unidadesEnExistencia"] != null ? Convert.ToInt32(reader["unidadesEnExistencia"]) : 0,
                            UnidadesEnPedido = reader["unidadesEnPedido"] != null ? Convert.ToInt32(reader["unidadesEnPedido"]) : 0,
                            NivelNuevoPedido = reader["nivelNuevoPedido"] != null ? Convert.ToInt32(reader["nivelNuevoPedido"]) : 0,
                            Suspendido = reader["suspendido"] != null ? Convert.ToInt32(reader["suspendido"]) : 0,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productos;
        }

        public void Eliminar(int IdProducto, int Suspendido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_DelProducto";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                parameters[1] = new SqlParameter("@suspendido", SqlDbType.Int);
                parameters[1].Value = Suspendido;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_InsProducto";
                parameters = new SqlParameter[9];
                parameters[0] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@idCategoria", SqlDbType.Int);
                parameters[1].Value = producto.IdCategoria;
                parameters[2] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar);
                parameters[2].Value = producto.CategoriaProducto;
                parameters[3] = new SqlParameter("@cantidadPorUnidad", SqlDbType.VarChar);
                parameters[3].Value = producto.CantidadPorUnidad;
                parameters[4] = new SqlParameter("@precioUnidad", SqlDbType.Int);
                parameters[4].Value = producto.PrecioUnidad;
                parameters[5] = new SqlParameter("@unidadesEnExistencia", SqlDbType.Int);
                parameters[5].Value = producto.UnidadesEnExistencia;
                parameters[6] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
                parameters[6].Value = producto.UnidadesEnPedido;
                parameters[7] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
                parameters[7].Value = producto.NivelNuevoPedido;
                parameters[8] = new SqlParameter("@suspendido", SqlDbType.Int);
                parameters[8].Value = producto.Suspendido;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            try
            {
                commandText = "USP_UpdProducto";
                parameters = new SqlParameter[10];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                parameters[1] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[1].Value = producto.NombreProducto;
                parameters[2] = new SqlParameter("@idCategoria", SqlDbType.Int);
                parameters[2].Value = producto.IdCategoria;
                parameters[3] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar);
                parameters[3].Value = producto.CategoriaProducto;
                parameters[4] = new SqlParameter("@cantidadPorUnidad", SqlDbType.VarChar);
                parameters[4].Value = producto.CantidadPorUnidad;
                parameters[5] = new SqlParameter("@precioUnidad", SqlDbType.Int);
                parameters[5].Value = producto.PrecioUnidad;
                parameters[6] = new SqlParameter("@unidadesEnExistencia", SqlDbType.Int);
                parameters[6].Value = producto.UnidadesEnExistencia;
                parameters[7] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
                parameters[7].Value = producto.UnidadesEnPedido;
                parameters[8] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
                parameters[8].Value = producto.NivelNuevoPedido;
                parameters[9] = new SqlParameter("@suspendido", SqlDbType.Int);
                parameters[9].Value = producto.Suspendido;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, commandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
