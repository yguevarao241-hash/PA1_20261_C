using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace semana4
{
    /// <summary>
    /// Lógica de interacción para ListBox.xaml
    /// </summary>
    public partial class ListBox : Window
    {
        public ListBox()
        {
            InitializeComponent();
        }



        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if (LbFrutas.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una fruta");
                return;
            }

            ListBoxItem listBoxItem = LbFrutas.SelectedItem as ListBoxItem;

            string valorSeleccionado = listBoxItem.Content.ToString();

            MessageBox.Show($"Fruta Seleccionada: {valorSeleccionado}");
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem nuevo = new ListBoxItem();

            nuevo.Content = txtNuevo.Text;

            LbFrutas.Items.Add(nuevo);

            txtNuevo.Clear();
        }
    }
}

