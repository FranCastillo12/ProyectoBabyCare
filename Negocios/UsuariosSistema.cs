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
        public static void EliminarUsuario(int idUsuario)
        {
            try
            {
                string spName = "EliminarUsuario";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idUser", idUsuario)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo eliminar el usuario");
            }
        }
        public static void EditarUsuario(int idUsuario, string nombre, string apellido, string correo, string contra)
        {
            try
            {
                string spName = "ActualizarUsuario";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idUser", idUsuario),
                    new SqlParameter("@name", nombre),
                    new SqlParameter("@lastname", apellido),
                    new SqlParameter("@email", correo),
                    new SqlParameter("@password", contra)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo el usuario la vacuna");
            }
        }
    }
}
