using Datos;
using Entidades;
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
        public void ModificarConfiguracionesSistema(int alertas,int Fotos,int Videos,int Ultrasonidos) {
            ConexionSQL conexion = new ConexionSQL();
            conexion.ModificarConfiguracionesSistema(alertas, Fotos, Videos, Ultrasonidos);

        }
        //Configuraciones Grupo familiar
        public Entidades.ConfiguracionesGrupoFamiliar TraerGrupoFamiliar() { 
            Entidades.ConfiguracionesGrupoFamiliar config=new Entidades.ConfiguracionesGrupoFamiliar();
            ConexionSQL conexion = new ConexionSQL();
            config = conexion.TraerConfiguracionesGrupoFamiliar();
            return config;
        }
        //----Modificaciones de parametros
        public void ModificarConfiguracionesGrupoFamiliar(int padres,int  madres,int  abuelos,int babysisters,int tios,int tias,int invitadps)
        {
            ConexionSQL conexion = new ConexionSQL();
            conexion.ModificarConfiguracionesFamiliares(padres, madres, abuelos, babysisters, tios, tias, invitadps);

        }
    }
}
