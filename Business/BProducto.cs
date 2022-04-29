using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;
using Data;

namespace Business
{
    public class BProducto
    {
        private DProducto dProducto = null;
        public List<Producto> Listar(int IdProducto)
        {
            List<Producto> productos = null;
            try
            {
                dProducto = new DProducto();
                productos = dProducto.Listar(new Producto { IdProducto = IdProducto });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return productos;
        }

        public bool Insertar(Producto producto)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();
                dProducto.Insertar(producto);
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool Actualizar(Producto producto)
        {
            bool result = true;

            try
            {
                dProducto = new DProducto();
                dProducto.Actualizar(producto);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool Eliminar(int IdProducto, int Suspendido)
        {
            bool result = true;
            try
            {
                dProducto = new DProducto();
                dProducto.Eliminar(IdProducto, Suspendido);
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
