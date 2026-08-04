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
using Microsoft.Data.SqlClient;

namespace SQLserverEjemplos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String CadenaConexion = "Server=.;Database=Northwind;Integrated Security=true;TrustServerCertificate=true;";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVerificacionConexion_Click(object sender, RoutedEventArgs e)
        {

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                try
                {
                    conexion.Open();
                    MessageBox.Show("Conexión exitosa: Base de datos = " + conexion.Database);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar: " + ex.Message);
                }
            }
        }

        private void btnCargarCategorias_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT CategoryID, CategoryName FROM Categories";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        cbxCategorias.Items.Clear();
                        while (reader.Read())
                        {
                            cbxCategorias.Items.Add(
                                new
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1)
                                }
                            );
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar categorías: " + ex.Message);
                }
            }
        }

        private void btnMostrarSelecionado_Click(object sender, RoutedEventArgs e)
        {
            if (cbxCategorias.SelectedItem != null)
            {
                dynamic categoriaSeleccionada = cbxCategorias.SelectedItem;
                int idCategoria = categoriaSeleccionada.Id;
                string nombreCategoria = categoriaSeleccionada.Nombre;
                MessageBox.Show($"Categoría seleccionada: ID = {idCategoria}, Nombre = {nombreCategoria}");

                MessageBox.Show($"Categoría seleccionada: ID = {cbxCategorias.SelectedValue}");
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna categoría.");
            }

        }
    }
}