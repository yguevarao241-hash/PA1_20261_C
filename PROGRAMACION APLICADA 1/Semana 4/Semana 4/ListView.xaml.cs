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
    /// Lógica de interacción para ListView.xaml
    /// </summary>
    public partial class ListView : Window
    {
        List<Alumno> alumnos = new List<Alumno>();
        public ListView()
        {
            InitializeComponent();
            alumnos.Add(new Alumno("Juan", "Perez", 30));
            alumnos.Add(new Alumno("Carlos", "Aguilar", 40));

            lvAlumnos.ItemsSource = alumnos;
        }
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Alumno nuevo = new Alumno(
                txtNombre.Text,
                txtApellidos.Text,
                Int32.Parse(txtEdad.Text)
                );
            alumnos.Add(nuevo);
            lvAlumnos.ItemsSource = null;
            lvAlumnos.ItemsSource = alumnos;

        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = (Alumno)lvAlumnos.SelectedItem;

            MessageBox.Show($"Alumno Seleccionado: {alumno.Nombres} {alumno.Apellidos} de {alumno.Edad} años");
        }
    }

}
