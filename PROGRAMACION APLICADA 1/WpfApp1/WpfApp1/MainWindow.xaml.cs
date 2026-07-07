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

namespace WpfApp1
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

        private void btSuma_Click(object sender, RoutedEventArgs e)
        {
            double n1 = Convert.ToDouble(txtNumero1.Text);
            double n2 = Convert.ToDouble(txtNumero2.Text);
            txtResultado.Text = (n1 + n2).ToString();
        }

        private void btResta_Click(object sender, RoutedEventArgs e)
        {
            double n1 = Convert.ToDouble(txtNumero1.Text);
            double n2 = Convert.ToDouble(txtNumero2.Text);
            txtResultado.Text = (n1 - n2).ToString();
        }

        private void btMultilplicacion_Click(object sender, RoutedEventArgs e)
        {
            double n1 = Convert.ToDouble(txtNumero1.Text);
            double n2 = Convert.ToDouble(txtNumero2.Text);

            txtResultado.Text = (n1 * n2).ToString();
        }

        private void btDivision_Click(object sender, RoutedEventArgs e)
        {
            double n1 = Convert.ToDouble(txtNumero1.Text);
            double n2 = Convert.ToDouble(txtNumero2.Text);

            if (n2 != 0)
            {
                txtResultado.Text = (n1 / n2).ToString();
            }
            else
            {
                MessageBox.Show("No se puede dividir entre cero.");
            }
        }
    }
}