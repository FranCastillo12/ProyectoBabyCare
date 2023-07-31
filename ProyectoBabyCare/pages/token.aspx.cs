using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocios;
using Entidades;
namespace ProyectoBabyCare.pages
{
    public partial class token : System.Web.UI.Page
    {     
        protected void Page_Load(object sender, EventArgs e)
        {            

        }

        protected void btnToken_Click(object sender, EventArgs e)
        {
            if (Session["tokenLogin"] != null)
            {
                string strToken = (string)Session["tokenLogin"];

                if (strToken == txtToken.Text)
                {
                    lblMensaje.Text = "El token ingresado SI es valido";
                    //Response.Redirect("ControlPanel.aspx");
                }
                else
                {
                    lblMensaje.Text = "El token ingresado NO es valido";
                }
            }
            else
            {
                lblMensaje.Text = "No se pudo enviar el codigo";

            }
        }

        protected void btnReenviar_Click(object sender, EventArgs e)
        {
            if (Session["Credenciales"] != null)
            {
                En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];
                int idUsuario = credenciales.IdUsuario;

                Entidades.Usuarios usuario = Negocios.Usuarios.GetUsuarioById(idUsuario);
                if (usuario != null)
                {
                    Negocios.Correos correos = new Negocios.Correos();
                    //Generamos el token
                    string token = correos.EnviarToken(usuario.Correo);
                    Session["tokenLogin"] = token;
                    lblMensaje.Text = "Codigo reenviado correctamente a "+usuario.Correo;
                }
                else
                {
                    lblMensaje.Text = "No se pudo encontrar el correo";
                }
            }
            else
            {
                lblMensaje.Text = "No se pudieron encontrar sus datos con el correo ingresado";
            }
        }
    }
}