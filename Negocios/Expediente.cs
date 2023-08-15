using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Expediente
    {
        public void ModificarExpediente(int idexpediente, float peso, float estatura, string tiposangre, string cedula, int genero) { 
            ConexionSQL conexion = new ConexionSQL();
            conexion.ModificarExpediente(idexpediente, peso, estatura, tiposangre, cedula, genero);
        }
        public void IngresarExpediente(int idbebe, string cedula, int genero, float peso, float estatura, string tiposangre) { 
            ConexionSQL con=new ConexionSQL();
            con.IngresarDatosBasicosExpediente(idbebe,cedula,genero,peso,estatura,tiposangre);
        }
        public void IngresarDetalleExpediente(int idbebe, string descripcion, DateTime fecha)
        {
            ConexionSQL con = new ConexionSQL();
            con.InsertarDetalleExpediente(idbebe,descripcion,fecha);
        }
        public void IngresarPadecimiento(int idbebe, int idpadecimiento)
        {
            ConexionSQL con = new ConexionSQL();
            con.InsertarPadecimientoExpediente(idbebe,idpadecimiento);
        }
        public string ValidarExpediente(int idbebe) {
            string respuesta = "";
            ConexionSQL con=new ConexionSQL();
            respuesta=con.ValidarExpediente(idbebe);
            return respuesta;
        }
        public Entidades.Expediente obtenerexpediente(int idbebe) {
            Entidades.Expediente Expediente=new Entidades.Expediente();
            ConexionSQL conexionSQL = new ConexionSQL();
            Expediente=conexionSQL.Expediente(idbebe);

            return Expediente;
        }
        public List<Entidades.Padecimientos> TodoslosPadecimientos() { 
            List<Entidades.Padecimientos> lstpadecimiento=new List<Entidades.Padecimientos> ();
            ConexionSQL con=new ConexionSQL ();
            lstpadecimiento=con.Todoslospadecimientos();
            return lstpadecimiento;
        }
        public List<Entidades.Padecimientos> PadecimientosExpediente(int idexpediente)
        {
            List<Entidades.Padecimientos> lstpadecimiento = new List<Entidades.Padecimientos>();
            ConexionSQL con = new ConexionSQL();
            lstpadecimiento = con.PadecimientosExpediente(idexpediente);
            return lstpadecimiento;
        }
        public List<Entidades.Generos> TraerGeneros()
        {
            List<Entidades.Generos> lstpadecimiento = new List<Entidades.Generos>();
            ConexionSQL con = new ConexionSQL();
            lstpadecimiento = con.TraerGeneros();
            return lstpadecimiento;
        }

        public string[] Detalles(int idexpediente)
        {
            ConexionSQL con = new ConexionSQL();
            string[] lstdetalles = con.Detallesdelembarazo(idexpediente);
            return lstdetalles;
        }
        public string[] Vacunas(int idexpediente)
        {
            ConexionSQL con = new ConexionSQL();
            string[] lstvacunas = con.historialvacunas(idexpediente);
            return lstvacunas;
        }

    }
}
