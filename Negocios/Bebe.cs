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
    public static class Bebe
    {
        public static Entidades.Bebe bebe(string idBebe) 
        {
            try
            {
                List<Entidades.Bebe> bebes = new List<Entidades.Bebe>();
                string spName = "VerBebe";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idBebe", idBebe),
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtBebe = iConexion.ExecuteSPWithDT(spName, lstParametros);

                if (dtBebe != null && dtBebe.Rows.Count >= 0)
                {
                    foreach (DataRow fila in dtBebe.Rows)
                    {
                        Entidades.Bebe bebe = new Entidades.Bebe
                        {
                            Nombre = fila[0].ToString(),
                            Apellidos = fila[1].ToString(),
                            FecNac = Convert.ToDateTime(fila[2].ToString()),
                            FechaReg = Convert.ToDateTime(fila[3].ToString()),
                        };

                        return bebe;
                    }
                }
                throw new Exception("No se pudo encontrar el bebe");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
