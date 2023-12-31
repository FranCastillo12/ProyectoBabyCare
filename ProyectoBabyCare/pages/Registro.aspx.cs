﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string script = "<script>document.body.style.zoom = '80%';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Set100PercentSizeScript", script);
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            string script = null;
            try
            {

                string nombre = txtNombre.Text;
                string apellidos = TxtApellidos.Text;
                string correo = txtCorreo.Text;
                string pass = TxtContra.Text;
                bool entrar = false;
                string regexEmail = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
                string regexNombre = @"^[A-Za-z ]+$";

                Regex regex = new Regex(regexEmail);
                Regex regexNombreU = new Regex(regexNombre);
                if (nombre == "")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('El nombre es requerido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (!regexNombreU.IsMatch(nombre))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                       "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('El nombre solo puede tener letras');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (!regexNombreU.IsMatch(apellidos))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Los apellidos solo pueden tener letras');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (apellidos == "")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Los apellidos es requerido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (correo == "")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('El correo es requerido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }

                if (!regex.IsMatch(correo))
                {
                    script =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('El email no es valido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El email no es valido <br>";
                    entrar = true;
                }
                if (pass == "")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('La contraseña es requerido');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (entrar)
                {

                }
                else
                {

                    Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();
                    int consutla = iUsuarios.VertificarCorreo(correo);
                    if (consutla > 0)
                    {
                        script =
                       "toastr.options.closeButton = true;" +
                      "toastr.options.positionClass = 'toast-bottom-right';" +
                       "toastr.error('El correo ingresado ya existe');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        txtCorreo.Text = "";
                        txtNombre.Text = "";
                        TxtApellidos.Text = "";
                        TxtContra.Text = "";
                    }
                    else
                    {
                        iUsuarios.RegistroUsuarios(nombre, apellidos, correo, pass);
                        Response.Redirect("../Login.aspx");
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