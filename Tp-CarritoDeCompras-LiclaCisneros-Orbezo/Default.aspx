<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp_CarritoDeCompras_LiclaCisneros_Orbezo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="display: flex; flex-direction: row; justify-content: space-between;">
            <%int count = 0; foreach (var item in listaA)
                {%>
            <div class="card" style="width: 18rem; height: 30rem; margin: 20px; border: 1px solid black;">
                <img src="<%=item.Url%>" class="card-img-top" alt="No Disponible" width="100%" height="55%" style="background-color: lightgray;">
                <div class="card-body" style="border-top: 1px solid black; display: flex; flex-direction: column; align-items: center;">
                    <h5 class="card-title"><%=item.nombre %></h5>
                    <p class="card-text"><%=item.descripcion%></p>
                    
                        <a href="Default.aspx?contador=<%=count%>" title="Añadir al carrito" onclick='agregarAlertaAdd()' class="btn btn-primary">Agregar 1</a>

                </div>
            </div>
            <%count++;
            } %>
        </div>
    </div>
</asp:Content>
