using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BitCoin
{
    class Conexion
    {
        public static SqlConnection agregaConexion()
        {
            SqlConnection con;
            try
            {
                con = new SqlConnection("Data Source = 112SALAS29; Initial Catalog = datosClientes; User ID = sa; Password = sqladmin");
                con.Open();
            }
            catch (Exception ex)
            {
                con = null;
                MessageBox.Show("No se pudo");
            }
            return con;
        }

        public static void llenarCombo(String pais, ComboBox cb)
        {
            SqlConnection con;
            SqlDataReader rd;
            try
            {
                con = Conexion.agregaConexion();
                SqlCommand cmd = new SqlCommand("select nombre from cliente where pais='"+pais+"'", con);
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
                SqlCommand cmd = new SqlCommand("select distinct pais from cliente", con);
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

        




    }
}
