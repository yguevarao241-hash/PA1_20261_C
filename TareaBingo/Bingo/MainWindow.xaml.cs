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

namespace Bingo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Button[,] botonesCartilla;
        private int[,] numerosCartilla;
        private bool[,] numerosMarcados;

        private List<int> numerosCantados;
        private Random random;

        private bool juegoActivo;



        public MainWindow()
        {
            InitializeComponent();
            InicializarVariables();
        }




        private void InicializarVariables()
        {

            botonesCartilla = new Button[5, 5]
            {
                {btn00,btn01,btn02,btn03,btn04},
                {btn10,btn11,btn12,btn13,btn14},
                {btn20,btn21,btn22,btn23,btn24},
                {btn30,btn31,btn32,btn33,btn34},
                {btn40,btn41,btn42,btn43,btn44}
            };


            numerosCartilla = new int[5, 5];

            numerosMarcados = new bool[5, 5];


            numerosCantados = new List<int>();

            random = new Random();

            juegoActivo = false;

        }





        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            GenerarCartilla();

            juegoActivo = true;

        }






        private void GenerarCartilla()
        {

            int[,] rangos =
            {
                {1,15},
                {16,30},
                {31,45},
                {46,60},
                {61,75}
            };



            for (int fila = 0; fila < 5; fila++)
            {

                for (int col = 0; col < 5; col++)
                {


                    botonesCartilla[fila, col].IsEnabled = true;

                    botonesCartilla[fila, col].Background = Brushes.White;

                    botonesCartilla[fila, col].Foreground = Brushes.Black;



                    numerosMarcados[fila, col] = false;




                    if (fila == 2 && col == 2)
                    {

                        botonesCartilla[fila, col].Content = "★";

                        botonesCartilla[fila, col].Background = Brushes.Gold;

                        botonesCartilla[fila, col].IsEnabled = false;


                        numerosMarcados[fila, col] = true;


                        numerosCartilla[fila, col] = 0;


                        continue;

                    }




                    int numero;

                    bool repetido;



                    do
                    {

                        numero = random.Next(
                            rangos[col, 0],
                            rangos[col, 1] + 1
                        );

                        repetido = false;



                        for (int f = 0; f < 5; f++)
                        {

                            if (f != fila &&
                               numerosCartilla[f, col] == numero)
                            {
                                repetido = true;
                                break;
                            }

                        }


                    } while (repetido);





                    numerosCartilla[fila, col] = numero;


                    botonesCartilla[fila, col].Content =
                        numero.ToString();


                }

            }


        }







        private void btnGenerar_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                GenerarCartilla();


                numerosCantados.Clear();


                tbUltimoNumero.Text = "-";


                tbNumerosCantados.Text = "0";


                juegoActivo = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "Error al generar cartilla: " + ex.Message
                );

            }

        }








        private void btnLugar_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (!juegoActivo)
                {

                    MessageBox.Show(
                        "Primero genera una cartilla"
                    );

                    return;

                }



                if (numerosCantados.Count >= 75)
                {

                    MessageBox.Show(
                        "Ya salieron todos los números"
                    );

                    return;

                }





                int numero;


                do
                {

                    numero = random.Next(1, 76);

                }
                while (numerosCantados.Contains(numero));





                numerosCantados.Add(numero);





                // Número grande

                tbUltimoNumero.Text =
                    numero.ToString();


                tbUltimoNumero.Foreground =
                    new SolidColorBrush(
                        Color.FromRgb(255, 20, 147)
                    );



                tbNumerosCantados.Text =
                    numerosCantados.Count.ToString();






                // Buscar número en cartilla

                for (int fila = 0; fila < 5; fila++)
                {

                    for (int col = 0; col < 5; col++)
                    {


                        if (numerosCartilla[fila, col] == numero)
                        {


                            numerosMarcados[fila, col] = true;



                            botonesCartilla[fila, col].Background =
                                new SolidColorBrush(
                                    Color.FromRgb(255, 182, 193)
                                );



                            botonesCartilla[fila, col].Foreground =
                                Brushes.DeepPink;



                            botonesCartilla[fila, col].IsEnabled = false;


                        }


                    }

                }







                if (VerificarBingo())
                {

                    juegoActivo = false;


                    MessageBox.Show(
                        "🎉 ¡BINGO! Has ganado la partida 🎉",
                        "Ganador",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "Error durante el juego: " + ex.Message
                );

            }


        }








        private void btnReiniciar_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                GenerarCartilla();


                numerosCantados.Clear();


                tbUltimoNumero.Text = "-";


                tbNumerosCantados.Text = "0";


                juegoActivo = true;


            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "Error al reiniciar: " + ex.Message
                );

            }

        }








        private bool VerificarBingo()
        {


            for (int fila = 0; fila < 5; fila++)
            {

                for (int col = 0; col < 5; col++)
                {


                    // Casilla libre

                    if (fila == 2 && col == 2)
                        continue;



                    if (numerosMarcados[fila, col] == false)
                    {

                        return false;

                    }


                }

            }



            return true;


        }



    }
}