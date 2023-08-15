using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class AlertasUsuario : System.Web.UI.Page
    {
        int idBebe = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropCategorias1.Items.Add("Seleccione una categoria");
                dropcategorias.Items.Add("Seleccione una categoria");
                if (Session["Credenciales"] != null)
                {
                    Entidades.En_Usuarios usu = (Entidades.En_Usuarios)Session["Credenciales"];
                    idBebe = Convert.ToInt32(usu.IdenBebe);

                    //Llama al metodo para activar las alertas y mostrar mensaje
                    Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                    DateTime horaActual = DateTime.Now;
                    alert.ActivateAlertas(horaActual, idBebe);
                    List<Entidades.Alerta> alertas = alert.TraerAlertas(idBebe);

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


                    //Resto de los metodos
                    Negocios.SeguimientoActividades s = new Negocios.SeguimientoActividades();


                    List<Entidades.Categorias> lstcategorias = s.Categorias();
                    foreach (Entidades.Categorias ca in lstcategorias)
                    {
                        dropCategorias1.Items.Add(ca.Idcategorial + "-" + ca.Nombre);
                        dropcategorias.Items.Add(ca.Idcategorial + "-" + ca.Nombre);
                    }



                    DataTable dt = new DataTable();
                    dt.Columns.Add("HoraAlerta", typeof(string));
                    dt.Columns.Add("idAlerta", typeof(int));
                    dt.Columns.Add("Descripcion", typeof(string));
                    dt.Columns.Add("Estado", typeof(bool));
                    dt.Columns.Add("Categoria", typeof(string));


                    string HoraAlerta = "";
                    foreach (Entidades.Alerta a in alertas)
                    {
                        HoraAlerta = a.HoraDeAlerta.ToString("hh:mm tt");
                        dt.Rows.Add(HoraAlerta, a.idAlerta, a.Descripcion, a.Estado, a.Categoria);
                    }



                    GridViewAlertas.DataSource = dt;
                    GridViewAlertas.DataBind();

            }

        }
        }

        protected void CheckBoxEstado_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkBox.NamingContainer;

            int idAlerta = Convert.ToInt32(GridViewAlertas.DataKeys[row.RowIndex].Value);

            bool Estado = checkBox.Checked;
            Negocios.AlertasUsuario alerta = new Negocios.AlertasUsuario();
            alerta.CambiarEstado(idAlerta,Estado);

            Response.Redirect("AlertasUsuario.aspx");
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            
            string seleccionado = dropCategorias1.SelectedValue;
            if (!seleccionado.Equals("Seleccione una categoria"))
            {
                string[] D = seleccionado.Split('-');
                DataTable dt = new DataTable();
                dt.Columns.Add("HoraAlerta", typeof(string));
                dt.Columns.Add("idAlerta", typeof(int));
                dt.Columns.Add("Descripcion", typeof(string));
                dt.Columns.Add("Estado", typeof(bool));
                dt.Columns.Add("Categoria", typeof(string));
                Negocios.AlertasUsuario alerta = new Negocios.AlertasUsuario();
                if (Session["Credenciales"] != null) {
                    Entidades.En_Usuarios usuario = (Entidades.En_Usuarios)Session["Credenciales"];
                    idBebe = Convert.ToInt32(usuario.IdenBebe);
                }

                if (idBebe!=0) {
                    List<Entidades.Alerta> alertas = alerta.FiltrarAlertas(idBebe, Convert.ToInt32(D[0]));
                    if (alertas.Count != 0)
                    {
                        string HoraAlerta = "";
                        foreach (Entidades.Alerta a in alertas)
                        {
                            HoraAlerta = a.HoraDeAlerta.ToString("hh:mm tt");
                            dt.Rows.Add(HoraAlerta, a.idAlerta, a.Descripcion, a.Estado, a.Categoria);
                        }
                        GridViewAlertas.DataSource = dt;
                        GridViewAlertas.DataBind();
                    }
                    else
                    {
                        string mensaje =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.error('No hay alertas registradas con la categoria seleccionada');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);
                    }
                }
                


            }
            else {
                string[] D = seleccionado.Split('-');
                DataTable dt = new DataTable();
                dt.Columns.Add("HoraAlerta", typeof(string));
                dt.Columns.Add("idAlerta", typeof(int));
                dt.Columns.Add("Descripcion", typeof(string));
                dt.Columns.Add("Estado", typeof(bool));
                dt.Columns.Add("Categoria", typeof(string));
                if (Session["Credenciales"] != null)
                {
                    Entidades.En_Usuarios usuario = (Entidades.En_Usuarios)Session["Credenciales"];
                    idBebe = Convert.ToInt32(usuario.IdenBebe);
                }
                Negocios.AlertasUsuario alerta = new Negocios.AlertasUsuario();
                List<Entidades.Alerta> alertas = alerta.TraerAlertas(idBebe);

                string HoraAlerta = "";
                foreach (Entidades.Alerta a in alertas)
                {
                    HoraAlerta = a.HoraDeAlerta.ToString("hh:mm tt");
                    dt.Rows.Add(HoraAlerta, a.idAlerta, a.Descripcion, a.Estado, a.Categoria);
                }
                GridViewAlertas.DataSource = dt;
                GridViewAlertas.DataBind();

                string mensaje =
                "toastr.options.closeButton = true;" +
                "toastr.options.positionClass = 'toast-bottom-right';" +
                $"toastr.error('Debe seleccionar una categoria para poder filtrar las alertas');";
                ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);
            }
            

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GridViewRow row = (GridViewRow)boton.NamingContainer;
            if (Session["Credenciales"] != null)
            {
                Entidades.En_Usuarios usuario = (Entidades.En_Usuarios)Session["Credenciales"];
                idBebe = Convert.ToInt32(usuario.IdenBebe);
            }
            int idAlerta = Convert.ToInt32(GridViewAlertas.DataKeys[row.RowIndex].Value);
            Negocios.AlertasUsuario alerta = new Negocios.AlertasUsuario();
            List<Entidades.Alerta> lstalertas = alerta.TraerAlertas(idBebe);
            if (lstalertas.Find(a => a.idAlerta == idAlerta && a.Estado == false) != null)
            {
                alerta.EliminarAlerta(idAlerta);
                Response.Redirect("AlertasUsuario.aspx");
            }
            else {
                    string mensaje =
                    "toastr.options.closeButton = true;" +
                     "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.error('No se puede eliminar esta alerta porque se encuentra activa');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);

            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Negocios.Configuraciones config=new Negocios.Configuraciones();
            Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
            Entidades.ConfiguracionesSistema sis=config.TraerConfiguraciones();
            if (Session["Credenciales"] != null)
            {
                Entidades.En_Usuarios USER = (Entidades.En_Usuarios)Session["Credenciales"];
                idBebe = Convert.ToInt32(USER.IdenBebe);
            }
            List<Entidades.Alerta> alertas = alert.TraerAlertas(idBebe);
            if (alertas.Count <= sis.Alertas)
            {
                string selected = dropcategorias.SelectedValue;
                string descripcion = txtDescripcionAlerta.Text;
                string[] D = selected.Split('-');
                string hora = txthora.Text;
                if (!selected.Equals("Seleccione una categoria"))
                {
                    if (!txthora.Text.Equals(""))
                    {
                        if (!descripcion.Equals(""))
                        {
                            DateTime Hoseleccionada;
                            if (DateTime.TryParseExact(hora, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out Hoseleccionada))
                            {
                                Negocios.AlertasUsuario Al = new Negocios.AlertasUsuario();
                                Entidades.En_Usuarios usuario = new En_Usuarios();
                                if (Session["Credenciales"] != null)
                                {
                                    usuario = (Entidades.En_Usuarios)Session["Credenciales"];
                                    Al.AgregarAlerta(Convert.ToInt32(usuario.IdenBebe), Convert.ToInt32(D[0]), descripcion, Hoseleccionada);
                                    Response.Redirect("AlertasUsuario.aspx");
                                }
                                else
                                {
                                    string mensaje =
                                     "toastr.options.closeButton = true;" +
                                         "toastr.options.positionClass = 'toast-bottom-right';" +
                                        $"toastr.error('No se puede registrar la alerta porque no hay un usuario autentificado');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);

                                }
                            }
                        }
                        else
                        {
                            string mensaje =
                                "toastr.options.closeButton = true;" +
                                 "toastr.options.positionClass = 'toast-bottom-right';" +
                                $"toastr.error('La descripcion de la alerta no puede ir vacia.');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);

                        }
                    }
                    else
                    {
                        string mensaje =
                                "toastr.options.closeButton = true;" +
                                 "toastr.options.positionClass = 'toast-bottom-right';" +
                                $"toastr.error('Debe seleccionar una hora para poder registrar la alerta.');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);
                    }
                }
                else
                {
                    string mensaje =
                    "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.error('Debe seleccionar una categoria antes de agregar la alerta.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);
                }

            }
            else {
                string mensaje =
                    "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                    $"toastr.error('El sistema no permite el ingreso de mas de {sis.Alertas} alertas');";
                ScriptManager.RegisterStartupScript(this, GetType(), "Toastrerror", mensaje, true);

            }


            
        }
    }
}