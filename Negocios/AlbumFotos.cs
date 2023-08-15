using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class AlbumFotos
    {
        public List<Entidades.FotosBebe> TraerFotosBebe(int idbebe) {
            List<Entidades.FotosBebe> lst = new List<Entidades.FotosBebe>();
            ConexionSQL con= new ConexionSQL();
            lst = con.TraerFotosBebe(idbebe);
            return lst;

        }
        public List<Entidades.FotosBebe> FiltrarFotos(int idbebe,DateTime fecha1,DateTime fecha2)
        {
            List<Entidades.FotosBebe> lst = new List<Entidades.FotosBebe>();
            ConexionSQL con = new ConexionSQL();
            lst = con.FiltrarFotosBebe(idbebe, fecha1, fecha2);
            return lst;

        }


    }
}
