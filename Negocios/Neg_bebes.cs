using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Neg_bebes
    {
        public void Registrarbebe(string nombre, string apellidos, string fechanacimiento)
        {
            try
            {
                string spName = "";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellidos", apellidos),
                new SqlParameter("@fechanacimiento", fechanacimiento),
            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
