using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Dietas
    {
        int _idDieta;
        string _NombreComida;
        int _edadInicio;
        int _edadFinal;
        string _NombreDietaHorarioDieta;
        string _HoraDieta;
        string _TipoComida;

        public int IdDieta { get => _idDieta; set => _idDieta = value; }
        public string NombreComida { get => _NombreComida; set => _NombreComida = value; }
        public int EdadInicio { get => _edadInicio; set => _edadInicio = value; }
        public int EdadFinal { get => _edadFinal; set => _edadFinal = value; }
        public string NombreDietaHorarioDieta { get => _NombreDietaHorarioDieta; set => _NombreDietaHorarioDieta = value; }
        public string HoraDieta { get => _HoraDieta; set => _HoraDieta = value; }
        public string TipoComida { get => _TipoComida; set => _TipoComida = value; }
    }
}
