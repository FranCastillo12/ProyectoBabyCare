using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Data.SqlClient;
using Amazon.S3;
using Amazon.S3.Transfer;
using System.IO;
using System.Configuration;
using System.Data;


namespace Negocios
{
    public static class Archivos
    {
        private static string accesskey = ConfigurationManager.AppSettings["AccessKey"];
        private static string secretkey = ConfigurationManager.AppSettings["SecretKey"];

        public static void SubirArchivoAWS(string ruta, byte[] fileBytes, int idBebe, string tituloArchivo, int tipoArchivo)
        {
            var credenciales = new Amazon.Runtime.BasicAWSCredentials(accesskey, secretkey);

            // Crea una instancia del cliente de S3
            using (var client = new AmazonS3Client(credenciales, Amazon.RegionEndpoint.USEast1))
            {
                try
                {
                    Random r = new Random();
                    //Generamos un numero aletorio por si existe una imagen con el mismo titulo
                    int n = r.Next(0, 99);
                    //Nombre con el que se va a guardar la imagen en S3
                    string fileNameInS3 = tituloArchivo + n.ToString();

                    //Asginamos si es video o foto
                    fileNameInS3 += tipoArchivo == 1 ? "_image" : "_video";

                    // Crear una solicitud de transferencia
                    var fileTransferUtility = new TransferUtility(client);

                    // Configuramos las opciones de carga
                    var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                    {
                        BucketName = "bucketbabycare",
                        InputStream = new MemoryStream(fileBytes),
                        Key = fileNameInS3,
                        CannedACL = S3CannedACL.PublicRead, //establece permisos publicos en el archivo subido                        
                    };

                    // Subimos el archivo a S3
                    fileTransferUtility.Upload(fileTransferUtilityRequest);

                    // Url final donde se guardó el archivo en S3
                    string finalUrl = $"https://{fileTransferUtilityRequest.BucketName}.s3.amazonaws.com/{fileNameInS3}";

                    //Creamos un objeto de tipo archivos para guardar en la bd
                    Entidades.Archivos archivo = new Entidades.Archivos
                    {
                        IdBebe = idBebe,
                        IdTipoArchivo = tipoArchivo,
                        TituloArchivo = tituloArchivo,
                        FechaArchivo = DateTime.UtcNow,
                        RutaArchivo = finalUrl
                    };

                    //Ejecutamos el metodo para subir el archivo a la bd
                    SubirArchivo(archivo);
                }
                catch (AmazonS3Exception as3e)
                {
                    throw new Exception(as3e.Message);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
        }
        public static void SubirArchivo(Entidades.Archivos archivo)
        {
            try
            {
                string spName = "SubirArchivo";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idBebe", archivo.IdBebe),
                    new SqlParameter("@idTipoArchivo", archivo.IdTipoArchivo),
                    new SqlParameter("@tituloArchivo", archivo.TituloArchivo),
                    new SqlParameter("@fechaArchivo", archivo.FechaArchivo),
                    new SqlParameter("@archivo", archivo.RutaArchivo)
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                iConexion.ExecuteSP(spName, lstParametros);
            }
            catch (Exception)
            {
                throw new Exception("No se pudo guardar el archivo a la base de datos");
            }
        }
        public static List<Entidades.Archivos> ListaArchivosBebe(int idBebe)
        {
            try
            {
                List<Entidades.Archivos> archivos = new List<Entidades.Archivos>();
                string spName = "CargarArchivosBebe";
                var lstParametros = new List<SqlParameter>()
                {
                    new SqlParameter("@idBebe", idBebe),
                };
                ConexionSQL iConexion = new Datos.ConexionSQL();
                DataTable dtArchivos = iConexion.ExecuteSPWithDT(spName, lstParametros);

                if (dtArchivos != null && dtArchivos.Rows.Count > 0)
                {
                    foreach (DataRow fila in dtArchivos.Rows)
                    {
                        Entidades.Archivos a = new Entidades.Archivos
                        {
                            IdArchivo = Convert.ToInt32(fila[0].ToString()),
                            IdBebe = Convert.ToInt32(fila[1].ToString()),
                            IdTipoArchivo = Convert.ToInt32(fila[2].ToString()),
                            TituloArchivo = fila[3].ToString(),
                            FechaArchivo = Convert.ToDateTime(fila[4].ToString()),
                            RutaArchivo = fila[5].ToString()
                        };

                        archivos.Add(a);
                    }
                }
                return archivos;

            }
            catch (Exception)
            {
                throw new Exception("No se pudo cargar la lista de archivos del bebé");
            }
        }
    }
}
