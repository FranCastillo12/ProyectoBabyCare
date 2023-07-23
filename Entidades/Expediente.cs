using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Expediente
    {
        private int idexpediente;
        private string nombrebebe;
        private int idbebe;
        private string cedula;
        private string nombrePadre;
        private string nombreMadre;
        private float peso;
        private float estatura;
        private string tiposangre;
        private string genero;
        private string fechanacimiento;

        public int Idexpediente { get => idexpediente; set => idexpediente = value; }
        public string Nombrebebe { get => nombrebebe; set => nombrebebe = value; }
        public int Idbebe { get => idbebe; set => idbebe = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string NombrePadre { get => nombrePadre; set => nombrePadre = value; }
        public string NombreMadre { get => nombreMadre; set => nombreMadre = value; }
        public float Peso { get => peso; set => peso = value; }
        public float Estatura { get => estatura; set => estatura = value; }
        public string Tiposangre { get => tiposangre; set => tiposangre = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Fechanacimiento { get => fechanacimiento; set => fechanacimiento = value; }
    }
}
