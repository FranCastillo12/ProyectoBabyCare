using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data.SqlClient;
using System.Data;

namespace Negocios
{
    public static class Dietas
    {
        public static List<Entidades.Dietas> listaDietasEdad(int idRangoEdad)
        {
            try
            {
                List<Entidades.Dietas> dietas = new List<Entidades.Dietas>();
                string spName = "VerDietasRango";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idRangoEdad", idRangoEdad),
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtDietas = iConexion.ExecuteSPWithDT(spName, lstParametros);

                if (dtDietas != null && dtDietas.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtDietas.Rows)
                    {
                        Entidades.Dietas d = new Entidades.Dietas
                        {
                            IdDieta = Convert.ToInt16(fila[0]),
                            NombreComida = fila[1].ToString(),
                            EdadInicio = Convert.ToInt16(fila[2].ToString()),
                            EdadFinal = Convert.ToInt16(fila[3].ToString()),
                            NombreDietaHorarioDieta = fila[4].ToString(),
                            HoraDieta = fila[5].ToString(),
                            TipoComida = fila[6].ToString()
                        };
                        dietas.Add(d);
                    }
                }
                return dietas;

            }
            catch (Exception)
            {
                throw new Exception("No se puieron cargar las dietas");
            }
        }
        public static List<Entidades.RangoEdadDietas> listaRangoDietas()
        {
            try
            {
                List<Entidades.RangoEdadDietas> rangos = new List<RangoEdadDietas>();
                string spName = "VerRangoDietas";                                
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtRangoDietas = iConexion.ExecuteSPWithDT(spName, null);

                if (dtRangoDietas != null && dtRangoDietas.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtRangoDietas.Rows)
                    {
                        Entidades.RangoEdadDietas red = new Entidades.RangoEdadDietas
                        {
                            IdRangoDietas = Convert.ToInt16(fila[0]),
                            EdadInicio = Convert.ToInt16(fila[1]),
                            EdadFinal = Convert.ToInt16(fila[2])
                        };
                        rangos.Add(red);
                    }
                }
                return rangos;
            }
            catch (Exception)
            {
                throw new Exception("No su pudieron cargar los rangos de edad para las dietas");
            }
        }
    }
}
