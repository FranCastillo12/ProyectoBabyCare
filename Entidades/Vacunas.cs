using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vacunas
    {
        String _Nombre;
        String _Descripcion;
        DateTime _Fecha;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
    }
}
