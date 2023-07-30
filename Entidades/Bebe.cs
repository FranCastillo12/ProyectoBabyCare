using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Bebe
    {
        string _nombre;
        string _apellidos;
        DateTime _fecNac;
        DateTime _fechaReg;

        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellidos { get => _apellidos; set => _apellidos = value; }
        public DateTime FecNac { get => _fecNac; set => _fecNac = value; }
        public DateTime FechaReg { get => _fechaReg; set => _fechaReg = value; }
    }
}
