using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Archivos
    {
        int _idArchivo;
        int _idBebe;
        int _idTipoArchivo;
        String _TituloArchivo;
        DateTime _fechaArchivo;
        String _rutaArchivo;

        public int IdArchivo { get => _idArchivo; set => _idArchivo = value; }
        public int IdBebe { get => _idBebe; set => _idBebe = value; }
        public int IdTipoArchivo { get => _idTipoArchivo; set => _idTipoArchivo = value; }
        public string TituloArchivo { get => _TituloArchivo; set => _TituloArchivo = value; }
        public DateTime FechaArchivo { get => _fechaArchivo; set => _fechaArchivo = value; }
        public string RutaArchivo { get => _rutaArchivo; set => _rutaArchivo = value; }
    }
}
