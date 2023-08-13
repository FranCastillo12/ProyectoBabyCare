using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConfiguracionesSistema
    {
        private int fotos;
        private int videos;
        private int ultrasonidos;
        private int alertas;

        public int Fotos { get => fotos; set => fotos = value; }
        public int Videos { get => videos; set => videos = value; }
        public int Ultrasonidos { get => ultrasonidos; set => ultrasonidos = value; }
        public int Alertas { get => alertas; set => alertas = value; }
    }
}
