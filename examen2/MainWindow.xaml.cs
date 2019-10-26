using System;
using System.Collections.Generic;
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

namespace examen2
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

        private void BtModificar_Click(object sender, RoutedEventArgs e)
        {
            Modificar m = new Modificar();
            m.Show();
            this.Hide();
        }
        private void BtCursos_Click(object sender, RoutedEventArgs e)
        {
            Cursos m = new Cursos();
            m.Show();
            this.Hide();
        }

        private void BtAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Curso c = new Curso(txNombre.Text, Int32.Parse(txHoras.Text), cbEstados.SelectedIndex);
                MessageBox.Show(c.Alta(c));
            }            catch(Exception ex)
            {
                MessageBox.Show("No se pudo Agregar" + ex);
            }
        }

        private void CbEstados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion.llenarCombo(cbEstados);
        }

        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Aspirantes a = new Aspirantes();
                a.darDeBaja(cbClaveUica.SelectedItem.ToString());

            }catch(Exception ex)
            {
                MessageBox.Show("No se pudo Eliminar" + ex);
            }
        }

        public String darDeBaja(String nombre)
        {
            String res = "";
            try
            {
                SqlConnection con = Conexion.agregaConexion();
                String query = String.Format("delete from aspirante where nombre='{0}'", nombre);
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                res = "Baja exitosa";
            }
            catch (Exception e)
            {
                res = "No se pudo dar de baja" + e.ToString();
            }
            return res;
        }
    }
}
