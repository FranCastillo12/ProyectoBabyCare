using System;
using System.Collections.Generic;
using System.Globalization;
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
        List<Entidades.PrioridadCitas> prioridadCitas = Negocios.Citas.verPrioridadCitas();
        private bool nueva = true;
        int idCita = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];

            if (credenciales == null)
            {
                Response.Redirect("ControlPanel.aspx");
            }

            //No tiene bebes registrados
            if (credenciales.IdenBebe == null || credenciales.IdenBebe == "" || credenciales.Rol == "Abuelo" || credenciales.Rol == "BabySister" || credenciales.Rol == "Invitado")
            {
                //Alertas
                Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                DateTime horaActual = DateTime.Now;
                alert.ActivateAlertas(horaActual, Convert.ToInt32(credenciales.IdenBebe));
                List<Entidades.Alerta> alertas = alert.TraerAlertas(Convert.ToInt32(credenciales.IdenBebe));

                string scriptalerta = null;
                foreach (Entidades.Alerta alrt in alertas)
                {
                    if (alrt.HoraDeAlerta.TimeOfDay <= horaActual.TimeOfDay && alrt.Estado == true)
                    {
                        scriptalerta =
                    "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.warning('Hay una alerta pendiente en estos momentos! ({alrt.HoraDeAlerta.ToString("hh:mm tt")})');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrWarning", scriptalerta, true);
                    }
                }
                //Fin alertas

                //Mostrar mensaje de que debe registrar un bebe para poder utilizar esta pantalla
                deshabilitarControles();
                string mensaje;

                if (credenciales.IdenBebe == "" || credenciales.IdenBebe == null)
                    mensaje = "No tienes un bebé registrado para poder registrar vacunas";
                else
                    mensaje = "Como usuario " + credenciales.Rol + " no puedes registrar Vacunas";
                string script =
                               "toastr.options.closeButton = true;" +
                               "toastr.options.positionClass = 'toast-top-full-width';" +
                               $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else //Tiene al menos un bebe registrado
            {
                habilitarControles();
                if (!IsPostBack)
                {
                    foreach (PrioridadCitas p in prioridadCitas)
                    {
                        drpPrioridad.Items.Add(p.Prioridad);

                    }
                    //drpFiltro.Items.Add("Sin filtro");
                    //drpFiltro.Items.Add("Fecha");
                    //drpFiltro.Items.Add("Prioridad");

                }
                //Generamos la lista de citas
                GenerarContenidoCitas();
                //Validaciones si es edicion o nueva
                if (Session["Editar"] != null && (bool)Session["Editar"] == true)
                {
                    nueva = false;
                }
                else if (Session["Editar"] != null && (bool)Session["Editar"] == false)
                {
                    nueva = true;
                }
                //Guardamos el id del bebe seleccionado acutlamente
                int idBebe = Convert.ToInt16(credenciales.IdenBebe);
            }
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
                    DateTime fechaOriginal = cita.Fecha;
                    string fechaFormateada;
                    fechaFormateada = fechaOriginal.ToString("dddd d MMMM yyyy hh:mm tt", CultureInfo.CreateSpecificCulture("en-us"));
                    Label lblCitaFecha = new Label
                    {
                        ID = "lblCitaFecha_" + cita.IdCita,
                        Text = fechaFormateada,
                        CssClass = "ContenidoCitas"
                    };
                    Label lblCitaPrioridad = new Label
                    {
                        ID = "lblCitaPrioridad_" + cita.IdCita,
                        Text = cita.Prioridad,
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

                    Panel contenedorCita = new Panel();

                    switch (cita.Prioridad)
                    {
                        case "Baja":
                            contenedorCita.CssClass = "CitaBaja";
                            break;
                        case "Media":
                            contenedorCita.CssClass = "CitaMedia";
                            break;
                        case "Alta":
                            contenedorCita.CssClass = "CitaAlta";
                            break;
                        default:
                            contenedorCita.CssClass = "CitaNormal";
                            break;
                    }

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
                    contenedorCita.Controls.Add(lblCitaPrioridad);

                    contenedorEditar.Controls.Add(btnEditar);
                    contenedorBorrar.Controls.Add(btnEliminar);

                    Citas.Controls.Add(contenedorCita);
                    Citas.Controls.Add(contenedorEditar);
                    Citas.Controls.Add(contenedorBorrar);
                    contenedorCitas.Controls.Add(Citas);
                }
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;

                string script =
                                 "toastr.options.closeButton = true;" +
                                 "toastr.options.positionClass = 'toast-top-full-width';" +
                                 $"toastr.error('{mensaje}');";
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

                        
                        //DateTime fecha = DateTime.ParseExact(cita.Fecha.ToString(), "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture);

                        DateTime fecha = cita.Fecha;
                        txtFecha.Text = fecha.ToString("yyyy-MM-ddTHH:mm");

                        switch (cita.Prioridad)
                        {
                            case "Baja":
                                drpPrioridad.SelectedIndex = 1;
                                break;
                            case "Media":
                                drpPrioridad.SelectedIndex = 2;
                                break;
                            case "Alta":
                                drpPrioridad.SelectedIndex = 3;
                                break;
                            default:
                                drpPrioridad.SelectedIndex = 0;
                                break;
                        }

                        nueva = false;
                        Session["Editar"] = true;
                    }
                    else if (accion == "Eliminar")
                    {
                        try
                        {
                            Negocios.Citas.BorrarCita(cita.IdCita);
                            Response.Redirect("Salud_Citas.aspx", false);
                        }
                        catch (Exception exc)
                        {
                            string mensaje = exc.Message;
                            string script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-top-full-width';" +
                                $"toastr.error('{mensaje}');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                        }
                    }
                }
            }
        }
        protected void btnAgrear_Click(object sender, EventArgs e) //Este boton agrega y tambien edita
        {
            try
            {
                //Validamos que los campos vengan con datos
                if (txtLugar.Text.Length < 5 || txtTitulo.Text.Length < 5 || txtFecha.Text.Length < 5)
                {
                    throw new Exception("Los datos ingresados no son validos");
                }

                //Creamos objeto prioridadCitas para buscar el index seleccionado 
                Entidades.PrioridadCitas p = prioridadCitas.FirstOrDefault(c => c.Prioridad == drpPrioridad.Text);
                int idPrioridad = p.IdPrioridad;

                if (!nueva)  //Editar
                {
                    int idCitaSeleccionada = Convert.ToInt16((string)Session["idCita"]); //La cita seleccionada
                    Negocios.Citas.EditarCita(idCitaSeleccionada, txtLugar.Text, txtTitulo.Text, Convert.ToDateTime(txtFecha.Text), idPrioridad);
                    Session["Editar"] = false; //Para saber que ya se aplico la edicion
                    Response.Redirect("Salud_Citas.aspx", false);
                }
                else //Nueva
                {
                    //Validamos que la fecha no sea menor al dia de mañana
                    if (Convert.ToDateTime(txtFecha.Text) < DateTime.Today)
                    {
                        throw new Exception("La fecha no puede ser menor al dia de hoy");
                    }
                    En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];
                    int idBebe = Convert.ToInt16(credenciales.IdenBebe);
                    Negocios.Citas.NuevaCita(idBebe, txtLugar.Text, txtTitulo.Text, Convert.ToDateTime(txtFecha.Text), idPrioridad);
                    Response.Redirect("Salud_Citas.aspx", false);
                }
            }
            catch (Exception exc)
            {
                string mensajeError = exc.Message;
                string script =
                                 "toastr.options.closeButton = true;" +
                                 "toastr.options.positionClass = 'toast-top-full-width';" +
                                 $"toastr.error('{mensajeError}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        private void deshabilitarControles()
        {
            txtLugar.Enabled = false;
            txtTitulo.Enabled = false;
            txtFecha.Enabled = false;
            btnAgrear.Enabled = false;
            btnAgregarNueva.Enabled = false;
            drpPrioridad.Enabled = false;
        }
        private void habilitarControles()
        {
            txtLugar.Enabled = true;
            txtTitulo.Enabled = true;
            txtFecha.Enabled = true;
            btnAgrear.Enabled = true;
            btnAgregarNueva.Enabled = true;
            drpPrioridad.Enabled = true;
        }
        protected void btnAgregarNueva_Click1(object sender, EventArgs e)
        {
            btnAgrear.Text = "Agregar";
            txtLugar.Text = "";
            txtTitulo.Text = "";
            txtFecha.Text = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm");
            drpPrioridad.SelectedIndex = 0;
            nueva = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        #region Comentado
        //private void orderListaFecha()
        //{
        //    if (!ckAscendente.Checked)
        //    {
        //       listaCitas = listaCitas.OrderByDescending(c=>c.Fecha).ToList();
        //        GenerarContenidoCitas();
        //    }
        //    else
        //    {
        //        listaCitas = listaCitas.OrderBy(c => c.Fecha).ToList();
        //        GenerarContenidoCitas();
        //    }
        //}
        //private void orderarListaPrioridad()
        //{
        //    if (!ckAscendente.Checked)
        //    {
        //        listaCitas = listaCitas.OrderByDescending(c => c.Prioridad).ToList();
        //        GenerarContenidoCitas();
        //    }
        //    else
        //    {
        //        listaCitas = listaCitas.OrderBy(c => c.Prioridad).ToList();
        //        GenerarContenidoCitas();
        //    }
        //}
        //protected void drpFiltro_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (drpFiltro.SelectedIndex == 0)
        //    {
        //        GenerarContenidoCitas();
        //    }
        //    else if (drpFiltro.SelectedIndex == 1)
        //    {
        //        orderListaFecha();
        //        GenerarContenidoCitas();
        //    }
        //    else if (drpFiltro.SelectedIndex == 2)
        //    {

        //        orderarListaPrioridad();
        //        GenerarContenidoCitas();
        //    }
        //}
        #endregion
    }
}