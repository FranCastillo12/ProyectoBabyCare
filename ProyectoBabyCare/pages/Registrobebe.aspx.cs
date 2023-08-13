using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace ProyectoBabyCare.pages
{
    public partial class Registrobebe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string script = "<script>document.body.style.zoom = '80%';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Set100PercentSizeScript", script);
        }

        protected void btnCrearCuentabebe_Click(object sender, EventArgs e)
        {
            string script = null;
            try
            {
                Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
                int idUsuario = credenciales.IdUsuario;
                string nombre = txtNombre.Text;
                string apellidos = TxtApellidos.Text;
                bool entrar = false;
                string fecha_nacimiento = txtfechadenacimiento.Text;
                string valorSeleccionado = ddl_departamentos.SelectedValue;
                string regexNombre = @"^[A-Za-z ]+$";

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
                if (valorSeleccionado == "0")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe seleccionar un parentezco');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (entrar)
                {

                }
                else
                {
                    Negocios.Neg_bebes iBebes = new Negocios.Neg_bebes();

                    iBebes.Registrarbebe(nombre, apellidos, fecha_nacimiento, idUsuario, valorSeleccionado);
                    Response.Redirect("Perfil.aspx");
                    //Poner el mensaje de exito
                    //    script = @"Swal.fire({
                    //        title: '¡Hola!',
                    //        text: 'Esto es SweetAlert2 desde ASP.NET',
                    //        icon: 'sucess'
                    //    });";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                }


            }
            catch (Exception ex)
            {
                script =
                       "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                       "toastr.warning('Ha occurido un error,Intentelo mas tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }

        protected void btnUnirseCodigo_Click(object sender, EventArgs e)
        {
            string script = null;
            try
            {
                Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
                int idUsuario = credenciales.IdUsuario;
                bool entrar = false;

                string codigo = txtCodigo.Text;


                if (codigo == "")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe de ingresar un código');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (entrar)
                {

                }
                else
                {
                    Negocios.Neg_bebes iBebes = new Negocios.Neg_bebes();
                   //Consulta para saber si la persona ya se encuentra enlazado al bebe
                    int consutla = iBebes.VerificarCodigobebe(idUsuario, codigo);
                    if (consutla == 0)
                    {
                        iBebes.IngresarXcodigo(idUsuario, codigo);
                        Response.Redirect("Perfil.aspx");
                    }
                    else
                    {
                       script = @"
                                    Swal.fire({
                                title: '¡Error!',
                                    text: 'El bebé ya se encuentra enlazado a su cuenta',
                                     icon: 'error'
                                     }).then(function() {
                                        // Esta función se ejecutará después de que el usuario haga clic en el botón 'Aceptar' de la alerta.
                                    window.location.href = 'Perfil.aspx'; // Reemplaza 'PaginaDeLogin.aspx' con la página de inicio de sesión.
                                        });
                                        ";

                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                    }
                }
            }
            catch (Exception ex)
            {
                if(ex.ToString() == "El codigo del bebé no existe")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('El codigo del bebé no existe');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                script = "toastr.warning('Ha occurido un error,Intentelo mas tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

            }
        }
    }
}
