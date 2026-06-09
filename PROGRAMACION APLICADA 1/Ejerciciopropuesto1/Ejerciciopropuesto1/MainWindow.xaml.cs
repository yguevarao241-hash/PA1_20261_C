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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtIngreso.Text, out var ingreso))
            {
                MessageBox.Show("Por favor, ingrese un monto válido en el Ingreso.");
                return;
            }

            var fonavi = chkFonavi.IsChecked == true ? ingreso * 0.08 : 0;
            var renta = chkImpRenta.IsChecked == true ? ingreso * 0.05 : 0;
            var afp = chkAFP.IsChecked == true ? ingreso * 0.12 : 0;

            var totalPagar = ingreso - fonavi - renta - afp;

            txtResultadoFonavi.Text = fonavi.ToString("C");
            txtResultadoRenta.Text = renta.ToString("C");
            txtResultadoAFP.Text = afp.ToString("C");
            txtResultadoTotal.Text = totalPagar.ToString("C");
        }
    }
}
