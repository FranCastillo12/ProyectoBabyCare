using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class PerfilesSistema : System.Web.UI.Page
    {
        List<Entidades.UsuariosSistema> usuarios = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            usuarios = Negocios.Administracion.ListaUsuariosSistema();

            foreach (Entidades.UsuariosSistema user in usuarios)
            {
                TableRow row = new TableRow();

                TableCell cellIdUsuario = new TableCell();
                cellIdUsuario.Text = user.IdUsuario.ToString();
                row.Cells.Add(cellIdUsuario);

                TableCell cellNombre = new TableCell();
                cellNombre.Text = user.Nombre;
                row.Cells.Add(cellNombre);

                TableCell cellApellidos = new TableCell();
                cellApellidos.Text = user.Apellidos;
                row.Cells.Add(cellApellidos);

                TableCell cellFecha = new TableCell();
                cellFecha.Text = user.FechaRegistro.ToString();
                row.Cells.Add(cellFecha);

                TableCell cellCorreo = new TableCell();
                cellCorreo.Text = user.Correo;
                row.Cells.Add(cellCorreo);

                TableCell cellContraseña = new TableCell();
                cellContraseña.Text = user.Contraseña;
                row.Cells.Add(cellContraseña);

                TableCell cellBebes = new TableCell();
                HyperLink linkBebes = new HyperLink();
                linkBebes.Text = user.BebesRegistrados.ToString();
                linkBebes.NavigateUrl = "RelacionesUsuario.aspx?idUsuario="+user.IdUsuario;
                //Session["UsuarioRelacion"]=

                cellBebes.Controls.Add(linkBebes);
                row.Cells.Add(cellBebes);

                TableCell cellOpciones = new TableCell();
                cellOpciones.Controls.Add(CrearOpcionesParaUsuario(user.IdUsuario));
                row.Cells.Add(cellOpciones);

                tablaUsuarios.Rows.Add(row);
            }

        }
        private Control CrearOpcionesParaUsuario(int idUsuario)
        {
            Button btnEditar = new Button();
            btnEditar.Text = "Modificar";
            btnEditar.CssClass = "btn btn-primary";
            btnEditar.Attributes["data-idusuario"] = idUsuario.ToString(); // Adjunta el ID como atributo personalizado

            HtmlGenericControl icon = new HtmlGenericControl("i");
            icon.Attributes["class"] = "bi bi-pencil";
            btnEditar.Controls.Add(icon);

            btnEditar.Click += (s, e) =>
            {
                // Accede al atributo personalizado para obtener el valor del ID
                int usuarioId = int.Parse(btnEditar.Attributes["data-idusuario"]);
                editarUsuario(usuarioId);
            };

            Button btnEliminar = new Button();
            btnEliminar.Text = "Eliminar";
            btnEliminar.CssClass = "btn btn-danger";
           
            icon.Attributes["class"] = "bi bi-trash";
           
            btnEliminar.Controls.Add(icon);

            btnEliminar.Click += (s, e) =>
            {
                eliminarUsuario(idUsuario);
            };

            // Crea un contenedor para los botones de opciones.
            Panel panelOpciones = new Panel();
            panelOpciones.Controls.Add(btnEditar);
            panelOpciones.Controls.Add(new LiteralControl("<br />")); // Agrega un salto de línea
            btnEliminar.Style.Add("margin-top", "10px");
            panelOpciones.Controls.Add(btnEliminar);

            return panelOpciones;
        }
        private void eliminarUsuario(int idUsuario)
        {            
            Entidades.UsuariosSistema usuario = usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (usuario.BebesRegistrados > 0)
            {
                MostrarMensaje("No se puede eliminar un usuario con bebes relacionados");                
            }
            else
            {
                try
                {
                    Negocios.UsuariosSistema.EliminarUsuario(idUsuario);
                    MostrarMensaje("Usuario eliminado correctamente, espere mientras se recarga la página");
                    string redirectScript = $@"<script type='text/javascript'>
                               setTimeout(function () {{
                                   window.location.href = 'PerfilesSistema.aspx';
                               }}, 5000);
                             </script>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "RedirectScript", redirectScript, false);                   
                }
                catch (Exception)
                {
                    MostrarMensaje("Algo salió mal");
                }
               
            }            
        }
        private void editarUsuario(int idUsuario)
        {
            Entidades.UsuariosSistema usuario = usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);            
            Negocios.UsuariosSistema.EliminarUsuario(idUsuario);
            Session["idUsuarioEdit"] = idUsuario;
            Response.Redirect("ActualizarUsuario.aspx");
            
        }
        private void MostrarMensaje(string mensaje)
        {
            string script =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('{mensaje}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);          
        }
    }
}