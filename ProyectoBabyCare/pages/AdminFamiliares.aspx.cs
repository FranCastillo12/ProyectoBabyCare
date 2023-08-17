using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class AdminFamiliares : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RecreateDynamicControls();

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //cambiorol.Visible = true;
            if (IsPostBack)
            {
                RecreateDynamicControls();
            }
        }
        protected void RecreateDynamicControls()
        {
            // Eliminar los controles existentes para recrearlos
            divContenedor.Controls.Clear();
            if (Request.QueryString["id"] != null)
            {
                string id = Convert.ToString(Request.QueryString["id"]);
                // Hacer lo que necesites con el valor de "id".

                Negocios.Neg_Usuarios iUsuario = new Negocios.Neg_Usuarios();

                DataTable TableUsuarios = iUsuario.ObtenerUsuarioRelacionados(id);

                StringBuilder StrListaUsuarios = new StringBuilder();

                int i = 0;
                // Agregar el botón al divContenedor
                foreach (DataRow drUsuarios in TableUsuarios.Rows)
                {
                    Panel panel = new Panel();
                    panel.CssClass = "form-controll";
                    panel.Style["display"] = "flex";
                    panel.Style["align-items"] = "center";
                    panel.Style["justify-content"] = "space-between";
                    panel.Style["overflow"] = "hidden";
                    panel.Style["background-color"] = "transparent"; // Establecer el color de fondo como blanco


                    Button button = new Button();
                    button.CssClass = "form-control";
                    button.ID = drUsuarios["idUsuarioBebe"].ToString();
                    button.Text = drUsuarios["nombre"].ToString();
                    button.Style["text-align"] = "left";
                    button.BorderStyle = BorderStyle.None; // Quitar los bordes del botón
                    button.Click += Button_Click;

                    Label label = new Label();
                    label.Text = drUsuarios["rol"].ToString();
                    label.Style["text-align"] = "right";
                    label.Style["padding-right"] = "20px"; // Agrega un espacio de 10px entre el borde derecho del panel y el contenido del label
                    label.Style["font-size"] = "30px";
                    string contenido = label.Text;
                    if (contenido == "Madre")
                    {
                        label.Style["color"] = "lightgreen"; // Cambiar a color verde suave

                    }
                    else if (contenido == "Padre")
                    {
                        label.Style["color"] = "orange"; // Cambiar a color rojo
                    }
                    else if (contenido == "Encargado")
                    {
                        label.Style["color"] = "purple"; // Cambiar a color rojo
                    }
                    else if (contenido == "Abuelo")
                    {
                        label.Style["color"] = "green"; // Cambiar a color rojo
                    }
                    else if (contenido == "BabySister")
                    {
                        label.Style["color"] = "blue"; // Cambiar a color rojo
                    }
                    else if (contenido == "Normal")
                    {
                        label.Style["color"] = "red"; // Cambiar a color rojo
                    }
                    panel.Controls.Add(button);
                    panel.Controls.Add(label);

                    divContenedor.Controls.Add(panel);
                }
            }
        }


        protected void Button_Click(object sender, EventArgs e)
        {
            cambiorol.Visible = true;
            Button boton = (Button)sender;
            string[] partes = boton.Text.Split(' ');
            string idBoton = boton.ID;
            lblnombre.Text = partes[0] + ' ' + partes[1];
            lblnumerousuario.Text = idBoton;

            Negocios.Neg_Usuarios iUsuario = new Negocios.Neg_Usuarios();

            DataTable TableUsuarios = iUsuario.ObtenerRoles();

            StringBuilder StrListaRoles = new StringBuilder();

            ddlRoles.DataSource = TableUsuarios;
            ddlRoles.DataTextField = "Rol";
            ddlRoles.DataValueField = "idRol";
            ddlRoles.DataBind();
            ddlRoles.Items.Insert(0, new ListItem("Rol", "0"));
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string redirectScript = null;
            string script = null;
            try
            {
                if (ddlRoles.SelectedValue == "0")
                {
                    cambiorol.Visible = true;
                    script =
                     "toastr.options.closeButton = true;" +
                     "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('Debe escoger un rol');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                else if (ddlRoles.SelectedValue == "")
                {
                    cambiorol.Visible = true;
                    script =
                     "toastr.options.closeButton = true;" +
                     "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('Debe escoger un rol');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                else
                {
                    string idUsuario = lblnumerousuario.Text;
                    string valorSeleccionado = ddlRoles.SelectedValue;
                    Negocios.Neg_Usuarios iUsuario = new Negocios.Neg_Usuarios();

                    Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
                    string idbebe = credenciales.IdenBebe;


                    if (valorSeleccionado == "3")//Padre
                    {

                        DataTable cantidad = iUsuario.CantidadFam(idbebe, valorSeleccionado);

                        if (cantidad.Rows.Count > 0)
                        {
                            DataRow row = cantidad.Rows[0];

                            int cantidadPadre = Convert.ToInt32(row[0]); // Primer columna

                            int cantidadTotalPadre = Convert.ToInt32(row[1]); // Primer columna

                            if (cantidadPadre >= cantidadTotalPadre)
                            {
                                script =
                             "toastr.options.closeButton = true;" +
                             "toastr.options.positionClass = 'toast-bottom-right';" +
                             "toastr.warning('Ya supero la cantidad de padres');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                            }
                            else
                            {

                                cambiorol.Visible = true;



                                iUsuario.CambioRol(idUsuario, valorSeleccionado);
                                script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-bottom-right';" +
                               "toastr.success('El cambio de rol se ha realizado con satisfacción');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                                // Agregar una redirección después de 1 segundo (1000 milisegundos)
                                redirectScript = "<meta http-equiv='refresh' content='1'>";
                                Response.Write(redirectScript);

                            }


                        }
                    }
                    else if (valorSeleccionado == "2")//Madre
                    {
                        DataTable cantidadMadres = iUsuario.CantidadFam(idbebe, valorSeleccionado);

                        if (cantidadMadres.Rows.Count > 0)
                        {
                            DataRow row = cantidadMadres.Rows[0];

                            int cantidadMadre = Convert.ToInt32(row[0]); // Primer columna

                            int cantidadTotalMadre = Convert.ToInt32(row[1]); // Primer columna

                            if (cantidadMadre >= cantidadTotalMadre)
                            {
                                script =
                             "toastr.options.closeButton = true;" +
                             "toastr.options.positionClass = 'toast-bottom-right';" +
                             "toastr.warning('Ya supero la cantidad de madres');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                            }
                            else
                            {
                                cambiorol.Visible = true;
                                iUsuario.CambioRol(idUsuario, valorSeleccionado);
                                script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-bottom-right';" +
                               "toastr.success('El cambio de rol se ha realizado con satisfacción');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                                // Agregar una redirección después de 1 segundo (1000 milisegundos)
                                redirectScript = "<meta http-equiv='refresh' content='1'>";
                                Response.Write(redirectScript);

                            }

                        }
                    }
                    else
                    {

                        cambiorol.Visible = true;
                        iUsuario.CambioRol(idUsuario, valorSeleccionado);
                        script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                       "toastr.success('El cambio de rol se ha realizado con satisfacción');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                        // Agregar una redirección después de 1 segundo (1000 milisegundos)
                        redirectScript = "<meta http-equiv='refresh' content='1'>";
                        Response.Write(redirectScript);
                    }
                }
            }
            catch (Exception ex)
            {
                script = "toastr.warning('Ha occurido un error,Intentelo mas tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
    }
}