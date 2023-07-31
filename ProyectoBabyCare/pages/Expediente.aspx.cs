using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
                idbebe = Convert.ToInt32(Convert.ToString(usuario.IdenBebe));
                string ExisteExpediente = ex.ValidarExpediente(idbebe);
                if (ExisteExpediente.Equals("No existe")) {
                    Response.Redirect("RegistrarExpediente.aspx");
                }
                if (usuario.Rol.Equals("Madre") || usuario.Rol.Equals("Padre")) { 
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

                        txtPadecimientos.Text = "";
                        if (lstpadecimientosexpediente.Count > 0)
                        {
                            int cont = 1;
                            foreach (Entidades.Padecimientos ex2 in lstpadecimientosexpediente)
                            {
                                txtPadecimientos.Text += cont + "-" + ex2.Nombrepadecimiento + "\n";
                                cont++;
                            }
                        }
                        else
                        {
                            txtPadecimientos.Text = "Sin registros";
                        }
                        //detalles
                        txtDetalles.Text = "";
                        string[] lstdetalle = ex.Detalles(expediente.Idexpediente);
                        if (lstdetalle.Length > 0 && !lstdetalle[0].Equals(""))
                        {
                            int cont = 1;
                            foreach (string s in lstdetalle)
                            {
                                if (!s.Equals(""))
                                {
                                    string[] atrib = s.Split('@');
                                    string[] fecha = atrib[1].Split(' ');
                                    txtDetalles.Text += $"{cont}-{fecha[0]}: {atrib[0]}\n";
                                    cont++;
                                }

                            }
                        }
                        else
                        {
                            txtDetalles.Text = "Sin registros";
                        }
                        //Vacunas
                        txtVacunas.Text = "";
                        string[] lstvacunas = ex.Vacunas(expediente.Idexpediente);
                        if (lstvacunas.Length > 0 && !lstvacunas[0].Equals(""))
                        {
                            int cont = 1;
                            foreach (string s in lstvacunas)
                            {
                                if (!s.Equals(""))
                                {
                                    string[] atrib = s.Split('@');
                                    string[] fecha = atrib[2].Split(' ');
                                    txtVacunas.Text += $"{cont}-{fecha[0]}: {atrib[0]}\n";
                                    txtVacunas.Text += $"Descripción: {atrib[1]}\n";
                                    cont++;
                                }

                            }
                        }
                        else
                        {
                            txtVacunas.Text = "Sin registros";
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
            if (!dpllPadecimientos.SelectedValue.Equals("Seleccione un padecimiento")) { 
                string padecimiento = dpllPadecimientos.SelectedValue;
                string[] data=padecimiento.Split('-');
                Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
                ex.IngresarPadecimiento(Convert.ToInt32(user.IdenBebe), Convert.ToInt32(data[0]));
            }
            Response.Redirect("Expediente.aspx");
        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            string detalle=txtDescripcion.Text;
            DateTime fecha=DateTime.Parse(txtFechaDetalle.Text);
            Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
            if (Convert.ToInt32(user.IdenBebe)!=0) {
                ex.IngresarDetalleExpediente(Convert.ToInt32(user.IdenBebe), detalle,fecha.Date);
            }
            Response.Redirect("Expediente.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string script = null;
            bool entrar = false;
            if (Session["Credenciales"] != null ) {
                string genero = dopgenero.SelectedValue;

                if (txtcedula.Text == "")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('La cédula no puede quedar en blanco');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (string.IsNullOrEmpty(txtestatura.Text))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('La estatura no puede quedar en blanco');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (string.IsNullOrEmpty(txtPeso.Text))
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('El peso no puede quedar en blanco');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                    //warningss += "El correo es necesario <br>";
                    entrar = true;
                }
                if (txtSangre.Text == "")
                {
                    script =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('El tipo de sangre no puede quedar en blanco');";
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
                    Response.Redirect("Expediente.aspx");
                }

            }

        }
    }
}