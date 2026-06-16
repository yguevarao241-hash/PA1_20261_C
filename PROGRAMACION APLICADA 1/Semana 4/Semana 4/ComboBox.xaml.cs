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

namespace Semana_4
{
    /// <summary>
    /// Lógica de interacción para ComboBox.xaml
    /// </summary>
    public partial class ComboBox : Window
    {
        public ComboBox()
        {
            InitializeComponent();
        }
        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFrutas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }
            ComboBoxItem seleccionado = (ComboBoxItem)cmbFrutas.SelectedItem;
            string valorSeleccionado = seleccionado.Content.ToString();

            MessageBox.Show($"Fruta Seleccionada: {valorSeleccionado}");

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem nuevoItem = new ComboBoxItem();
            nuevoItem.Content = txtNuevo.Text.ToUpper();

            cmbFrutas.Items.Add(nuevoItem);

            txtNuevo.Clear();
        }
    }
}
