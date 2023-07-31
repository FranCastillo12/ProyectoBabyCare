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
                string regexNumeros = @"^[0-9]{10}$";
                string regexNumeroFloat = @"^\d+(\.\d*)?$";


                if (respuesta.Equals("No existe"))
                {
                    string script = null;
                    bool entrar = false;
                    
                    int genero = 0;
                    if (txtCedula.Text == "")
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                             "toastr.options.positionClass = 'toast-bottom-right';" +
                            "toastr.error('La cédula no puede quedar en blanco');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    else if (txtpeso.Text == "")
                    {  script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-bottom-right';" +
                            "toastr.error('El peso no puede quedar en blanco');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    else if (!Regex.IsMatch(txtpeso.Text, regexNumeroFloat))
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-bottom-right';" +
                            "toastr.error('El peso solo puede tener numeros');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    else if (txtestatura.Text == "")
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                             "toastr.options.positionClass = 'toast-bottom-right';" +
                            "toastr.error('La estatura no puede quedar en blanco');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    else if (!Regex.IsMatch(txtestatura.Text, regexNumeroFloat))
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                             "toastr.options.positionClass = 'toast-bottom-right';" +
                            "toastr.error('La estatura solo puede tener numeros');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                        //warningss += "El correo es necesario <br>";
                        entrar = true;
                    }
                    else if (string.IsNullOrEmpty(txtfecha.Text))
                    {
                        script =
                            "toastr.options.closeButton = true;" +
                            "toastr.options.positionClass = 'toast-bottom-right';" +
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
                        string cedula = txtCedula.Text;
                        float peso = float.Parse(txtpeso.Text);
                        float estatura = float.Parse(txtestatura.Text);
                        DateTime fecha = DateTime.Parse(txtfecha.Text);
                        string tiposangre = txtTiposangre.Text;
                        ex.IngresarExpediente(Convert.ToInt32(usu.IdenBebe), cedula, genero, peso, estatura, tiposangre, fecha);
                        Response.Redirect("Expediente.aspx");
                    }   
                }
            }
        }
    }
}