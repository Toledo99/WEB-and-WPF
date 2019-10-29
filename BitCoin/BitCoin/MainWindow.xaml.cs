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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitCoin
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Conexion.llenarCombo2(cbPaises);
                Conexion.llenarCombo(cbPaises.Text, cbRecibe);
                Conexion.llenarCombo(cbPaises.Text, cbTransfiere);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ejecutar" + ex);
            }
            
        }

        private void BtTransaccion_Click(object sender, RoutedEventArgs e)
        {
            if (txMonto.Text.CompareTo("") != 0)
            {

                double totRecibe, totTransfiere;
                int res, res2;
                SqlConnection con;
                con = Conexion.agregaConexion();
                SqlCommand cmd5 = new SqlCommand(String.Format("select idCliente from cliente where nombre='{0}'", cbTransfiere.SelectedValue), con);
                SqlDataReader rd5 = cmd5.ExecuteReader();
                SqlCommand cmd6 = new SqlCommand(String.Format("select idCliente from cliente where nombre='{0}'", cbRecibe.SelectedValue), con);
                SqlDataReader rd6 = cmd6.ExecuteReader();
                SqlCommand cmd4 = new SqlCommand(String.Format("select saldo from transaccion where idCliente={0}", rd6.GetInt32(0)), con);
                SqlDataReader rd4 = cmd4.ExecuteReader();
                totTransfiere = rd4.GetDouble(0) - double.Parse(txMonto.Text);
                if (totTransfiere <= double.Parse(txMonto.Text))
                {
                    SqlCommand cmd = new SqlCommand(String.Format("select saldo from transaccion where idCliente='{0}'", cbRecibe.SelectedValue), con);
                    SqlDataReader rd = cmd4.ExecuteReader();
                    totRecibe = rd.GetDouble(0) - double.Parse(txMonto.Text);
                    SqlCommand cmd2 = new SqlCommand(String.Format("update transaccion set saldo={0} where idCliente='{1}'", totRecibe, cbRecibe.SelectedValue), con);
                    res = cmd.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand(String.Format("update transaccion set saldo={0} where idCliente='{1}'", totTransfiere, cbTransfiere.SelectedValue), con);
                    res2 = cmd.ExecuteNonQuery();
                    if (res > 0 && res2 > 0)
                        MessageBox.Show("Saldo del Recibidor: "+totRecibe);

                }
                else
                    MessageBox.Show("No hay saldo suficiente para transferir");

            }
            else
                MessageBox.Show("No se puso nada en monto");
        }




        private void BtReporte_Click(object sender, RoutedEventArgs e)
        {
            Reporte main = new Reporte();
            main.Show();
            this.Hide();

        }

        private void CbPaises_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                cbRecibe.Items.Clear();
                cbTransfiere.Items.Clear();
                Conexion.llenarCombo(cbPaises.Text, cbRecibe);
                Conexion.llenarCombo(cbPaises.Text, cbTransfiere);

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo ejecutar" + ex);
            }
        }
    }
}
