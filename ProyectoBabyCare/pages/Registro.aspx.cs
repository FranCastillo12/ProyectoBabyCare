using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellidos = TxtApellidos.Text;
                string correo = txtCorreo.Text;
                string pass = TxtContra.Text;

                Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();

                iUsuarios.RegistroUsuarios(nombre, apellidos, correo, pass);
                //Poner el mensaje de exito
                string script = @"Swal.fire({
                        title: '¡Hola!',
                        text: 'Esto es SweetAlert2 desde ASP.NET',
                        icon: 'sucess'
                    });";
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);

            }
            catch (Exception ex)
            {
            }
        }
    }
}