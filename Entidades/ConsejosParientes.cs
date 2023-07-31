using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ConsejosParientes
    {
        int _id;
        string _descripcion;

        public int Id { get => _id; set => _id = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
    }
}
