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

namespace examen2
{
    /// <summary>
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void BtRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void BtModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Curso c = new Curso();
                c.modificar(cbCursos.SelectedIndex, Int32.Parse(txHoras.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo modificar " + ex);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion.llenarCombo2(cbCursos);
        }
    }
}
