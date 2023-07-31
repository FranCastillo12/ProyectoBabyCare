using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace ProyectoBabyCare.pages
{
    public partial class Salud_Citas : System.Web.UI.Page
    {
        List<Entidades.Citas> listaCitas = new List<Entidades.Citas>();
        private bool nueva = true;         
        int idCita;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Editar"] != null && (bool)Session["Editar"] == true)
            {
                nueva = false;
            }
            else if (Session["Editar"] != null && (bool)Session["Editar"] == false)
            {
                nueva = true;
            }
            GenerarContenidoCitas();
            En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];
            int idBebe = Convert.ToInt16(credenciales.IdenBebe);
        }
        private void GenerarContenidoCitas()
        {
            try
            {
                En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];                
                int idBebe = Convert.ToInt16(credenciales.IdenBebe);
                listaCitas = Negocios.Citas.ListaCitas(idBebe);

                foreach (var cita in listaCitas)
                {

                    Label lblCitaLugar = new Label
                    {
                        ID = "lblCitaId_" + cita.IdCita,
                        Text = cita.Lugar,
                        CssClass = "ContenidoCitas"
                    };
                    Label lblCitaTitulo = new Label
                    {
                        ID = "lblCitaTitulo_" + cita.IdCita,
                        Text = cita.Titulo,
                        CssClass = "ContenidoCitas"
                    };
                    Label lblCitaFecha = new Label
                    {
                        ID = "lblCitaFecha_" + cita.IdCita,
                        Text = cita.Fecha.ToString(),
                        CssClass = "ContenidoCitas"
                    };

                    Button btnEditar = new Button
                    {
                        ID = "btnEditar_" + cita.IdCita, // Asignar un ID único al botón
                        Text = "Editar",
                        CssClass = "btnEditar"
                    };
                    btnEditar.Click += ButtonEditarEliminar_Click;

                    Button btnEliminar = new Button
                    {
                        ID = "btnEliminar_" + cita.IdCita, // Asignar un ID único al botón
                        Text = "Borrar",
                        CssClass = "btnEditar"
                    };
                    btnEliminar.Click += ButtonEditarEliminar_Click;

                    Panel Citas = new Panel
                    {
                        CssClass = "Citas"
                    };

                    Panel contenedorCita = new Panel
                    {
                        CssClass = "Citas1"
                    };

                    Panel contenedorEditar = new Panel
                    {
                        CssClass = "Citas2",
                    };

                    Panel contenedorBorrar = new Panel
                    {
                        CssClass = "Citas2"
                    };

                    contenedorCita.Controls.Add(lblCitaLugar);
                    contenedorCita.Controls.Add(lblCitaTitulo);
                    contenedorCita.Controls.Add(lblCitaFecha);

                    contenedorEditar.Controls.Add(btnEditar);
                    contenedorBorrar.Controls.Add(btnEliminar);

                    Citas.Controls.Add(contenedorCita);
                    Citas.Controls.Add(contenedorEditar);
                    Citas.Controls.Add(contenedorBorrar);
                    contenedorCitas.Controls.Add(Citas);
                }
            }
            catch (Exception)
            {
                string script =
                                 "toastr.options.closeButton = true;" +
                                 "toastr.options.positionClass = 'toast-bottom-right';" +
                                 "toastr.error('Revisar los datos ingresados');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        protected void ButtonEditarEliminar_Click(object sender, EventArgs e)
        {
            Button btnEditarEliminar = (Button)sender;
            string idBoton = btnEditarEliminar.ID;

            string accion = idBoton.StartsWith("btnEditar_") ? "Editar" : idBoton.StartsWith("btnEliminar_") ? "Eliminar" : string.Empty;

            if (!string.IsNullOrEmpty(accion))
            {
                string idCita = idBoton.Replace("btnEditar_", "").Replace("btnEliminar_", "");
                Session["idCita"] = idCita;
                var cita = listaCitas.FirstOrDefault(c => c.IdCita == Convert.ToInt16(idCita));

                if (cita != null)
                {
                    if (accion == "Editar")
                    {
                        btnAgrear.Text = "Confirmar edición";
                        this.idCita = cita.IdCita;
                        txtLugar.Text = cita.Lugar;
                        txtTitulo.Text = cita.Titulo;
                        txtFecha.Text = cita.Fecha.ToString();
                        nueva = false;
                        Session["Editar"] = true;
                    }
                    else if (accion == "Eliminar")
                    {                        
                        try
                        {
                            Negocios.Citas.BorrarCita(cita.IdCita);
                            Response.Redirect("Salud_Citas.aspx",false);
                        }
                        catch (Exception)
                        {

                            string script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-bottom-right';" +
                                "toastr.error('Revisar los datos ingresados');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                        }                        
                    }
                }
            }
        }

        protected void btnAgrear_Click(object sender, EventArgs e)
        {
            try
            {
                string validar;
                validar = txtLugar.Text.Substring(5);
                validar = txtTitulo.Text.Substring(5);
                DateTime fecha = Convert.ToDateTime(txtFecha.Text);
            }
            catch
            {
                lblMensaje.Text = "Debe digitar datos válidos";
            }
            try
            {
                if (!nueva)  //Editar
                {
                    int idSession = Convert.ToInt16((string)Session["idCita"]);
                    Negocios.Citas.EditarCita(idSession, txtLugar.Text, txtTitulo.Text, Convert.ToDateTime(txtFecha.Text));
                    Session["Editar"] = false;
                    Response.Redirect("Salud_Citas.aspx", false);
                }
                else //Nueva
                {
                    En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];
                    int idBebe = Convert.ToInt16(credenciales.IdenBebe);
                    Negocios.Citas.NuevaCita(idBebe, txtLugar.Text, txtTitulo.Text, Convert.ToDateTime(txtFecha.Text));
                    Response.Redirect("Salud_Citas.aspx", false);
                }
            }
            catch (Exception exc)
            {
                string script =
                                 "toastr.options.closeButton = true;" +
                                  "toastr.options.positionClass = 'toast-bottom-right';" +
                                 "toastr.error('Revisar los datos ingresados');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }

        }

        protected void btnAgregarNueva_Click(object sender, EventArgs e)
        {
            btnAgrear.Text = "Agregar";
            txtLugar.Text ="";
            txtTitulo.Text = "";
            txtFecha.Text = "";
            nueva = true;
            
        }
    }    
}