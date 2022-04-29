using System;
using System.Collections.Generic;
using System.Windows;
using Business;
using Entity;

namespace DAEA_LAB06_JE
{
    public partial class ManProducto : Window
    {

        public int ID { get; set; }

        public ManProducto(int Id)
        {
            InitializeComponent();

            ID = Id;

            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);

                if (productos.Count > 0)
                {
                    lblID.Content = productos[0].IdProducto.ToString();
                    txtNombreProducto.Text = productos[0].NombreProducto;
                    txtIdCategoria.Text = productos[0].IdCategoria.ToString(); 
                    txtCategoria.Text = productos[0].CategoriaProducto;
                    txtCantidadxUnidad.Text = productos[0].CantidadPorUnidad;
                    txtPrecio.Text = productos[0].PrecioUnidad.ToString();
                    txtEnExistencia.Text = productos[0].UnidadesEnExistencia.ToString(); 
                    txtEnPedido.Text = productos[0].UnidadesEnPedido.ToString();
                    txtNivel.Text = productos[0].NivelNuevoPedido.ToString();
                    txtSuspendido.Text = productos[0].Suspendido.ToString();
                }
            }
            else
            {
                btnEliminar.IsEnabled = false;
            }
        }

      
        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                //listar todas las categorias
                bProducto = new BProducto();
                if (ID > 0)
                {
                    result = bProducto.Actualizar(new Producto
                    {
                        IdProducto = ID,
                        NombreProducto = Convert.ToString(txtNombreProducto.Text),
                        IdCategoria = Convert.ToInt32(txtIdCategoria.Text),
                        CategoriaProducto = Convert.ToString(txtCategoria.Text),
                        CantidadPorUnidad = Convert.ToString(txtCantidadxUnidad.Text) ,
                        PrecioUnidad = Convert.ToInt32(txtPrecio.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtEnExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtEnPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivel.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text) 
                });
                }
                else
                {
                    result = bProducto.Insertar(new Producto
                    {
                        NombreProducto = Convert.ToString(txtNombreProducto.Text),
                        IdCategoria = Convert.ToInt32(txtIdCategoria.Text),
                        CategoriaProducto = Convert.ToString(txtCategoria.Text),
                        CantidadPorUnidad = Convert.ToString(txtCantidadxUnidad.Text),
                        PrecioUnidad = Convert.ToInt32(txtPrecio.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtEnExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtEnPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivel.Text),
                        Suspendido = Convert.ToInt32(txtSuspendido.Text)
                    });
                }
                if (!result)
                {
                    MessageBox.Show($"Comunicarse con el Administrador -> {result}");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Comunicarse con el Administrador -> {ex}");
            }
            finally
            {
                bProducto = null;
            }
        }
        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;
            try
            {
                //1° se lista todas las categorias
                bProducto = new BProducto();

                //2° eliminar el registro
                result = bProducto.Eliminar(ID,1);
                if (!result)
                {
                    MessageBox.Show("Debe estar suspendido el producto para eliminarlo");
                }
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally
            {
                bProducto = null;
            }
        }

    }
}
