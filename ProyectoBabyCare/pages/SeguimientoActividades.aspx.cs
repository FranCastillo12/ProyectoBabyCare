using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBabyCare.pages
{
    public partial class SeguimientoActividades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Entidades.Categorias> lstcategorias = new List<Entidades.Categorias>();
            Negocios.SeguimientoActividades seg=new Negocios.SeguimientoActividades();
            lstcategorias=seg.Categorias();
            dropCategoria.Items.Add("Selecciona una categoría");
            foreach (Entidades.Categorias c in lstcategorias) {
                dropCategoria.Items.Add($"{c.Idcategorial}-{c.Nombre}");
            }
        }
    }
}