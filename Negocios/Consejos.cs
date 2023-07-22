using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Consejos
    {
        public List<Entidades.Consejos> Obtenerconsejos(){ 
            List<Entidades.Consejos> consejos = new List<Entidades.Consejos>(); 
            ConexionSQL con = new ConexionSQL();
            consejos=con.Consejos();
            return consejos;
            
        }
    }
}
