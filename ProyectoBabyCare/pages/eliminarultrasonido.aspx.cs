using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class eliminarultrasonido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idUltrasonido = Convert.ToInt16(Request.QueryString["IDultrasonido"]);
            Negocios.Neg_Ultrasonidos iUltrasonidos = new Negocios.Neg_Ultrasonidos();
            iUltrasonidos.EliminarUltrasonido(idUltrasonido);
            Response.Redirect("Ultrasonidos.aspx");
        }
    }
}