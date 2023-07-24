using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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
                string regexNumeros = @"^[0-9]+$";
                string regexNumeroFloat = @"^[0-9]+(\.[0-9]+)?$";


                if (respuesta.Equals("No existe"))
                {
                    bool entrar = false;
                    //Obtener datos del formulario
                    string cedula=txtCedula.Text;
                    float peso=float.Parse(txtpeso.Text);
                    float estatura= float.Parse(txtestatura.Text);
                    DateTime fecha=DateTime.Parse(txtfecha.Text);
                    string tiposangre=txtTiposangre.Text;
                    int genero = 0;
                    if (cedula == "")
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-top-full-width';" +
                            "toastr.error('La cédula no puede quedar en blanco');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    if (Regex.IsMatch(cedula, regexNumeros))
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-top-full-width';" +
                            "toastr.error('La cédula solo puede contener numeros');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    if (peso == "")
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-top-full-width';" +
                            "toastr.error('El peso no puede quedar en blanco');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    if (Regex.IsMatch(peso, regexNumeroFloat))
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-top-full-width';" +
                            "toastr.error('El peso solo puede tener numeros');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    if (estatura == "")
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-top-full-width';" +
                            "toastr.error('El peso no puede quedar en blanco');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    if (Regex.IsMatch(estatura, regexNumeroFloat))
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-top-full-width';" +
                            "toastr.error('El peso solo puede tener numeros');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    if (string.IsNullOrEmpty(fecha))
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-top-full-width';" +
                            "toastr.error('La fecha de nacimiento no puede ir vacia');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    if (R1.Checked)
                    {
                        genero = 1;
                    }
                    else if (R2.Checked)
                    {
                        genero = 2;
                    }
                    else
                    {
                        script =
                          "toastr.options.closeButton = true;" +
                          "toastr.options.positionClass = 'toast-top-full-width';" +
                          "toastr.error('Debe indicar el genero');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        entrar = true;
                    }
                    if (entrar)
                    {


                    }
                    else
                    {
                        ex.IngresarExpediente(Convert.ToInt32(usu.IdenBebe), cedula, genero, peso, estatura, tiposangre, fecha);
                        Response.Redirect("Expediente.aspx");
                    }   
                }
            }
        }
    }
}