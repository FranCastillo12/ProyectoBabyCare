using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class AlertasUsuario
    {
        public List<Entidades.Alerta> TraerAlertas(int idbebe) {
            List<Entidades.Alerta> sltalertas=new List<Entidades.Alerta>();
            Datos.ConexionSQL sQL = new Datos.ConexionSQL();
           sltalertas=sQL.AlertasBebe(idbebe);

            return sltalertas;
            
        }

        public void CambiarEstado(int idAlerta, bool Estado)
        {
            Datos.ConexionSQL sQL = new Datos.ConexionSQL();
            sQL.CambiarEstadoAlerta(idAlerta, Estado);
        }
        public void ActivateAlertas(DateTime now, int idbebe) { 
           ConexionSQL conexionSQL = new ConexionSQL();
            conexionSQL.ActivarAlertaSiguiente(now,idbebe);
        }

        public void EliminarAlerta(int idAlerta) {
            ConexionSQL conexionSQL = new ConexionSQL();
            conexionSQL.EliminarAlerta(idAlerta);
        }
        public void AgregarAlerta(int bebe,int cat,string desc,DateTime hora) {
            ConexionSQL conexionSQL = new ConexionSQL();
            conexionSQL.AgregarAlerta(bebe,cat,desc,hora);
        }

        public List<Entidades.Alerta> FiltrarAlertas(int idBebe,int idCategoria) { 
            List<Entidades.Alerta> lstAlertas= new List<Entidades.Alerta>();
            ConexionSQL conexionSQL = new ConexionSQL();
            lstAlertas=conexionSQL.FiltrarAlertas(idBebe,idCategoria);
            return lstAlertas;
        }
    }
}
