using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string script = null;
            try
            {

                string user = username.Text;
                string pass = password.Text;
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
                    //warnings.InnerHtml = warningss;

                }
                else
                {
                    if (Page.IsValid)
                    {
                        Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();


                        DataTable resultTable = iUsuarios.VerificarCredencialesAdmin(user, pass);

                        if (resultTable != null && resultTable.Rows.Count > 0)
                        {
                            // Assuming the value you need to retrieve is in the first row and first column of the DataTable
                            string correo = resultTable.Rows[0][0].ToString();
                            Session["Correo"] = correo;
                            //Falta cambiar pantalla
                            Response.Redirect("pages/GestorBebes/index.aspx");
                        }
                        else
                        {
                            script = @"Swal.fire({
                        title: '¡Error!',
                        text: 'Correo/Contraseña incorrectos',
                        icon: 'error'
                    });";
                            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                            username.Text = "";
                            password.Text = "";

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
    }
}