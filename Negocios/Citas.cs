using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
namespace Negocios
{
    public static class Citas
    {
        public static List<Entidades.Citas> ListaCitas(int idBebe)
        {
            try
            {
                List<Entidades.Citas> citas = new List<Entidades.Citas>();
                string spName = "VerCitas";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idBebe", idBebe),
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtCitas = iConexion.ExecuteSPWithDT(spName, lstParametros);

                if (dtCitas != null && dtCitas.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtCitas.Rows)
                    {
                        Entidades.Citas c = new Entidades.Citas
                        {
                            IdCita = Convert.ToInt16(fila[0].ToString()),
                            Lugar = fila[1].ToString(),
                            Titulo = fila[2].ToString(),
                            Fecha = Convert.ToDateTime(fila[3].ToString())
                        };

                        citas.Add(c);
                    }
                }
                return citas;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void EditarCita(int idCita, string lugar, string titulo, DateTime fecha)
        {
            try
            {
                string spName = "EditarCita";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idCita", idCita),
                    new SqlParameter("@Lugar", lugar),
                    new SqlParameter("@Titulo", titulo),
                    new SqlParameter("@Fecha", fecha),
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception exc)
            {
                throw new Exception("No se pudo editar la cita");
            }            
        }
        public static void NuevaCita(int idBebe, string lugar, string titulo, DateTime fecha)
        {
            try
            {
                string spName = "NuevaCita";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idBebe", idBebe),
                    new SqlParameter("@Lugar", lugar),
                    new SqlParameter("@Titulo", titulo),
                    new SqlParameter("@Fecha", fecha),
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception exc)
            {
                throw new Exception("No se pudo crear la cita la cita");
            }
        }
        public static void BorrarCita(int idCita)
        {
            try
            {
                string spName = "BorrarCita";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idCita", idCita)                   
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception exc)
            {
                throw new Exception("No se pudo borrar la cita");
            }
        }
    }
}
