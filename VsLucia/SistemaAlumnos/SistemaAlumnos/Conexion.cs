using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace SistemaAlumnos
{
    class Conexion
    {
        SqlCommand cmd;
        SqlDataReader rd;

        public static SqlConnection conectar()
        {
            SqlConnection cnn;
            try
            {
                cnn = new SqlConnection("Data Source=CC102-05\\SA;Initial Catalog=baseSistemaAlumno;Persist Security Info=True;User ID=sa;Password=adminadmin");
                cnn.Open();
                MessageBox.Show("Sí se pudo conectar");

            }
            catch (Exception ex)
            {
                cnn = null;
                MessageBox.Show("No se pudo hacer la conexión" + ex);
            }
            return cnn;
        }

        public static String comprobarPw(String usuario, String pw)
        {
            String res = "ERROR";
            SqlDataReader rd;
            SqlConnection con;
            //TRY CATCH SIEMPRE
            try
            {
                con = Conexion.conectar();
                //if (con != null)
                //{}
                SqlCommand cmd = new SqlCommand(String.Format("select contra from usuarios where nombreUsuario ='{0}'",usuario),con);
                //LAVES Y CERO PARA QUE LO COMPARE CON EL 1ER DATO
                //EL QUERY ENTRA EN LA 1ERA PARTE 
                rd = cmd.ExecuteReader();
                        if (rd.Read())
                        {
                             if (rd.GetString(0).Equals(pw))
                             res = "CONTRASEÑA CORRECTA";
                          else
                              res = "CONTRASEÑA INCORRECTA";
                        }
                        else
                              {
                             res = "USUARIO INCORRECTO";
                               }       
            }
            catch (Exception ex)
            {
                res = "ERROR" + ex;
            }

         return res;
        }

        public void llenarComboAlta(ComboBox cb)
        {
            try {
                SqlConnection con;
                con = Conexion.conectar();
                cmd = new SqlCommand("select nombre from programa", con);
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    //Si hay datos en el reader
                    cb.Items.Add(rd["nombre"].ToString());
                }
                cb.SelectedIndex=0;
                rd.Close();
                con.Close();
            } catch (Exception ex) {
                MessageBox.Show("No se pudo llenar el combo" + ex);
                //Diccionario se trae el nombre de la columna y los valores. 
            }
        }

    }
}
