using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class SeguimientoActividades : System.Web.UI.Page
    {
        List<Entidades.Categorias> lstcategorias = new List<Entidades.Categorias>();
        List<Entidades.Seguimientos> lstseguimientos = new List<Entidades.Seguimientos>();
        Negocios.SeguimientoActividades seg = new Negocios.SeguimientoActividades();
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack) { 
                lstcategorias=seg.Categorias();
                if (Session["Credenciales"] != null) {
                    Entidades.En_Usuarios usu=new Entidades.En_Usuarios();
                    usu = (Entidades.En_Usuarios)Session["Credenciales"];

                    //Llama al metodo para activar las alertas y mostrar mensaje
                    Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                    DateTime horaActual = DateTime.Now;
                    alert.ActivateAlertas(horaActual, Convert.ToInt32(usu.IdenBebe));
                    List<Entidades.Alerta> alertas = alert.TraerAlertas(Convert.ToInt32(usu.IdenBebe));

                    string scriptalerta = null;
                    foreach (Entidades.Alerta alrt in alertas)
                    {
                        if (alrt.HoraDeAlerta.TimeOfDay <= horaActual.TimeOfDay && alrt.Estado == true)
                        {
                            scriptalerta =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        $"toastr.warning('Hay una alerta pendiente en estos momentos! ({alrt.HoraDeAlerta.ToString("hh:mm tt")})');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrWarning", scriptalerta, true);
                        }
                    }
                    // Final del metodo de mostrar alertas

                    if (!usu.IdenBebe.Equals(""))
                    {
                        lstseguimientos = seg.TraerSeguimientos(Convert.ToInt32(usu.IdenBebe), 0, DateTime.Now.Date, DateTime.Now.Date);
                    }
                    else {
                        Response.Redirect("ControlPanel.aspx");
                    }
                    
                }
                
                dropCategoria.Items.Add("Selecciona una categoría");
                foreach (Entidades.Categorias c in lstcategorias) {
                    dropCategoria.Items.Add($"{c.Idcategorial}-{c.Nombre}");
                    dropcategorias.Items.Add($"{c.Idcategorial}-{c.Nombre}");
                }
                DataTable tablaseguimientos = new DataTable();
                tablaseguimientos.Columns.Add("Fecha", typeof(string));
                tablaseguimientos.Columns.Add("Descripción", typeof(string));
                tablaseguimientos.Columns.Add("Categoría", typeof(string));

                foreach (Entidades.Seguimientos s in lstseguimientos)
                {
                    string Fechaseguimiento = Convert.ToString(s.Fecha);
                    string[] Fechaseg=Fechaseguimiento.Split(' ');
                    tablaseguimientos.Rows.Add(Fechaseg[0], s.Descripcion, s.Categoria);

                }

                gridseguimiento.DataSource = tablaseguimientos;
                gridseguimiento.DataBind();
            }
            
        }



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            gridseguimiento.DataSource=dataTable;
            gridseguimiento.DataBind();

            string seleccionado=dropCategoria.SelectedValue;
            string fecha1=txtFechaSeguimiento1.Text;
            string fecha2 = txtFechaSeguimiento2.Text;
            DateTime Fecha1;
            DateTime Fecha2;
            int idcategoria = 0;
            if (!seleccionado.Equals("Selecciona una categoría"))
            {
                string[] data = seleccionado.Split('-');
                idcategoria = Convert.ToInt32(data[0]);
            }

            if (fecha1.Equals(""))
            {
                Fecha1 = DateTime.Now;
            }
            else { 
                Fecha1=DateTime.Parse(fecha1);
            }

            if (fecha2.Equals(""))
            {
                Fecha2 = DateTime.Now;
            }
            else
            {
                Fecha2 = DateTime.Parse(fecha2);
            }

            if (Session["Credenciales"] != null) {
                Entidades.En_Usuarios usu = new Entidades.En_Usuarios();
                usu = (Entidades.En_Usuarios)Session["Credenciales"];
                //Filtro....
                lblMensaje.Text = "";
                if (Fecha1.Date<=DateTime.Now.Date && Fecha2.Date <= DateTime.Now.Date) {
                    lstseguimientos = seg.TraerSeguimientos(Convert.ToInt32(usu.IdenBebe), idcategoria, Fecha1.Date, Fecha2.Date);
                    if (lstseguimientos.Count > 0)
                    {
                        DataTable tablaseguimientos = new DataTable();
                        tablaseguimientos.Columns.Add("Fecha", typeof(string));
                        tablaseguimientos.Columns.Add("Descripción", typeof(string));
                        tablaseguimientos.Columns.Add("Categoría", typeof(string));

                        foreach (Entidades.Seguimientos s in lstseguimientos)
                        {
                            string Fechaseguimiento = Convert.ToString(s.Fecha);
                            string[] Fechaseg = Fechaseguimiento.Split(' ');
                            tablaseguimientos.Rows.Add(Fechaseg[0], s.Descripcion, s.Categoria);

                        }

                        gridseguimiento.DataSource = tablaseguimientos;
                        gridseguimiento.DataBind();
                    }
                    else {
                        lblMensaje.Text = "Sin registros";
                    }

                }
                else{
                    lblMensaje.Text = "Ninguna de las fechas pueden ser mayores que hoy";
                }
                
            }

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            bool entrar = false;
            string script = null;
            string categoria = dropcategorias.SelectedValue;
            string descripcion = txtdescripcionseguimiento.Text;


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