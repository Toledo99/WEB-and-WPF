using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sitioExamen2
{
    public partial class Reporte : System.Web.UI.Page
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
                OdbcConnection con = conectarBD();
                if (con != null)
                {
                    String query = String.Format("select curso.* from curso where idCurso in (select idCurso from cursoTomado where cursoTomado.idPersona = '{0}') ", Session["id"].ToString());
                    OdbcCommand com = new OdbcCommand(query, con);
                    OdbcDataReader rd = com.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                    con.Close();
                }

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("Pagina2.aspx");
        }
    }
}