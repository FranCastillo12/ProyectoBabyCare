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
        public Entidades.Expediente obtenerexpediente(string correo,int idbebe) {
            Entidades.Expediente Expediente=new Entidades.Expediente();
            ConexionSQL conexionSQL = new ConexionSQL();
            Expediente=conexionSQL.Expediente(correo,idbebe);

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
