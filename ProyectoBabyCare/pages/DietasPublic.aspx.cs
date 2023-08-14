using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class DietasPublic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {                        

                List<Entidades.RangoEdadDietas> listaRangos = new List<Entidades.RangoEdadDietas>();
                listaRangos = Negocios.Dietas.listaRangoDietas();
                foreach (var r in listaRangos)
                {
                    string fila = r.EdadInicio + " a " + r.EdadFinal + " meses";

                    if (r.EdadInicio == 12)
                    {
                        fila = "1 a 2 años";
                    }
                    else if (r.EdadInicio == 24)
                    {
                        fila = "2 a 5 años";
                    }

                    drpRangos.Items.Add(new ListItem(fila, r.IdRangoDietas.ToString()));
                }                
                
                int idRango = 1;
                if (Session["idRango"] != null)
                {
                    idRango = (int)Session["idRango"];
                }

                string drpRangosTexto;
                ListItem ls = drpRangos.Items[idRango-1];
                drpRangosTexto = ls.Text;
                lblMensajeFlotante.Text = "Estas buscando dietas para niños " + drpRangosTexto;

                //drpRangos.SelectedIndex = idRango-1;

                List<Entidades.Dietas> listaDietas = new List<Entidades.Dietas>();                
                listaDietas = Negocios.Dietas.listaDietasEdad(idRango);              

                if (listaDietas.Count == 6)
                {
                    string cadena;
                    var dieta = listaDietas[0];
                    cadena = "Un buen desayuno para tu bebé es " + dieta.NombreComida;
                    lblComida1.Text = cadena;
                    dieta = listaDietas[1];
                    cadena = "La merienda en la mañana es necesaria para tu bebé, puedes darle " + dieta.NombreComida;
                    lblComida2.Text = cadena;
                    dieta = listaDietas[2];
                    cadena = "La comida de medio día es importa para tu bebé, puedes darle " + dieta.NombreComida;
                    lblComida3.Text = cadena;
                    dieta = listaDietas[3];
                    cadena = "Una saludable merienda en la tarde para tu bebé es " + dieta.NombreComida;
                    lblComida4.Text = cadena;
                    dieta = listaDietas[4];
                    cadena = "Para la cena, puedes darle a tu bebé " + dieta.NombreComida;
                    lblComida5.Text = cadena;
                    dieta = listaDietas[5];
                    cadena = "Antes de dormir  puedes darle a tu bebé " + dieta.NombreComida;
                    lblComida6.Text = cadena;
                }
            } catch (Exception exc)
            {
                lblComida1.Text = exc.Message;
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            int seleccionado = 1;
            Session["idRango"] = seleccionado;
            Response.Redirect("DietasPublic.aspx");
        }

        protected void btnAplicar_Click(object sender, EventArgs e)
        {
            int seleccionado = drpRangos.SelectedIndex;
            Session["idRango"] = seleccionado+1;
            Response.Redirect("DietasPublic.aspx");
        }

        protected void drpRangos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}