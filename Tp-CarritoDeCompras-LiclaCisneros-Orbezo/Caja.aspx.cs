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
    public partial class Caja : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public List<Articulo> carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.id = 1;
            ArticuloNegocio nuevo = new ArticuloNegocio();
            
         
            carrito = (List<Articulo>)Session["carritoCompra"];
            carrito.Add(nuevo.buscarArticulo(articulo, 0));
            Session.Add("carritoCompra", carrito);

            listaArticulos = carrito;
        }
    }
}