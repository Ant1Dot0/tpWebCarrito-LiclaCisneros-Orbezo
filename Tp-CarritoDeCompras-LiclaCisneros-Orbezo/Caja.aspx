<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Caja.aspx.cs" Inherits="Tp_CarritoDeCompras_LiclaCisneros_Orbezo.Caja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="ArticulosPagar">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="card mt-2">
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

                                    <%int count = 0; foreach (var arti in listaArticulos)
                                        {  %>
                                    <tr>
                                        <td><%=arti.codigo%></td>
                                        <td><%=arti.nombre%></td>
                                        <td><%=arti.precio%></td>
                                        <td>
                                            <a href="Caja.aspx?contador=<%=count%>" class="btn btn-secondary"><i class="fa-solid fa-minus"></i></a>
                                        </td>
                                    </tr>
                                    <% count++;
                                        } %>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="card text-center bg-danger text-white mb-3 mt-2">
                        <div class="card-body">
                            <h1>Total a Pagar</h1>
                            <h1>$<%=totalPagar %></h1>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    
                    <div class="card text-center  bg-success text-white mb-3 mt-2">
                            <asp:Button ID="btnPagar" runat="server" Text="Pagar" Font-Size="45" CssClass="btn btn-success card-body" Height="152" OnClick="btnPagar_Click" />

                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
