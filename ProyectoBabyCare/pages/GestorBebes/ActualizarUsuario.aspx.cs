using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class ActualizarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                         
                if (Session["idUsuarioEdit"] != null)
                {
                    int idUsuario = (int)Session["idUsuarioEdit"];
                    List<Entidades.UsuariosSistema> usuarios = Negocios.Administracion.ListaUsuariosSistema();

                    Entidades.UsuariosSistema usuario = usuarios.FirstOrDefault(u => u.IdUsuario==idUsuario);

                    if (usuario != null)
                    {
                        txtId.Text = usuario.IdUsuario.ToString();
                        txtNombre.Text = usuario.Nombre;
                        txtApellidos.Text = usuario.Apellidos;                
                        txtFecha.Text = usuario.FechaRegistro.ToString("dd-MM-yyyy");
                        txtEmail.Text = usuario.Correo;
                        txtPass.Text = usuario.Contraseña;
                        txtBebes.Text = usuario.BebesRegistrados.ToString();
                    }
                }
                else
                {
                    //No se pudo cargar la informacion
                }
            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(txtId.Text);
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;

            if (nombre.Length <= 2)
            {
                // Manejar validación de nombre
                MostrarMensaje("El nombre no es válido");
            }
            else if (apellidos.Length <= 2)
            {
                // Manejar validación de apellidos
                MostrarMensaje("El apellido no es válido");
            }
            else if (email.Length <= 5)
            {
                // Manejar validación de email
                MostrarMensaje("El correo no es válido");
            }
            else if (pass.Length <= 3)
            {
                // Manejar validación de contraseña
                MostrarMensaje("La contraseña no es válida");
            }
            else
            {
                try
                {
                    // Realizar la edición con los valores capturados
                    Negocios.UsuariosSistema.EditarUsuario(idUsuario, nombre, apellidos, email, pass);
                    MostrarMensaje("Usuario actualizado correctamente");
                    RedireccionarA("PerfilesSistema.aspx");                    

                }
                catch (Exception)
                {
                    // Manejar la excepción
                }
            }
        }
        private void MostrarMensaje(string mensaje)
        {
            string script =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

           // RedireccionarA("PerfilesSistema.aspx");
        }
        private void RedireccionarA(string pagina)
        {
            string redirectScript = $@"<script type='text/javascript'>
                               setTimeout(function () {{
                                   window.location.href = '{pagina}';
                               }}, 5000);
                             </script>";
            ScriptManager.RegisterStartupScript(this, GetType(), "RedirectScript", redirectScript, false);
        }
    }
}