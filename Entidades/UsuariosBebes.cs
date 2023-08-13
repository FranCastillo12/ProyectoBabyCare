using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class UsuariosBebes
    {
        int idUsuario;
        string nombre;
        string apellidos;
        int idbebe;
        string nombreBebe;
        int idRol;
        string rol;
        int encargado;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int Idbebe { get => idbebe; set => idbebe = value; }
        public string NombreBebe { get => nombreBebe; set => nombreBebe = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Encargado { get => encargado; set => encargado = value; }
    }
}
