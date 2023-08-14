using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;

namespace ProyectoBabyCare.pages
{
    public partial class Etapas_Desarrollo : System.Web.UI.Page
    {
        int idBebe = 0;
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


            Entidades.En_Usuarios usu = (Entidades.En_Usuarios)Session["Credenciales"];
            idBebe = Convert.ToInt32(usu.IdenBebe);
            //Llama al metodo para activar las alertas y mostrar mensaje
            Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
            DateTime horaActual = DateTime.Now;
            alert.ActivateAlertas(horaActual, idBebe);
            List<Entidades.Alerta> alertas = alert.TraerAlertas(idBebe);

            string scriptalerta = null;
            foreach (Entidades.Alerta alrt in alertas)
            {
                if (alrt.HoraDeAlerta.TimeOfDay <= horaActual.TimeOfDay && alrt.Estado == true)
                {
                    scriptalerta =
                "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.warning('Hay una alerta pendiente en estos momentos! ({alrt.HoraDeAlerta.ToString("hh:mm tt")})');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrWarning", scriptalerta, true);
                }
            }
            // Final del metodo de mostrar alertas

        }
    }
}