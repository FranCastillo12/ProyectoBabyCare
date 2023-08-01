using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class RangoEdadDietas
    {
        int _idRangoDietas;
        int _EdadInicio;
        int _EdadFinal;

        public int IdRangoDietas { get => _idRangoDietas; set => _idRangoDietas = value; }
        public int EdadInicio { get => _EdadInicio; set => _EdadInicio = value; }
        public int EdadFinal { get => _EdadFinal; set => _EdadFinal = value; }
    }
}
