using Microsoft.Win32;
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

namespace Auto_limpioExpres
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Registro> registros = new List<Registro>();

        int autos = 0;
        int camionetas = 0;
        int suvs = 0;

        int clientesSalon = 0;

        decimal totalRecaudado = 0;

        public MainWindow()
        {
            InitializeComponent();
            lvHistorial.ItemsSource = registros;
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPlaca.Text.Length == 0)
            {
                MessageBox.Show("Ingrese placa");
                return;
            }

            string tipoVehiculo = "";
            decimal total = 0;

            if (rbAuto.IsChecked == true)
            {
                tipoVehiculo = "Auto";
                total += 20;
                autos++;
            }
            else if (rbCamioneta.IsChecked == true)
            {
                tipoVehiculo = "Camioneta";
                total += 30;
                camionetas++;
            }
            else if (rbSUV.IsChecked == true)
            {
                tipoVehiculo = "SUV";
                total += 35;
                suvs++;
            }

            int extras = 0;

            if (cbEncerado.IsChecked == true)
            {
                total += 15;
                extras++;
            }

            if (cbMotor.IsChecked == true)
            {
                total += 20;
                extras++;
            }

            if (cbSalon.IsChecked == true)
            {
                total += 25;
                extras++;

                clientesSalon++;
            }

            if (extras == 3)
            {
                total -= 10;
            }

            lbTotal.Content = $"Total: S/. {total}";

            Registro nuevo = new Registro();

            nuevo.Placa = txtPlaca.Text;
            nuevo.TipoVehiculo = tipoVehiculo;
            nuevo.ServiciosExtras = extras;
            nuevo.TotalPagar = total;

            registros.Add(nuevo);

            lvHistorial.ItemsSource = null;
            lvHistorial.ItemsSource = registros;

            totalRecaudado += total;

            lbAutos.Content = $"Autos: {autos}";
            lbCamionetas.Content = $"Camionetas: {camionetas}";
            lbSUV.Content = $"SUV: {suvs}";
            lbRecaudado.Content = $"Total Recaudado: S/. {totalRecaudado}";
            lbSalon.Content = $"Clientes con Limpieza Salón: {clientesSalon}";

            Limpiar();
        }

        private void Limpiar()
        {
            txtPlaca.Clear();

            rbAuto.IsChecked = false;
            rbCamioneta.IsChecked = false;
            rbSUV.IsChecked = false;

            cbEncerado.IsChecked = false;
            cbMotor.IsChecked = false;
            cbSalon.IsChecked = false;
        }

    }
}