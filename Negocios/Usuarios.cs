using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Negocios
{
    public static class Usuarios
    {
        public static Entidades.Usuarios GetUsuarioById(int idUsuario)
        {
            try
            {
                string spName = "GetUsuarioById";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idUsuario", idUsuario),
                };

                ConexionSQL iConexion = new ConexionSQL();                
                DataTable dtUsuarios = iConexion.ExecuteSPWithDT(spName, lstParametros);
                
                if (dtUsuarios != null && dtUsuarios.Rows.Count > 0)
                {                    
                    DataRow fila = dtUsuarios.Rows[0];
                    Entidades.Usuarios usuario = new Entidades.Usuarios
                    {
                        IdUsuario = Convert.ToInt32(fila[0]),
                        Nombre = fila[1].ToString(),
                        Apellidos = fila[2].ToString(),
                        Correo = fila[3].ToString(),
                        Estado = Convert.ToInt32(fila[4]),
                        FechaRegistro = Convert.ToDateTime(fila[5])
                    };
                    return usuario;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }            
        }       
    }
}
