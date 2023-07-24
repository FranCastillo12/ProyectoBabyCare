using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Seguimientos
    {
        private string categoria;
        private string descripcion;
        private DateTime fecha;

        public string Categoria { get => categoria; set => categoria = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
