using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Etapas_Desarrollo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Text.StringBuilder strListaProductos = new System.Text.StringBuilder();
            // List<Productos> productos = Neg_Productos.CargarProductos();

            for (int i = 0; i < 10; i++)
            {


                strListaProductos.Append("<div class=\"card\" style=\"--clr: #009688\">");
                strListaProductos.Append("<div class=\"img-box\">");
                strListaProductos.Append("<img src=\"").Append("https://i.postimg.cc/t4w95jsf/img-01.png").Append("\" />");
                strListaProductos.Append("</div>");
                strListaProductos.Append("<div class=\"content\">");
                strListaProductos.Append("<h2>").Append("Leafs").Append("</h2>");
                strListaProductos.Append("<p>").Append("Lorem ipsum, dolor sit amet consectetur adipisicing elit.\r\n                    Architecto, hic? Magnam eum error saepe doloribus corrupti\r\n                    repellat quisquam alias doloremque!").Append("</p>");
                strListaProductos.Append("<a href=\"/Pages/frmMantenimiento.aspx?opcion=2&codigoProducto=").Append(i).Append("\">Read More</a>");
                strListaProductos.Append("</div>");
                strListaProductos.Append("</div>");
            }

            // Agrega el código HTML a la página web para mostrar las cartas
            this.lstfrmMantenimiento.InnerHtml = strListaProductos.ToString();
        }
    }
}