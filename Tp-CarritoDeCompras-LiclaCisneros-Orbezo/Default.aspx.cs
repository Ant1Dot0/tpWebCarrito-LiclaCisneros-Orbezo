using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Tp_CarritoDeCompras_LiclaCisneros_Orbezo
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> articulos = new List<Articulo>();
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            articulos = artNegocio.listar();
            listaArticulos = articulos;
        }
    }
}