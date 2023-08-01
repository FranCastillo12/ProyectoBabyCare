using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PrioridadCitas
    {
        int _idPrioridad;
        string _Prioridad;

        public int IdPrioridad { get => _idPrioridad; set => _idPrioridad = value; }
        public string Prioridad { get => _Prioridad; set => _Prioridad = value; }
    }
}
