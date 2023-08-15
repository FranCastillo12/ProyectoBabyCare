using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace ProyectoBabyCare.pages
{
    public partial class ControlPanel : System.Web.UI.Page
    {
        protected string ImageUrlsArray { get; set; }
        string correo = "";
        string idbebe = "27";
        string rol = "Padre";
        string nombreBebe = "Mateo";
        string apellidosBebe = "Jesus";
        DateTime temp = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];

                if (credenciales == null)
                {
                    Response.Redirect("../Login.aspx");
                }
                if (credenciales.IdenBebe == null || credenciales.IdenBebe == "")
                {
                    Response.Redirect("ControlPanel2.aspx");
                }
                else
                {
                   
                    //Llama al metodo para activar las alertas y mostrar mensaje
                    Negocios.AlertasUsuario alert = new Negocios.AlertasUsuario();
                    DateTime horaActual = DateTime.Now;
                    alert.ActivateAlertas(horaActual,Convert.ToInt32(credenciales.IdenBebe));
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
                    
                    idbebe = credenciales.IdenBebe;
                    GuardarDatosBebe(credenciales);
                    CargarRegistros();
                    BuscarRol();
                    GenerarConsejo(); //Generamos un consejo siempre que se carga la pagina
                    CargarFotos(credenciales);
                }
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-top-full-width';" +
                                $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        private void CargarRegistros()
        {
            try
            {
                List<Entidades.Citas> listaCitas = Negocios.ControlPanel.ListaCitas(Convert.ToInt16(idbebe));
                List<Entidades.Alertas> listaAlertas = Negocios.ControlPanel.ListaAlertas(Convert.ToInt16(idbebe));
                List<Seguimientos> listaSeguimientos = Negocios.ControlPanel.ListaSeguimiento(Convert.ToInt16(idbebe));
                List<Entidades.Vacunas> listaVacunas = Negocios.ControlPanel.ListaVacunas(Convert.ToInt16(idbebe));

                int cantidadCitas, cantidadAlertas, cantidadVacunas, cantidadSeguimientos;

                cantidadCitas = listaCitas.Count; cantidadVacunas = listaVacunas.Count;
                cantidadAlertas = listaAlertas.Count; cantidadSeguimientos = listaSeguimientos.Count;

                if (rol == "Padre" || rol == "Madre") //Usuarios padre y madre
                {
                    SinNotificaciones1();
                    string cadena;
                    if (cantidadVacunas > 0)
                    {
                        Entidades.Vacunas v = listaVacunas.First();

                        string dia = v.Fecha.ToString("dddd d 'de' MMMM 'de' yyyy");
                        string hora = v.Fecha.ToString(" ' a las ' hh:mm tt", CultureInfo.CreateSpecificCulture("en-us"));
                        cadena = "La ultima vacuna fue " + v.Nombre + " el día " + dia + hora;
                        lblNotificacion1.Text = cadena;
                    }
                    if (cantidadCitas > 0) //Cargamos datos sobre citas
                    {
                        //Citas futuras de prioridad alta
                        var citasPrioridadAlta = listaCitas.Where(c => c.Fecha > DateTime.Now && c.Prioridad == "Alta").ToList();

                        if (citasPrioridadAlta.Count > 0)
                        {
                            //La cita mas cercana
                            var citaProxima = citasPrioridadAlta.OrderBy(c => Math.Abs((c.Fecha - DateTime.Now).Ticks)).FirstOrDefault();

                            if (citaProxima != null)
                            {
                                string dia = citaProxima.Fecha.ToString("dddd d 'de' MMMM 'de' yyyy");
                                string hora = citaProxima.Fecha.ToString(" ' a las ' hh:mm tt", CultureInfo.CreateSpecificCulture("en-us"));
                                cadena = "La siguiente cita de prioridad alta es de " + citaProxima.Titulo + " el día " + dia + hora + " en " + citaProxima.Lugar;

                                lblNotificacion2.Text = cadena;
                            }
                        }
                        //lista de citas futuras
                        var citasFuturas = listaCitas.Where(c => c.Fecha > DateTime.Now).ToList();
                        if (citasFuturas.Count > 0)
                        {
                            //Cita mas proxima de cualquier prioridad
                            var citaProxima = citasFuturas.OrderBy(c => Math.Abs((c.Fecha - DateTime.Now).Ticks)).FirstOrDefault();

                            if (citaProxima != null)
                            {
                                string dia = citaProxima.Fecha.ToString("dddd d 'de' MMMM 'de' yyyy");
                                string hora = citaProxima.Fecha.ToString(" ' a las ' hh:mm tt", CultureInfo.CreateSpecificCulture("en-es"));
                                cadena = nombreBebe + " tiene una cita de " + citaProxima.Titulo + " el dia " + dia + hora + " en " + citaProxima.Lugar + " de prioridad " + citaProxima.Prioridad;

                                lblNotificacion3.Text = cadena;
                            }
                        }
                    }

                    if (cantidadAlertas > 0)
                    {
                        //Cargamos las alertas futuras
                        var AlertasFuturas = listaAlertas.Where(a => DateTime.Parse(a.HoraAlerta) > DateTime.Now).ToList();
                        if (AlertasFuturas.Count > 0)
                        {
                            //Cargamos la alerta siguiente
                            var alertaSiguiente = AlertasFuturas.OrderBy(a => Math.Abs((DateTime.Parse(a.HoraAlerta) - DateTime.Now).Ticks)).FirstOrDefault();
                            if (alertaSiguiente != null)
                            {
                                DateTime fechaHora = DateTime.Parse(alertaSiguiente.HoraAlerta);
                                string hora = fechaHora.ToString("hh:mm tt", CultureInfo.CreateSpecificCulture("en-es"));
                                cadena = $"Alerta({alertaSiguiente.Categoria})<br>Recuerda " + alertaSiguiente.Descripcion + " a las " + hora;
                                lblNotificacion4.Text = cadena;
                            }
                        }//Verificamos si hay mas de una alerta
                        if (AlertasFuturas.Count > 1)
                        {
                            //Cargamos la segunda alerta siguiente
                            var alertasSiguientes = AlertasFuturas.OrderBy(a => Math.Abs((DateTime.Parse(a.HoraAlerta) - DateTime.Now).Ticks)).ToList();
                            if (alertasSiguientes != null && alertasSiguientes.Count > 1)
                            {
                                var SegundaAlerta = alertasSiguientes.Skip(1).FirstOrDefault();
                                DateTime fechaHora = DateTime.Parse(SegundaAlerta.HoraAlerta);
                                string hora = fechaHora.ToString("hh:mm tt", CultureInfo.CreateSpecificCulture("en-es"));
                                cadena = $"Alerta({SegundaAlerta.Categoria})<br>Recuerda " + SegundaAlerta.Descripcion + " a las " + hora;
                                lblNotificacion5.Text = cadena;

                            }
                        }
                    }
                    if (cantidadSeguimientos > 0)
                    {
                        Random r = new Random();
                        int index = r.Next(0, cantidadSeguimientos - 1);
                        var seguimientoAleatorio = listaSeguimientos[index];
                        DateTime fecha = seguimientoAleatorio.Fecha;
                        string strfecha = fecha.ToString("dddd d ' de ' MMMM ' del 'yyyy");
                        cadena = seguimientoAleatorio.Descripcion + " el día " + strfecha;
                        lblNotificacion6.Text = cadena;
                    }
                }
                else //Usuarios normales
                {
                    string cadena;
                    SinNotificaciones2();

                    //Cargamos alertas
                    if (cantidadAlertas > 0)
                    {
                        //Cargamos las alertas futuras
                        var AlertasFuturas = listaAlertas.Where(a => DateTime.Parse(a.HoraAlerta) > DateTime.Now).ToList();
                        if (AlertasFuturas.Count > 0)
                        {
                            //Cargamos la alerta siguiente
                            var alertaSiguiente = AlertasFuturas.OrderBy(a => Math.Abs((DateTime.Parse(a.HoraAlerta) - DateTime.Now).Ticks)).FirstOrDefault();
                            if (alertaSiguiente != null)
                            {
                                DateTime fechaHora = DateTime.Parse(alertaSiguiente.HoraAlerta);
                                string hora = fechaHora.ToString("hh:mm tt", CultureInfo.CreateSpecificCulture("en-es"));
                                cadena = $"Alerta({alertaSiguiente.Categoria})<br>Recuerda " + alertaSiguiente.Descripcion + " a las " + hora;
                                lblNotificacion4.Text = cadena;
                            }
                        }//Verificamos si hay mas de una alerta
                        if (AlertasFuturas.Count > 1)
                        {
                            //Cargamos la segunda alerta siguiente
                            var alertasSiguientes = AlertasFuturas.OrderBy(a => Math.Abs((DateTime.Parse(a.HoraAlerta) - DateTime.Now).Ticks)).ToList();
                            if (alertasSiguientes != null && alertasSiguientes.Count > 1)
                            {
                                var SegundaAlerta = alertasSiguientes.Skip(1).FirstOrDefault();
                                DateTime fechaHora = DateTime.Parse(SegundaAlerta.HoraAlerta);
                                string hora = fechaHora.ToString("hh:mm tt", CultureInfo.CreateSpecificCulture("en-es"));
                                cadena = $"Alerta({SegundaAlerta.Categoria})<br>Recuerda " + SegundaAlerta.Descripcion + " a las " + hora;
                                lblNotificacion5.Text = cadena;
                            }
                        }
                    }
                    if (cantidadSeguimientos > 0)
                    {
                        Random r = new Random();
                        int index = r.Next(0, cantidadSeguimientos - 1);
                        var seguimientoAleatorio = listaSeguimientos[index];
                        DateTime fecha = seguimientoAleatorio.Fecha;
                        string strfecha = fecha.ToString("dddd d ' de ' MMMM ' del 'yyyy");
                        cadena = seguimientoAleatorio.Descripcion + " el día " + strfecha;
                        lblNotificacion6.Text = cadena;
                    }
                }
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                                "toastr.options.closeButton = true;" +
                                "toastr.options.positionClass = 'toast-top-full-width';" +
                                $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        private void BuscarRol()
        {
            switch (rol)
            {
                case "Padre":
                    lblPerfil.Text = "Perfil de Padre";
                    break;
                case "Madre":
                    lblPerfil.Text = "Perfil de Madre";
                    break;
                case "Abuelo":
                    lblPerfil.Text = "Perfil de Abuelo";
                    break;
                case "BabySister":
                    lblPerfil.Text = "Perfil de BabySister";
                    break;
                case "Normal":
                    lblPerfil.Text = "Perfil Normal";
                    break;
                case "Invitado":
                    lblPerfil.Text = "Perfil de invitado";
                    break;
                default:
                    lblPerfil.Text = "No tienes un rol aún";
                    break;
            }
        }
        private void GenerarConsejo()
        {
            try
            {

                Negocios.Consejos nConsejos = new Negocios.Consejos();

                List<Entidades.Consejos> consejos = new List<Entidades.Consejos>();
                consejos = nConsejos.Obtenerconsejos();

                Random r = new Random();

                int consejoAleatorio = r.Next(0, consejos.Count);

                //Asignamos consejo
                lblConsejo.Text = consejos[consejoAleatorio].Descripcion.ToString();
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                               "toastr.options.closeButton = true;" +
                               "toastr.options.positionClass = 'toast-top-full-width';" +
                               $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }

        }
        private void GuardarDatosBebe(En_Usuarios credenciales)
        {
            try
            {

                Entidades.Bebe bebe = Negocios.Bebe.bebe(credenciales.IdenBebe);

                correo = credenciales.Usuario;
                idbebe = credenciales.IdenBebe;
                rol = credenciales.Rol;
                nombreBebe = bebe.Nombre;
                apellidosBebe = bebe.Apellidos;
                temp = bebe.FecNac;

                //Asginamos datos del bebe al label
                lblNombre.Text = nombreBebe + " " + apellidosBebe;

                //Calculamos edad;                
                TimeSpan diferencia = DateTime.Now - temp;
                int anios = diferencia.Days / 365;
                int meses = diferencia.Days % 365 / 30;
                int dias = diferencia.Days % 365 % 30;
                //Mostramos la edad
                lblEdad.Text = anios.ToString() + " años, " + meses.ToString() + " meses y " + dias.ToString() + " días";
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                               "toastr.options.closeButton = true;" +
                               "toastr.options.positionClass = 'toast-top-full-width';" +
                               $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }
        }
        private void CargarFotos(En_Usuarios credenciales) 
        {        
            List<Entidades.Archivos> ListaArchivos = Negocios.Archivos.ListaArchivosBebe(Convert.ToInt32(credenciales.IdenBebe));           
            List<string> urlImagenes = new List<string>();
            if (ListaArchivos != null && ListaArchivos.Count > 0)
            {                
                foreach (var archivo in ListaArchivos)
                {
                    if (archivo.RutaArchivo.EndsWith("image"))
                    {
                        //fotoPerfi.ImageUrl = archivo.RutaArchivo;
                        urlImagenes.Add(archivo.RutaArchivo);
                    //    fotoBebes.ImageUrl = archivo.RutaArchivo;
                    }                   
                }
            }
            else
            {
                urlImagenes.Add("../images/bebe1.jpg");
                urlImagenes.Add("../images/bebe2.jpg");
                urlImagenes.Add("../images/bebe3.jpg");
                urlImagenes.Add("../images/bebe4.png");
                urlImagenes.Add("../images/bebe5.jpg");
                urlImagenes.Add("../images/bebe6.png");
            }
            // Convierte el arreglo de URLs en una cadena JSON
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ImageUrlsArray = serializer.Serialize(urlImagenes);
            
        }
        private void SinNotificaciones1() //Usuarios padre y madre
        {
            lblNotificacion1.Text = "No se tiene registrada la ultima vacuna de " + nombreBebe;
            lblNotificacion2.Text = "No hay citas de prioridad alta registradas";
            lblNotificacion3.Text = "No hay citas registradas para " + nombreBebe;
            lblNotificacion4.Text = "Puedes registrar alertas proximas para que te recordemos";
            lblNotificacion5.Text = "Las alertas te ayudan a recordar cosas importantes por hacer";
            lblNotificacion6.Text = "No hay notas de seguimiento registradas";
        }
        private void SinNotificaciones2() //Usuarios normales
        {

            lblNotificacion1.Text = "Gracias por formar parte de esta familia";
            lblNotificacion2.Text = "Cumples un rol muy importante en el desarrollo del bebé";
            lblNotificacion3.Text = $"Eres parte de la familia<br> Del lado derecho de este panel podrás ver notificaciones que te pueden interesar";
            lblNotificacion4.Text = "No hay alertas en este momento, parece que todo esta al dia :)";
            lblNotificacion5.Text = "Las alertas te ayudan a recordar cosas importantes por hacer";
            lblNotificacion6.Text = "No hay notas de seguimiento registradas";

            try
            {
                List<Entidades.ConsejosParientes> consejosParientes = Negocios.ControlPanel.ListaConsejosParientes(1);
                List<Entidades.ConsejosParientes> felicitacionesParientes = Negocios.ControlPanel.ListaConsejosParientes(2);

                Random r = new Random();
                int index = r.Next(0, consejosParientes.Count - 1);

                string consejo = consejosParientes[index].Descripcion;
                string felicitacion = felicitacionesParientes[index].Descripcion;

                lblNotificacion1.Text = consejo;
                lblNotificacion2.Text = felicitacion;
            }
            catch (Exception exc)
            {
                string mensaje = exc.Message;
                string script =
                               "toastr.options.closeButton = true;" +
                               "toastr.options.positionClass = 'toast-top-full-width';" +
                               $"toastr.error('{mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ToastrNotification", script, true);
            }

        }
    }
}