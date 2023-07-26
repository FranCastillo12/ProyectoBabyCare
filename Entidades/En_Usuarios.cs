using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class En_Usuarios
    {
        private int IntIdUsuario;

        public int IdUsuario { get => IntIdUsuario; set => IntIdUsuario = value; }

        private string StrUsuario;

        public string Usuario { get => StrUsuario; set => StrUsuario = value; }


        private string StrPass;
        public string Pass { get => StrPass; set => StrPass = value; }


        private string Strrol;

        public string Rol { get => Strrol; set => Strrol = value; }

        private string StrIdenBebe;

        public string IdenBebe { get => StrIdenBebe; set => StrIdenBebe = value; }

    }
}
