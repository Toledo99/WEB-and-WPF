 using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sitioExamen2
{
    public partial class Pagina1 : System.Web.UI.Page
    {
        protected OdbcConnection conectarBD()
        {
            String stringConexion = "Driver={SQL Server Native Client 11.0};Server=112SALAS10;Uid=sa;Pwd=sqladmin;Database=datosCursos";
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txNombre.Text.CompareTo("") != 0 && txCorreo.Text.CompareTo("") != 0)
            {
                OdbcConnection con = conectarBD();
                if (con != null)
                {
                    String query3 = "select nombre from persona whe";
                    OdbcCommand sql3 = new OdbcCommand(query3, con);
                    String query2 = "select max(idPersona) from persona";
                    OdbcCommand sql2 = new OdbcCommand(query2, con);
                    int folio = Int16.Parse(sql2.ExecuteScalar().ToString()) + 1;
                    String query = String.Format("insert into persona values ('{0}','{1}','{2}')", folio, txCorreo.Text, txNombre.Text);
                    OdbcCommand sql = new OdbcCommand(query, con);
                    sql.ExecuteNonQuery();
                    Session["id"] = folio;
                    con.Close();
                    Response.Redirect("Pagina2.aspx");
                }
                else
                    lbResultados.Text = "No se pudo conectar";
            }
            else
                lbResultados.Text = "falta llenar un espacio";
        }

    }
}