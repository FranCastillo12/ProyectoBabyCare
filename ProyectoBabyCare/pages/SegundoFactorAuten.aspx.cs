using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class SegundoFactorAuten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string script = "<script>document.body.style.zoom = '80%';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Set100PercentSizeScript", script);
        }

        protected void btnReenviar_Click(object sender, EventArgs e)
        {
            string script = null;
            if (Session["Credenciales"] != null)
            {
                Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
                int idUsuario = credenciales.IdUsuario;

                Entidades.Usuarios usuario = Negocios.Usuarios.GetUsuarioById(idUsuario);
                if (usuario != null)
                {
                    Negocios.Correos correos = new Negocios.Correos();
                    //Generamos el token
                    string token = correos.EnviarToken(usuario.Correo);
                    Session["tokenLogin"] = token;

                    //lblMensaje.Text = "Codigo reenviado correctamente a " + usuario.Correo;

                    script =
                        "toastr.options.closeButton = true;" +
                       "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.success('El correo se ha reenviado');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                else
                {
                    script =
                        "toastr.options.closeButton = true;" +
                       "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('No se pudo encontrar el correo');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                    //lblMensaje.Text = "No se pudo encontrar el correo";
                }
            }
            else
            {
                script =
                        "toastr.options.closeButton = true;" +
                       "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.warning('No se pudieron encontrar sus datos con el correo ingresado');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                // lblMensaje.Text = "No se pudieron encontrar sus datos con el correo ingresado";
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            string script = null;
            if (Session["tokenLogin"] != null)
            {
                string strToken = (string)Session["tokenLogin"];

                if (strToken == txtCorreo.Text)
                {                    
                    Response.Redirect("ControlPanel.aspx");
                }
                else
                {
                    script =
                         "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                         "toastr.error('El token ingresado no es valido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                    //lblMensaje.Text = "El token ingresado NO es valido";
                }
            }
            else
            {
                script =
                         "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                         "toastr.error('No se pudo enviar el codigo');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                //lblMensaje.Text = "No se pudo enviar el codigo";
            }
        }
    }
}