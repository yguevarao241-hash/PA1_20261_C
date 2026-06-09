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

namespace Ejercicio_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtIngreso.Text, out double ingreso))
            {
                double fonavi = 0;//variables 
                double renta = 0;
                double afp = 0;

                if (chkFonavi.IsChecked == true) fonavi = ingreso * 0.08;//formulario de conversion
                if (chkImpRenta.IsChecked == true) renta = ingreso * 0.05;
                if (chkAFP.IsChecked == true) afp = ingreso * 0.12;

                double totalPagar = ingreso - (fonavi + renta + afp);

                txtResultadoFonavi.Text = fonavi.ToString("C");// para pasar a modo dinero
                txtResultadoRenta.Text = renta.ToString("C");
                txtResultadoAFP.Text = afp.ToString("C");
                txtResultadoTotal.Text = totalPagar.ToString("C");
            }
            else
            {
                MessageBox.Show("Ingrese monto valido");
            }
        }
    }
}