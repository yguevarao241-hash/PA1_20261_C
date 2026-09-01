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

namespace MatrizVotos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[,] txtVotos;

        private string[] partidos =
        {
            "Buhito",
            "Aguila",
            "Torito",
            "Lorito"
        };

        private string[] zonas =
        {
            "A","B","C","D"
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtVotos = new TextBox[,]
            {
                { txt00, txt01, txt02, txt03 },
                { txt10, txt11, txt12, txt13 },
                { txt20, txt21, txt22, txt23 },
                { txt30, txt31, txt32, txt33 }
            };
            txt00.Text = "122";
            txt01.Text = "254";
            txt02.Text = "382";
            txt03.Text = "445";

            txt10.Text = "472";
            txt11.Text = "364";
            txt12.Text = "205";
            txt13.Text = "228";

            txt20.Text = "143";
            txt21.Text = "117";
            txt22.Text = "474";
            txt23.Text = "293";

            txt30.Text = "411";
            txt31.Text = "202";
            txt32.Text = "261";
            txt33.Text = "335";
        
      
        }

        private void btnResultados_Click(object sender, RoutedEventArgs e)
        {
            int[,] votos = new int[4, 4];

            int total = 0;

            int[] sumaFilas = new int[4];
            int[] sumaColumnas = new int[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (int.TryParse(txtVotos[i, j].Text, out int valor))
                    {
                        votos[i, j] = valor;

                        total += valor;

                        sumaFilas[i] += valor;

                        sumaColumnas[j] += valor;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un número válido.");
                        txtVotos[i, j].Focus();
                        return;
                    }
                }
            }

            tbTotal.Text = total.ToString();

            int mayorFila = sumaFilas[0];
            int posFila = 0;

            for (int i = 1; i < 4; i++)
            {
                if (sumaFilas[i] > mayorFila)
                {
                    mayorFila = sumaFilas[i];
                    posFila = i;
                }
            }

            tbGanador.Text = partidos[posFila];

            int mayorColumna = sumaColumnas[0];
            int posColumna = 0;

            for (int i = 1; i < 4; i++)
            {
                if (sumaColumnas[i] > mayorColumna)
                {
                    mayorColumna = sumaColumnas[i];
                    posColumna = i;
                }
            }

            tbZona.Text = zonas[posColumna];
        }
    }
}