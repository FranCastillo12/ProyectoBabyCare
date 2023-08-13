using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Neg_Ultrasonidos
    {
        public void IngresarUltrasonidos(string idbebe, byte[] imagen, string fecha, string des)
        {
            try
            {
                string spName = "SP_AgregarUltrasonidos";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@idbebe", idbebe),
                new SqlParameter("@imagen",imagen),
                new SqlParameter("@fecha", fecha),
                new SqlParameter("@descrip", des)
            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Obtener_Ultrasonidos(string idbebe)
        {
            string spName = "SP_ObtenerUltrasonidos";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@idbebe", idbebe),
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);
        }
        public void EliminarUltrasonido(int idUltrasonido)
        {
            try
            {
                string spName = "SP_EliminarUltrasonido";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@idUltra", idUltrasonido)
            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Canidad_Ultrasonidos(int idbebe)
        {
            try
            {
                string spName = "SP_CantidadUltrasonidos";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@idbebe", idbebe)
            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                return iConexion.ExecuteSPWithScalar(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
