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
            Negocios.Consejos nConsejos = new Negocios.Consejos();                    

            List<Entidades.Consejos> consejos = new List<Entidades.Consejos>();
            consejos = nConsejos.Obtenerconsejos();

            Random r = new Random();

            int consejoAleatorio = r.Next(0, consejos.Count);            

            lblConsejo.Text = consejos[consejoAleatorio].Descripcion.ToString();         
            
            if(!IsPostBack)
            {
                Entidades.En_Usuarios iUsuarios = null;
                iUsuarios = new Entidades.En_Usuarios()
                {
                    Usuario = "gabriBr23@gmail.com",
                    IdenBebe = "5",
                    Rol = "4"
                };

                switch(iUsuarios.Rol)
                {
                    case "2":
                        lblPerfil.Text = "Perfil de Madre";
                        break;
                    case "3":
                        lblPerfil.Text = "Perfil de Padre";
                        break;
                    case "4":
                        lblPerfil.Text = "Perfil de abuelo";
                        break;
                    case "5":
                        lblPerfil.Text = "Perfil de babySister";
                        break;
                    case "6":
                        lblPerfil.Text = "Perfil normal";
                        break;
                    default:
                        lblPerfil.Text = "Perfil indefinido";
                        break;
                }

                if (iUsuarios.Rol == "2" || iUsuarios.Rol == "3")
                {                    
                   List<Citas> listaCitas = Negocios.ControlPanel.ListaCitas(6);
                   List<Alertas> listaAlertas = Negocios.ControlPanel.ListaAlertas(6);
                   List<Seguimientos> listaSeguimientos = Negocios.ControlPanel.ListaSeguimiento(6);

                }
                else
                {
                    List<Alertas> listaAlertas = Negocios.ControlPanel.ListaAlertas(6);
                    List<Seguimientos> listaSeguimientos = Negocios.ControlPanel.ListaSeguimiento(6);
                }
            }
        }
    }
}