using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace evaluacion
{
    public partial class evaluacion : System.Web.UI.Page
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

            lbSession.Text = Session["idEval"].ToString();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double p = promedio();
            
            
            if (p > 8)

                Response.Redirect("Felicitaciones.aspx");
            else
                Response.Redirect("recomendaciones.aspx");
            
        }

        public double promedio()
        {
            double prom = 0;

            OdbcConnection miConexion = conectarBD();
            if (miConexion != null)
            {
                //String querySuma = String.Format("select SUM(evaluacion.trabajandoConOtros+evaluacion.contribuciones+evaluacion.actitud+evaluacion.resolucionProblemas) from evaluacion, trabajador where evaluacion.idTrabajador=trabajador.idTrabajador and evaluacion.idEval={0}", Session["idEval"]);
                //OdbcCommand cmd = new OdbcCommand(querySuma, miConexion);
                OdbcCommand cmd = new OdbcCommand(String.Format("select SUM(evaluacion.trabajandoConOtros+evaluacion.contribuciones+evaluacion.actitud+evaluacion.resolucionProblemas) from evaluacion, trabajador where evaluacion.idTrabajador=trabajador.idTrabajador and evaluacion.idEval={0}", Session["idEval"].ToString()), miConexion);
                //OdbcDataReader rd = cmd.ExecuteReader(); //trae datos
                double suma= double.Parse(cmd.ExecuteScalar().ToString());
                prom = suma/4;
                txPromedio.Text = prom.ToString();
                miConexion.Close();
            }
            return prom;

        }
    }
}
