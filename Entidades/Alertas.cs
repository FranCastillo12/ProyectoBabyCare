using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Alertas
    {
        String _HoraAlerta;
        String _Descripcion;
        String _Categoria;
        int _Estado;

        public string HoraAlerta { get => _HoraAlerta; set => _HoraAlerta = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
    }
}
