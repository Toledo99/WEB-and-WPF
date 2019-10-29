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
    /// Interaction logic for Baja.xaml
    /// </summary>
    public partial class Baja : Window
    {
        public Baja()
        {
            InitializeComponent();
        }

        private void btBaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno a = new Alumno();
                int res = a.eliminar(Convert.ToInt16(tbFolio.Text));
                if (res < 0)
                    MessageBox.Show("No encontrado");
                else
                    MessageBox.Show("Se dio de baja " + res);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error");
            }
        }

        private void btRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Alta a = new Alta();
            a.Show();

        }
    }
}
