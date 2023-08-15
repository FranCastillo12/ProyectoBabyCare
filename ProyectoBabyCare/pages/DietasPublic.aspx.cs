using Entidades;
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
                En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];

                if (credenciales == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                else
                {
                    if (credenciales.IdenBebe != null && credenciales.IdenBebe!="")
                    {
                        //Llama al metodo para activar las alertas y mostrar mensaje
                        Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                        DateTime horaActual = DateTime.Now;
                        alert.ActivateAlertas(horaActual, Convert.ToInt32(credenciales.IdenBebe));
                        List<Entidades.Alerta> alertas = alert.TraerAlertas(Convert.ToInt32(credenciales.IdenBebe));

                        string scriptalerta = null;
                        foreach (Entidades.Alerta alrt in alertas)
                        {
                            if (alrt.HoraDeAlerta.TimeOfDay <= horaActual.TimeOfDay && alrt.Estado == true)
                            {
                                scriptalerta =
                            "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-bottom-right';" +
                            $"toastr.warning('Hay una alerta pendiente en estos momentos! ({alrt.HoraDeAlerta.ToString("hh:mm tt")})');";
                                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrWarning", scriptalerta, true);
                            }
                        }
                    }                    

                    List<Entidades.RangoEdadDietas> listaRangos = Negocios.Dietas.listaRangoDietas();

                    Dictionary<int, string> rangoMapeo = new Dictionary<int, string>
                    {
                        { 12, "1 a 2 años" },
                        { 24, "2 a 5 años" }
                    };

                    foreach (var r in listaRangos)
                    {
                        string fila = r.EdadInicio == 12 ? rangoMapeo[12] : r.EdadInicio == 24 ? rangoMapeo[24] : r.EdadInicio + " a " + r.EdadFinal + " meses";
                        drpRangos.Items.Add(new ListItem(fila, r.IdRangoDietas.ToString()));
                    }

                    int idRango = Session["idRango"] != null ? (int)Session["idRango"] : 1;

                    if (drpRangos.Items.Count >= idRango)
                    {
                        string drpRangosTexto = drpRangos.Items[idRango - 1].Text;
                        lblMensajeFlotante.Text = "Estás buscando dietas para niños " + drpRangosTexto;
                    }
                    // drpRangos.SelectedValue = idRango.ToString();

                    List<Entidades.Dietas> listaDietas = Negocios.Dietas.listaDietasEdad(idRango);
                    Random random = new Random();
                    string[] horarios = { "Desayuno", "Merienda Mañana", "Medio Dia", "Merienda Tarde", "Cena", "Noche" };

                    foreach (string horario in horarios)
                    {
                        var dietas = listaDietas.Where(d => d.NombreDietaHorarioDieta == horario);

                        if (dietas.Any())
                        {
                            int cantidad = dietas.Count();
                            int numeroRandom = random.Next(0, cantidad);
                            var dieta = dietas.ElementAt(numeroRandom);
                            string cadena = ObtenerCadena(horario, dieta.NombreComida);

                            if (horario == "Noche")
                            {
                                lblComida6.Text = cadena;
                            }
                            else if (horario == "Cena")
                            {
                                lblComida5.Text = cadena;
                            }
                            else
                            {
                                AsignarTextoEtiqueta(horario, cadena);
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
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
            Session["idRango"] = seleccionado + 1;
            Response.Redirect("DietasPublic.aspx");
        }

        private string ObtenerCadena(string horario, string nombreComida)
        {
            if (horario == "Merienda Mañana")
            {
                return "La merienda en la mañana es necesaria para tu bebé, puedes darle " + nombreComida;
            }
            else if (horario == "Medio Dia")
            {
                return "La comida de medio día es importante para tu bebé, puedes darle " + nombreComida;
            }
            else if (horario == "Merienda Tarde")
            {
                return "Una saludable merienda en la tarde para tu bebé es " + nombreComida;
            }
            else if (horario == "Cena" || horario == "Noche")
            {
                return "Para la cena, puedes darle a tu bebé " + nombreComida;
            }
            else
            {
                return "Un buen " + horario.ToLower() + " para tu bebé es " + nombreComida;
            }
        }
        private void AsignarTextoEtiqueta(string horario, string cadena)
        {
            if (horario == "Desayuno")
            {
                lblComida1.Text = cadena;
            }
            else if (horario == "Merienda Mañana")
            {
                lblComida2.Text = cadena;
            }
            else if (horario == "Medio Dia")
            {
                lblComida3.Text = cadena;
            }
            else if (horario == "Merienda Tarde")
            {
                lblComida4.Text = cadena;
            }
        }

        protected void drpRangos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}