using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Neg_Usuarios
    {
        public int VertificarCorreo(string correo)
        {
            try
            {
                string spName = "SP_VerificarCorreo";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@correo", correo),

            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                return iConexion.ExecuteSPWithScalar(spName, lstParametros);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegistroUsuarios(string nombre, string apellidos, string correo, string pass)
        {
            try
            {
                string spName = "SP_InsertarUsuarios";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@nombre", nombre),
                new SqlParameter("@apellidos", apellidos),
                new SqlParameter("@correo", correo),
                new SqlParameter("@contra", pass)
            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Entidades.En_Usuarios VerificarCredenciales(string user, string pass)
        {
            string spName = "SP_IniciarSesion";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@correo", user),
                new SqlParameter("@contra", pass)
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            DataTable dtDatos = iConexion.ExecuteSPWithDT(spName, lstParametros);
            Entidades.En_Usuarios iUsuarios = null;
            if (dtDatos != null && dtDatos.Rows.Count > 0)
            {
                iUsuarios = new Entidades.En_Usuarios()
                {
                    IdUsuario = Convert.ToInt32(dtDatos.Rows[0]["idUsuario"]),
                    IdenBebe = dtDatos.Rows[0]["idBebe"].ToString(),
                    Rol = dtDatos.Rows[0]["idRol"].ToString()
                };
            }
            return iUsuarios;

        }

        public DataTable DatosUsuario(int idusuario)
        {
            string spName = "SP_DatosUsuario";
            var lstParametros = new List<SqlParameter>()
            {
               new SqlParameter("@idUsuario", idusuario),

            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);

        }

        public DataTable Datosbebes(int idusuario)
        {
            string spName = "SP_Obtenerbebes";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@idUsuario", idusuario),

            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);

        }
        public DataTable ObtenerUsuarioRelacionados(string idbebe)
        {
            try
            {
                string SpName = "SP_ObteneUsuariosRelacionados";
                var lstParametros = new List<SqlParameter>()
                {
                     new SqlParameter("@idbebe", idbebe)
                };
                Datos.ConexionSQL Iconexion = new Datos.ConexionSQL();
                return Iconexion.ExecuteSPWithDT(SpName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerRoles()
        {
            try
            {
                string SpName = "SP_ObtenerRoles";
                var lstParametros = new List<SqlParameter>()
                {
                };
                Datos.ConexionSQL Iconexion = new Datos.ConexionSQL();
                return Iconexion.ExecuteSPWithDT(SpName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CambioRol(string idUsuario, string idrol)
        {
            try
            {
                string SpName = "SP_UpdateRol";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idusuario", idUsuario),
                    new SqlParameter("@idrol", idrol),

                };
                Datos.ConexionSQL Iconexion = new Datos.ConexionSQL();
                Iconexion.ExecuteSP(SpName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CambioDatos(int idUsuario, string correo, string nombre, string apellidos)
        {
            try
            {
                string SpName = "SP_ModificarDatosUsuario";
                var lstParametros = new List<SqlParameter>()
                {
                   new SqlParameter("@idUsuario", idUsuario),
                    new SqlParameter("@correo", correo),
                    new SqlParameter("@nombre", nombre),
                     new SqlParameter("@apellidos", apellidos)
                };
                Datos.ConexionSQL Iconexion = new Datos.ConexionSQL();
                Iconexion.ExecuteSP(SpName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerSessionbebe(string idbebe, int idusuario)
        {
            try
            {
                string SpName = "SP_Rol";
                var lstParametros = new List<SqlParameter>()
                {
                      new SqlParameter("@idBebe", idbebe),
                      new SqlParameter("@idUsuario", idusuario)
                };
                Datos.ConexionSQL Iconexion = new Datos.ConexionSQL();
                return Iconexion.ExecuteSPWithDT(SpName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable CantidadFam(string idbebe, string idrol)
        {
            try
            {
                string SpName = "SP_ObtenerCantidadFami";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idbebe", idbebe),
                    new SqlParameter("@idrol", idrol),

                };
                Datos.ConexionSQL Iconexion = new Datos.ConexionSQL();
                return Iconexion.ExecuteSPWithDT(SpName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






        #region "admin"

        public DataTable VerificarCredencialesAdmin(string user, string pass)
        {
            string spName = "SP_InicioSesionAdmin";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@correo", user),
                new SqlParameter("@contra", pass)
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);
        }
        #endregion
    }
}
