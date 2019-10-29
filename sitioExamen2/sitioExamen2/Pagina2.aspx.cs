using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sitioExamen2
{
    public partial class Pagina2 : System.Web.UI.Page
    {
        protected OdbcConnection conectarBD()
        {
            String stringConexion ="Driver={SQL Server Native Client 11.0};Server=112SALAS10;Uid=sa;Pwd=sqladmin;Database=datosCursos";
            try
            {
                OdbcConnection conexion = new OdbcConnection(stringConexion);
                conexion.Open();
                lbResultados.Text = "conexion exitosa";
                return conexion;
            }
            catch (Exception ex)
            {
                lbResultados.Text = ex.StackTrace.ToString();
                return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OdbcConnection miConexion = conectarBD();
                if (miConexion != null)
                {
                    String query = "select nombre from curso";
                    OdbcCommand cmd = new OdbcCommand(query, miConexion);
                    OdbcDataReader rd;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        ddCurso.Items.Add(rd.GetString(0));
                    }
                    rd.Close(); 	  
                }
                miConexion.Close();
            }
        }

        protected void btReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reporte.aspx");
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection con = conectarBD();
                if (con != null)
                {
                    String query2 = "select max(idCursoTomado) from cursoTomado";
                    OdbcCommand sql2 = new OdbcCommand(query2, con);
                    int id = Int16.Parse(sql2.ExecuteScalar().ToString()) + 1;
                    String query = String.Format("insert into cursoTomado values ({0},{1},'{2}')", id, Session["id"], ddCurso.SelectedIndex);
                    OdbcCommand cmd = new OdbcCommand(query, con);
                    OdbcDataReader rd;
                    rd = cmd.ExecuteReader();
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                lbResultados.Text = "No se agrego curso" + ex;
            }
        }
    }
}