using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoBabyCare.pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Negocios.Configuraciones config = new Negocios.Configuraciones();
                Entidades.ConfiguracionesSistema configsistema = new Entidades.ConfiguracionesSistema();
                Entidades.ConfiguracionesGrupoFamiliar configgrupo = new Entidades.ConfiguracionesGrupoFamiliar();
                configsistema = config.TraerConfiguraciones();
                configgrupo = config.TraerGrupoFamiliar();
                //Cargar datos del sistema
                txtAlertas.Text = configsistema.Alertas.ToString();
                txtFotos.Text = configsistema.Fotos.ToString();
                txtVideos.Text = configsistema.Videos.ToString();
                txtUltrasonidos.Text = configsistema.Ultrasonidos.ToString();

                //Cargar datos del grupo familiar
                txtPadres.Text = configgrupo.Padres.ToString();
                txtMadres.Text = configgrupo.Madres.ToString();
                txtAbuelos.Text = configgrupo.Abuelos.ToString();
                txtBabysisters.Text = configgrupo.Babysisters.ToString();
                txtTios.Text = configgrupo.Tios.ToString();
                txtTias.Text = configgrupo.Tias.ToString();
                txtInvitados.Text = configgrupo.Invitados.ToString();
            }
        }

        protected void btnModificarGrupoFamiliar_Click(object sender, EventArgs e)
        {
            if (!txtPadres.Text.Trim().Equals("") && !txtMadres.Text.Trim().Equals("") && !txtTios.Text.Trim().Equals("") && !txtTias.Text.Trim().Equals("")
                && !txtAbuelos.Text.Trim().Equals("") && !txtBabysisters.Text.Trim().Equals("") && !txtInvitados.Text.Trim().Equals("")) {

                int padres = Convert.ToInt32(txtPadres.Text);
                int madres = Convert.ToInt32(txtMadres.Text);
                int abuelos = Convert.ToInt32(txtAbuelos.Text);
                int babysisters = Convert.ToInt32(txtBabysisters.Text);
                int tios = Convert.ToInt32(txtTios.Text);
                int tias = Convert.ToInt32(txtTias.Text);
                int invitadps = Convert.ToInt32(txtInvitados.Text);
                Negocios.Configuraciones config = new Negocios.Configuraciones();
                config.ModificarConfiguracionesGrupoFamiliar(padres, madres, abuelos, babysisters, tios, tias, invitadps);

                Response.Redirect("Configuraciones.aspx");

            }
            else {
               string scriptalerta =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Ninguno de los campos del grupo familiar puede ir vacio');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
        }

        protected void btnModificarSistema_Click(object sender, EventArgs e)
        {
            if (!txtAlertas.Text.Trim().Equals("") && !txtFotos.Text.Trim().Equals("") && !txtVideos.Text.Trim().Equals("") && !txtUltrasonidos.Text.Trim().Equals(""))
            {
                int alertas= Convert.ToInt32(txtAlertas.Text);
                int Fotos= Convert.ToInt32(txtFotos.Text);
                int Videos= Convert.ToInt32(txtVideos.Text);
                int Ultrasonidos= Convert.ToInt32(txtUltrasonidos.Text);
                Negocios.Configuraciones config = new Negocios.Configuraciones();
                config.ModificarConfiguracionesSistema(alertas,Fotos,Videos,Ultrasonidos);

                Response.Redirect("Configuraciones.aspx");
            }
            else
            {
                string scriptalerta =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Ninguno de los campos de configuraciones del sistema puede ir vacio');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
            }
            

        }
    }
}