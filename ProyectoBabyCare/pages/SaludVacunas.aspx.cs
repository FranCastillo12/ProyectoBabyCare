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
    public partial class SaludVacunas : System.Web.UI.Page
    {
        List<Entidades.Vacunas> listaVacunas = new List<Entidades.Vacunas>();
        protected void Page_Load(object sender, EventArgs e)
        {
            int idBebe = 6;
            try
            {                
                listaVacunas = Negocios.Vacunas.ListaVacunas(idBebe);

                // Recorrer la lista de vacunas y crear elementos HTML para cada una
                foreach (var vacuna in listaVacunas)
                {
                    // Crear el botón para la vacuna
                    Button btnVacuna = new Button
                    {
                        ID = "btnVacuna_" + vacuna.Nombre, // Asignar un ID único al botón
                        Text = vacuna.Nombre,
                        CssClass = "btnAceptar"
                    };
                    btnVacuna.Click += ButtonVacuna_Click; // Asignar un evento click para el botón

                    // Crear el div contenedor para cada vacuna
                    Panel contenedor = new Panel();

                    contenedor.CssClass = "Vacuna";
                    contenedor.Controls.Add(new Panel
                    {
                        CssClass = "VacunaLogo",
                        Controls = { new Image { ImageUrl = "../images/flecha2.png", AlternateText = "", Width = Unit.Percentage(100), Height = Unit.Percentage(100) } }
                    });
                    contenedor.Controls.Add(new Panel
                    {
                        CssClass = "VacunaTexto",
                        Controls = { new Panel { CssClass = "textoNuevaVacuna", Controls = { btnVacuna } } }
                    });

                    // Agregar el div contenedor al div "contenedorVacunas"
                    contenedorVacunas.Controls.Add(contenedor);
                }
            }catch(Exception exc)
            {

            }
        }
        protected void ButtonVacuna_Click(object sender, EventArgs e)
        {
            Button btnVacuna = (Button)sender;
            string idVacuna = btnVacuna.ID;

            string NombreVacuna = btnVacuna.ID.Replace("btnVacuna_", "");

            foreach(var vacuna in listaVacunas)
            {
                if (vacuna.Nombre == NombreVacuna)
                {
                    txtTitulo.Text = NombreVacuna;
                    txtDescripcion.Text = vacuna.Descripcion;
                    txtFecha.Text = vacuna.Fecha.ToString();
                }
            }            

        }

        protected void btnRegistrarNueva_Click(object sender, EventArgs e)
        {
            txtTitulo.Text = "Titulo Vacuna Nueva";
            txtDescripcion.Text = "Descripcion Vacuna nueva";
            txtFecha.Text = DateTime.Now.ToString();
        }
    }
}