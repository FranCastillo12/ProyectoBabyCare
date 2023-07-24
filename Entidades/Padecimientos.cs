using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Padecimientos
    {
        private int idPadecimiento;
        private string nombrepadecimiento;

        public int IdPadecimiento { get => idPadecimiento; set => idPadecimiento = value; }
        public string Nombrepadecimiento { get => nombrepadecimiento; set => nombrepadecimiento = value; }
    }
}
