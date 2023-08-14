using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages.GestorBebes
{
    public partial class Creaciondedietas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                DropRango.Items.Add("Seleccione un rango de dietas");
                DropTipo.Items.Add("Seleccione un tipo de comida");
                DropHorario.Items.Add("Seleccione un horario");
                Negocios.CreacionDietas dietas=new Negocios.CreacionDietas();
                List<Entidades.RangoEdadDietas> lstrangodietas= new List<Entidades.RangoEdadDietas>();
                List < Entidades.TiposComida> lst1 = new List<Entidades.TiposComida>();
                List < Entidades.HorariosDieta> lst2 = new List<Entidades.HorariosDieta>();
                lstrangodietas = dietas.listaRangoDietas();
                lst1=dietas.TraerTiposComida();
                lst2=dietas.TraerHorariosDietas();
                foreach (Entidades.RangoEdadDietas r in lstrangodietas)
                {

                    string fila = "";
                    if (r.EdadInicio == 12)
                    {
                        fila = "1 a 2 años";
                    }
                    else if (r.EdadInicio == 24)
                    {
                        fila = "2 a 5 años";
                    }
                    else {
                       fila = r.EdadInicio + " a " + r.EdadFinal + " meses";
                    }

                    DropRango.Items.Add(r.IdRangoDietas+"-"+fila);
                }
                foreach (Entidades.TiposComida r in lst1) {
                    DropTipo.Items.Add(r.IdTipoComida+"-"+r.Nombre1);
                }
                foreach (Entidades.HorariosDieta r in lst2)
                {
                    DropHorario.Items.Add(r.IdHorario + "-" + r.Nombre);
                }


            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string rangoselected =DropRango.SelectedValue;
            string tiposelected =DropTipo.SelectedValue;
            string horarioselected =DropHorario.SelectedValue;
            string nombrecomida =txtNombre.Text;
            if (!rangoselected.Equals("Seleccione un rango de dietas"))
            {
                if (!tiposelected.Equals("Seleccione un tipo de comida"))
                {
                    if (!horarioselected.Equals("Seleccione un horario"))
                    {
                        if (!nombrecomida.Equals(""))
                        {
                            string[] data1=rangoselected.Split('-');
                            string[] data2 = tiposelected.Split('-');
                            string[] data3 = horarioselected.Split('-');
                            int id1 = Convert.ToInt32(data1[0]);
                            int id2 = Convert.ToInt32(data2[0]);
                            int id3 = Convert.ToInt32(data3[0]);

                            Negocios.CreacionDietas c=new Negocios.CreacionDietas();
                            c.CrearDieta(id1,id2,id3,nombrecomida);

                            Response.Redirect("Creaciondedietas.aspx");
                        }
                        else
                        {
                            string scriptalerta =
                                    "toastr.options.closeButton = true;" +
                                     "toastr.options.positionClass = 'toast-bottom-right';" +
                                    "toastr.error('Debe ingresar un nombre para la comida');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);

                        }

                    }
                    else
                    {
                        string scriptalerta =
                                "toastr.options.closeButton = true;" +
                                 "toastr.options.positionClass = 'toast-bottom-right';" +
                                "toastr.error('Debe seleccionar un horario');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);

                    }

                }
                else
                {
                    string scriptalerta =
                            "toastr.options.closeButton = true;" +
                             "toastr.options.positionClass = 'toast-bottom-right';" +
                            "toastr.error('Debe seleccionar un tipo de comida');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);

                }

            }
            else {
                string scriptalerta =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe seleccionar un rango de dietas');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);

            }




        }
    }
}