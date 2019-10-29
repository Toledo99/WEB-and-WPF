using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BitCoin
{
    /// <summary>
    /// Lógica de interacción para Reporte.xaml
    /// </summary>
    public partial class Reporte : Window
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = Conexion.agregaConexion();
                String query = "select distinct cliente.*, saldo from cliente, transaccion where cliente.idCliente =transaccion.idCliente";
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                dgReporte.ItemsSource = dr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falló"+ex);
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
    }
}
