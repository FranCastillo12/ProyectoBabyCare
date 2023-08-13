using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConfiguracionesGrupoFamiliar
    {
        private int padres;
        private int madres;
        private int tios;
        private int tias;
        private int abuelos;
        private int babysisters;
        private int invitados;

        public int Padres { get => padres; set => padres = value; }
        public int Madres { get => madres; set => madres = value; }
        public int Tios { get => tios; set => tios = value; }
        public int Tias { get => tias; set => tias = value; }
        public int Abuelos { get => abuelos; set => abuelos = value; }
        public int Babysisters { get => babysisters; set => babysisters = value; }
        public int Invitados { get => invitados; set => invitados = value; }
    }
}
