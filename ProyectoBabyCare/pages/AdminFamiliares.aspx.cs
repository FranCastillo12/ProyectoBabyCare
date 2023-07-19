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

        }
        protected void RecreateDynamicControls()
        {
            // Eliminar los controles existentes para recrearlos
            divContenedor.Controls.Clear();

            Negocios.Neg_Usuarios iUsuario = new Negocios.Neg_Usuarios();

            DataTable TableUsuarios = iUsuario.ObtenerUsuarioRelacionados("1");

            StringBuilder StrListaUsuarios = new StringBuilder();

            int i = 0;
            // Agregar el botón al divContenedor
            foreach (DataRow drUsuarios in TableUsuarios.Rows)
            {
                Panel panel = new Panel();
                panel.CssClass = "form-control";
                panel.Style["display"] = "flex";
                panel.Style["align-items"] = "center";
                panel.Style["justify-content"] = "space-between";
                panel.Style["white-space"] = "nowrap";
                panel.Style["overflow"] = "hidden";
                panel.Style["text-overflow"] = "ellipsis";
                panel.Style["background-color"] = "white"; // Establecer el color de fondo como blanco


                Button button = new Button();

                button.ID = drUsuarios["id_usuarioxbebe"].ToString();
                button.Text = drUsuarios["nombre"].ToString();
                button.Style["text-align"] = "left";
                button.Style["background-color"] = "white"; // Establecer el color de fondo como blanco
                button.BorderStyle = BorderStyle.None; // Quitar los bordes del botón

                button.Click += Button_Click;

                Label label = new Label();
                label.Text = drUsuarios["rol"].ToString();
                label.Style["text-align"] = "right";
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




                panel.Controls.Add(button);
                panel.Controls.Add(label);

                divContenedor.Controls.Add(panel);
            }
        }


        protected void Button_Click(object sender, EventArgs e)
        {
            cambiorol.Visible = true;
            //    Button boton = (Button)sender;
            //    string[] partes = boton.Text.Split(' ');
            //    string idBoton = boton.ID;
            //    lblnombre.Text = partes[0] +' '+ partes[1];
            //    lblnumerousuario.Text = idBoton;

            //    Negocios.Neg_usuarios iUsuario = new Negocios.Neg_usuarios();

            //    DataTable TableUsuarios = iUsuario.ObtenerRoles();

            //    StringBuilder StrListaRoles = new StringBuilder();

            //    ddlRoles.DataSource = TableUsuarios;
            //    ddlRoles.DataTextField = "rol";
            //    ddlRoles.DataValueField = "id_rol";
            //    ddlRoles.DataBind();
            //    ddlRoles.Items.Insert(0, new ListItem(partes[2], "0"));
            //}

            //protected void Unnamed_Click(object sender, EventArgs e)
            //{
            //    cambiorol.Visible = true;
            //    string idUsuario = lblnumerousuario.Text;
            //    string valorSeleccionado = ddlRoles.SelectedValue;

            //    Negocios.Neg_usuarios iUsuario = new Negocios.Neg_usuarios();
            //    iUsuario.CambioRol(idUsuario, valorSeleccionado);



        }


        protected void btnGuardarCambios_Click(object sender, EventArgs e)
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
            ddlRoles.DataTextField = "rol";
            ddlRoles.DataValueField = "id_rol";
            ddlRoles.DataBind();
            ddlRoles.Items.Insert(0, new ListItem(partes[2], "0"));
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            cambiorol.Visible = true;
            string idUsuario = lblnumerousuario.Text;
            string valorSeleccionado = ddlRoles.SelectedValue;

            Negocios.Neg_Usuarios iUsuario = new Negocios.Neg_Usuarios;
            iUsuario.CambioRol(idUsuario, valorSeleccionado);
        }
    }
}