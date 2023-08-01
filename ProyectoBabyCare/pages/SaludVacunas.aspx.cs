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
    public partial class SaludVacunas : System.Web.UI.Page
    {
        List<Entidades.Vacunas> listaVacunas = new List<Entidades.Vacunas>();
        int idBebe = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];
                if (credenciales.IdenBebe == null || credenciales.IdenBebe == "" || credenciales.Rol == "Abuelo" || credenciales.Rol == "BabySister" || credenciales.Rol == "Invitado")
                {
                    //Response.Redirect("Perfil.aspx");
                    //Mostrar mensaje de que se debe registar un bebe
                    deshabilitarControles();
                    string mensaje;
                    if (credenciales.IdenBebe == "" || credenciales.IdenBebe == null)                    
                        mensaje = "No tienes un bebé registrado para poder registrar vacunas";
                    else
                        mensaje = "Como usuario "+credenciales.Rol+" no puedes registrar Vacunas";
                    string script =
                                   "toastr.options.closeButton = true;" +
                                   "toastr.options.positionClass = 'toast-bottom-right';" +
                                   $"toastr.error('{mensaje}');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                else
                {
                    //Guardamos el id del bebe seleccionado
                    idBebe = Convert.ToInt16(credenciales.IdenBebe);

                    ////Valicion de que existe el expediente
                    Negocios.Expediente ex = new Negocios.Expediente();
                    string ExisteExpediente = ex.ValidarExpediente(idBebe);
                    if (ExisteExpediente.Equals("No existe"))
                    {
                        Response.Redirect("RegistrarExpediente.aspx");
                    }
                    //Fin valicion de que existe el expediente
                    //Habilitar los controles 
                    habilitarControles();
                    listaVacunas = Negocios.Vacunas.ListaVacunas(idBebe);

                    // Recorrer la lista de vacunas y crear elementos HTML para cada una
                    foreach (var vacuna in listaVacunas)
                    {
                        // Crear el botón para la vacuna
                        Button btnVacuna = new Button
                        {
                            ID = "btnVacuna_" + vacuna.IdVacuna, // Asignar un ID único al botón
                            Text = vacuna.Nombre,
                            CssClass = "btnAceptar"
                        };
                        btnVacuna.Click += ButtonVacuna_Click; // Asignar un evento click para el botón

                        // Crear el div contenedor para cada vacuna
                        Panel contenedor = new Panel();

                        contenedor.CssClass = "Vacuna";
                        contenedor.Controls.Add(new Panel
                        {
                            CssClass = "VacunaLogo",
                            Controls = { new Image { ImageUrl = "../images/flecha2.png", AlternateText = "", Width = Unit.Percentage(100), Height = Unit.Percentage(100) } }
                        });
                        contenedor.Controls.Add(new Panel
                        {
                            CssClass = "VacunaTexto",
                            Controls = { new Panel { CssClass = "textoNuevaVacuna", Controls = { btnVacuna } } }
                        });

                        // Agregar el div contenedor al div "contenedorVacunas"
                        contenedorVacunas.Controls.Add(contenedor);
                    }
                }
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-bottom-right';" +
                                $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        protected void ButtonVacuna_Click(object sender, EventArgs e)
        {
            Button btnVacuna = (Button)sender;
            string idBotonVacuna = btnVacuna.ID;

            string idVacuna = btnVacuna.ID.Replace("btnVacuna_", "");

            foreach (var vacuna in listaVacunas)
            {
                if (vacuna.IdVacuna.ToString() == idVacuna)
                {
                    txtTitulo.Text = vacuna.Nombre;

                    txtDescripcion.Text = vacuna.Descripcion;
                    string fechaStr = vacuna.Fecha.ToString();
                    //DateTime fecha = DateTime.ParseExact(fechaStr, "dd/MM/yyyy H:mm:ss", CultureInfo.InvariantCulture);

                    txtDescripcion.Text = vacuna.Descripcion;                    

                    DateTime fecha = vacuna.Fecha;
                    txtFecha.Text = fecha.ToString("yyyy-MM-ddTHH:mm");

                    int i = vacuna.IdVacuna;
                    Session["idVacuna"] = i;
                }
            }
        }

        protected void btnRegistrarNueva_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = "Titulo Vacuna Nueva";
            txtDescripcion.Text = "Descripcion Vacuna nueva";
            txtFecha.Text = DateTime.Now.ToString();
        }
        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                int i = (int)Session["idVacuna"];

                Negocios.Vacunas.BorrarVacuna(i, idBebe);
                Response.Redirect("SaludVacunas.aspx", false);
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-bottom-right';" +
                                $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            //var vacuna = listaVacunas.FirstOrDefault(v=>v.nom)            
            try
            {
                DateTime fecha;
                if (txtTitulo.Text.Length < 5 || txtDescripcion.Text.Length < 5 || txtFecha.Text.Length < 5)
                {
                    throw new Exception("Datos no válidos");
                }
                fecha = Convert.ToDateTime(txtFecha.Text);

                int i = (int)Session["idVacuna"];

                Negocios.Vacunas.EditarVacuna(i, idBebe, txtTitulo.Text, txtDescripcion.Text, fecha);

                Response.Redirect("SaludVacunas.aspx", false);
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                                 "toastr.options.closeButton = true;" +
                                 "toastr.options.positionClass = 'toast-bottom-right';" +
                                 $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTitulo.Text.Length < 5 || txtDescripcion.Text.Length < 5 || txtFecha.Text.Length < 5)
                {
                    throw new Exception("Datos no válidos");
                }
                DateTime fecha = Convert.ToDateTime(txtFecha.Text);

                Negocios.Vacunas.AgregarVacuna(idBebe, txtTitulo.Text, txtDescripcion.Text, Convert.ToDateTime(txtFecha.Text));
                Response.Redirect("SaludVacunas.aspx", false);
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                                "toastr.options.closeButton = true;" +
                               "toastr.options.positionClass = 'toast-bottom-right';" +
                                $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        private void deshabilitarControles()
        {
            txtFecha.Enabled = false;
            txtTitulo.Enabled = false;
            txtDescripcion.Enabled = false;
            btnAgregar.Enabled = false;
            btnEditar.Enabled = false;
            btnRegistrarNueva.Enabled = false;
            btnBorrar.Enabled = false;
        }
        private void habilitarControles()
        {
            txtFecha.Enabled = true;
            txtTitulo.Enabled = true;
            txtDescripcion.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnRegistrarNueva.Enabled = true;
            btnBorrar.Enabled = true;
        }
    }
}