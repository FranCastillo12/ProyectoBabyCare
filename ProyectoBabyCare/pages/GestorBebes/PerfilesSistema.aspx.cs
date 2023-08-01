using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class PerfilesSistema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable ListaUsuariosSistema = Negocios.UsuariosSistema.ListaUsuariosSistema();
            //gvUsuarios.DataSource = ListaUsuariosSistema;
            //gvUsuarios.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}