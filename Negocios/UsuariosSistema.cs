using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public static class UsuariosSistema
    {
        public static DataTable ListaUsuariosSistema()
        {
            try
            {                
                string spName = "VerUsuariosSistema";              

                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable lista = iConexion.ExecuteSPWithDT(spName, null);
                return lista;
            }
            catch (Exception exc)
            {
                throw new Exception("No se pudieron cargar los usuarios del sistema");
            }
        }
    }
}
