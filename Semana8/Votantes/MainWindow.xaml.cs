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

namespace Votantes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[,] txtVotos;
        private TextBlock[] tbTotalPartidos;
        private TextBlock[] tbTotalZonas;

        private string[] partidos =
        {
            "Buhito",
            "Aguila",
            "Torito",
            "Lorito"
        };

        private string[] zonas =
        {
            "A",
            "B",
            "C",
            "D"
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

            tbTotalPartidos = new TextBlock[]
            {
                tbTotalP0,
                tbTotalP1,
                tbTotalP2,
                tbTotalP3
            };

            tbTotalZonas = new TextBlock[]
            {
                tbTotalZ0,
                tbTotalZ1,
                tbTotalZ2,
                tbTotalZ3
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

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            int[,] votos = new int[4, 4];

            int totalVotantes = 0;

            // Leer datos de la matriz
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    votos[i, j] = Convert.ToInt32(txtVotos[i, j].Text);
                }
            }

            // Totales por partido
            int mayorPartido = 0;

            for (int i = 0; i < 4; i++)
            {
                int suma = 0;

                for (int j = 0; j < 4; j++)
                {
                    suma += votos[i, j];
                }

                tbTotalPartidos[i].Text = suma.ToString();

                totalVotantes += suma;

                if (Convert.ToInt32(tbTotalPartidos[i].Text) >
                    Convert.ToInt32(tbTotalPartidos[mayorPartido].Text))
                {
                    mayorPartido = i;
                }
            }

            // Totales por zona
            int mayorZona = 0;

            for (int j = 0; j < 4; j++)
            {
                int suma = 0;

                for (int i = 0; i < 4; i++)
                {
                    suma += votos[i, j];
                }

                tbTotalZonas[j].Text = suma.ToString();

                if (Convert.ToInt32(tbTotalZonas[j].Text) >
                    Convert.ToInt32(tbTotalZonas[mayorZona].Text))
                {
                    mayorZona = j;
                }
            }

            tbTotalVotantes.Text = totalVotantes.ToString();

            lblCandidatoGanador.Text = partidos[mayorPartido];

            lblZonaMax.Text = zonas[mayorZona];
        }
    }
}
