using Entidades;
using Negocios;
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
        int idbebe = 0;
        string correo = "";
        Negocios.Expediente ex = new Negocios.Expediente();
        List<Entidades.Padecimientos> lstpadecimientos = new List<Padecimientos>();
        List<Entidades.Padecimientos> lstpadecimientosexpediente = new List<Padecimientos>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Session["Credenciales"] != null)
                {
                    Entidades.En_Usuarios usuario = (Entidades.En_Usuarios)Session["Credenciales"];
                    correo = usuario.Usuario;
                    idbebe = Convert.ToInt32(Convert.ToString(usuario.IdenBebe));
                }

                lstpadecimientos = ex.TodoslosPadecimientos();
                dpllPadecimientos.Items.Add("Seleccione un padecimiento");
                foreach (Entidades.Padecimientos ex1 in lstpadecimientos)
                {
                    dpllPadecimientos.Items.Add(ex1.IdPadecimiento + "-" + ex1.Nombrepadecimiento);
                }
                if (idbebe != 0 && !correo.Equals(""))
                {
                    Entidades.Expediente expediente = new Entidades.Expediente();

                    expediente = ex.obtenerexpediente(correo, idbebe);

                    txtnombre.Text = expediente.Nombrebebe;
                    txtPeso.Text = Convert.ToString(expediente.Peso);
                    txtSangre.Text = expediente.Tiposangre.Trim();
                    txtpapa.Text = expediente.NombrePadre;
                    txtmama.Text = expediente.NombreMadre;
                    txtestatura.Text = Convert.ToString(expediente.Estatura);
                    txtfecha.Text = expediente.Fechanacimiento;

                    //padecimientos


                    lstpadecimientosexpediente = ex.PadecimientosExpediente(expediente.Idexpediente);

                    txtPadecimientos.Text = "";
                    if (lstpadecimientosexpediente.Count > 0)
                    {
                        int cont = 1;
                        foreach (Entidades.Padecimientos ex2 in lstpadecimientosexpediente)
                        {
                            txtPadecimientos.Text += cont + "-" + ex2.Nombrepadecimiento + "\n";
                            cont++;
                        }
                    }
                    else
                    {
                        txtPadecimientos.Text = "Sin registros";
                    }
                    //detalles
                    txtDetalles.Text = "";
                    string[] lstdetalle = ex.Detalles(expediente.Idexpediente);
                    if (lstdetalle.Length > 0)
                    {
                        int cont = 1;
                        foreach (string s in lstdetalle)
                        {
                            if (!s.Equals(""))
                            {
                                string[] atrib = s.Split('@');
                                string[] fecha = atrib[1].Split(' ');
                                txtDetalles.Text += $"{cont}-{fecha[0]}: {atrib[0]}\n";
                                cont++;
                            }

                        }
                    }
                    else
                    {
                        txtDetalles.Text = "Sin registros";
                    }
                    //Vacunas
                    txtVacunas.Text = "";
                    string[] lstvacunas = ex.Vacunas(expediente.Idexpediente);
                    if (lstvacunas.Length > 0)
                    {
                        int cont = 1;
                        foreach (string s in lstvacunas)
                        {
                            if (!s.Equals(""))
                            {
                                string[] atrib = s.Split('@');
                                string[] fecha = atrib[2].Split(' ');
                                txtVacunas.Text += $"{cont}-{fecha[0]}: {atrib[0]}\n";
                                txtVacunas.Text += $"Descripción: {atrib[1]}\n";
                                cont++;
                            }

                        }
                    }
                    else
                    {
                        txtVacunas.Text = "Sin registros";
                    }

                }
                else {
                    txtnombre.Text = "Sin registros";
                    txtPeso.Text = "Sin registros";
                    txtSangre.Text = "Sin registros";
                    txtpapa.Text = "Sin registros";
                    txtmama.Text = "Sin registros";
                    txtestatura.Text = "Sin registros";
                    txtfecha.Text = "Sin registros";
                }
            }
            

        }

        protected void btnagregarpadecimientos_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}