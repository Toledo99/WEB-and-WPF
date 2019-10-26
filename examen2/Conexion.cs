using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace examen2
{
    class Conexion
    {
        public static SqlConnection agregaConexion()
        {
            SqlConnection con;
            try
            {
                con = new SqlConnection("Data Source = localhost; Initial Catalog = datosCursos; User ID = sa; Password = sqladmin");
                con.Open();
                MessageBox.Show("Si pude conectarme");
            }
            catch (Exception e)
            {
                con = null;
                MessageBox.Show("No se pudo");
            }
            return con;
        }

        public static void llenarCombo(ComboBox cb)
        {
            SqlConnection con;
            SqlDataReader rd;
            try
            {
                con = Conexion.agregaConexion();
                SqlCommand cmd = new SqlCommand("select nombre from estado", con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cb.Items.Add(rd.GetString(0));
                }
                cb.SelectedIndex = 0;
                rd.Close();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo llenar el combo" + e);
            }
        }

        public static void llenarCombo2(ComboBox cb)
        {
            SqlConnection con;
            SqlDataReader rd;
            try
            {
                con = Conexion.agregaConexion();
                SqlCommand cmd = new SqlCommand("select idCurso from curso", con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    cb.Items.Add(rd.GetInt32(0));
                }
                cb.SelectedIndex = 0;
                rd.Close();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo llenar el combo" + e);
            }
        }

        public String generarReporte(int idEdo, DataGrid dg)
        {
            String res = " ";
            try
            {
                SqlConnection con = Conexion.agregaConexion();
                String query = String.Format("select * from curso where idEdo={0}",
                idEdo);
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();
                dg.ItemsSource = dr;
                res = "Éxito";
            }
            catch (Exception e)
            {
                res = "Falló";
            }
            return res;
        }
    }
    
}
