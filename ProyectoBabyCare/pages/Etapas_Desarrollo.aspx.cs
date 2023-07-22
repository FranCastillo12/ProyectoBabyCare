using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;

namespace ProyectoBabyCare.pages
{
    public partial class Etapas_Desarrollo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


           Negocios.Neg_EtapasDesarrollo iEtapas = new Negocios.Neg_EtapasDesarrollo();

            DataTable dtEtapas = iEtapas.Obtener_EtapasDesarrollo();

            System.Text.StringBuilder strListaProductos = new System.Text.StringBuilder();
            // List<Productos> productos = Neg_Productos.CargarProductos();


            foreach (DataRow drEtapas in dtEtapas.Rows)
            {
                strListaProductos.Append("<div class=\"card\" style=\"--clr: #009688\">");
                strListaProductos.Append("<div class=\"img-box\">");
                strListaProductos.Append("<img src=\"").Append(drEtapas["imagen"]).Append("\" />");
                strListaProductos.Append("</div>");
                strListaProductos.Append("<div class=\"content\">");
                strListaProductos.Append("<h2>").Append(Convert.ToString(drEtapas["categoriaEtapa"])).Append("</h2>");//Edad de la etapa
                strListaProductos.Append("<p>").Append(Convert.ToString(drEtapas["Descripcion"])).Append("</p>");//descipcion
                strListaProductos.Append("<a href=\"").Append(drEtapas["link"]).Append("\">Leer más</a>"); // Link a una página para leer más

                strListaProductos.Append("</div>");
                strListaProductos.Append("</div>");
            }
            

            // Agrega el código HTML a la página web para mostrar las cartas
            this.lstfrmMantenimiento.InnerHtml = strListaProductos.ToString();
        }
    }
}