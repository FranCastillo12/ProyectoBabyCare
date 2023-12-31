﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Perfil : System.Web.UI.Page
    {
        int idBebe = 0;
        string nombrebebe;
        protected void Page_Load(object sender, EventArgs e)
        {

            string script = "<script>document.body.style.zoom = '100%';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Set100PercentSizeScript", script);
            if (!IsPostBack)
            {
                boton.Visible = false;
                btnAdministrarFamiliares.Visible = false;
                Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
                int idUsuario = credenciales.IdUsuario;
                string idbebe = credenciales.IdenBebe;
                Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();
                DataTable dtUsuarios = iUsuarios.DatosUsuario(idUsuario);
                System.Text.StringBuilder strListaDatos = new System.Text.StringBuilder();

                foreach (DataRow drEmpleados in dtUsuarios.Rows)
                {

                    // Rellenar un TextBox llamado txtNombre con el valor de la columna "Nombre"
                    txtNombre.Text = Convert.ToString(drEmpleados["nombre"]);

                    // Rellenar otro TextBox llamado txtApellido con el valor de la columna "Apellido1"
                    txtApellidos.Text = Convert.ToString(drEmpleados["apellidos"]);


                    txtCorreo.Text = Convert.ToString(drEmpleados["correo"]);

                    TextBox1.Text = Convert.ToString(drEmpleados["Rol"]);

                }

                DataTable dtbebes = iUsuarios.Datosbebes(idUsuario);


                dropbebes.DataSource = dtbebes;
                dropbebes.DataTextField = "nombre_bebe";
                dropbebes.DataValueField = "idBebe";
                dropbebes.DataBind();
                dropbebes.Items.Insert(0, new ListItem("Seleccione un bebé", "0"));
                ListItem itemSeleccionado = dropbebes.Items.FindByValue(idbebe);
                if (itemSeleccionado != null)
                {
                    itemSeleccionado.Selected = true;
                    dropbebes_SelectedIndexChanged(dropbebes, EventArgs.Empty);

                }
                SitePrivate masterPage = (SitePrivate)this.Master;
                masterPage.MiMetodoEnMasterPage();


                //Llama al metodo para activar las alertas y mostrar mensaje
                Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                DateTime horaActual = DateTime.Now;
                alert.ActivateAlertas(horaActual, idBebe);
                List<Entidades.Alerta> alertas = alert.TraerAlertas(idBebe);

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
                // Final del metodo de mostrar alertas
            }
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
            int idUsuario = credenciales.IdUsuario;
            string script = null;
            string correo = txtCorreo.Text;
            string regexLetras = ("^[a-zA-Z\\s]+$");
            Regex regex = new Regex(regexLetras);
            string regexEmail = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
            Regex regexx = new Regex(regexEmail);

            if (!regexx.IsMatch(correo))
            {
                script =
                  "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                  "toastr.error('El email no es valido');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                //warningss += "El email no es valido <br>";
                
            }
            if (correo == "")
            {
                script =
                  "toastr.options.closeButton = true;" +
                  "toastr.options.positionClass = 'toast-bottom-right';" +
                  "toastr.error('El email no puede estar vacio');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                //warningss += "El email no es valido <br>";

            }


            else if (txtNombre.Text == "")
            {

                script =
                  "toastr.options.closeButton = true;" +
                  "toastr.options.positionClass = 'toast-bottom-right';" +
                 "toastr.error('El nombre no puede estar vacio');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (!regex.IsMatch(txtNombre.Text))
            {
                script =
                 "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                "toastr.error('El nombre solo puede contener letras');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (txtApellidos.Text == "")
            {
                script =
                 "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                "toastr.error('Los apellidos no pueden estar vacios');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (!regex.IsMatch(txtApellidos.Text))
            {
                script =
                 "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
               "toastr.error('Los apellidos solo pueden contener letras');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else
            {
                string nombre = txtNombre.Text;
                string apellidos = txtApellidos.Text;
                

                Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();

                iUsuarios.CambioDatos(idUsuario, correo, nombre, apellidos);
                //Poner el mensaje de exito
                script =
                 "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
               "toastr.success('Datos modificados');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }

        protected void btnAdministrarFamiliares_Click(object sender, EventArgs e)
        { 
            //string idbebe = Session["idbebe"] as string;
            Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
            string idbebe = credenciales.IdenBebe;
            Response.Redirect("AdminFamiliares.aspx?id=" + idbebe);

        }

        protected void dropbebes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
            int idUsuario = credenciales.IdUsuario;
            string rol = null;
            string encargado = null;
            string script = null;
            try
            {
              
                    if (dropbebes.SelectedValue == "0")
                {
                    script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-bottom-right';" +
                           "toastr.error('Debe escoger un rol');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                else
                {


                    string valorSeleccionado = dropbebes.SelectedValue;

                    Negocios.Neg_Usuarios iUsuario = new Negocios.Neg_Usuarios();


                    credenciales.IdenBebe = valorSeleccionado;
                    Session["Credenciales"] = credenciales;
                    //Session["idbebe"] = valorSeleccionado;

                    DataTable resultTable = iUsuario.ObtenerSessionbebe(valorSeleccionado, idUsuario);
                    if (resultTable != null && resultTable.Rows.Count > 0)
                    {
                        // Assuming the value you need to retrieve is in the first row and first column of the DataTable
                       
                        rol = resultTable.Rows[0][0].ToString();
                        lblcodigo.Text = resultTable.Rows[0][1].ToString();
                        encargado = resultTable.Rows[0][2].ToString();
                        lblnombreBebe.Text = resultTable.Rows[0][3].ToString();
                        TextBox1.Text = rol;
           
                        // Store the value in the Session
                        credenciales.Rol = rol;
                        Session["Credenciales"] = credenciales;
                        Session["rol"] = rol;
                    }
                    //script = "toastr.success('Ahora tiene el rol');";
                    //ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    if (encargado == "True")
                    {
                        btnAdministrarFamiliares.Visible = true;
                        boton.Visible = true;
                    }
                    else
                    {
                        btnAdministrarFamiliares.Visible = false;
                        boton.Visible = false;
                    }
                    // Obtener la instancia de la Master Page
                    SitePrivate masterPage = (SitePrivate)this.Master;

                    // Ahora puedes llamar al método público de la Master Page
                        masterPage.MiMetodoEnMasterPage();
                }

               
            }
            catch (Exception ex)
            {
                script = "toastr.warning('Ha occurido un error,Intentelo mas tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }

        protected void btnEnviarCodido_Click(object sender, EventArgs e)
        {
            string correo = txtemail.Text;
            string codigo = lblcodigo.Text;
            string nombrebebe = lblnombreBebe.Text;
            string script = null;
            //Aqui se debe ingresar para el envio de correos
            if (correo == "")
            {

                script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-bottom-right';" +
                           "toastr.error('Debe de ingresar un correo');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else
            {
                
                Negocios.Correos CorreoCodigo = new Negocios.Correos();
                CorreoCodigo.EnviarCorreoCodigo(nombrebebe, correo, codigo);


                script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-bottom-right';" +
                           "toastr.success('Correo enviado con exito');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                txtemail.Text = "";
            }

        }

    }
}
