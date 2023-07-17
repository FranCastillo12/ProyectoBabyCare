using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

                Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();
                DataTable dtUsuarios = iUsuarios.DatosUsuario("castillof075@gmail.com");
                System.Text.StringBuilder strListaDatos = new System.Text.StringBuilder();

                foreach (DataRow drEmpleados in dtUsuarios.Rows)
                {

                    // Rellenar un TextBox llamado txtNombre con el valor de la columna "Nombre"
                    txtNombre.Text = Convert.ToString(drEmpleados["nombre"]);

                    // Rellenar otro TextBox llamado txtApellido con el valor de la columna "Apellido1"
                    txtApellidos.Text = Convert.ToString(drEmpleados["apellidos"]);


                    txtCorreo.Text = Convert.ToString(drEmpleados["correo"]);
                }

                DataTable dtbebes = iUsuarios.Datosbebes("castillof075@gmail.com");


                dropbebes.DataSource = dtbebes;
                dropbebes.DataTextField = "nombre_bebe";
                dropbebes.DataValueField = "nombre_bebe";
                dropbebes.DataBind();
                dropbebes.Items.Insert(0, new ListItem("Seleccione una cuenta", "0"));
            }
        }

        protected void btnModificarDatos_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string correo = txtCorreo.Text;

            Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();

            iUsuarios.CambioDatos(correo, nombre, apellidos);
            //Poner el mensaje de exito
            string script = @"Swal.fire({
                        title: '¡Hola!',
                        text: 'Esto es SweetAlert2 desde ASP.NET',
                        icon: 'sucess'
                    });";
            ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
        }
    }
}