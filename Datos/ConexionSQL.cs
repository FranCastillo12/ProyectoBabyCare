﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using Entidades;
using System.Dynamic;

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
        public int ExecuteSPWithScalar(string SPName, List<SqlParameter> ListaParametros)
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

                object result = cmd.ExecuteScalar();

                sqlConn.Close();

                return Convert.ToInt32(result);
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
        #region Alertas
        public List<Entidades.Alerta> AlertasBebe(int idbebe)
        {
            List<Entidades.Alerta> alertas = new List<Entidades.Alerta>();

            try
            {
                sqlConn.Open();

                SqlCommand command = new SqlCommand("VerAlertasbebe", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.Alerta alerta = new Entidades.Alerta();
                        alerta.idAlerta = Convert.ToInt32(reader["idAlerta"].ToString());
                        alerta.Descripcion = reader["nombre"].ToString();
                        if (Convert.ToBoolean(reader["Estado"].ToString()) == true)
                        {
                            alerta.Estado = true;
                        }
                        else {
                            alerta.Estado = false;
                        }
                        alerta.Categoria = reader["categoria"].ToString();  
                        if (!reader.IsDBNull(reader.GetOrdinal("HoraAlerta")))
                        {
                            TimeSpan horaDeAlertaTimeSpan = reader.GetTimeSpan(reader.GetOrdinal("HoraAlerta"));
                            DateTime fechaHoy = DateTime.Today;
                            DateTime horaDeAlerta = fechaHoy.Add(horaDeAlertaTimeSpan);
                            alerta.HoraDeAlerta = horaDeAlerta;
                        }

                        alertas.Add(alerta);
                    }
                }
                sqlConn.Close();


            }
            catch (Exception e)
            {

            }

            return alertas;
        }
        public string CambiarEstadoAlerta(int idAlerta,bool Estado)
        {
            string respuesta = "No existe";
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("ModificarEstadoAlerta", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idAlerta", idAlerta);
                command.Parameters.AddWithValue("@Estado", Estado);
                
                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e) { }
            return respuesta;
        }

        public void ActivarAlertaSiguiente(DateTime Horasistema,int idbebe) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("ActivarAlertaSiguiente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idBebe", idbebe);
                command.Parameters.AddWithValue("@HoraSistema", Horasistema);

                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e) { }
        }

        //EliminarAlerta
        public void EliminarAlerta(int idAlerta) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("EliminarAlerta", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idalerta", idAlerta);


                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e) { }
        }

        public void AgregarAlerta(int idBebe,int Categoria,string Descripcion,DateTime hora)
        {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("AgregarAlerta", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@hora", hora);
                command.Parameters.AddWithValue("@idcategoria", Categoria);
                command.Parameters.AddWithValue("@descripcion", Descripcion);
                command.Parameters.AddWithValue("@idbebe", idBebe);


                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e) { }
        }

        public List<Entidades.Alerta> FiltrarAlertas(int idBebe,int idCategoria) {
            List<Entidades.Alerta> lstalertas=new List<Entidades.Alerta>();
            try
            {
                sqlConn.Open();

                SqlCommand command = new SqlCommand("FiltrarAlertas", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idBebe", idBebe);
                command.Parameters.AddWithValue("@idCategoria", idCategoria);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.Alerta alerta = new Entidades.Alerta();
                        alerta.idAlerta = Convert.ToInt32(reader["idAlerta"].ToString());
                        alerta.Descripcion = reader["nombre"].ToString();
                        if (Convert.ToBoolean(reader["Estado"].ToString()) == true)
                        {
                            alerta.Estado = true;
                        }
                        else
                        {
                            alerta.Estado = false;
                        }
                        alerta.Categoria = reader["categoria"].ToString();
                        if (!reader.IsDBNull(reader.GetOrdinal("HoraAlerta")))
                        {
                            TimeSpan horaDeAlertaTimeSpan = reader.GetTimeSpan(reader.GetOrdinal("HoraAlerta"));
                            DateTime fechaHoy = DateTime.Today;
                            DateTime horaDeAlerta = fechaHoy.Add(horaDeAlertaTimeSpan);
                            alerta.HoraDeAlerta = horaDeAlerta;
                        }

                        lstalertas.Add(alerta);
                    }
                }
                sqlConn.Close();


            }
            catch (Exception e)
            {

            }
            return lstalertas;
        
        }

        #endregion

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

        public void IngresarDatosBasicosExpediente(int idbebe,string cedula,int genero,float peso,float estatura,string tiposangre) {
            try 
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("IngresarDatosBasicosExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                command.Parameters.AddWithValue("@cedula", cedula);
                command.Parameters.AddWithValue("@genero", genero);
                command.Parameters.AddWithValue("@peso", peso);
                command.Parameters.AddWithValue("@estatura", estatura);
                command.Parameters.AddWithValue("@tiposangre", tiposangre);
                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch(Exception ex){ }
            
        }
        public Entidades.Expediente Expediente(int idbebe)
        {
            Entidades.Expediente Expediente = new Entidades.Expediente();
            try
            {
                sqlConn.Open();
                string info = "";
                SqlCommand command = new SqlCommand("ObtenerDatosBasicosExpedienteBebe", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
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

        public List<Entidades.Generos> TraerGeneros() { 
            List<Entidades.Generos> lstGeneros=new List<Generos> ();
            Entidades.Generos genero = null;
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerGeneros", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        genero = new Entidades.Generos();
                        genero.Idgenero = Convert.ToInt32(reader["idGenero"].ToString());
                        genero.NGenero = reader["Genero"].ToString();
                        lstGeneros.Add(genero);
                    }
                }
                sqlConn.Close();

            }
            catch (Exception e)
            {

            }

            return lstGeneros;
        }

        public void ModificarExpediente(int idexpediente, float peso, float estatura, string tiposangre, string cedula, int genero) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("ModificarExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idexpediente", idexpediente);
                command.Parameters.AddWithValue("@cedula", cedula);
                command.Parameters.AddWithValue("@genero", genero);
                command.Parameters.AddWithValue("@peso", peso);
                command.Parameters.AddWithValue("@Estatura", estatura);
                command.Parameters.AddWithValue("@Tiposangre", tiposangre);
                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception ex) { }
        }
        public void InsertarDetalleExpediente(int idbebe,string descripcion,DateTime fecha) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("IngresarDetalleExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                command.Parameters.AddWithValue("@descripcion", descripcion);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception ex) { }
        }
        public void InsertarPadecimientoExpediente(int idbebe,int idpadecimiento) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("IngresarPadecimientoExpediente", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                command.Parameters.AddWithValue("@idpadecimiento", idpadecimiento);
                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception ex) { }
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

        public List<Entidades.Seguimientos> TraerSeguimientos(int  idbebe, DateTime fecha1, DateTime fecha2, int idcategoria) {
            List<Entidades.Seguimientos> lstseguimientos = new List<Seguimientos>();
            Entidades.Seguimientos segui =new Seguimientos();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerSeguimientoActividadxFecha", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idbebe", idbebe);
                command.Parameters.AddWithValue("@idCategoria", idcategoria);
                command.Parameters.AddWithValue("@Fecha1",fecha1);
                command.Parameters.AddWithValue("@Fecha2", fecha2);

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


        #region Configuraciones
        public Entidades.ConfiguracionesSistema TraerConfiguraciones()
        {
            Entidades.ConfiguracionesSistema configuraciones=new Entidades.ConfiguracionesSistema();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerConfiguracionesSistema", sqlConn);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        configuraciones.Fotos= Convert.ToInt32(reader["Cantidad_Fotos"].ToString());
                        configuraciones.Videos = Convert.ToInt32(reader["Cantidad_Videos"].ToString());
                        configuraciones.Ultrasonidos = Convert.ToInt32(reader["Cantidad_Ultrasonidos"].ToString());
                        configuraciones.Alertas= Convert.ToInt32(reader["Cantidad_Alertas"].ToString());
                    }
                }

                sqlConn.Close();
            }
            catch (Exception e) { }
            return configuraciones;
        }

        public Entidades.ConfiguracionesGrupoFamiliar TraerConfiguracionesGrupoFamiliar()
        {
            Entidades.ConfiguracionesGrupoFamiliar configuraciones = new Entidades.ConfiguracionesGrupoFamiliar();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerConfiguracionesGrupoFamiliar", sqlConn);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        configuraciones.Padres = Convert.ToInt32(reader["Cantidad_Padres"].ToString());
                        configuraciones.Madres = Convert.ToInt32(reader["Cantidad_Madres"].ToString());
                        configuraciones.Abuelos = Convert.ToInt32(reader["Cantidad_Abuelos"].ToString());
                        configuraciones.Babysisters = Convert.ToInt32(reader["Cantidad_Babysisters"].ToString());
                        configuraciones.Invitados = Convert.ToInt32(reader["Cantidad_Invitados"].ToString());
                    }
                }

                sqlConn.Close();
            }
            catch (Exception e) { }
            return configuraciones;
        }

        public void ModificarConfiguracionesFamiliares(int padres,int madres,int abuelos,int babysisters,int invitadps) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("ModificarConfiguracionesGrupoFamiliar", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@padres", padres);
                command.Parameters.AddWithValue("@madres", madres);
                command.Parameters.AddWithValue("@abuelos", abuelos);
                command.Parameters.AddWithValue("@Babysisters", babysisters);
                command.Parameters.AddWithValue("@invitados", invitadps);


                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e) { }
        }
        public void ModificarConfiguracionesSistema(int alertas, int Fotos, int Videos, int Ultrasonidos)
        {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("ModificarConfiguracionesSistema", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CantidadAlertas", alertas);
                command.Parameters.AddWithValue("@Cantidadfotos", Fotos);
                command.Parameters.AddWithValue("@Cantidadvideos", Videos);
                command.Parameters.AddWithValue("@CantidadUltrasonidos", Ultrasonidos);

                command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e) { }
        }
        #endregion

        #region CreacionDietas
        public List<Entidades.TiposComida> TraerTiposComida() {
            List<Entidades.TiposComida> lst=new List<TiposComida> ();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerTiposdecomida", sqlConn);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       // configuraciones.Fotos = Convert.ToInt32(reader["Cantidad_Fotos"].ToString());
                       Entidades.TiposComida ent=new Entidades.TiposComida();
                        ent.IdTipoComida= Convert.ToInt32(reader["idTipoComida"].ToString());
                        ent.Nombre1 = reader["NombreTipoComida"].ToString();
                        lst.Add(ent);
                    }
                }

                sqlConn.Close();
            }
            catch (Exception e) { }
            return lst;

        }
        public List<Entidades.HorariosDieta> TraerHorariosDieta()
        {
            List<Entidades.HorariosDieta> lst = new List<Entidades.HorariosDieta>();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerHorariosDietas", sqlConn);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // configuraciones.Fotos = Convert.ToInt32(reader["Cantidad_Fotos"].ToString());
                        Entidades.HorariosDieta ent = new Entidades.HorariosDieta();
                        ent.IdHorario = Convert.ToInt32(reader["idHorarioDieta"].ToString());
                        ent.Nombre = reader["NombreHorarioDieta"].ToString();
                        lst.Add(ent);
                    }
                }

                sqlConn.Close();
            }
            catch (Exception e) { }
            return lst;
        }

        public List<Entidades.RangoEdadDietas> TraerRangosDietas()
        {
            List<Entidades.RangoEdadDietas> lst = new List<Entidades.RangoEdadDietas>();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("VerRangoDietas", sqlConn);
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.RangoEdadDietas ent = new Entidades.RangoEdadDietas();
                        ent.IdRangoDietas=Convert.ToInt32(reader["idRangoedadDieta"].ToString());
                        ent.EdadInicio= Convert.ToInt32(reader["EdadInicio"].ToString());
                        ent.EdadFinal= Convert.ToInt32(reader["edadFinal"].ToString());
                        lst.Add(ent);
                    }
                }

                sqlConn.Close();
            }
            catch (Exception e) { }
            return lst;
        }
        //CrearDieta
        public void CrearDieta(int rango,int tipo,int horario,string comida) {
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("CrearDieta", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@rango", rango);
                command.Parameters.AddWithValue("@horario", horario);
                command.Parameters.AddWithValue("@tipo", tipo);
                command.Parameters.AddWithValue("@comida", comida);

                int c = command.ExecuteNonQuery();

                sqlConn.Close();
            }
            catch (Exception e)
            {

            }

        }
        #endregion

        #region AlbumFotos
        public List<Entidades.FotosBebe> TraerFotosBebe(int idbebe) {
            List<Entidades.FotosBebe> lst = new List<Entidades.FotosBebe>();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("TraerFotosBebe", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idBebe", idbebe);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.FotosBebe fotos=new FotosBebe();

                        fotos.Url = reader["URL"].ToString();
                        fotos.Fecha = DateTime.Parse(reader["Fecha"].ToString());

                        lst.Add(fotos);
                    }
                }

                sqlConn.Close();
            }
            catch (Exception e) { }

            return lst;
        }

        //FiltrarFotosBebe
        public List<Entidades.FotosBebe> FiltrarFotosBebe(int idbebe,DateTime fecha1,DateTime fecha2)
        {
            List<Entidades.FotosBebe> lst = new List<Entidades.FotosBebe>();
            try
            {
                sqlConn.Open();
                SqlCommand command = new SqlCommand("FiltrarFotosBebe", sqlConn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idBebe", idbebe);
                command.Parameters.AddWithValue("@Fecha1", fecha1);
                command.Parameters.AddWithValue("@Fecha2", fecha2);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Entidades.FotosBebe fotos = new FotosBebe();

                        fotos.Url = reader["URL"].ToString();
                        fotos.Fecha = DateTime.Parse(reader["Fecha"].ToString());

                        lst.Add(fotos);
                    }
                }

                sqlConn.Close();
            }
            catch (Exception e) { }

            return lst;
        }


        #endregion


        #endregion

    }
}
