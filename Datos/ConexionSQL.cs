using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace Datos
{
   public class ConexionSQL
    {

        public SqlConnection sqlConn;

        public ConexionSQL()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionSQL"].ConnectionString);
        }

        #region "Manejo de constultas SQL"
        public void QueryDB(string QuerySQL)
        {
            try
            {
                // Se indica la consulta que se desea realizar
                SqlCommand cmd = new SqlCommand(QuerySQL)
                {
                    Connection = this.sqlConn
                };
                // Se abre conexion con la base de datos
                sqlConn.Open();

                // Ejecuta la consulta de la base de datos
                cmd.ExecuteNonQuery();

                // Se cierra la conexion
                sqlConn.Close();
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Devuelve un datatable
        public DataTable QueryDBWithDT(string QuerySQL)
        {
            try
            {
                // Indica la consulta que se desea hacer
                SqlCommand cmd = new SqlCommand(QuerySQL);
                cmd.Connection = this.sqlConn;


                // Objeeto para ejecutar la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                // Objeto para almacenar la informacion
                DataTable dtDatos = new DataTable();

                // Ejecuta la consulta
                adapter.Fill(dtDatos);

                return dtDatos;
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region "Manejo de Procedimientos Almacenados"

        public void ExecuteSP(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SPName,
                    Connection = this.sqlConn
                };

                foreach (SqlParameter sqlParam in ListaParametros)
                    cmd.Parameters.Add(sqlParam);


                sqlConn.Open();

                cmd.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet ExecuteSPWithDS(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = SPName,
                    Connection = this.sqlConn
                };
                foreach (SqlParameter sqlParam in ListaParametros)
                    cmd.Parameters.Add(sqlParam);

                // Objeeto para ejecutar la consulta
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);


                DataSet dsDatos = new DataSet();

                // Ejecuta la consulta
                adapter.Fill(dsDatos);

                return dsDatos;
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable ExecuteSPWithDT(string SPName, List<SqlParameter> ListaParametros)
        {
            try
            {
                SqlCommand cmd = new SqlCommand()
                {
                    CommandText = SPName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = this.sqlConn
                };

                if (ListaParametros != null && ListaParametros.Count > 0)
                    cmd.Parameters.AddRange(ListaParametros.ToArray());

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtDatos = new DataTable();
                // Ejecuta la consulta
                adapter.Fill(dtDatos);

                return dtDatos;
            }
            catch (SqlException sql)
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
                throw sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  Sebas
        public List<NombresBebes> TraerNombres(string letra, int numgenero)
        {
            List<NombresBebes> lstNombres = new List<NombresBebes>();
            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("BuscarNombresPorLetra", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@letra", letra);
                command.Parameters.AddWithValue("@Sexo", numgenero);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombre = reader["Nombre"].ToString();
                        string significado = reader["Significado"].ToString();
                        string genero = reader["idgenero"].ToString();
                        info += $"{nombre},{significado},{genero};";

                    }
                }
                sqlConn.Close();
                //Convertir la informacion
                string[] data1 = info.Split(';');
                foreach (string s in data1)
                {
                    string[] atrib = s.Split(',');
                    NombresBebes bebe = new NombresBebes();
                    bebe.Nombre1 = atrib[0];
                    bebe.Significado1 = atrib[1];
                    if (atrib[2] == "1")
                    {
                        bebe.Genero1 = "Niño";
                    }
                    else
                    {
                        bebe.Genero1 = "Niña";
                    }
                    lstNombres.Add(bebe);
                }

            }
            catch (Exception e)
            {

            }


            return lstNombres;
        }

        public List<Consejos> Consejos()
        {
            List<Consejos> lstConsejos = new List<Consejos>();
            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("TraerConsejos", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string titulo = reader["Titulo"].ToString();
                        string descripcion = reader["Descripcion"].ToString();

                        info += $"{titulo},{descripcion};";

                    }
                }
                sqlConn.Close();
                //Convertir la informacion
                string[] data1 = info.Split(';');
                foreach (string s in data1)
                {
                    string[] atrib = s.Split(',');
                    Entidades.Consejos consejos = new Entidades.Consejos();
                    //Continuacion del metodo
                    consejos.Titulo = atrib[0];
                    consejos.Descripcion = atrib[1];

                    lstConsejos.Add(consejos);
                }

            }
            catch (Exception e)
            {

            }


            return lstConsejos;
        }

        #endregion
    }
}
