using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                boton.Visible = false;
                btnAdministrarFamiliares.Visible = false;
                Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];
                string correo = credenciales.Usuario;
                string idbebe = credenciales.IdenBebe;
                Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();
                DataTable dtUsuarios = iUsuarios.DatosUsuario(correo);
                System.Text.StringBuilder strListaDatos = new System.Text.StringBuilder();

                foreach (DataRow drEmpleados in dtUsuarios.Rows)
                {

                    // Rellenar un TextBox llamado txtNombre con el valor de la columna "Nombre"
                    txtNombre.Text = Convert.ToString(drEmpleados["nombre"]);

                    // Rellenar otro TextBox llamado txtApellido con el valor de la columna "Apellido1"
                    txtApellidos.Text = Convert.ToString(drEmpleados["apellidos"]);


                    txtCorreo.Text = Convert.ToString(drEmpleados["correo"]);
                }

                DataTable dtbebes = iUsuarios.Datosbebes(correo);


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
            }
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
          
                string script = null;
                Regex regex = new Regex("^[a-zA-Z\\s]+$");
                if (txtNombre.Text == "")
                {
                    script = "toastr.error('El nombre no puede estar vacio');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                //else if (regex.IsMatch(txtNombre.Text))
                //{
                //    script = "toastr.success('¡Hola, esto es un ejemplo de Toastr en ASPX!');";
                //    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                //}
                else if (txtApellidos.Text == "")
                {
                    script = "toastr.error('Los apellidos no pueden estar vacios');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                //else if (regex.IsMatch(txtApellidos.Text)){
                //    script = "toastr.success('¡Hola, esto es un ejemplo de Toastr en ASPX!');";
                //    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                //}
                else
                {
                    string nombre = txtNombre.Text;
                    string apellidos = txtApellidos.Text;
                    string correo = txtCorreo.Text;

                    Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();

                    iUsuarios.CambioDatos(correo, nombre, apellidos);
                    //Poner el mensaje de exito
                    script = "toastr.success('Datos modificados');";
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
            string correo = credenciales.Usuario;
            string rol = null;
            string encargado = null;
            string script = null;
            try
            {
                if (dropbebes.SelectedValue == "0")
                {
                   
                    script = "toastr.error('Debe escoger un rol');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }
                else
                {
                   
                    
                    string valorSeleccionado = dropbebes.SelectedValue;

                    Negocios.Neg_Usuarios iUsuario = new Negocios.Neg_Usuarios();


                    credenciales.IdenBebe = valorSeleccionado;
                    Session["Credenciales"] = credenciales;
                    //Session["idbebe"] = valorSeleccionado;

                    DataTable resultTable = iUsuario.ObtenerSessionbebe(valorSeleccionado,correo);
                    if (resultTable != null && resultTable.Rows.Count > 0)
                    {
                        // Assuming the value you need to retrieve is in the first row and first column of the DataTable
                        rol = resultTable.Rows[0][0].ToString();
                        lblcodigo.Text = resultTable.Rows[0][1].ToString();
                        encargado = resultTable.Rows[0][2].ToString();

                        // Store the value in the Session
                        credenciales.Rol = rol;
                        Session["Credenciales"] = credenciales;
                        //Session["rol"] = rol;
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

                }


            }
            catch (Exception ex)
            {
                script = "toastr.warning('Ha occurido un error,Intentelo mas tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
    


   
    }
}
