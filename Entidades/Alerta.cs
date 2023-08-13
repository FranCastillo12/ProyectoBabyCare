using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alerta
    {
        public int idAlerta { get; set; }
        public DateTime HoraDeAlerta { get; set; }
        public string Categoria { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
