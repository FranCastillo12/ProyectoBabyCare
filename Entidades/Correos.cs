using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace Entidades
{
    public class Correos
    {
        private static string EmailBabyCare = "BabyCare.helpyourbaby@gmail.com";
        private static string Contrasenia = "uyzlxrlifxoqovjo";
        public void EnviarCorreo (string NombreUsuario,string CorreoUsuario) {
            try
            {
                // Datos del remitente


                // Datos del destinatario
                string destinatarioEmail = CorreoUsuario;

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(EmailBabyCare, Contrasenia);

                // Crear el mensaje
                MailMessage mensaje = new MailMessage(EmailBabyCare, destinatarioEmail);
                mensaje.Subject = "Correo de confirmación de registro";
                mensaje.Body = $"Estimado {NombreUsuario}, reciba una cordial bienvenida a nuestra aplicación de parte del equipo de desarrollo BabyCare,¡esperamos poder ser de ayuda en las actividades cotidianas de tu niño y que disfrute su instancia con nostros!";

                // Enviar el mensaje
                clienteSmtp.Send(mensaje);

                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
        public string EnviarToken( string correo)
        {
            try
            {
                Random r = new Random();
                int token = r.Next(999, 10000);
                string ContenidoMensaje ="¡Hola!"+"\n\nSe esta intentando acceder a su cuenta de BabyCare," +
                    " para completar el proceso ingrese el siguiente codigo:\n\n"+Convert.ToString(token) +
                    "\n\nSaludos.\nEquipo BabyCare.";


                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential(EmailBabyCare, Contrasenia);

                // Crear el mensaje
                MailMessage mensaje = new MailMessage(EmailBabyCare, correo);
                mensaje.Subject = "Correo de confirmación de registro";
                mensaje.Body = ContenidoMensaje;

                // Enviar el mensaje
                clienteSmtp.Send(mensaje);

                return Convert.ToString(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
