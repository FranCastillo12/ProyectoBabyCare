using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class GestionBebes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Negocios.Neg_bebes iBebes = new Negocios.Neg_bebes();

            //Crear la tabla de forma dinamica
            DataTable dtEtapas = iBebes.Obtener_bebesGes();
            System.Text.StringBuilder strListaProductos = new System.Text.StringBuilder();

            foreach (DataRow drEtapas in dtEtapas.Rows)
            {
                String estado = null;
                DateTime fechaRegistro = (DateTime)drEtapas["FechaRegistroBebe"];
                string fechaSinHora = fechaRegistro.ToString("yyyy-MM-dd");
                //Saber si el bebe esta activo o no
                if (drEtapas["EstadoBebe"].ToString() == "True")
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Inactivo";
                }



                strListaProductos.Append("<tr>");
                strListaProductos.Append("<th scope=\"row\">");
                strListaProductos.Append(drEtapas["nombre"]);
                strListaProductos.Append("</th>");
                strListaProductos.Append("<td>");
                strListaProductos.Append(fechaSinHora);
                strListaProductos.Append("</td>");
                strListaProductos.Append("<td>");
                strListaProductos.Append(estado);
                strListaProductos.Append("</td>");
                strListaProductos.Append("<td>");
                strListaProductos.Append("<div class=\"dropdown\">");
                strListaProductos.Append("<button class=\"btn btn\" type=\"button\" id=\"dropdownMenuButton1\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\" style=\"color:black\">");
                strListaProductos.Append("<i class=\"fa-solid fa-user-gear\" style=\"color: #000000;\"></i>");
                strListaProductos.Append("Opciones");
                strListaProductos.Append("</button>");
                strListaProductos.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton1\">");
                strListaProductos.Append("<li runat=\"server\"><a class=\"dropdown-item btnActivarClass\" href=\"#\" id=\"btnActualizar_" + drEtapas["idBebe"] + "\" onserverclick=\"btnActualizar_ServerClick\" runat=\"server\" data-rowindex=\"" + drEtapas["idBebe"] + "\" >Activar</a></li>");
                strListaProductos.Append("<li runat=\"server\"><a class=\"dropdown-item btnInactivarClass\" href=\"#\" id=\"btnEliminar_" + drEtapas["idBebe"] + "\" onserverclick=\"btnEliminar_ServerClick\" runat=\"server\" CommandArgument=\"" + drEtapas["idBebe"] + "\">Inactivar</a></li>");
                strListaProductos.Append("</ul>");
                strListaProductos.Append("</div>");
                strListaProductos.Append("</td>");

            }

            this.lstfrmMantenimiento.InnerHtml = strListaProductos.ToString();
        }

        protected void hiddenBtnActivar_Click(object sender, EventArgs e)
        {
            string clickedButtonId = hiddenBtnId.Value;
            string[] parts = clickedButtonId.Split('_');

            Negocios.Neg_bebes iBebes = new Negocios.Neg_bebes();

            iBebes.CambiarEstado(Convert.ToInt32(parts[1]), 1);
            string redirectScript = "<meta http-equiv='refresh' content='0.1'>";
            Response.Write(redirectScript);
        }

        protected void hiddenBtnInactivar_Click(object sender, EventArgs e)
        {
            string clickedButtonId = hiddenBtnId.Value;
            string[] parts = clickedButtonId.Split('_');

            Negocios.Neg_bebes iBebes = new Negocios.Neg_bebes();

            iBebes.CambiarEstado(Convert.ToInt32(parts[1]), 0);
            string redirectScript = "<meta http-equiv='refresh' content='0'>";
            Response.Write(redirectScript);
        }
    }
}