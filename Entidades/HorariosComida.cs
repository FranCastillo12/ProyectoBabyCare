using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HorariosDieta
    {
        private int idHorario;
        private string nombre;

        public int IdHorario { get => idHorario; set => idHorario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
