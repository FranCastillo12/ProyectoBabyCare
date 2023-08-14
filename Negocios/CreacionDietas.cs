using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class CreacionDietas
    {
        //Sebas
        public void CrearDieta(int rango, int tipo, int horario, string comida)
        {
            ConexionSQL conexion = new ConexionSQL();
            conexion.CrearDieta(rango,tipo,horario,comida);

        }
        public List<Entidades.RangoEdadDietas> listaRangoDietas() { 
            List<Entidades.RangoEdadDietas> lst =new List<Entidades.RangoEdadDietas> ();
            ConexionSQL conexion = new ConexionSQL();
            lst = conexion.TraerRangosDietas();
            return lst;
        }
        public List<Entidades.HorariosDieta> TraerHorariosDietas()
        {
            ConexionSQL conexion = new ConexionSQL();
            List<Entidades.HorariosDieta> lst = new List<Entidades.HorariosDieta>();
            lst = conexion.TraerHorariosDieta();
            return lst;
        }
        public List<Entidades.TiposComida> TraerTiposComida()
        {
            ConexionSQL conexion = new ConexionSQL();
            List<Entidades.TiposComida> lst = new List<Entidades.TiposComida>();
            lst = conexion.TraerTiposComida();
            return lst;
        }
    }
}
