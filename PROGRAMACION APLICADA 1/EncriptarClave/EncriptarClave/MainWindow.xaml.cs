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

namespace EncriptarClave
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
        private void btnEncriptar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Ingrese una clave.",
                    "Validación",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            string clave = txtClave.Text;
            string claveEncriptada = "";

            foreach (char letra in clave)
            {
                if (letra >= 'a' && letra <= 'z')
                {
                    if (letra == 'z')
                        claveEncriptada += 'a';
                    else
                        claveEncriptada += (char)(letra + 1);
                }
                else if (letra >= 'A' && letra <= 'Z')
                {
                    if (letra == 'Z')
                        claveEncriptada += 'A';
                    else
                        claveEncriptada += (char)(letra + 1);
                }
                else if (char.IsDigit(letra))
                {
                    if (letra == '9')
                        claveEncriptada += '0';
                    else
                        claveEncriptada += (char)(letra + 1);
                }
                else
                {
                    claveEncriptada += letra;
                }
            }

            txtResultado.Text = claveEncriptada;
        }
    }
}