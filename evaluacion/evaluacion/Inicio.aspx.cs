using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evaluacion
{
    public partial class Inicio : System.Web.UI.Page
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

        public void llenarDd(DropDownList dd)
        {
            try
            {
                OdbcConnection con;
                con = conectarBD();
                OdbcCommand cmd = new OdbcCommand("select nombre from trabajador", con);
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                conectarBD();
                llenarDd(ddNombres);
            }
        }

        protected void ddNombres_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OdbcConnection miConexion = conectarBD();
            int id2 = 0;
            int idTrab = 0;

            if (miConexion != null)//o sea si se conecto
            {
                String queryId = String.Format("select count(idEval) from evaluacion");
                OdbcCommand cmd = new OdbcCommand(queryId, miConexion);
                OdbcDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Read();
                    id2 = rd.GetInt32(0) + 1;
                    rd.Close();
                }

                if (id2 > 1)
                {
                    String queryMax = String.Format("select MAX(idEval) from evaluacion");
                    OdbcCommand cmd1 = new OdbcCommand(queryMax, miConexion);
                    OdbcDataReader rd1 = cmd1.ExecuteReader();

                    if (rd1.HasRows)
                    {
                        rd1.Read();
                        id2 = rd1.GetInt32(0) + 1;
                        rd1.Close();
                    }
                }

                String queryTrabajador = String.Format("select idTrabajador from trabajador where nombre='{0}'",ddNombres.SelectedValue.ToString());
                OdbcCommand cmd0 = new OdbcCommand(queryTrabajador, miConexion);
                OdbcDataReader rd0 = cmd0.ExecuteReader();
                if (rd0.HasRows)
                {
                    rd0.Read();
                    idTrab = rd0.GetInt32(0);

                }

                String queryTrab = String.Format("select idEval from evaluacion where idTrabajador='{0}'", idTrab);
                OdbcCommand cmd4 = new OdbcCommand(queryTrabajador, miConexion);
                OdbcDataReader rd4 = cmd4.ExecuteReader();
                if (rd4.HasRows)
                {
                    rd4.Read();
                    Session["idEval"] = id2;
                    rd4.Close();
                }

                //APRENDÍ A INSERTAR ASÍ ...
                String queryAdd = String.Format("insert into evaluacion(idEval, idTrabajador, trabajandoConOtros, contribuciones, actitud,resolucionProblemas) values({0},{1},{2},{3},{4},{5})", id2,idTrab , TextBox1.Text,TextBox2.Text,TextBox3.Text,TextBox4.Text);
                OdbcCommand cmd2 = new OdbcCommand(queryAdd, miConexion);
                int rd2 = cmd2.ExecuteNonQuery(); //trae datos


                
            }
            Response.Redirect("evaluacion.aspx");
            miConexion.Close();
        }

        protected void lbReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("reporte.aspx");
        }
    }
    }
