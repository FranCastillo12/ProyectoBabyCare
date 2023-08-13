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
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            List<Entidades.UsuariosSistema> usuarios = Negocios.Administracion.ListaUsuariosSistema();

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
                linkBebes.NavigateUrl = "DetalleUsuario.aspx?idUsuario=" + user.IdUsuario;
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
            btnEditar.Text = " Editar";
            btnEditar.CssClass = "btn btn-primary";
            
            HtmlGenericControl icon = new HtmlGenericControl("i");
            icon.Attributes["class"] = "bi bi-pencil";
            
            btnEditar.Controls.Add(icon);

            btnEditar.Click += (s, e) =>
            {
               
            };


            Button btnEliminar = new Button();
            btnEliminar.Text = " Delete";
            btnEliminar.CssClass = "btn btn-danger";
           
            icon.Attributes["class"] = "bi bi-trash";
           
            btnEliminar.Controls.Add(icon);

            btnEliminar.Click += (s, e) =>
            {
                
            };

            // Crea un contenedor para los botones de opciones.
            Panel panelOpciones = new Panel();
            panelOpciones.Controls.Add(btnEditar);
            btnEliminar.Style.Add("margin-top", "10px");
            panelOpciones.Controls.Add(btnEliminar);

            return panelOpciones;
        }
    }
}