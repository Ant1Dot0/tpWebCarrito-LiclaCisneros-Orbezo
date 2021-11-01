﻿using System;
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
        public List<Articulo> listaA { get; set; }
        public List<Articulo> carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio nuevo = new ArticuloNegocio();
            listaA = nuevo.listar();

            carrito = (List<Articulo>)Session["carritoCompra"];

            if (carrito == null)
            {
                carrito = new List<Articulo>();
            }


        }
    }
}