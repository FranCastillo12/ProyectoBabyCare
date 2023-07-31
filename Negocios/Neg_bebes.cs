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
        public void Registrarbebe(string nombre, string apellidos, string fechanacimiento, int idUsuario, string rol)
        {
            try
            {
                string spName = "SP_InsertarBebe";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellidos", apellidos),
                new SqlParameter("@fecha_nacimiento", fechanacimiento),
                new SqlParameter("@idUsuario", idUsuario),
                new SqlParameter("@rol", rol),

            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IngresarXcodigo(int idUsuario, string codigo)
        {
            try
            {
                string spName = "SP_unirseXcodigo";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@codigo", codigo),
                new SqlParameter("@idUsuario", idUsuario)
            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int VerificarCodigobebe(int idUsuario, string codigo)
        {
            try
            {
                string spName = "SP_Existenciabebe";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@codigo", codigo),
                new SqlParameter("@idUsuario", idUsuario)
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
