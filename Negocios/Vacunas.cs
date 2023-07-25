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
                            Nombre = fila[0].ToString(),
                            Descripcion = fila[1].ToString(),
                            Fecha = Convert.ToDateTime(fila[2].ToString())
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
    }
}
