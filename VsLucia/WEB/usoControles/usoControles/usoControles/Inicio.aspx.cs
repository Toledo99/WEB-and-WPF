using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace usoControles
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddColores.Items.Count == 0)
            {
                //Se tiene que llenar desde el loaded
                ddColores.Items.Add("Rojo");
                ddColores.Items.Add("Verde");
                ddColores.Items.Add("Rosa");
                ddColores.Items.Add("Amarillo");
            }

            if (rbSabores.Items.Count == 0)
            {
                rbSabores.Items.Add("Vainilla");
                rbSabores.Items.Add("Fresa");
                rbSabores.Items.Add("Chocolate");

            }

           
            

            if (cbCafe.Items.Count== 0)
            {
                //Se tiene que llenar desde el loaded
                cbCafe.Items.Add("Americano");
                cbCafe.Items.Add("Capuccino");
                cbCafe.Items.Add("Latte");
            }
        }

        protected void ddColores_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = 0;
            seleccion = ddColores.SelectedIndex;
            lbColores.Text = "Índice seleccionado:" + seleccion.ToString();
            //OBJETO SESIÓN: ME VA A DEJAR RECUPERAR INFORMACIÓN ENTRE PÁGINAS. Pasar info de una página a
            //otra página.
            Session["controles"] = "Cambió al DropDownList";
            lbSession.Text = Session["controles"].ToString();
        }

        protected void cbCafe_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            for (i = 0; i < cbCafe.Items.Count; i++)
            {
                if (cbCafe.Items[i].Selected == true)
                {
                    ListBox1.Items.Add(i.ToString());
                    ListBox2.Items.Add(cbCafe.Items[i].Value.ToString());
                }
            }

                Session["controles"] = "Cambió al checkbox list";
                lbSession.Text = Session["controles"].ToString();

            }


        

        protected void rbSabores_SelectedIndexChanged1(object sender, EventArgs e)
        {
            lbIndice.Text = "indice seleccionado: " + rbSabores.SelectedIndex.ToString();
            lbContenido.Text = "el contenido seleccionado:" + rbSabores.SelectedValue.ToString();
            lbSession.Text = Session["controles"].ToString();
        }
    }
    }
