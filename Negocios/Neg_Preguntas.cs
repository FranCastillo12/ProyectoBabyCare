using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Neg_Preguntas
    {
        #region "Metodos para la base de datos"
        public DataTable Obtener_Respuesta(string pregunta)
        {
            string spName = "SP_ObtenerRespuesta";
            var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@pregunta", pregunta),
            };
            Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
            return iConexion.ExecuteSPWithDT(spName, lstParametros);

        }

        public void AgregarPregunta(string pregunta, string respuesta)
        {
            try
            {
                string spName = "SP_AgregarPregunta";
                var lstParametros = new List<SqlParameter>()
            {
                new SqlParameter("@pregunta", pregunta),
                new SqlParameter("@respuesta",respuesta),

            };
                Datos.ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region"Metodos para usar ChatGPT"
        public class Request
        {
            public string model { get; set; }
            public List<Message> messages { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        public class Response
        {
            public string id { get; set; }
            public string _object { get; set; }
            public int created { get; set; }
            public Choice[] choices { get; set; }
            public Usage usage { get; set; }
        }

        public class Usage
        {
            public int prompt_tokens { get; set; }
            public int completion_tokens { get; set; }
            public int total_tokens { get; set; }
        }

        public class Choice
        {
            public int index { get; set; }
            public Message message { get; set; }
            public string finish_reason { get; set; }
        }

        //public class Message
        //{
        //    public string role { get; set; }
        //    public string content { get; set; }
        //}

        #endregion


    }
}
