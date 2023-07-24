using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class SeguimientoActividades
    {
        public List<Entidades.Categorias> Categorias()
        {
            ConexionSQL conexionSQL = new ConexionSQL();
            List<Entidades.Categorias> lista = conexionSQL.TraerCategorias();
            return lista;
        }
        public void InsertarSeguimiento(int idcategoria,int idbebe,string fecha,string descripcion) { 
            ConexionSQL con=new ConexionSQL();
            con.InsertarSeguimientoActividad(idcategoria,idbebe,descripcion,fecha);
        }

    }
}
