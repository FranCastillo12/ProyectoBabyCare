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
                    lstseguimientos = seg.TraerSeguimientos(Convert.ToInt32(usu.IdenBebe),0,DateTime.Now.Date);
                }
                
                dropCategoria.Items.Add("Selecciona una categoría");
                foreach (Entidades.Categorias c in lstcategorias) {
                    dropCategoria.Items.Add($"{c.Idcategorial}-{c.Nombre}");
                }
                gridseguimiento.DataSource = lstseguimientos;
                gridseguimiento.DataBind();
            }
            
        }



        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            gridseguimiento.DataSource=dataTable;
            gridseguimiento.DataBind();

            string seleccionado=dropCategoria.SelectedValue;
            string fecha=txtFechaSeguimiento.Text;
            DateTime Fecha;
            int idcategoria = 0;
            int idbebe = 0;
            if (!seleccionado.Equals("Selecciona una categoría"))
            {
                string[] data = seleccionado.Split('-');
                idcategoria = Convert.ToInt32(data[0]);
            }
            if (fecha.Equals(""))
            {
                Fecha = DateTime.Now;
            }
            else { 
                Fecha=DateTime.Parse(fecha);
            }
            if (Session["Credenciales"] != null) {
                Entidades.En_Usuarios usu = new Entidades.En_Usuarios();
                usu = (Entidades.En_Usuarios)Session["Credenciales"];
                lstseguimientos = seg.TraerSeguimientos(Convert.ToInt32(usu.IdenBebe), idcategoria, Fecha.Date);

                gridseguimiento.DataSource = lstseguimientos;
                gridseguimiento.DataBind();
            }

        }
    }
}