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
    public static class ControlPanel
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
                    foreach(DataRow fila in dtCitas.Rows)
                    {
                        Entidades.Citas c = new Entidades.Citas
                        {                            
                            Lugar = fila[1].ToString(),
                            Titulo = fila[2].ToString(),
                            Fecha= Convert.ToDateTime(fila[3])
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
        public static List<Entidades.Alertas> ListaAlertas(int idBebe)        
        {
            try
            {
                List<Alertas> alertas = new List<Alertas>();
                string spName = "VerAlertas";
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
                        Alertas a = new Alertas
                        {
                            HoraAlerta = fila[0].ToString(),
                            Descripcion = fila[1].ToString(),
                            Categoria = fila[2].ToString()
                        };
                        alertas.Add(a);
                    }
                }
                return alertas;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Entidades.Seguimientos> ListaSeguimiento(int idBebe)
        {
            try
            {
                List<Seguimientos> seguimientos = new List<Seguimientos>();
                string spName = "TraerSeguimientoActividadxFecha";
                DateTime fechaActual = DateTime.Now;
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idbebe", idBebe),
                    new SqlParameter("@idCategoria", "0"),
                    new SqlParameter("@Fecha", fechaActual)                    
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtSeguimiento = iConexion.ExecuteSPWithDT(spName, lstParametros);

                if (dtSeguimiento != null && dtSeguimiento.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtSeguimiento.Rows)
                    {
                        Seguimientos s = new Seguimientos
                        {
                            Categoria = fila[2].ToString(),
                            Descripcion = fila[3].ToString(),
                            Fecha = Convert.ToDateTime(fila[4].ToString())
                        };
                        seguimientos.Add(s);
                    }
                }
                return seguimientos;

            }
            catch (Exception)
            {
                throw;
            }
        }
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
    }
}
