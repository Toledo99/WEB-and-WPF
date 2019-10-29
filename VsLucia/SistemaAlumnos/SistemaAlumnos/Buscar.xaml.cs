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
using System.Windows.Shapes;

namespace SistemaAlumnos
{
    /// <summary>
    /// Interaction logic for Buscar.xaml
    /// </summary>
    public partial class Buscar : Window
    {
        public Buscar()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno a = new Alumno();
                List<Alumno> res = a.buscar(tbNombre.Text);
                //Busca al alumno por nombre y regresa
                dgDatos.ItemsSource = res;
            }
            catch (Exception)
            {
                MessageBox.Show("OCURRIÓ UN ERROR");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            Alta a = new Alta();
            a.Show();

        }

        private void DgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
