using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class Ultrasonidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];

                if (credenciales == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                if(credenciales.Rol == "Padre" || credenciales.Rol == "Madre")
                {
                    btnmodal.Visible = true;
                }
                else
                {
                    btnmodal.Visible = false;
                }
                //Cargar los cards en la pantalla

                Negocios.Neg_Ultrasonidos iUltrasonidos = new Negocios.Neg_Ultrasonidos();

                //iddelbebe
                string idbebe = credenciales.IdenBebe;

                DataTable dtEtapas = iUltrasonidos.Obtener_Ultrasonidos(idbebe);

                System.Text.StringBuilder strListaProductos = new System.Text.StringBuilder();

                foreach (DataRow drEtapas in dtEtapas.Rows)
                {
                    //Formatear la fecha 
                    DateTime fechaObj = Convert.ToDateTime(drEtapas["Fecha"]);
                    string fechaFormateada = fechaObj.ToString("dd/MM/yyyy");
                    //Convertir la imagen para que se muestre
                    byte[] imageBytes = (byte[])drEtapas["Imagen"];
                    string base64Image = Convert.ToBase64String(imageBytes);

                    // Cargar los elementos del card
                    strListaProductos.Append("<div class=\"card\">");
                    strListaProductos.Append("<div><img src=\"data:image/jpg;base64,").Append(base64Image).Append("\" /></div>");//Imagen del ultrasonido
                    strListaProductos.Append("<h5>").Append(fechaFormateada).Append("</h5>");//Fecha
                    strListaProductos.Append("<p>").Append(Convert.ToString(drEtapas["Descripcion"])).Append("</p>");//descipcion
                    strListaProductos.Append("<a href=\"eliminarultrasonido.aspx?IDultrasonido=" + drEtapas["idUltrasonido"] + "\">");
                    strListaProductos.Append("<i class=\"fa-solid fa-x eliminar\" style=\"color: #ff0000;\"></i>");
                    strListaProductos.Append("</a>");
                    strListaProductos.Append("</div>");
                }

                //Agrega el código HTML a la página web para mostrar las cartas
                this.lstfrmMantenimiento.InnerHtml = strListaProductos.ToString();
            }
        }

        protected void btnAgrefarUltrasonido_Click(object sender, EventArgs e)
        {
            string script = null;
            //Metodo para guardar la imagen en sql
            //Obtener la fecha del ultasonido
            string fecha = txtdia.Text;
            //Obtener la descripcion del ultrasoniod
            string descip = txtdescrip.Text;
            //Obtener la imagen del ultrasonido
            int tamanio = file.PostedFile.ContentLength;

            string extension = System.IO.Path.GetExtension(file.FileName);
            //Inicio de validaciones

            if (fecha == "")
            {
                script =
                    "toastr.options.closeButton = true;" +
                    "toastr.options.positionClass = 'toast-bottom-right';" +
                    "toastr.error('Debe de ingresar una fecha');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (descip == "")
            {
                script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe de ingresar una descripción');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (tamanio <= 0)
            {
                script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe de escoger una imagen');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else if (extension.ToLower() != ".jpg" || extension.ToLower() != ".png")
            {

                Entidades.En_Usuarios credenciales = (Entidades.En_Usuarios)Session["Credenciales"];

                Negocios.Neg_Ultrasonidos iUltrasonidos = new Negocios.Neg_Ultrasonidos();

                //Id del bebe que esta en la sesion
                int idbebe = Convert.ToInt32(credenciales.IdenBebe);

                DataTable cantidad = iUltrasonidos.Canidad_Ultrasonidos(idbebe);

                if (cantidad.Rows.Count > 0)
                {
                    DataRow row = cantidad.Rows[0];
                    int cantidadUltra = Convert.ToInt32(row[0]); // Primer columna

                    int cantidadTotalUltra = Convert.ToInt32(row[1]); // Primer columna


                    if (cantidadUltra >= cantidadTotalUltra)
                    {
                        script =
                     "toastr.options.closeButton = true;" +
                     "toastr.options.positionClass = 'toast-bottom-right';" +
                     "toastr.warning('Ya supero la cantidad de ultrasonidos que se puede subir');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
                    }
                    else
                    {
                        byte[] ImagenOriginal = new byte[tamanio];

                        file.PostedFile.InputStream.Read(ImagenOriginal, 0, tamanio);
                        Bitmap ImagenOriginalBinaria = new Bitmap(file.PostedFile.InputStream);

                        //Id del bebe que esta en la sesion

                        //string idbebe = credenciales.IdenBebe;

                        //Falta llamar la variable del bebe
                        iUltrasonidos.IngresarUltrasonidos(idbebe, ImagenOriginal, fecha, descip);

                        //Vaciar los campos
                        txtdescrip.Text = "";
                        txtdia.Text = "";
                        // Clear the data-img attribute
                        imgArea.Attributes["data-img"] = "";

                        // Remove any existing image elements inside the img-area
                        var imageElementt = imgArea.FindControl("imgElement") as System.Web.UI.HtmlControls.HtmlImage;
                        if (imageElementt != null)
                        {
                            imgArea.Controls.Remove(imageElementt);
                        }

                        Response.Redirect("Ultrasonidos.aspx");
                    }
                }
            }
            else
            {
                script =
                  "toastr.options.closeButton = true;" +
                  "toastr.options.positionClass = 'toast-bottom-right';" +
                  "toastr.error('Solo puede subir archivos jpg o png');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            //Vaciar los campos
            txtdescrip.Text = "";
            txtdia.Text = "";
            // Clear the data-img attribute
            imgArea.Attributes["data-img"] = "";

            // Remove any existing image elements inside the img-area
            var imageElement = imgArea.FindControl("imgElement") as System.Web.UI.HtmlControls.HtmlImage;
            if (imageElement != null)
            {
                imgArea.Controls.Remove(imageElement);
            }
        }

        protected void btncerrar_Click(object sender, EventArgs e)
        {
            txtdescrip.Text = "";
            txtdia.Text = "";
            // Clear the data-img attribute
            imgArea.Attributes["data-img"] = "";

            // Remove any existing image elements inside the img-area
            var imageElement = imgArea.FindControl("imgElement") as System.Web.UI.HtmlControls.HtmlImage;
            if (imageElement != null)
            {
                imgArea.Controls.Remove(imageElement);
            }
        }

        protected void modal_Click(object sender, EventArgs e)
        {
            string script = "$('#mymodal').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }

      
    }
}