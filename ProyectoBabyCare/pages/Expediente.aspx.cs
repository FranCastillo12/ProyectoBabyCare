using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Expediente : System.Web.UI.Page
    {
        int idbebe = 0;
        string correo = "";
        Negocios.Expediente ex = new Negocios.Expediente();
        List<Entidades.Padecimientos> lstpadecimientos = new List<Padecimientos>();
        List<Entidades.Padecimientos> lstpadecimientosexpediente = new List<Padecimientos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Credenciales"] != null)
            {
                Entidades.En_Usuarios usuario = (Entidades.En_Usuarios)Session["Credenciales"];
                correo = usuario.Usuario;

                if (!usuario.IdenBebe.Equals(""))
                {
                    idbebe = Convert.ToInt32(Convert.ToString(usuario.IdenBebe));
                    //Llama al metodo para activar las alertas y mostrar mensaje
                    Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                    DateTime horaActual = DateTime.Now;
                    alert.ActivateAlertas(horaActual, idbebe);
                    List<Entidades.Alerta> alertas = alert.TraerAlertas(idbebe);

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


                    
                    string ExisteExpediente = ex.ValidarExpediente(idbebe);
                    if (ExisteExpediente.Equals("No existe"))
                    {
                        Response.Redirect("RegistrarExpediente.aspx");
                    }
                    if (usuario.Rol.Equals("Madre") || usuario.Rol.Equals("Padre"))
                    {
                        btnModificar.Visible = true;
                        btnagregarpadecimientos.Visible = true;
                        btnAgregarDetalle.Visible = true;
                        txtDescripcion.Visible = true;
                        txtFechaDetalle.Visible = true;
                        dpllPadecimientos.Visible = true;
                    }
                    else
                    {
                        btnModificar.Visible = false;
                        btnagregarpadecimientos.Visible = false;
                        btnAgregarDetalle.Visible = false;
                        txtDescripcion.Visible = false;
                        txtFechaDetalle.Visible = false;
                        dpllPadecimientos.Visible = false;
                    }

                }
                else {
                    Response.Redirect("ControlPanel.aspx");
                }

            }
            if (!IsPostBack) {
                Session["idExpedienteBebe"] = null;



                lstpadecimientos = ex.TodoslosPadecimientos();
                dpllPadecimientos.Items.Add("Seleccione un padecimiento");
                foreach (Entidades.Padecimientos ex1 in lstpadecimientos)
                {
                    dpllPadecimientos.Items.Add(ex1.IdPadecimiento + "-" + ex1.Nombrepadecimiento);
                }
                if (idbebe != 0)
                {
                    Entidades.Expediente expediente = new Entidades.Expediente();
                    
                    expediente = ex.obtenerexpediente(idbebe);
                    if (expediente.Idexpediente != 0)
                    {
                        Session["idExpedienteBebe"] = expediente.Idexpediente;
                        txtnombre.Text = expediente.Nombrebebe;
                        txtPeso.Text = Convert.ToString(expediente.Peso);
                        txtSangre.Text = expediente.Tiposangre.Trim();
                        txtpapa.Text = expediente.NombrePadre;
                        txtmama.Text = expediente.NombreMadre;
                        txtestatura.Text = Convert.ToString(expediente.Estatura);
                        string[] fechanac= expediente.Fechanacimiento.Split(' ');
                        txtfecha.Text = fechanac[0];
                        txtcedula.Text = expediente.Cedula;

                        //Generos
                        List<Entidades.Generos> lstgeneros= new List<Entidades.Generos>();
                        lstgeneros=ex.TraerGeneros();
                        foreach (Entidades.Generos g in lstgeneros) {
                            dopgenero.Items.Add(g.NGenero);
                        }

                        foreach (ListItem item in dopgenero.Items) {

                            if (item.Value == expediente.Genero)
                            {
                                // Si encuentra el valor buscado, lo selecciona
                                item.Selected = true;

                                break; // Termina el bucle después de encontrar el valor buscado
                            }
                        }

                        //padecimientos


                        lstpadecimientosexpediente = ex.PadecimientosExpediente(expediente.Idexpediente);

                        lblMensaje1.Text = "";
                        if (lstpadecimientosexpediente.Count > 0)
                        {
                            DataTable tablapadecimientos = new DataTable();
                            tablapadecimientos.Columns.Add("#", typeof(int));
                            tablapadecimientos.Columns.Add("Nombre del padecimiento", typeof(string));
                            int cont = 1;
                            foreach (Entidades.Padecimientos ex2 in lstpadecimientosexpediente)
                            {
                                tablapadecimientos.Rows.Add(cont,ex2.Nombrepadecimiento);
                                cont++;
                            }
                            gridpadecimientos.DataSource = tablapadecimientos;
                            gridpadecimientos.DataBind();
                        }
                        else
                        {
                            lblMensaje1.Text = "Sin registros";
                        }
                        //detalles
                        lblMensaje2.Text = "";
                        string[] lstdetalle = ex.Detalles(expediente.Idexpediente);
                        if (lstdetalle.Length > 0 && !lstdetalle[0].Equals(""))
                        {
                            DataTable tabladetalles = new DataTable();
                            tabladetalles.Columns.Add("Fecha del detalle", typeof(string));
                            tabladetalles.Columns.Add("Descripcion", typeof(string));
                            foreach (string s in lstdetalle)
                            {
                                if (!s.Equals(""))
                                {
                                    string[] atrib = s.Split('@');
                                    string[] fecha = atrib[1].Split(' ');
                                    //tabladetalles.Text += $"{fecha[0]}: {atrib[0]}\n";
                                    tabladetalles.Rows.Add(fecha[0], atrib[0]);
                                }

                            }
                            griddetalles.DataSource = tabladetalles;
                            griddetalles.DataBind();
                        }
                        else
                        {
                            lblMensaje2.Text = "Sin registros";
                        }
                        //Vacunas
                        lblMensaje3.Text = "";
                        string[] lstvacunas = ex.Vacunas(expediente.Idexpediente);
                        if (lstvacunas.Length > 0 && !lstvacunas[0].Equals(""))
                        {
                            DataTable tablaVacunas = new DataTable();
                            tablaVacunas.Columns.Add("Fecha de vacuna", typeof(string));
                            tablaVacunas.Columns.Add("Nombre", typeof(string));
                            tablaVacunas.Columns.Add("Descripción", typeof(string));

                            foreach (string s in lstvacunas)
                            {
                                if (!s.Equals(""))
                                {
                                    string[] atrib = s.Split('@');
                                    string[] fecha = atrib[2].Split(' ');
                                    //Generar el DATATABLE
                                    tablaVacunas.Rows.Add(fecha[0], atrib[0], atrib[1]);
                                }
                                
                            }
                            gridvacunas.DataSource = tablaVacunas;
                            gridvacunas.DataBind();
                        }
                        else
                        {
                            lblMensaje3.Text= "Sin registros";
                        }
                    }
                    else
                    {
                        txtnombre.Text = "Sin registros";
                        txtPeso.Text = "Sin registros";
                        txtSangre.Text = "Sin registros";
                        txtpapa.Text = "Sin registros";
                        txtmama.Text = "Sin registros";
                        txtestatura.Text = "Sin registros";
                        txtfecha.Text = "Sin registros";
                        txtcedula.Text = "Sin registro";
                    }


                }
                else {
                    txtnombre.Text = "Sin registros";
                    txtPeso.Text = "Sin registros";
                    txtSangre.Text = "Sin registros";
                    txtpapa.Text = "Sin registros";
                    txtmama.Text = "Sin registros";
                    txtestatura.Text = "Sin registros";
                    txtfecha.Text = "Sin registros";
                    txtcedula.Text = "Sin registro";
                }
            }
            

        }

        protected void btnagregarpadecimientos_Click(object sender, EventArgs e)
        {
            string script = null;
            if (dpllPadecimientos.SelectedValue.Equals("Seleccione un padecimiento")) {
                script =
                         "toastr.options.closeButton = true;" +
                          "toastr.options.positionClass = 'toast-bottom-right';" +
                         "toastr.error('Debe de seleccionar un padecimiento');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else
            {
                string padecimiento = dpllPadecimientos.SelectedValue;
                string[] data = padecimiento.Split('-');
                Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
                ex.IngresarPadecimiento(Convert.ToInt32(user.IdenBebe), Convert.ToInt32(data[0]));
                Response.Redirect("Expediente.aspx");
            }
            
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            string script = null;
            if(txtDescripcion.Text== "")
            {
                script =
                         "toastr.options.closeButton = true;" +
                          "toastr.options.positionClass = 'toast-bottom-right';" +
                         "toastr.error('Debe de ingresar una descripcion');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (txtFechaDetalle.Text == "")
            {
                script =
                         "toastr.options.closeButton = true;" +
                          "toastr.options.positionClass = 'toast-bottom-right';" +
                         "toastr.error('Debe de ingresar la fecha de cuando sucedio');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else
            {
                string detalle = txtDescripcion.Text;
                DateTime fecha = DateTime.Parse(txtFechaDetalle.Text);
                Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
                if (Convert.ToInt32(user.IdenBebe) != 0)
                {
                    ex.IngresarDetalleExpediente(Convert.ToInt32(user.IdenBebe), detalle, fecha.Date);
                }
                Response.Redirect("Expediente.aspx");
            }
           
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string script = null;
            bool entrar = false;
            string regexNumeroFloat = @"^\d+(,\d*)?$";
            if (Session["Credenciales"] != null ) {
                string genero = dopgenero.SelectedValue;

                if (!string.IsNullOrEmpty(txtcedula.Text) && txtcedula.Text.Contains(" "))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Revisar los datos ingresandos en la cédula');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (!string.IsNullOrEmpty(txtestatura.Text) && txtcedula.Text.Contains(" "))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Revisar los datos ingresandos en la estatura');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (!string.IsNullOrEmpty(txtPeso.Text) && txtcedula.Text.Contains(" "))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Revisar los datos ingresandos en el peso');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (!string.IsNullOrEmpty(txtSangre.Text) && txtcedula.Text.Contains(" "))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Revisar los datos ingresandos en el tipo de sangre');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (!Regex.IsMatch(txtPeso.Text, regexNumeroFloat))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('El peso solo puede tener numeros');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (!Regex.IsMatch(txtestatura.Text, regexNumeroFloat))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('La estatura solo puede tener numeros');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                int idGenero = 0;
                if (genero.Equals("Hombre"))
                {
                    idGenero = 1;
                }
                else if (genero.Equals("Mujer"))
                {
                    idGenero = 2;
                }
                else {
                    script =
                         "toastr.options.closeButton = true;" +
                          "toastr.options.positionClass = 'toast-bottom-right';" +
                         "toastr.error('Debe indicar el genero');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    entrar = true;
                }


                if (entrar)
                {


                }
                else
                {
                    float peso = float.Parse(txtPeso.Text);
                    string tiposangre = txtSangre.Text;
                    float estatura = float.Parse(txtestatura.Text);
                    string cedula = txtcedula.Text;
                    
                    if (Convert.ToInt32(Session["idExpedienteBebe"]) != 0 && Session["idExpedienteBebe"] != null)
                    {
                        ex.ModificarExpediente(Convert.ToInt32(Session["idExpedienteBebe"]), peso, estatura, tiposangre, cedula, idGenero);
                    }
                    

                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Datos modificados');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);



                }

            }

        }

        protected void txtSangre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}