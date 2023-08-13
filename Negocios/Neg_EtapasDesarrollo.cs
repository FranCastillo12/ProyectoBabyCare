using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Neg_EtapasDesarrollo
    {
        #region"Parte de usuarios"
        public DataTable Obtener_EtapasDesarrollo()
        {
            string spName = "SP_ObtenerEtapas";
            var lstParametros = new List<SqlParameter>()
            {
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);

        }
        #endregion

        #region"Parte de gestor de bebes"
        public DataTable Obtener_EtapasDesarrolloSeleccionada(string idetapa)
        {
            string spName = "SP_ObtenerEtapaSeleccionada";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@idetapa", idetapa),
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);

        }
        public DataTable Obtener_Categorias()
        {
            string spName = "SP_CategoriaEtapas";
            var lstParametros = new List<SqlParameter>()
            {

            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);

        }

        public void InsertEtapa(int idcategoria, string des, string imagen, string link)
        {
            string spName = "SP_InsertarEtapa";
            var lstParametros = new List<SqlParameter>()
            {
                   new SqlParameter("@idcategoria", idcategoria),
                   new SqlParameter("@imagen", imagen),
                   new SqlParameter("@des", des),
                   new SqlParameter("@link", link),
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            iConexion.ExecuteSP(spName, lstParametros);

        }

        public void UpdateEtapa(int idetapa, int idcategoria, string des, string imagen, string link)
        {
            string spName = "SP_UpdateEtapa";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@idetapa", idetapa),
                   new SqlParameter("@idcategoria", idcategoria),
                   new SqlParameter("@imagen", imagen),
                   new SqlParameter("@des", des),
                   new SqlParameter("@link", link),
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            iConexion.ExecuteSP(spName, lstParametros);
        }
        public void DeleteEtapa(int idetapa)
        {
            string spName = "SP_DeleteEtapa";
            var lstParametros = new List<SqlParameter>()
            {
                  new SqlParameter("@idetapa", idetapa)
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            iConexion.ExecuteSP(spName, lstParametros);

        }

        #endregion

    }
}
