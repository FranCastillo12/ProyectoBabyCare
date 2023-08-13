using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class GestionEtapasDesarrollo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //Llenar el drop
                Negocios.Neg_EtapasDesarrollo iEtapas = new Negocios.Neg_EtapasDesarrollo();
                DataTable dtEtapas = iEtapas.Obtener_Categorias();

                ddlCategoriasEtapas.DataSource = dtEtapas;
                ddlCategoriasEtapas.DataTextField = "CategoriaEtapa";
                ddlCategoriasEtapas.DataValueField = "idCategoriaEtapa";
                ddlCategoriasEtapas.DataBind();
                ddlCategoriasEtapas.Items.Insert(0, new ListItem("Seleccione una cuenta", "0"));

                //Crear la tabla de forma dinamica
                dtEtapas = iEtapas.Obtener_EtapasDesarrollo();

                System.Text.StringBuilder strListaProductos = new System.Text.StringBuilder();

                foreach (DataRow drEtapas in dtEtapas.Rows)
                {
                    strListaProductos.Append("<tr>");
                    strListaProductos.Append("<th scope=\"row\">");
                    strListaProductos.Append(drEtapas["idEtapaDesarrollo"]);
                    strListaProductos.Append("</th>");
                    strListaProductos.Append("<td>");
                    strListaProductos.Append(Convert.ToString(drEtapas["categoriaEtapa"]));
                    strListaProductos.Append("</td>");
                    strListaProductos.Append("<td>");
                    strListaProductos.Append("<div class=\"dropdown\">");
                    strListaProductos.Append("<button class=\"btn btn\" type=\"button\" id=\"dropdownMenuButton1\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\" style=\"color:black\">");
                    strListaProductos.Append("<i class=\"fa-solid fa-user-gear\" style=\"color: #000000;\"></i>");
                    strListaProductos.Append("Opciones");
                    strListaProductos.Append("</button>");
                    strListaProductos.Append("<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton1\">");
                    strListaProductos.Append("<li runat=\"server\"><a class=\"dropdown-item btnActualizarClass\" href=\"#\" id=\"btnActualizar_" + drEtapas["idEtapaDesarrollo"] + "\" onserverclick=\"btnActualizar_ServerClick\" runat=\"server\" data-rowindex=\"" + drEtapas["idEtapaDesarrollo"] + "\" >Actualizar</a></li>");
                    strListaProductos.Append("<li runat=\"server\"><a class=\"dropdown-item btnEliminarClass\" href=\"#\" id=\"btnEliminar_" + drEtapas["idEtapaDesarrollo"] + "\" onserverclick=\"btnEliminar_ServerClick\" runat=\"server\" CommandArgument=\"" + drEtapas["idEtapaDesarrollo"] + "\">Eliminar</a></li>");
                    strListaProductos.Append("</ul>");
                    strListaProductos.Append("</div>");
                    strListaProductos.Append("</td>");
                }
                this.lstfrmMantenimiento.InnerHtml = strListaProductos.ToString();
            }
        }

        protected void hiddenBtnActualizar_Click(object sender, EventArgs e)
        {
            string idcategoria = null;
            lblopcion.Text = "2";
            //Obtengo el id del boton para saber cual elemtento fue seleccionado
            lblmodal.Text = "Actualizar etapa";
            string clickedButtonId = hiddenBtnId.Value;
            string[] parts = clickedButtonId.Split('_');

            //Consulta a la base de datos para saber la informacion del la etapa seleccionada

            Negocios.Neg_EtapasDesarrollo iEtapas = new Negocios.Neg_EtapasDesarrollo();

            DataTable dtEtapas = iEtapas.Obtener_EtapasDesarrolloSeleccionada(parts[1]);



            foreach (DataRow drEtapas in dtEtapas.Rows)
            {
                message.Text = Convert.ToString(drEtapas["Descripcion"]);
                urlimagen.Text = Convert.ToString(drEtapas["Imagen"]);
                txtlink.Text = Convert.ToString(drEtapas["link"]);
                idcategoria = Convert.ToString(drEtapas["idCategoriaEtapa"]);

            }
            //Obtener la categorias y saber si se selecciono una



            dtEtapas = iEtapas.Obtener_Categorias();

            ddlCategoriasEtapas.DataSource = dtEtapas;
            ddlCategoriasEtapas.DataTextField = "CategoriaEtapa";
            ddlCategoriasEtapas.DataValueField = "idCategoriaEtapa";
            ddlCategoriasEtapas.DataBind();
            ddlCategoriasEtapas.Items.Insert(0, new ListItem("Seleccione una cuenta", "0"));


            ListItem itemSeleccionado = ddlCategoriasEtapas.Items.FindByValue(idcategoria);

            if (itemSeleccionado != null)
            {
                itemSeleccionado.Selected = true;


            }

            //Mostar el modal
            string script = @"<script>
                        $(document).ready(function () {
                            $('#myModal').modal('show');
                        });
                     </script>";

            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModalScript", script, false);
        }

        protected void hiddenBtnEliminar_Click(object sender, EventArgs e)
        {
            string script = null;
            string clickedButtonId = hiddenBtnId.Value;
            string[] parts = clickedButtonId.Split('_');



            Negocios.Neg_EtapasDesarrollo iEtapas = new Negocios.Neg_EtapasDesarrollo();

            iEtapas.DeleteEtapa(Convert.ToInt32(parts[1]));

            string redirectScript = "<meta http-equiv='refresh' content='0.5'>";
            Response.Write(redirectScript);


            //Validacion de que se elimino
            script =
                 "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                 "toastr.error('La información ha sido eliminada);";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
        }

        protected void ddlCategoriasEtapas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valorSeleccionado = ddlCategoriasEtapas.SelectedValue.ToString();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string redirectScript = null;
            string script = null;
            int opcion = Convert.ToInt32(lblopcion.Text);
            string clickedButtonId = hiddenBtnId.Value;
            string[] parts = clickedButtonId.Split('_');
            string valorSeleccionado = ddlCategoriasEtapas.SelectedValue.ToString();
            string des = message.Text;
            string img = urlimagen.Text;
            string link = txtlink.Text;


            if (valorSeleccionado == "0")
            {
                script =
                 "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                "toastr.error('Seleccione una etapa');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (des == "")
            {
                script =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                "toastr.error('Ingresar la explicación de la etapa');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (img == "")
            {
                script =
               "toastr.options.closeButton = true;" +
               "toastr.options.positionClass = 'toast-bottom-right';" +
               "toastr.error('Ingresar una imagen representativa');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (link == "")
            {
                script =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                "toastr.error('Ingresar un link de referencia');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else
            {
                Negocios.Neg_EtapasDesarrollo iEtapas = new Negocios.Neg_EtapasDesarrollo();

                //If para saber si puede actulizar
                if (lblmodal.Text == "Actualizar etapa")
                {
                    iEtapas.UpdateEtapa(Convert.ToInt32(parts[1]), Convert.ToInt32(valorSeleccionado), des, img, link);
                    redirectScript = "<meta http-equiv='refresh' content='0.5'>";
                    Response.Write(redirectScript);

                    script =
                     "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                     "toastr.success('La información ha sido actualizada');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                //Ingresar etapa
                else if (lblmodal.Text == "Ingresar Etapa")
                {
                    //Ingresar etapa de desarrollo
                    iEtapas.InsertEtapa(Convert.ToInt32(valorSeleccionado), img, des, link);


                    redirectScript = "<meta http-equiv='refresh' content='0.5'>";
                    Response.Write(redirectScript);
                    //Validacion de que todo salio bien
                    script =
                     "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                     "toastr.success('La información ha sido ');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }

            }
            //Poner la opcion de agregar como default
            lblopcion.Text = "1";
            lblopcion.Text = "Ingresar Etapa";
        }

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            lblopcion.Text = "1";
            lblmodal.Text = "Ingresar Etapa";
            message.Text = "";
            urlimagen.Text = "";
            txtlink.Text = "";
            ddlCategoriasEtapas.SelectedValue = "0";
        }
    }
}