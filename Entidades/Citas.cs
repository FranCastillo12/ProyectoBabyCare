using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Citas
    {
        int _idCita;
        string _lugar;
        string _titulo;
        DateTime _fecha;

        public int IdCita { get => _idCita; set => _idCita = value; }
        public string Lugar { get => _lugar; set => _lugar = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        
    }
}
