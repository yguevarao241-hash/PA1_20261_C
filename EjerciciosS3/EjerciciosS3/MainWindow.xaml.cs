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

namespace EjerciciosS3
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

        private void btAplicar_Click(object sender, RoutedEventArgs e)
        {
            lbtexto.FontFamily = new FontFamily("Segoe UI");
            lbtexto.Foreground = Brushes.Black;
            lbtexto.Background = Brushes.Transparent;
            if(cbTipoLetra.IsChecked==true)
            {
                lbtexto.FontFamily = new FontFamily("Consolas");
            }
            if(cbColorTexto.IsChecked == true)
            {
                lbtexto.Foreground = Brushes.Black;
            }
            if(cbColorFondo.IsChecked==true)
            {
                lbtexto.Background = Brushes.Black;
            }
        }

        private void btnAplicarRadio_Click(object sender, RoutedEventArgs e)
        {
            lbTextoRadio.FontFamily = new FontFamily("Segoe UI");
            lbTextoRadio.Foreground = Brushes.Black;
            lbTextoRadio.Background = Brushes.Transparent;
            if (rbTipoLetra.IsChecked == true)
            {
                lbTextoRadio.FontFamily = new FontFamily("Consolas");
            }
            if (rbColorTexto.IsChecked == true)
            {
                lbTextoRadio.Foreground = Brushes.Black;
            }
            if (rbColorFondo.IsChecked == true)
            {
                lbTextoRadio.Background = Brushes.Black;
            }
        }
    }
}