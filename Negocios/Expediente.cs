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
    }
}
