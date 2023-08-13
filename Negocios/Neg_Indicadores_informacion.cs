using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Neg_Indicadores_informacion
    {
        public DataTable Obtener_Indicadores_Informacion()
        {
            string spName = "SP_Indicadores_Informacion";
            var lstParametros = new List<SqlParameter>()
            {
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);

        }
    }
}
