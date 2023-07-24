using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare
{
    public partial class RegistrarExpediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Session["Credenciales"] != null) { 
                Entidades.En_Usuarios usu = (Entidades.En_Usuarios)Session["Credenciales"];
                Negocios.Expediente ex=new Negocios.Expediente();
                string respuesta = ex.ValidarExpediente(Convert.ToInt32(usu.IdenBebe));

                if (respuesta.Equals("No existe"))
                {
                    //Obtener datos del formulario
                    string cedula=txtCedula.Text;
                    float peso=float.Parse(txtpeso.Text);
                    float estatura= float.Parse(txtestatura.Text);
                    DateTime fecha=DateTime.Parse(txtfecha.Text);
                    string tiposangre=txtTiposangre.Text;
                    int genero = 0;
                    if (R1.Checked)
                    {
                        genero = 1;
                    }
                    else if (R2.Checked)
                    {
                        genero = 2;
                     }

                    if (genero != 0) {
                        ex.IngresarExpediente(Convert.ToInt32(usu.IdenBebe),cedula,genero,peso,estatura,tiposangre,fecha);
                        Response.Redirect("Expediente.aspx");
                    }
                        
                }
            }
        }
    }
}