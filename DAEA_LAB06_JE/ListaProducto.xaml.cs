using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using Business;
using Entity;

namespace DAEA_LAB06_JE
{
    public partial class ListaProducto : Window
    {
        public ListaProducto()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BProducto bProducto = null;
            try
            {
                //0:Listar todas las categorias
                bProducto = new BProducto();
                dgvProducto.ItemsSource = bProducto.Listar(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Comunicarse con el admin -> {ex}");
            }
            finally
            {
                bProducto = null;
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            //se coloca 0 pq es nuevo
            ManProducto manProducto = new ManProducto(0);
            manProducto.ShowDialog();
            Cargar();
        }

        private void dgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idProducto = 0;
            var item = (Producto)dgvProducto.SelectedItem;
            if (null == item) return;
            idProducto = Convert.ToInt32(item.IdProducto);

            ManProducto manProducto = new ManProducto(idProducto);
            manProducto.ShowDialog();
            Cargar();
        }
    }
}
