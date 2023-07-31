using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare
{
    public partial class SitePrivate : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];

            string rol = credenciales.Rol;

           if(rol == "Invitado")
            {
                expediente.Visible = false;
                navbarDropdownMenuLink1.Visible = false;
            }
            else
            {
                expediente.Visible = true;
                navbarDropdownMenuLink1.Visible = true;
            }
        }

        public void MiMetodoEnMasterPage()
        {
            Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];

            string rol = credenciales.Rol;

            if (rol == "Invitado")
            {
                expediente.Visible = false;
                navbarDropdownMenuLink1.Visible = false;
            }
            else
            {
                expediente.Visible = true;
                navbarDropdownMenuLink1.Visible = true;
            }
        }
    }
}