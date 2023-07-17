using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtCorreo.Text;
                string pass = txtContra.Text;


                if (Page.IsValid)
                {
                    Negocios.Neg_Usuarios iUsuarios = new Negocios.Neg_Usuarios();


                    Entidades.En_Usuarios iCredenciales = iUsuarios.VerificarCredenciales(user, pass);


                    if (iCredenciales != null)
                    {
                        Session["credenciales"] = iCredenciales;

                        Response.Redirect("");
                    }
                    else
                    {
                        string script = @"Swal.fire({
                        title: '¡Hola!',
                        text: 'Esto es SweetAlert2 desde ASP.NET',
                        icon: 'error'
                    });";
                        ScriptManager.RegisterStartupScript(this, GetType(), "SweetAlert", script, true);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("#");
        }
    }
}