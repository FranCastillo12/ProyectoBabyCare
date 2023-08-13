using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class Configuraciones
    {
        //Configuraciones sistema
        public Entidades.ConfiguracionesSistema TraerConfiguraciones() { 
            Entidades.ConfiguracionesSistema config=new Entidades.ConfiguracionesSistema();
            ConexionSQL conexion = new ConexionSQL();
            config = conexion.TraerConfiguraciones();
            return config;
        }
        //----Modificaciones de parametros
        public void ModificarConfiguracionesSistema() {
            ConexionSQL conexion = new ConexionSQL();

        }
        //Configuraciones Grupo familiar
        public Entidades.ConfiguracionesGrupoFamiliar TraerGrupoFamiliar() { 
            Entidades.ConfiguracionesGrupoFamiliar config=new Entidades.ConfiguracionesGrupoFamiliar();
            ConexionSQL conexion = new ConexionSQL();
            config = conexion.TraerConfiguracionesGrupoFamiliar();
            return config;
        }
        //----Modificaciones de parametros
        public void ModificarConfiguracionesGrupoFamiliar()
        {
            ConexionSQL conexion = new ConexionSQL();

        }
    }
}
