using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Correos
    {
        public void EnviarCorreo(string NombreUsuario,string CorreoUsuario) {
            Entidades.Correos correo=new Entidades.Correos();
            correo.EnviarCorreo(NombreUsuario,CorreoUsuario);

        }
    }
}
