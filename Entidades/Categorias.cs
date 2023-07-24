using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        private int idcategorial;
           private string nombre;

        public int Idcategorial { get => idcategorial; set => idcategorial = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
