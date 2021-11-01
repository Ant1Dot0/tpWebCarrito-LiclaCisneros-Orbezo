<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="Tp_CarritoDeCompras_LiclaCisneros_Orbezo.Caja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="ArticulosPagar">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Listado de Articulos</h4>
                            <table class="table table-striped">
                                <thead class="thead-dark">
                                    <tr>
                                        <th>Codigo</th>
                                        <th>Nombre</th>
                                        <th>Precio</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <%foreach (var arti in listaArticulos)
                                        {  %>
                                    <tr>
                                        <td><%=arti.codigo%></td>
                                        <td><%=arti.nombre%></td>
                                        <td><%=arti.precio%></td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="quitar" CssClass="btn btn-secondary" PostBackUrl="~/default2.aspx" />
                                        </td>
                                    </tr>
                                    <%} %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
    
</asp:Content>
