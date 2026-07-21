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

namespace MenuContextual
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
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menu = sender as MenuItem;

            switch (menu.Header.ToString())
            {
                case "Menu Item 1":
                    MessageBox.Show("Seleccionaste el Menú 1");
                    break;

                case "Menu Item 2":
                    MessageBox.Show("Seleccionaste el Menú 2");
                    break;

                case "Menu Item 3":
                    MessageBox.Show("Seleccionaste el Menú 3");
                    break;

                case "Salir":
                    Close();
                    break;
            }
        }
        }
}