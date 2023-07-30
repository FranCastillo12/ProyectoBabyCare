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
    public static class Vacunas
    {
        public static List<Entidades.Vacunas> ListaVacunas(int idBebe)
        {
            try
            {
                List<Entidades.Vacunas> vacunas = new List<Entidades.Vacunas>();
                string spName = "VerVacunas";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idBebe", idBebe),
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtVacunas = iConexion.ExecuteSPWithDT(spName, lstParametros);

                if (dtVacunas != null && dtVacunas.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtVacunas.Rows)
                    {
                        Entidades.Vacunas v = new Entidades.Vacunas
                        {
                            IdVacuna = Convert.ToInt16(fila[0].ToString()),
                            Nombre = fila[1].ToString(),
                            Descripcion = fila[2].ToString(),
                            Fecha = Convert.ToDateTime(fila[3].ToString())
                        };

                        vacunas.Add(v);
                    }
                }
                return vacunas;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void AgregarVacuna(int idBebe, string nombre, string descripcion, DateTime fecha)
        {
            try
            {
                string spName = "AgregarVacuna";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idBebe", idBebe),
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@Descripcion", descripcion),
                    new SqlParameter("@Fecha", fecha)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            } catch (Exception)
            {
                throw new Exception("No se pudo agregar la vacuna");
            }
        }
        public static void EditarVacuna(int idVacuna,int idBebe, string nombre, string descripcion, DateTime fecha)
        {
            try
            {
                string spName = "EditarVacuna";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idVacuna", idVacuna),
                    new SqlParameter("@idBebe", idBebe),
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@Descripcion", descripcion),
                    new SqlParameter("@Fecha", fecha)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo editar la vacuna");
            }
        }
        public static void BorrarVacuna(int idVacuna, int idBebe)
        {
            try
            {
                string spName = "BorrarVacuna";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idVacuna", idVacuna),
                    new SqlParameter("@idBebe", idBebe)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo borrar la vacuna");
            }
        }
    }
}
