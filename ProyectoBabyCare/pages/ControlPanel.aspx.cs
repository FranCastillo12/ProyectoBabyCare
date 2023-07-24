using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocios;
namespace ProyectoBabyCare.pages
{
    public partial class ControlPanel : System.Web.UI.Page
    {               
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    string correo = "";
                    string idbebe = "";
                    string rol = "";
                    string nombreBebe = "";
                    string apellidosBebe = "";

                    En_Usuarios credenciales = (En_Usuarios)Session["Credenciales"];
                    Entidades.Bebe bebe = (Entidades.Bebe)Session["DatosBebe"];

                    if (credenciales != null && bebe !=null)
                    {
                        correo = credenciales.Usuario;
                        idbebe = credenciales.IdenBebe;
                        rol = credenciales.Rol;
                        nombreBebe = bebe.Nombre;
                        apellidosBebe = bebe.Apellidos;
                    }
                    else 
                    {
                        throw new Exception("No se pudo cargar la información");
                    }

                    Negocios.Consejos nConsejos = new Negocios.Consejos();

                    List<Entidades.Consejos> consejos = new List<Entidades.Consejos>();
                    consejos = nConsejos.Obtenerconsejos();

                    Random r = new Random();

                    int consejoAleatorio = r.Next(0, consejos.Count);

                    //Asignamos consejo
                    lblConsejo.Text = consejos[consejoAleatorio].Descripcion.ToString();

                    //Asginamos datos del bebe
                    lblNombre.Text = nombreBebe + apellidosBebe;

                    //Calculamos edad;
                    TimeSpan diferencia = DateTime.Now - bebe.FecNac;
                    int anios = diferencia.Days / 365;
                    int meses = diferencia.Days % 365 / 30;
                    int dias = diferencia.Days % 365 % 30;
                    //Asignamos la edad
                    lblEdad.Text = anios.ToString() + " años, " + meses.ToString() + " meses y " + dias.ToString() +" días";

                    switch (rol)
                    {
                        case "2":
                            lblPerfil.Text = "Perfil de Madre";
                            break;
                        case "3":
                            lblPerfil.Text = "Perfil de Padre";
                            break;
                        case "4":
                            lblPerfil.Text = "Perfil de abuelo";
                            break;
                        case "5":
                            lblPerfil.Text = "Perfil de babySister";
                            break;
                        case "6":
                            lblPerfil.Text = "Perfil normal";
                            break;
                        default:
                            lblPerfil.Text = "Perfil indefinido";
                            break;
                    }
                
                    List<Citas> listaCitas = Negocios.ControlPanel.ListaCitas(6);
                    List<Alertas> listaAlertas = Negocios.ControlPanel.ListaAlertas(6);
                    List<Seguimientos> listaSeguimientos = Negocios.ControlPanel.ListaSeguimiento(6);
                    List<Vacunas> listaVacunas = Negocios.ControlPanel.ListaVacunas(6);                

                    int cantidadCitas, cantidadAlertas, cantidadVacunas, cantidadSeguimientos;

                    cantidadCitas = listaCitas.Count;cantidadVacunas = listaVacunas.Count;
                    cantidadAlertas = listaAlertas.Count;cantidadSeguimientos = listaSeguimientos.Count;

                    if (rol == "2" || rol == "3") //Usuarios padre y madre
                    {
                        SinNotificaciones1();
                        string cadena;
                        if (cantidadVacunas > 0)
                        {
                            lblNotificacion1.Text = "La ultima vacuna fue el " + listaVacunas[cantidadVacunas - 1].Fecha.ToString();
                        }
                        if (cantidadCitas > 0)
                        {
                            lblNotificacion2.Text = "Se tiene una cita de " + listaCitas[cantidadCitas - 1].Titulo.ToString() + " en " + listaCitas[cantidadCitas - 1].Lugar.ToString() +
                                " el día " + listaCitas[cantidadCitas - 1].Fecha;
                        }
                        if (cantidadCitas > 1)
                        { 
                            lblNotificacion3.Text = "Se tiene una cita de " + listaCitas[cantidadCitas - 2].Titulo.ToString() + " en " + listaCitas[cantidadCitas - 2].Lugar.ToString() +
                                " el día " + listaCitas[cantidadCitas - 2].Fecha;
                        }
                        if (cantidadAlertas > 0)
                        {                        
                            cadena = "Alerta siguiente: " + listaAlertas[cantidadAlertas - 1].Descripcion +
                                "\nHora: " + listaAlertas[cantidadAlertas - 1].HoraAlerta +
                                "\nCategoria: " + listaAlertas[cantidadAlertas - 1].Categoria;
                            lblNotificacion4.Text = cadena;
                        }
                        if (cantidadAlertas > 1)
                        {
                            cadena = "Otra alerta: " + listaAlertas[cantidadAlertas - 2].Descripcion +
                                "\nHora: " + listaAlertas[cantidadAlertas - 2].HoraAlerta +
                                "\nCategoria: " + listaAlertas[cantidadAlertas - 2].Categoria;
                            lblNotificacion5.Text = cadena;
                        }
                        if (cantidadSeguimientos > 0)
                        {                        
                            cadena = "Actividad del bebe\n" + listaSeguimientos[cantidadSeguimientos - 1].Descripcion +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 1].Fecha.ToString() +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 1].Categoria.ToString();
                            lblNotificacion6.Text = cadena;
                        }                    
                    }
                    else //Usuarios normales
                    {
                        string cadena;
                        if (cantidadAlertas > 0)
                        {                        
                            cadena = "Alerta siguiente: " + listaAlertas[cantidadAlertas - 1].Descripcion +
                                "\nHora: " + listaAlertas[cantidadAlertas - 1].HoraAlerta +
                                "\nCategoria: " + listaAlertas[cantidadAlertas - 1].Categoria;
                            lblNotificacion1.Text = cadena;
                        }
                        if (cantidadAlertas > 1)
                        {                        
                            cadena = "Alerta : " + listaAlertas[cantidadAlertas - 2].Descripcion +
                                "\nHora: " + listaAlertas[cantidadAlertas - 2].HoraAlerta +
                                "\nCategoria: " + listaAlertas[cantidadAlertas - 2].Categoria;
                            lblNotificacion2.Text = cadena;
                        }
                        if (cantidadAlertas > 2)
                        {                        
                            cadena = "Alerta : " + listaAlertas[cantidadAlertas - 3].Descripcion +
                                "\nHora: " + listaAlertas[cantidadAlertas - 3].HoraAlerta +
                                "\nCategoria: " + listaAlertas[cantidadAlertas - 3].Categoria;
                            lblNotificacion3.Text = cadena;
                        }

                        if (cantidadSeguimientos > 0)
                        {                        
                            cadena = "Actividad del bebe\n" + listaSeguimientos[cantidadSeguimientos - 1].Descripcion +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 1].Fecha.ToString() +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 1].Categoria.ToString();
                            lblNotificacion4.Text = cadena;
                        }
                        if (cantidadSeguimientos > 1)
                        {
                            cadena = "Actividad del bebe\n" + listaSeguimientos[cantidadSeguimientos - 2].Descripcion +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 2].Fecha.ToString() +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 2].Categoria.ToString();
                            lblNotificacion5.Text = cadena;
                        }
                        if (cantidadSeguimientos > 2)
                        {           
                            cadena = "Actividad del bebe\n" + listaSeguimientos[cantidadSeguimientos - 3].Descripcion +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 3].Fecha.ToString() +
                                "\n" + listaSeguimientos[cantidadSeguimientos - 3].Categoria.ToString();
                            lblNotificacion6.Text = cadena;
                        }
                    }
                }
                catch (Exception exc)
                {
                    lblNotificacion1.Text = "Ocurrió un error, "+ exc.Message;
                }
            }
        }
        private void SinNotificaciones1() //Usuarios padre y madre
        {
            lblNotificacion1.Text = "No hay vacunas registradas";
            lblNotificacion2.Text = "No hay citas registradas";
            lblNotificacion3.Text = "No hay citas registradas";
            lblNotificacion4.Text = "No hay alertas registradas";
            lblNotificacion5.Text = "No hay alertas registradas";
            lblNotificacion6.Text = "No hay notas de seguimiento";
        }
        private void SinNotificaciones2() //Usuarios normales
        {
            lblNotificacion1.Text = "No hay Alertas para mostrar";
            lblNotificacion2.Text = "No hay Alertas para mostrar";
            lblNotificacion3.Text = "No hay Alertas para mostrar";
            lblNotificacion4.Text = "No hay notas de seguimiento";
            lblNotificacion5.Text = "No hay notas de seguimiento";
            lblNotificacion6.Text = "No hay notas de seguimiento";
        }
    }
}