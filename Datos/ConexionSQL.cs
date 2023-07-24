using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Entidades;

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


        #region expediente
        public string ValidarExpediente(int idbebe) {
            string respuesta = "No existe";
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("ExisteExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        respuesta = reader["respuesta"].ToString();
                    }
                }
                sqlConn.Close();
            }
            catch (Exception e){}
            return respuesta;
        }

        public void IngresarDatosBasicosExpediente(int idbebe,string cedula,int genero,float peso,float estatura,string tiposangre,DateTime fechanac) {
            sqlConn.Open();
            SqlCommand command = new SqlCommand("IngresarDatosBasicosExpediente", sqlConn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idbebe", idbebe);
            command.Parameters.AddWithValue("@cedula", cedula);
            command.Parameters.AddWithValue("@genero", genero);
            command.Parameters.AddWithValue("@peso", peso);
            command.Parameters.AddWithValue("@estatura", estatura);
            command.Parameters.AddWithValue("@tiposangre", tiposangre);
            command.Parameters.AddWithValue("@fecha", fechanac);
            command.ExecuteNonQuery();

            command.Clone();
        }
        public Entidades.Expediente Expediente(string correo,int idbebe)
        {
            Entidades.Expediente Expediente = new Entidades.Expediente();
            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("ObtenerDatosBasicosExpedienteBebe", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@correo", correo);
                command.Parameters.AddWithValue("@idbebe", idbebe);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string idexpediente = reader["idExpediente"].ToString();
                        string nombrebebe = reader["NombreBebe"].ToString();
                        string idbebe2 = reader["idBebe"].ToString();
                        string cedula = reader["Cedula"].ToString();
                        string nombrePadre = reader["NombrePadre"].ToString();
                        string nombreMadre = reader["NombreMadre"].ToString();
                        string peso = reader["Peso"].ToString();
                        string estatura = reader["Estatura"].ToString();
                        string tiposangre = reader["TipoSangre"].ToString();
                        string genero = reader["Genero"].ToString();
                        string fechanacimiento = reader["FechaNacimiento"].ToString();

                        info = $"{idexpediente}@{nombrebebe}@{idbebe2}@{cedula}@{nombrePadre}@{nombreMadre}@{peso}@{estatura}@{tiposangre}@{genero}@{fechanacimiento}";

                    }
                }
                sqlConn.Close();
                //Convertir la informacion
                string[] atrib = info.Split('@');
                Entidades.Expediente expediente = new Entidades.Expediente();
                //Continuacion del metodo
                expediente.Idexpediente = Convert.ToInt32(atrib[0]);
                expediente.Nombrebebe = atrib[1];
                expediente.Idbebe = Convert.ToInt32(atrib[2]);
                expediente.Cedula = atrib[3];
                expediente.NombrePadre = atrib[4];
                expediente.NombreMadre = atrib[5];
                expediente.Peso = float.Parse(atrib[6]);
                expediente.Estatura = float.Parse(atrib[7]);
                expediente.Tiposangre = atrib[8];
                if (atrib[9].Equals("1"))
                {
                    expediente.Genero = "Hombre";
                }
                else {
                    expediente.Genero = "Mujer";
                }
                
                expediente.Fechanacimiento = atrib[10];

                Expediente = expediente;
            }
            catch (Exception e)
            {

            }


            return Expediente;
        }
       
        public List<Entidades.Padecimientos> Todoslospadecimientos() { 
            List<Entidades.Padecimientos> padecimientos=new List<Padecimientos> ();

            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("TraerPadecimientos", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string idpadecimiento = reader["idPadecimiento"].ToString();
                        string nombrepadecimiento = reader["NombrePadecimiento"].ToString();

                        info += $"{idpadecimiento}@{nombrepadecimiento};";

                    }
                }
                sqlConn.Close();
                //Convertir la informacion
                string[] data = info.Split(';');
                foreach (string s in data) {
                    string[] atrib = s.Split('@');
                    Entidades.Padecimientos padecimientos1 = new Entidades.Padecimientos();
                    //Continuacion del metodo
                    padecimientos1.Nombrepadecimiento = atrib[1];
                    padecimientos1.IdPadecimiento = Convert.ToInt32(atrib[0]);


                    padecimientos.Add(padecimientos1);
                }
                
            }
            catch (Exception e)
            {

            }

            return padecimientos;
        }

        public List<Entidades.Padecimientos> PadecimientosExpediente(int idexpediente)
        {
            List<Entidades.Padecimientos> padecimientos = new List<Padecimientos>();

            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("TraerPadecimientosExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idexpediente", idexpediente);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string nombrepadecimiento = reader["NombrePadecimiento"].ToString();

                        info += $"{nombrepadecimiento};";

                    }
                }
                sqlConn.Close();
                //Convertir la informacion
                string[] data = info.Split(';');
                foreach (string s in data)
                {
                    if (!s.Equals("")) { 
                        Entidades.Padecimientos padecimientos1 = new Entidades.Padecimientos();
                        //Continuacion del metodo
                        padecimientos1.Nombrepadecimiento = s;
                        padecimientos.Add(padecimientos1);                    
                    }
                }

            }
            catch (Exception e)
            {

            }

            return padecimientos;
        }

        public string[] Detallesdelembarazo(int idexpediente)
        {
            string[] lstdetalles=null;
            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("TraerDetallesExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idExpediente", idexpediente);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Descripcion = reader["Descripcion"].ToString();
                        string Fecha = reader["Fecha"].ToString();

                        info += $"{Descripcion}@{Fecha};";

                    }
                }
                sqlConn.Close();
                lstdetalles = info.Split(';');

            }
            catch (Exception e){}

            return lstdetalles;
        }
        public string[] historialvacunas(int idexpediente)
        {
            string[] lstvacunas = null;
            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("TraerVacunasExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idexpediente", idexpediente);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Descripcion = reader["DescripcionVacuna"].ToString();
                        string Nombre = reader["NombreVacuna"].ToString();
                        string Fecha = reader["Fecha"].ToString();

                        info += $"{Nombre}@{Descripcion}@{Fecha};";

                    }
                }
                sqlConn.Close();
                lstvacunas = info.Split(';');

            }
            catch (Exception e) { }

            return lstvacunas;
        }
        #endregion

        #region NombresSignificados
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
        #endregion

        #region Consejos
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

        #region SeguimientoActividades
        public List<Entidades.Categorias> TraerCategorias() {
            List<Entidades.Categorias> lstcategorias = new List<Entidades.Categorias>();

            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("TraerCategorias", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["idCategoria"].ToString();
                        string des = reader["Descripcion"].ToString();
                        info += $"{id}@{des};";

                    }
                }
                sqlConn.Close();
                //Convertir la informacion
                string[] data1 = info.Split(';');
                foreach (string s in data1)
                {
                    string[] atrib = s.Split('@');
                    Entidades.Categorias categoria =new Entidades.Categorias();
                    categoria.Idcategorial = Convert.ToInt32(atrib[0]);
                    categoria.Nombre = atrib[1];
                    lstcategorias.Add(categoria);
                }

            }
            catch (Exception e)
            {

            }

            return lstcategorias;
        }

        public void InsertarSeguimientoActividad(int idcategoria,int idbebe,string Descripcion,DateTime Fecha) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("InsertarSeguimientoActividad", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                command.Parameters.AddWithValue("@idcategoria", idcategoria);
                command.Parameters.AddWithValue("@Descripcion", Descripcion);
                command.Parameters.AddWithValue("@Fecha", Fecha);

                int c=command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e)
            {

            }
        }

        public List<Entidades.Seguimientos> TraerSeguimientos(int  idbebe,DateTime fecha,int idcategoria) {
            List<Entidades.Seguimientos> lstseguimientos = new List<Seguimientos>();
            Entidades.Seguimientos segui =new Seguimientos();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerSeguimientoActividadxFecha", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                command.Parameters.AddWithValue("@idCategoria", idcategoria);
                command.Parameters.AddWithValue("@Fecha",fecha);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        segui = new Seguimientos();
                        segui.Categoria = reader["Categoria"].ToString();
                        segui.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                        segui.Descripcion = reader["Descripcion"].ToString();
                        lstseguimientos.Add(segui);

                    }
                }

                sqlConn.Close();
            } 
            catch(Exception ex){ }

            return lstseguimientos;
        }
        #endregion

        #endregion

        #region Ernye

        //Traer la lista de citas del bebé
        public DataTable TablaCitas (int idBebe)
        {
            // private string comandoVerCitas = "";
            DataTable dataTable = new DataTable();
            try
            {
                using (sqlConn) 
                {
                    using (SqlCommand sqlCommand = new SqlCommand("comando", sqlConn)) 
                    {
                        sqlCommand.CommandType=CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("idBebe", SqlDbType.Int)).Value = idBebe;

                        sqlConn.Open();

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    };
                };
                return dataTable;

            } catch (Exception)
            {
                return dataTable;
            }
        }

        //Traer la lista de alertas 
        public DataTable TablaAlertas(int idBebe)
        {
            // private string comandoVerCitas = "";
            DataTable dataTable = new DataTable();
            try
            {
                using (sqlConn)
                {
                    using (SqlCommand sqlCommand = new SqlCommand("comando", sqlConn))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("idBebe", SqlDbType.Int)).Value = idBebe;

                        sqlConn.Open();

                        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            dataAdapter.Fill(dataTable);
                        }
                    };
                };
                return dataTable;

            }
            catch (Exception)
            {
                return dataTable;
            }
        }

        #endregion
    }
}
