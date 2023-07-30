using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare
{
    public partial class NombresSignificados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            txtArea.Text = "";
            string letra=txtLetra.Text;
            int genero=0;
            if (radioBtn1.Checked) {
                genero = 3;
            }else if (radioBtn2.Checked)
            {
                genero=1;
            }else if (radioBtn3.Checked) {
                genero = 2;
            }


            Negocios.ConsumirAPI bd=new Negocios.ConsumirAPI();
            List<Entidades.NombresSignificados> nombres = bd.ObtenerNombresSignificados(letra,genero);
            //Agregar nombres el textarea
            int Conteo = 1;
            foreach (Entidades.NombresSignificados n in nombres) {
                txtArea.Text += $" {Conteo}-{n.Nombre}: {n.Significado} \n";
                Conteo++;
            }

        }
    }
}