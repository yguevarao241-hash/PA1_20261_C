using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registrar_clientes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        int escolares = 0;
        
        int universitarios = 0;
        int organizacionales = 0;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            string tarifa = "";
            double precio = 0;

            int cantidad = int.Parse(txtCantidad.Text);

            if (rbEscolar.IsChecked == true)
            {
                tarifa = "Escolar";
                precio = 0.10;
                escolares++;
            }
            else if (rbUniversitarios.IsChecked == true)
            {
                tarifa = "Universitario";
                precio = 0.20;
                universitarios++;
            }
            else if (rbOrganizacion.IsChecked == true)
            {
                tarifa = "Organización";
                precio = 0.30;
                organizacionales++;
            }

            double importe = cantidad * precio;

            lstCliente.Items.Add(txtCliente.Text);
            lstCelular.Items.Add(txtCelular.Text);
            lstCantidad.Items.Add(cantidad);
            lstTarifa.Items.Add(tarifa);
            lstImporte.Items.Add(importe.ToString("F2"));

            Limpiar();
        }

        private void Limpiar()
        {
            txtCliente.Clear();
            txtCelular.Clear();
            txtCantidad.Clear();

            rbEscolar.IsChecked = false;
            rbUniversitarios.IsChecked = false;
            rbOrganizacion.IsChecked = false;

            txtCliente.Focus();
        }

        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            txtEscolares.Text = escolares.ToString();
            rbUniversitarios.Content = universitarios.ToString();
            txtOrganizacionales.Text = organizacionales.ToString();
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}