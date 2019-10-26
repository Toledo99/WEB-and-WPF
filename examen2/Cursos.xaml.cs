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
    /// Lógica de interacción para Cursos.xaml
    /// </summary>
    public partial class Cursos : Window
    {
        public Cursos()
        {
            InitializeComponent();
        }

        private void BtMostrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Curso c;
                c = new Curso();
                c.generarReporte(cbEstados.SelectedIndex, dgCursos);
            }catch(Exception ex)
            {
                MessageBox.Show("No se puede mostrar reporte " + ex);
            }
        }

        private void BtRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Conexion.llenarCombo2(cbEstados);
        }
    }
}
