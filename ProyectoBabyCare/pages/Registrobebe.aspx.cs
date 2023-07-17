using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Registrobebe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearCuentabebe_Click(object sender, EventArgs e)
        {
            try{
                string nombre = txtNombre.Text;
                string apellidos = TxtApellidos.Text;
                string fecha_nacimiento = txtfechadenacimiento.Text;

                Negocios.Neg_bebes iBebes = new Negocios.Neg_bebes();

                iBebes.Registrarbebe(nombre, apellidos, fecha_nacimiento);
                //Poner el mensaje de exito
                string script = @"Swal.fire({
                        title: '¡Hola!',
                        text: 'Esto es SweetAlert2 desde ASP.NET',
                        icon: 'sucess'
                    });";
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
            } catch (Exception ex) {
                throw ex;
            
            }    
        }

        protected void btnUnirseCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                //Falta llamar a la variable session
                string codigo = txtCodigo.Text;
                string correo = "";
                Negocios.Neg_bebes iBebes = new Negocios.Neg_bebes();

                iBebes.IngresarXcodigo(correo, codigo);
                string script = @"Swal.fire({
                        title: '¡Hola!',
                        text: 'Esto es SweetAlert2 desde ASP.NET',
                        icon: 'sucess'
                    });";
                ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
    }
}