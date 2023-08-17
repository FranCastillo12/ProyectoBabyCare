using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class AlbumFotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idBebe = 0;
                if (Session["Credenciales"] != null)
                {
                    Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
                    idBebe = Convert.ToInt32(user.IdenBebe);
                }
                Negocios.AlbumFotos album = new Negocios.AlbumFotos();
                if (idBebe != 0)
                {
                    //Llama al metodo para activar las alertas y mostrar mensaje
                    Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                    DateTime horaActual = DateTime.Now;
                    alert.ActivateAlertas(horaActual, idBebe);
                    List<Entidades.Alerta> alertas = alert.TraerAlertas(idBebe);

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
                    // Final del metodo de mostrar alertas


                    List<Entidades.FotosBebe> lst = album.TraerFotosBebe(idBebe);
                    PintarImagenes(lst);
                }
                else {
                    string scriptalerta =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe iniciar sesion para poder visualiar su album de fotos');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                }
                

            }
            else { 
            
            
            }
        }
        public void PintarImagenes(List<Entidades.FotosBebe> lst) {
            StringBuilder HTML = new StringBuilder();
            if (lst.Count > 0) {
              
                //parametros de impresion
                DateTime FechaFoto = lst[0].Fecha;//Agarra la fecha de la primera foto de la lista;
                                                  //metodos
                int contador = 0;
                while (contador < lst.Count - 1)
                {

                    //HTML.Append("");
                    if (lst[contador].Fecha.Year == FechaFoto.Year)
                    {
                        HTML.Append("<div class='row mt-3'>");
                        HTML.Append($"<h1 style='background-color: #F6E0ED; color: mediumblue; text-align: center;'>{FechaFoto.Year}</h1>");

                        while (lst[contador].Fecha.Year == FechaFoto.Year)
                        {
                            HTML.Append($"<img src = '{lst[contador].Url}' class='Imagen' runat='server'/>");

                            if (contador < lst.Count - 1)
                            {
                                contador++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (lst[contador].Fecha.Year != FechaFoto.Year)
                        {
                            FechaFoto = lst[contador].Fecha;
                        }
                        HTML.Append("</div>");
                    }
                }
                if (lst.Count == 1)
                {
                    HTML.Append("<div class='row mt-3'>");
                    HTML.Append($"<h1 style='background-color: #F6E0ED; color: mediumblue; text-align: center;'>{FechaFoto.Year}</h1>");
                    HTML.Append($"<img src = '{lst[0].Url}' class='Imagen' runat='server'/>");
                    HTML.Append("</div>");
                }
            }
            ContenedorAlbum.InnerHtml = HTML.ToString();

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string fecha1 = txtfecha1.Text;
            string fecha2 = txtfecha2.Text;
            DateTime Fecha1=DateTime.Now;
            DateTime Fecha2=DateTime.Now;
            if (!fecha1.Equals("") && !fecha2.Equals(""))
            {
                int idBebe = 0;
                if (Session["Credenciales"] != null) {
                    Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
                    idBebe = Convert.ToInt32(user.IdenBebe);
                }
                Negocios.AlbumFotos al=new Negocios.AlbumFotos();
                if (idBebe != 0)
                {
                    Fecha1 = DateTime.Parse(fecha1);
                    Fecha2 = DateTime.Parse(fecha2);
                    List<Entidades.FotosBebe> lst = al.FiltrarFotos(idBebe, Fecha1, Fecha2);
                    PintarImagenes(lst);
                }
                else {
                    string scriptalerta =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe iniciar sesion para poder filtrar fotos del album');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                }
                

            }
            else {
                int idBebe = 0;
                if (Session["Credenciales"] != null)
                {
                    Entidades.En_Usuarios user = (Entidades.En_Usuarios)Session["Credenciales"];
                    idBebe = Convert.ToInt32(user.IdenBebe);
                }
                Negocios.AlbumFotos al = new Negocios.AlbumFotos();
                if (idBebe != 0)
                {
                    List<Entidades.FotosBebe> lst = al.TraerFotosBebe(idBebe);
                    PintarImagenes(lst);
                }
                else
                {
                    string scriptalerta =
                        "toastr.options.closeButton = true;" +
                         "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe iniciar sesion para poder filtrar fotos del album');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrError", scriptalerta, true);
                }

            }
        }
    }
}