using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace ProyectoBabyCare.pages
{
    public partial class ControlPanel : System.Web.UI.Page
    {               
        protected void Page_Load(object sender, EventArgs e)
        {
            
           
                //if (iUsuarios != null)
                //{
                    Negocios.Consejos nConsejos = new Negocios.Consejos();                    

                    List<Entidades.Consejos> consejos = new List<Entidades.Consejos>();
                    consejos = nConsejos.Obtenerconsejos();

                    Random r = new Random();

                    int consejoAleatorio = r.Next(0, consejos.Count);

                    lblConsejo.Text = consejos[consejoAleatorio].ToString();

                //}
            
        }
    }
}