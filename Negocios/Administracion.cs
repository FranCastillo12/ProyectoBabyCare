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
    public static class Administracion
    {
        public static List<Entidades.UsuariosSistema> ListaUsuariosSistema()
        {
            try
            {
                List<Entidades.UsuariosSistema> usuarios = new List<Entidades.UsuariosSistema>();
                string spName = "CargarUsuarios";
                
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtUsuarios = iConexion.ExecuteSPWithDT(spName, null);

                if (dtUsuarios != null && dtUsuarios.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtUsuarios.Rows)
                    {
                        Entidades.UsuariosSistema u = new Entidades.UsuariosSistema
                        {
                            IdUsuario= Convert.ToInt32(fila[0].ToString()),
                            Nombre = fila[1].ToString(),
                            Apellidos = fila[2].ToString(),
                            FechaRegistro = Convert.ToDateTime(fila[3].ToString()),
                            Correo = fila[4].ToString(),
                            Contraseña = fila[5].ToString(),
                            BebesRegistrados = Convert.ToInt32(fila[6].ToString()),
                        };
                        usuarios.Add(u);
                    }
                }
                return usuarios;

            }
            catch (Exception)
            {
                throw new Exception("No se pudieron cargar los usuarios");
            }
        }
        public static void ActualizarUsuario(int idUsuario, string nombre, string apellidos, string correo, string contrasena)
        {
            try
            {
                string spName = "ActualizarUsuario";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idUser", idUsuario),
                    new SqlParameter("@name", nombre),
                    new SqlParameter("@lastname", apellidos),
                    new SqlParameter("@email", correo),
                    new SqlParameter("@password", contrasena)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo actualizar el usuario");
            }
        }
        public static void EliminarUsuario(int idUsuario)
        {
            try
            {
                string spName = "EliminarUsuario";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idVacuna", idUsuario)                    
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo borrar el usuario");
            }
        }
        public static List<Entidades.UsuariosBebes> ListaUsuarioBebe(int idUsuario)
        {
            try
            {
                List<Entidades.UsuariosBebes> lista = new List<Entidades.UsuariosBebes>();
                string spName = "CargarRelacionesUsuario";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idUser", idUsuario)                   
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtUsuarioBebe = iConexion.ExecuteSPWithDT(spName, lstParametros);

                if (dtUsuarioBebe != null && dtUsuarioBebe.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtUsuarioBebe.Rows)
                    {
                        Entidades.UsuariosBebes u = new Entidades.UsuariosBebes
                        {
                            IdUsuario = Convert.ToInt32(fila[0].ToString()),
                            Nombre = fila[1].ToString(),
                            Apellidos = fila[2].ToString(),
                            Idbebe = Convert.ToInt32(fila[3].ToString()),
                            NombreBebe = fila[4].ToString(),
                            IdRol = Convert.ToInt32(fila[5].ToString()),
                            Rol = fila[6].ToString(),
                            Encargado = Convert.ToBoolean(fila[7].ToString())
                        };
                        lista.Add(u);
                    }
                }
                return lista;

            }
            catch (Exception)
            {
                throw new Exception("No se pudieron cargar las relaciones del usuario");
            }
        }
        public static void ActualizarRelacionUsuarioBebe(int idUsuario, int idBebe, int idRol)
        {
            try
            {
                string spName = "ActualizarRelacionUsuarioBebe";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idUsuario", idUsuario),
                    new SqlParameter("@idBebe", idBebe),
                    new SqlParameter("@idRol", idRol)                    
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo actualizar la relacion");
            }
        }
        public static void EliminarRelacionUsuarioBebe(int idUsuario, int idBebe)
        {
            try
            {
                string spName = "EliminarRelacionUsuarioBebe";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idUser", idUsuario),
                    new SqlParameter("@idBebe", idBebe)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo eliminar la relacion");
            }
        }
        public static List<Entidades.Roles> ListaRoles()
        {
            try
            {
                List<Entidades.Roles> roles = new List<Entidades.Roles>();
                string spName = "VerRoles";

                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtRoles = iConexion.ExecuteSPWithDT(spName, null);

                if (dtRoles != null && dtRoles.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtRoles.Rows)
                    {
                        Entidades.Roles r = new Entidades.Roles
                        {
                            IdRol= Convert.ToInt32(fila[0].ToString()),
                            NombreRol = fila[1].ToString()
                        };
                        roles.Add(r);
                    }
                }
                return roles;

            }
            catch (Exception)
            {
                throw new Exception("No se pudieron cargar los roles");
            }
        }
    }
}
