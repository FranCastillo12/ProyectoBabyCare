using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NombresSignificados
    {
        public List<NombresBebes> ObtenerNombres(string Letra,int genero) { 
            ConexionSQL conexionSQL = new ConexionSQL();
            List<NombresBebes> lista=conexionSQL.TraerNombres(Letra, genero);
            return lista;
        }
    }
}
