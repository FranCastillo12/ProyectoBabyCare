using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        int _IdUsuario;
        string _Nombre;
        string _Apellidos;
        string _Correo;
        int _Estado;
        DateTime _FechaRegistro;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public string Correo { get => _Correo; set => _Correo = value; }
        public DateTime FechaRegistro { get => _FechaRegistro; set => _FechaRegistro = value; }

    }
}
