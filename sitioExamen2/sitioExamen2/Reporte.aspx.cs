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
            String stringConexion = "Driver={SQL Server Native Client 11.0} Server = DESKTOP - OFMNE4A; Uid = sa; Pwd = sqladmin; Database = holis";
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

        protected void btRegistrar_Click(object sender, EventArgs e)
        {
            OdbcConnection con = conectarBD();
            if (con != null)
            {
                //
                String query2 = "select max(id) from persona";
                OdbcCommand sql2 = new OdbcCommand(query2, con);
                int folio = Int16.Parse(sql2.ExecuteScalar().ToString()) + 1;
                String query = "insert into persona(id, nombre, contra, email) values ('" + folio +"', '" + tx.Text + "', '" + txContra.Text + "','" + txCorreo.Text + "');";
                OdbcCommand sql = new OdbcCommand(query, con);
                sql.ExecuteNonQuery();
                Response.Redirect("Pagina2.aspx");
                con.Close();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pagina1.aspx");
        }
    }
}