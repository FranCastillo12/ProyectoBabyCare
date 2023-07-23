using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Expediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int idbebe=0;
            string correo = "";
            if (Session["Credenciales"]!=null && Session["idbebe"]!=null) {
                Entidades.En_Usuarios usuario = (Entidades.En_Usuarios)Session["Credenciales"];
                correo = usuario.Usuario;
                idbebe = Convert.ToInt32(Convert.ToString(Session["idbebe"]));
            }
            if (!IsPostBack)
            {
                if (idbebe != 0 && !correo.Equals("")) { 
                    Entidades.Expediente expediente= new Entidades.Expediente();
                    Negocios.Expediente ex=new Negocios.Expediente();
                    expediente = ex.obtenerexpediente(correo,idbebe);

                    txtnombre.Text = expediente.Nombrebebe;
                    txtPeso.Text=Convert.ToString(expediente.Peso);
                    txtSangre.Text = expediente.Tiposangre;
                    txtpapa.Text = expediente.NombrePadre;
                    txtmama.Text = expediente.NombreMadre;
                }

            }
        }
    }
}