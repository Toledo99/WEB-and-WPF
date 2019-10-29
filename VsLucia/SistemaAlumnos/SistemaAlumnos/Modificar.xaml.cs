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
    /// Interaction logic for Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void tbModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Alumno a = new Alumno(Convert.ToInt16(tbFolio.Text), tbCorreo.Text);
                int res = a.modificar(a);
                if (res > 0)
                    MessageBox.Show("Se modifico el correo");
                else
                    MessageBox.Show("No se encontro al alumno");
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error");
            }
        }

        private void tbRegresar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Alta a = new Alta();
            a.Show();

        }
    }
}


