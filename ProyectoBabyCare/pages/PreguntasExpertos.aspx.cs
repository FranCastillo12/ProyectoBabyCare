using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Negocios.Neg_Preguntas;
namespace ProyectoBabyCare.pages
{
    public partial class PreguntasExpertos : System.Web.UI.Page
    {
        int idBebe = 0;
        public static string _EndPoint = "https://api.openai.com/";
        public static string _URI = "v1/chat/completions";
        //Falta la llave
        public static string _APIKey = "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";
        protected void Page_Load(object sender, EventArgs e)
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
        }

        protected void btnPreguntar_Click(object sender, EventArgs e)
        {
            string script = "";
            //Obtener la pregunta
            string pregunta = txtpregunta.Text;

            if (pregunta == "")
            {
                script =
                        "toastr.options.closeButton = true;" +
                        "toastr.options.positionClass = 'toast-bottom-right';" +
                        "toastr.error('Debe de ingresar una pregunta');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
            else
            {
                Negocios.Neg_Preguntas iPreguntas = new Negocios.Neg_Preguntas();


                DataTable dtpreguntas = iPreguntas.Obtener_Respuesta(pregunta);

                if (dtpreguntas.Rows.Count > 0)
                {

                    foreach (DataRow drPreguntas in dtpreguntas.Rows)
                    {
                        txtrespuesta.Text = drPreguntas["respuesta"].ToString();

                    }
                }
                else
                {
                    //Llamar metodos para el uso de chatgpt
                    ChatGpt(pregunta);
                    iPreguntas.AgregarPregunta(pregunta, txtrespuesta.Text);
                }
            }
        }


        protected void ChatGpt(string pregunta)
        {
            //var pSolicitud = txtSolicitud.Text;

            var strRespuesta = "";

            // Consumir la API
            var oCliente = new RestClient(_EndPoint);
            var oSolicitud = new RestRequest(_URI, Method.Post);
            oSolicitud.AddHeader("Content-Type", "application/json");
            oSolicitud.AddHeader("Authorization", "Bearer " + _APIKey);


            // Creamos el cuerpo de la solicitud
            var oCuerpo = new Request()
            {
                model = "gpt-3.5-turbo",
                messages = new List<Negocios.Neg_Preguntas.Message>()
            {
                new Negocios.Neg_Preguntas.Message() {
                    role="user",
                    content=pregunta
                }
            }
            };

            var jsonString = JsonConvert.SerializeObject(oCuerpo);

            oSolicitud.AddJsonBody(jsonString);
            try
            {
                var oRespuesta = oCliente.Post<Response>(oSolicitud);
                strRespuesta = oRespuesta.choices[0].message.content;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // Asignar la respuesta a un control en la página, como un Label
            txtrespuesta.Text = strRespuesta;


        }
    }
}