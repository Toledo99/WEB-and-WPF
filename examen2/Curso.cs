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
    class Curso
    {
        public String nombre;
        public int hora;
        public int idEstado;

        public Curso(string nombre, int hora, int idEstado)
        {
            this.nombre = nombre;
            this.hora = hora;
            this.idEstado = idEstado;
        }

        public Curso()
        {
        }

        public String Alta(Curso c)
        {
            String res;
            try
            {
                SqlConnection con;
                con = Conexion.agregaConexion();
                //creamos el contador
                String queryMax = "select top(1) idCurso from curso order by idCurso desc";
                SqlCommand cmd = new SqlCommand(queryMax, con);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Read();
                    int maximo = rd.GetInt32(0) + 1;

                    rd.Close();
                    String query2 = string.Format("insert into curso values " +
                        "({0}, '{1}', {2}, {3}) ", maximo, c.nombre, c.hora, c.idEstado);
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    res = "Alta exitosa";
                    
                }
                else
                {
                    //f = "NO Tiene filas";
                    String query = string.Format("insert into curso values " +
                        "({0}, '{1}', {2}, {3}) ", 1, c.nombre, c.hora, c.idEstado);
                    SqlCommand cmd2 = new SqlCommand(query, con);
                    cmd2.ExecuteNonQuery();
                    res = "Alta exitosa";
                }
                con.Close();
            }
            catch (Exception e)
            {
                res = "Alta NO exitosa" + e.Message;
            }
            return res;
        }



        public int modificar(int idCurso, int horas)
        {
            int res;
            SqlConnection con;
            con = Conexion.agregaConexion();
            SqlCommand cmd = new SqlCommand(String.Format("update curso set horas ='{0}' where idCurso = '{1}'", horas,idCurso),con);
            res = cmd.ExecuteNonQuery();
            if (res > 0)
                MessageBox.Show("Se modifico :D");
            else
                MessageBox.Show("No se modifico D:");
            return res;
        }
        public String generarReporte(int idEdo, DataGrid dg)
        {
            String res = " ";
            try
            {
                SqlConnection con = Conexion.agregaConexion();
                String query = String.Format("select * from curso where idEdo={0}",idEdo);
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
