using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace videojuegos
{
    public partial class Pagina2 : System.Web.UI.Page
    {

        protected OdbcConnection conectarBD()
        {
            String stringConexion = "Driver={SQL Server Native Client 11.0};Server=CC102-05\\SA;Uid=sa;Pwd=adminadmin;Database=gameSpot";
            try
            {
                OdbcConnection conexion = new OdbcConnection(stringConexion);
                conexion.Open();
                Label1.Text = "conexion exitosa";
                return conexion;
            }
            catch (Exception ex)
            {
                Label1.Text= ex.StackTrace.ToString();
                return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            OdbcConnection miConexion = conectarBD();
            if (miConexion != null)
            {
                String query = String.Format("select nombre, edad, sexo from usuario where claveU={0}", Session["claveUnica"].ToString());
                OdbcCommand cmd = new OdbcCommand(query, miConexion);
                OdbcDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txNombre.Text = rd.GetString(0);
                    txEdad.Text = rd.GetString(1);
                    txSexo.Text = rd.GetString(2);
                    rd.Close();

                }
                else
                    Label1.Text = "error";

            }
            else
                Label1.Text = "no se pudo conectar";
        }

            protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina3.aspx");
          
        }
    }
}