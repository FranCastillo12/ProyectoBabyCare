using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Consejos : System.Web.UI.Page
    {
        int indice=0;
        List<Entidades.Consejos> lstConsejos = new List<Entidades.Consejos>();
        Negocios.Consejos consejos = new Negocios.Consejos();
    
        protected void Page_Load(object sender, EventArgs e)
        {
            lstConsejos=consejos.Obtenerconsejos();
            if (Session["indice"] != null)
            {
                indice = (int)Session["indice"];
            }
            if (!IsPostBack)
            {
                if (lstConsejos.Count>0) { 
                    lbltitulo.Text = lstConsejos[indice].Titulo;
                    lblDescripcion.Text = lstConsejos[indice].Descripcion;
                }
            }
        }

        protected void bder_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            // Obtener el valor del CommandArgument para identificar el botón clickeado
            string botonID = boton.CommandArgument;

            // Agrega aquí la lógica específica para cada botón según su identificación
            switch (botonID)
            {
                case "adelante":
                    // Lógica para el boton adelante
                    if (indice >= lstConsejos.Count)
                    {
                        indice++;
                        if (indice > lstConsejos.Count-1)
                        {
                            indice = 0;
                            lbltitulo.Text = lstConsejos[indice].Titulo;
                            lblDescripcion.Text = lstConsejos[indice].Descripcion;

                            Session["Indice"] = indice;
                        }
                    }
                    else {
                        indice++;
                        if (indice > lstConsejos.Count-1) {
                            indice = 0;
                        }
                        lbltitulo.Text = lstConsejos[indice].Titulo;
                        lblDescripcion.Text = lstConsejos[indice].Descripcion;

                        Session["Indice"] = indice;
                    }

                    break;
                case "atras":
                    // Lógica para el boton atras
                    if (indice <= 1)
                    {
                        indice--;
                        if (indice<0) {
                            indice=lstConsejos.Count-1;
                        }
                        lbltitulo.Text=lstConsejos[indice].Titulo;
                        lblDescripcion.Text = lstConsejos[indice].Descripcion;

                        Session["Indice"] = indice;  
                    }
                    else
                    {
                        indice--;
                        lbltitulo.Text = lstConsejos[indice].Titulo;
                        lblDescripcion.Text = lstConsejos[indice].Descripcion;

                        Session["Indice"] = indice;
                    }
                    break;
                default:
                    // Código para manejar casos no esperados
                    break;
            }
        }
    }

}