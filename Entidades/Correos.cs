using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Entidades
{
    public class Correos
    {
        private string EmailBabyCare = "BabyCare.helpyourbaby@gmail.com";
        private string Contrasenia = "uyzlxrlifxoqovjo";
        public void EnviarCorreo(string NombreUsuario,string CorreoUsuario) {
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
        public void EnviarCorreoCodigobebe(string Nombrebebe, string CorreoUsuario,string codigobebe)
        {
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
                mensaje.Subject = $"Invitación especial: Conoce a nuestro precioso bebé {Nombrebebe}";

                string html = $"<!DOCTYPE html> <html> <head> </head> <body> <div> <div style=\"margin:auto;width:50%;\"> <label style=\"color:black\">Queremos compartir este momento de alegría contigo, y para ello, hemos preparado información encantadora sobre {Nombrebebe}. Aquí tienes el código para acceder:</labe> <br><br> <h2 style=\"text-align: center;\">{codigobebe}</h2> <button style=\"position: absolute; right: 500px;background-color: #FFC0CB; color: #fff; padding: 10px 20px; border: none; border-radius: 5px; cursor: pointer;\"><a style=\"text-decoration: none;color:black\" href=\"https://www.google.com\">Ir a Baby Care</a></button> </div> </div> </body> </html>";

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html,Encoding.UTF8, MediaTypeNames.Text.Html);
                mensaje.AlternateViews.Add(htmlView);

                //mensaje.Body = $"Estimado {NombreUsuario}, reciba una cordial bienvenida a nuestra aplicación de parte del equipo de desarrollo BabyCare,¡esperamos poder ser de ayuda en las actividades cotidianas de tu niño y que disfrute su instancia con nostros!";

                // Enviar el mensaje
                clienteSmtp.Send(mensaje);

                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }

        }
    }
}
