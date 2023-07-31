using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class ControlPanel2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Negocios.Consejos nConsejos = new Negocios.Consejos();

                List<Entidades.Consejos> consejos = new List<Entidades.Consejos>();
                consejos = nConsejos.Obtenerconsejos();

                Random r = new Random();

                int consejoAleatorio = r.Next(0, consejos.Count);

                //Asignamos consejo
                lblConsejo.Text = consejos[consejoAleatorio].Descripcion.ToString();
            }
            catch (Exception exc)
            {
                lblConsejo.Text = exc.Message;
            }            

            lblNombre.Text = "No tienes ningun bebé asociado";
            lblEdad.Text = $"Dirigite a 'Mi perfil' para agregar tu primer bebé";
            
            lblNotificacion1.Text = $"BabyCare te ayudará en el cuido de tu pequeño. Tener un bebé es" +
                $" una gran responsabilidad pero también un gran privilegio";
            lblNotificacion2.Text = $"De este lado del panel podras ver informacíón importante de tu bebé<br>" +
                $"Además de consejos y recomendaciones para el día a día";
            lblNotificacion3.Text = $"¡Que tengas un maravilloso día hoy!<br>Te recomendaos navegar por el sistema" +
                $" y de paso agregar tu primer bebé :)";
            lblNotificacion4.Text = $"Agrega tu primer bebé en<br>'Mi perfil'";
            lblNotificacion5.Text = "De este lado del panel podrás ver las alertas importantes y las notas de seguimiento";
        }
    }
}