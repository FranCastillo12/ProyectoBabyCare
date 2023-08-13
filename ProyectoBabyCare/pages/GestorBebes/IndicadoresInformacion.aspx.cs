using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.styles.PaginasAdmin
{
    public partial class IndicadoresInformacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Negocios.Neg_Indicadores_informacion Indicadores = new Negocios.Neg_Indicadores_informacion();

                DataTable dtIndicadores = Indicadores.Obtener_Indicadores_Informacion();

                foreach (DataRow drIndicadores in dtIndicadores.Rows)
                {
                    h1usuarios.InnerText = drIndicadores["Usuarios"].ToString();
                    h1bebes_registrados.InnerText = drIndicadores["Total_Bebes"].ToString();
                    h1bebes_activos.InnerText = drIndicadores["Bebes_Activos"].ToString();
                    h1citas.InnerText = drIndicadores["Citas"].ToString();
                    h1vacunas.InnerText = drIndicadores["Vacunas"].ToString();
                    h1Archivos.InnerText = drIndicadores["Total_Archivos"].ToString();
                }
            }
        }
    }
}