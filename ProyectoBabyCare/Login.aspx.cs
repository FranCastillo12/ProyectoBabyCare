using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace ProyectoBabyCare
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string script = null;
            try
            {
                
                string user = txtCorreo.Text;
                string pass = txtContra.Text;
                var warningss = "";
                bool entrar = false;
                string regexEmail = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
                Regex regex = new Regex(regexEmail);

                if (user == "")
                {
                     script =
                         "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-top-full-width';" +
                         "toastr.error('El correo es requerido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }

                if (!regex.IsMatch(user))
                {
                    script = 
                      "toastr.options.closeButton = true;" +
                      "toastr.options.positionClass = 'toast-top-full-width';" +
                      "toastr.error('El email no es valido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El email no es valido <br>";
                    entrar = true;
                }
                if (pass == "")
                {
                    script =
                      "toastr.options.closeButton = true;" +
                      "toastr.options.positionClass = 'toast-top-full-width';" +
                      "toastr.error('La contraseña es necesaria');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "La contraseña es necesaria <br>";
                    entrar = true;
                }
                if (entrar)
                {
                    warnings.InnerHtml = warningss;
                    
                }
                else
                {
                if (Page.IsValid)
                {
                    Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();


                    Entidades.En_Usuarios iCredenciales = iUsuarios.VerificarCredenciales(user, pass);
                        //Guardamos los datos del bebe
                    //Entidades.Bebe bebe = Negocios.Bebe.bebe(iCredenciales.IdenBebe);

                    if (iCredenciales != null)
                    {
                        Session["Credenciales"] = iCredenciales;
                            //variable de sesion con datos del bebe

                        //Session["DatosBebe"] = bebe;


                        //Session["DatosBebe"] = bebe;

                        Response.Redirect("pages/ControlPanel.aspx");
                    }
                    else
                    {
                       script = @"Swal.fire({
                        title: '¡Error!',
                        text: 'Correo/Contraseña incorrectos',
                        icon: 'error'
                    });";
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                            txtCorreo.Text = "";
                            txtContra.Text = "";
                        
                    }
                }
                }
            }
            catch (Exception ex)
            {
                script = "toastr.warning('Ha occurido un error,Intentelo mas tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("pages/Registro.aspx");
        }
    }
}
