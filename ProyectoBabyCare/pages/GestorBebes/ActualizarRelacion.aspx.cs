using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class ActualizarRelacion : System.Web.UI.Page
    {
        // string strRol=null;         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Entidades.Roles> roles = Negocios.Administracion.ListaRoles();
                foreach (var rol in roles)
                {
                    drpRol.Items.Add(rol.NombreRol);
                }
                Entidades.UsuariosBebes usuario =(Entidades.UsuariosBebes)Session["RelacionUsuario"];
                if (usuario != null)
                {
                    txtId.Text = usuario.IdUsuario.ToString();
                    txtNombre.Text = usuario.Nombre;
                    txtApellidos.Text = usuario.Apellidos;
                    txtIdBebe.Text = usuario.Idbebe.ToString();
                    txtNombreBebe.Text = usuario.NombreBebe;
                    txtEncargado.Text = usuario.Encargado.ToString();                    
                    foreach (var rol in roles)
                    {
                        if (rol.NombreRol == usuario.Rol)
                        {
                            ListItem selectedItem = drpRol.Items.FindByText(rol.NombreRol);
                            if (selectedItem != null)
                            {
                                selectedItem.Selected = true;
                                //strRol = selectedItem.Text;
                                Session["RolInicial"]= selectedItem.Text;
                            }
                        }
                    }
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (drpRol.Text == (String)Session["RolInicial"])
            {
                MostrarMensajeRedireccionamiento("No se realizaron cambios. Será redirigido a la pantalla de usuarios.");
            }
            else // Se cambió el rol
            {
                ActualizarRolUsuario();
            }
        }

        private void MostrarMensajeRedireccionamiento(string mensaje)
        {
            string script =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

            RedireccionarA("PerfilesSistema.aspx");
        }
        private void MostrarMensaje(string mensaje)
        {
            string script =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);            
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

        private void ActualizarRolUsuario()
        {
            List<Entidades.Roles> roles = Negocios.Administracion.ListaRoles();
            string drpRolStr = drpRol.SelectedItem != null ? drpRol.SelectedItem.Text : null;

            var rolSeleccionado = roles.FirstOrDefault(r => r.NombreRol == drpRolStr);
            if (rolSeleccionado != null)
            {                
                try
                {
                    Entidades.UsuariosBebes usuario = (Entidades.UsuariosBebes)Session["RelacionUsuario"];
                    if (usuario.Encargado)
                    {
                        if (rolSeleccionado.IdRol != 2 && rolSeleccionado.IdRol != 3)
                        {
                            MostrarMensaje("El encargado solo puede ser padre o madre");
                        }
                        else
                        {
                            actualizar(usuario,rolSeleccionado);
                        }
                    }
                    else
                    {
                        actualizar(usuario, rolSeleccionado);
                    }
                    
                }
                catch (Exception)
                {
                    MostrarMensajeRedireccionamiento("No se pudo actualizar el rol del usuario, algo salió mal.");
                }
            }
        }
        private void actualizar(Entidades.UsuariosBebes usuario, Entidades.Roles rolSeleccionado)
        {
            int idUsuario = usuario.IdUsuario;
            int idBebe = usuario.Idbebe;
            int idRol = rolSeleccionado.IdRol;

            Negocios.Administracion.ActualizarRelacionUsuarioBebe(idUsuario, idBebe, idRol);

            MostrarMensajeRedireccionamiento("Se actualizó el rol del usuario. Será redirigido a la pantalla de usuarios.");
        }

    }
}