using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class CargaFotosVideos : System.Web.UI.Page
    {
        List<string> urlArchivos = new List<string>();
        List<Entidades.Archivos> ListaArchivos = null;
        bool bebeSeleccionado = false;
        int idBebe = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];

                if (credenciales == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                if (credenciales.IdenBebe != null && credenciales.IdenBebe != "")
                {
                    //Alertas
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
                    //Fin alertas

                    //Cargamos los datos del bebé
                    Entidades.Bebe bebe = Negocios.Bebe.bebe(credenciales.IdenBebe);
                    //Cargamos informacion del bebé
                    CargarLabels(bebe);
                    idBebe = Convert.ToInt32(credenciales.IdenBebe);
                    ListaArchivos = Negocios.Archivos.ListaArchivosBebe(idBebe);
                    bebeSeleccionado = true;
                }
                urlArchivos.Clear();

                if (ListaArchivos != null && ListaArchivos.Count > 0)
                {
                    Random r = new Random();

                    foreach (var archivo in ListaArchivos)
                    {
                        if (archivo.RutaArchivo.EndsWith("image"))
                        {
                            fotoPerfi.ImageUrl = archivo.RutaArchivo;
                        }
                        urlArchivos.Add(archivo.RutaArchivo);
                    }
                }
                else
                {
                    urlArchivos.Add("../images/bebe1.jpg");
                    urlArchivos.Add("../images/bebe2.jpg");
                    urlArchivos.Add("../images/bebe3.jpg");
                    urlArchivos.Add("../images/bebe4.png");
                    urlArchivos.Add("../images/bebe5.jpg");
                    urlArchivos.Add("../images/bebe6.png");
                }

                CargarImagenes();
                CargarCuadrosLuz();

                //No tiene uun bebe seleccionado, no puede cargar datos
                if (!bebeSeleccionado)
                {
                    FileUpload1.Enabled = false;
                    Button1.Enabled = false;
                }
            }
            catch (Exception exc)
            {
                string script =
                  "toastr.options.closeButton = true;" +
                 "toastr.options.positionClass = 'toast-bottom-right';" +
                  "toastr.error('Ha ocurrido un error intentarlo mas tarde');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string script = null;           

            if (FileUpload1.HasFile)
            {
                if (System.IO.Path.GetExtension(FileUpload1.FileName) != ".jpg"
                    && System.IO.Path.GetExtension(FileUpload1.FileName) != ".png"
                    && System.IO.Path.GetExtension(FileUpload1.FileName) != ".gif"
                    && System.IO.Path.GetExtension(FileUpload1.FileName) != ".jpeg"
                    && System.IO.Path.GetExtension(FileUpload1.FileName) != ".mp4")
                {
                    script =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('Solo puedes cargar imagenes y videos');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                    //lblMensaje.Text = "Solo puedes cargar imagenes y videos";
                }
                else if (FileUpload1.PostedFile.ContentLength > 10240 * 1024)
                {
                    script =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('El archivo es demasiado grande. El tamaño máximo permitido es 10 MB.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                    //lblMensaje.Text = "El archivo es demasiado grande. El tamaño máximo permitido es 10 MB.";
                }
                else //Todo es valido
                {
                    bool LimiteArchivosAlcanzado = false;

                    if (ListaArchivos != null)
                    {
                        //Calculamos la cantidad de videos y fotos que tiene el usuario
                        int countImages = 0;
                        int countVideos = 0;
                        foreach (var archivo in ListaArchivos)
                        {
                            if (archivo.IdTipoArchivo == 1)
                            {
                                countImages += 1;
                            }
                            else
                            {
                                countVideos += 1;
                            }
                        }
                        try
                        {
                            Negocios.Configuraciones config = new Negocios.Configuraciones();
                            Entidades.ConfiguracionesSistema configSistema = config.TraerConfiguraciones();

                            //Haciemos las validaciones con los configuracion del sistema
                            if (Path.GetExtension(FileUpload1.FileName) == ".mp4") //es video
                            {
                                if (countVideos >= configSistema.Videos)
                                {
                                    LimiteArchivosAlcanzado = true;
                                    script =
                                      "toastr.options.closeButton = true;" +
                                      "toastr.options.positionClass = 'toast-bottom-right';" +
                                      "toastr.error('Limite de carga de videos alcanzado');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                                }
                            }
                            else //es foto
                            {
                                if (countImages >= configSistema.Fotos)
                                {
                                    LimiteArchivosAlcanzado = true;
                                    script =
                                      "toastr.options.closeButton = true;" +
                                      "toastr.options.positionClass = 'toast-bottom-right';" +
                                      "toastr.error('Limite de carga de fotos alcanzado');";
                                    ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                                }
                            }
                        } catch (Exception)
                        {
                            script =
                          "toastr.options.closeButton = true;" +
                          "toastr.options.positionClass = 'toast-bottom-right';" +
                          "toastr.error('Error en la carga de las confiraciones del sistema');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                        }                                                                       
                    }
                    if (!LimiteArchivosAlcanzado)
                    {
                        GuardarArchivo();
                        script =
                       "toastr.options.closeButton = true;" +
                       "toastr.options.positionClass = 'toast-bottom-right';" +
                       "toastr.error('Archivo guardado con exito');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                        //lblMensaje.Text = "Archivo guardado con exito";
                        Response.Redirect("CargaFotosVideos.aspx");
                    }                   
                }
            }
            else
            {
                script =
                   "toastr.options.closeButton = true;" +
                   "toastr.options.positionClass = 'toast-bottom-right';" +
                   "toastr.error('No haz seleccionado ningun archivo');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                //  lblMensaje.Text = "No haz seleccionado ningun archivo";
            }
        }
        private void GuardarArchivo()
        {
            try
            {
                //creamos arreglo de bytes con el contenido del archivo
                byte[] filebytes;
                using (var inputstream = FileUpload1.PostedFile.InputStream)
                {
                    using (var memorystream = new MemoryStream())
                    {
                        inputstream.CopyTo(memorystream);
                        filebytes = memorystream.ToArray();
                    }
                }
                //guardamos la ruta local
                string rutalocal = Path.GetFileName(FileUpload1.FileName);
                int idbebe = idBebe;
                string tituloarchivo = "archivo_bebe_" + idbebe.ToString() + "_";
                int tipoimagen = Path.GetExtension(FileUpload1.FileName) == ".mp4" ? 2 : 1;

                Negocios.Archivos.SubirArchivoAWS(rutalocal, filebytes, idbebe, tituloarchivo, tipoimagen);

            }
            catch (Exception e)
            {
                string script =
                   "toastr.options.closeButton = true;" +
                   "toastr.options.positionClass = 'toast-bottom-right';" +
                   "toastr.error('Ha ocurrido un error al guardar el archivo');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                //  Excepcion guardando el archivo
            }
        }
        private void CargarImagenes()
        {
            StringBuilder galleryHtml = new StringBuilder();

            for (int i = 0; i < urlArchivos.Count; i++)
            {
                if (!urlArchivos[i].EndsWith("video"))
                {
                    string imageId = "archivo" + (i + 1);
                    string imageUrl = urlArchivos[i];

                    galleryHtml.AppendLine("<section class='gallery-item'>");
                    galleryHtml.AppendLine($"    <a href='#{imageId}'>");
                    galleryHtml.AppendLine($"        <img src='{imageUrl}' alt='' />");
                    galleryHtml.AppendLine($"    </a>");
                    galleryHtml.AppendLine("</section>");
                }
                else
                {
                    string videoId = "archivo" + (i + 1);
                    string videoUrl = urlArchivos[i];  // Reemplaza imageUrl por videoUrl

                    galleryHtml.AppendLine("<section class='gallery-item'>");
                    galleryHtml.AppendLine($"    <a href='#{videoId}'>");
                    galleryHtml.AppendLine($"        <video controls>");  // Cambia img por video
                    galleryHtml.AppendLine($"            <source src='{videoUrl}' type='video/mp4'>");  // Cambia src y tipo de archivo
                    galleryHtml.AppendLine($"            Your browser does not support the video tag.");  // Mensaje de respaldo
                    galleryHtml.AppendLine($"        </video>");
                    galleryHtml.AppendLine($"    </a>");
                    galleryHtml.AppendLine("</section>");
                }
            }

            galleryContainer.InnerHtml = galleryHtml.ToString();
        }
        private void CargarCuadrosLuz()
        {
            StringBuilder lightboxHtml = new StringBuilder();

            for (int i = 0; i < urlArchivos.Count; i++)
            {
                if (!urlArchivos[i].EndsWith("video"))
                {
                    string imageId = "archivo" + (i + 1);
                    string prevImageId = "archivo" + (i == 0 ? urlArchivos.Count : i);
                    string nextImageId = "archivo" + (i == urlArchivos.Count - 1 ? 1 : i + 2);
                    string imageUrl = urlArchivos[i];

                    lightboxHtml.AppendLine("<article class='light-box' id='" + imageId + "'>");
                    lightboxHtml.AppendLine($"    <a href='#{prevImageId}' class='next'><i class='fa-solid fa-arrow-left'></i></a>");
                    lightboxHtml.AppendLine($"    <img src='{imageUrl}' alt='' />");
                    lightboxHtml.AppendLine($"    <a href='#{nextImageId}' class='next'><i class='fa-solid fa-arrow-right'></i></a>");
                    lightboxHtml.AppendLine($"    <a href='#' class='close'>X</a>");
                    lightboxHtml.AppendLine("</article>");
                }
                else
                {
                    string videoId = "archivo" + (i + 1);
                    string prevVideoId = "archivo" + (i == 0 ? urlArchivos.Count : i);
                    string nextVideoId = "archivo" + (i == urlArchivos.Count - 1 ? 1 : i + 2);
                    string videoUrl = urlArchivos[i];

                    lightboxHtml.AppendLine("<article class='light-box' id='" + videoId + "'>");
                    lightboxHtml.AppendLine($"    <a href='#{prevVideoId}' class='next'><i class='fa-solid fa-arrow-left'></i></a>");
                    lightboxHtml.AppendLine($"    <video controls>");
                    lightboxHtml.AppendLine($"        <source src='{videoUrl}' type='video/mp4'>");
                    lightboxHtml.AppendLine($"        Your browser does not support the video tag.");
                    lightboxHtml.AppendLine($"    </video>");
                    lightboxHtml.AppendLine($"    <a href='#{nextVideoId}' class='next'><i class='fa-solid fa-arrow-right'></i></a>");
                    lightboxHtml.AppendLine($"    <a href='#' class='close'>X</a>");
                    lightboxHtml.AppendLine("</article>");
                }
            }

            lightboxContainer.InnerHtml = lightboxHtml.ToString();
        }
        private void CargarLabels(Entidades.Bebe bebe)
        {
            DateTime temp = bebe.FecNac;

            //Asginamos datos del bebe al label
            lblNombre.Text = bebe.Nombre + " " + bebe.Apellidos;

            //Calculamos edad;                
            TimeSpan diferencia = DateTime.Now - temp;
            int anios = diferencia.Days / 365;
            int meses = diferencia.Days % 365 / 30;
            int dias = diferencia.Days % 365 % 30;
            //Mostramos la edad
            lblEdad.Text = anios.ToString() + " años y " + meses.ToString() + " meses";
        }
    }
}