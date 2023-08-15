using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FotosBebe
    {
        private DateTime fecha;
        private string url;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Url { get => url; set => url = value; }
    }
}
