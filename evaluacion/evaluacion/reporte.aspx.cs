using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evaluacion
{
    public partial class reporte : System.Web.UI.Page
    {
        protected OdbcConnection conectarBD()
        {
            String stringConexion = "Driver={SQL Server Native Client 11.0};Server=LUCALIZARDIAD3F;Uid=sa;Pwd=sqladmin;Database=trabajadores";
            try
            {
                OdbcConnection conexion = new OdbcConnection(stringConexion);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddNombre.Items.Clear();
                conectarBD();
                llenarDd(ddNombre);
            }
            
            }


        }





        public void llenarDd(DropDownList dd)
        {
            try
            {
                OdbcConnection con;
                con = conectarBD();
                OdbcCommand cmd = new OdbcCommand("select distinct nombre from trabajador", con);
                OdbcDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    dd.Items.Add(rd["nombre"].ToString());
                }
                //cb.SelectedIndex = 0;
                rd.Close();
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddNombres_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OdbcConnection miConexion = conectarBD();
            if (miConexion != null)
            {
                OdbcCommand cmd = new OdbcCommand(String.Format("select distinct * from evaluacion, trabajador where evaluacion.idTrabajador = trabajador.idTrabajador and trabajador.nombre ='{0}'", ddNombre.SelectedValue), miConexion);
                OdbcCommand cmd = new OdbcCommand(query, miConexion);
                OdbcDataReader rd = cmd.ExecuteReader();
                ddNombre.Items.Clear();
                llenarDd(ddNombre);
                while (rd.Read())
                {
                    OdbcDataReader rd = cmd.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                }

            }
                rd.Close();
            }

        }

    }
           
    
