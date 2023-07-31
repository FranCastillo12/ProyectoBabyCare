using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class AgregarSeguimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                List<Entidades.Categorias> lstcategorias = new List<Entidades.Categorias>();
                Negocios.SeguimientoActividades seg = new Negocios.SeguimientoActividades();
                lstcategorias = seg.Categorias();
                dropcategorias.Items.Add("Selecciona una categoría");
                foreach (Entidades.Categorias c in lstcategorias)
                {
                    dropcategorias.Items.Add($"{c.Idcategorial}-{c.Nombre}");
                }
            }
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            bool entrar = false;
            string script = null;
            string categoria=dropcategorias.SelectedValue;
            string descripcion=txtdescripcionseguimiento.Text;


            if (descripcion == "")
            {
                script =
                    "toastr.options.closeButton = true;" +
                     "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('La descripción no puede estar vacia');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                //warningss += "El correo es necesario <br>";
                entrar = true;
            }
            if (categoria == "Selecciona una categoría")
            {
                script =
                    "toastr.options.closeButton = true;" +
                     "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('Seleccione una categoria');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);

                //warningss += "El correo es necesario <br>";
                entrar = true;
            }
            if (entrar)
            {
               

            }
            else
            {

                if (Session["Credenciales"] != null)
                {
                    Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
                    string[] data = categoria.Split('-');
                    Negocios.SeguimientoActividades seg = new Negocios.SeguimientoActividades();
                    DateTime fecha = DateTime.Now;
                    seg.InsertarSeguimiento(Convert.ToInt32(data[0]), Convert.ToInt32(user.IdenBebe), fecha.Date, descripcion);

                    Response.Redirect("SeguimientoActividades.aspx");
                }
                else
                {
                    script =
                    "toastr.options.closeButton = true;" +
                     "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.warning('Ha ocurrido un error');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                }




            }




        }
    }
}