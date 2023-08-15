using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class RelacionesUsuario : System.Web.UI.Page
    {
        List<Entidades.UsuariosBebes> lista = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idUsuario"] != null)
            {
                // Capturar el valor del parámetro "idUser" y convertirlo a entero
                int idUser = Convert.ToInt32(Request.QueryString["idUsuario"]);

                CargarLista(idUser);
            }
        }

        private void CargarLista(int idUsuario)
        {
            try
            {
                lista = Negocios.Administracion.ListaUsuarioBebe(idUsuario);
                foreach (Entidades.UsuariosBebes fila in lista)
                {
                    TableRow row = new TableRow();

                    TableCell cellIdUsuario = new TableCell();
                    cellIdUsuario.Text = fila.IdUsuario.ToString();
                    row.Cells.Add(cellIdUsuario);

                    TableCell cellNombre = new TableCell();
                    cellNombre.Text = fila.Nombre;
                    row.Cells.Add(cellNombre);

                    TableCell cellApellidos = new TableCell();
                    cellApellidos.Text = fila.Apellidos;
                    row.Cells.Add(cellApellidos);

                    TableCell cellIdBebe = new TableCell();
                    cellIdBebe.Text = fila.Idbebe.ToString();
                    row.Cells.Add(cellIdBebe);

                    TableCell cellNombreBebe = new TableCell();
                    cellNombreBebe.Text = fila.NombreBebe;
                    row.Cells.Add(cellNombreBebe);

                    TableCell cellIdRol = new TableCell();
                    cellIdRol.Text = fila.IdRol.ToString();
                    row.Cells.Add(cellIdRol);

                    TableCell cellRol = new TableCell();
                    cellRol.Text = fila.Rol;
                    row.Cells.Add(cellRol);

                    TableCell cellEncargado = new TableCell();
                    cellEncargado.Text = fila.Encargado.ToString();
                    row.Cells.Add(cellEncargado);

                    TableCell cellOpciones = new TableCell();
                    cellOpciones.Controls.Add(CrearOpcionesParaUsuario(fila.IdUsuario, fila.Idbebe));
                    row.Cells.Add(cellOpciones);

                    tablaUsuarios.Rows.Add(row);
                }
            }
            catch (Exception)
            {
                MostrarMensaje("No se pudieron cargar las relaciones, intente de nuevo mas tarde");
            }
        }
        private Control CrearOpcionesParaUsuario(int idUsuario, int idBebe)
        {
            Button btnEditar = new Button();
            btnEditar.Text = "Modificar Rol";
            btnEditar.CssClass = "btn btn-primary";
            btnEditar.Attributes["data-idusuario"] = idUsuario.ToString();
            btnEditar.Attributes["data-idBebe"] = idBebe.ToString();
            HtmlGenericControl icon = new HtmlGenericControl("i");
            icon.Attributes["class"] = "bi bi-pencil";
            btnEditar.Controls.Add(icon);

            btnEditar.Click += (s, e) =>
            {
                // Accede al atributo personalizado para obtener el valor del ID
                int usuarioId = int.Parse(btnEditar.Attributes["data-idusuario"]);
                int bebeId = int.Parse(btnEditar.Attributes["data-idBebe"]);
                editarUsuario(usuarioId, bebeId);
            };

            Button btnEliminar = new Button();
            btnEliminar.Text = "Eliminar Relacion";
            btnEliminar.CssClass = "btn btn-danger";
            btnEliminar.Attributes["data-idusuario"] = idUsuario.ToString();
            btnEliminar.Attributes["data-idBebe"] = idBebe.ToString();
            icon.Attributes["class"] = "bi bi-trash";

            btnEliminar.Controls.Add(icon);

            btnEliminar.Click += (s, e) =>
            {
                int usuarioId = int.Parse(btnEliminar.Attributes["data-idusuario"]);
                int bebeId = int.Parse(btnEliminar.Attributes["data-idBebe"]);
                eliminarUsuario(usuarioId, bebeId);
            };

            // Crea un contenedor para los botones de opciones.
            Panel panelOpciones = new Panel();
            panelOpciones.Controls.Add(btnEditar);
            panelOpciones.Controls.Add(new LiteralControl("<br />")); // Agrega un salto de línea
            btnEliminar.Style.Add("margin-top", "10px");
            panelOpciones.Controls.Add(btnEliminar);

            return panelOpciones;
        }
        private void eliminarUsuario(int idUsuario, int idBebe)
        {
            //Entidades.UsuariosSistema usuario = usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            Entidades.UsuariosBebes usuario = lista.FirstOrDefault(u => u.IdUsuario == idUsuario && u.Idbebe == idBebe);
            try
            {
                if (usuario.Encargado)
                {
                    MostrarMensaje("No se puede eliminar la relacion porque el usuario es encargado");
                }
                else
                {
                    Negocios.Administracion.EliminarRelacionUsuarioBebe(usuario.IdUsuario, usuario.Idbebe);
                    MostrarMensaje("Relación eliminada correctamente, será redirigido a la pagina de usuarios");

                    string redirectScript = $@"<script type='text/javascript'>
                                   setTimeout(function () {{
                                       window.location.href = 'PerfilesSistema.aspx';
                                   }}, 3000);
                                 </script>";
                    ScriptManager.RegisterStartupScript(this, GetType(), "RedirectScript", redirectScript, false);
                }
            }
            catch (Exception)
            {
                MostrarMensaje("No se pudo eliminar el usuario, intente de nuevo mas tarde");
            }
        }
        private void editarUsuario(int idUsuario, int idBebe)
        {
            Entidades.UsuariosBebes usuario = lista.FirstOrDefault(u => u.IdUsuario == idUsuario && u.Idbebe == idBebe);
            Session["RelacionUsuario"] = usuario;
            Response.Redirect("ActualizarRelacion.aspx");
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