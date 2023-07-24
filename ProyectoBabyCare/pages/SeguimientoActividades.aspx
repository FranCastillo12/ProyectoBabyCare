<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="SeguimientoActividades.aspx.cs" Inherits="ProyectoBabyCare.pages.SeguimientoActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <h1>Seguimiento de actividades</h1>
        <form runat="server" style="font-family: 'Baloo 2', sans-serif">
            <div class="row">
                <div style="width: 20%; margin-left: 15%">
                    <a runat="server" href="AgregarSeguimiento.aspx" class="btn btn-success">
                        <h2>+ Actividad</h2>
                    </a>
                </div>
                <%-- Fin boton --%>
                <div style="width: 30%; margin-left: 5%;">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Categoría"></asp:Label>
                    </div>
                    <asp:DropDownList ID="dropCategoria" CssClass="form-controlddl" runat="server"></asp:DropDownList>
                </div>
                <%-- Fin categoria --%>
                <div style="width: 15%">
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Fecha actividad"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtFechaSeguimiento" runat="server" type="date" placeholder="Fecha" CssClass="form-control"></asp:TextBox>
                </div>
                <%-- Fin fecha --%>
            </div>
            <%-- Fin row --%>


            <div class="row" style="margin-top: 2%;">
                <div style="width: 50%;">
                    <%-- Imagen --%>
                    <div style="text-align: center;">
                        <img runat="server" src="~/images/agenda.jpg" style="width: 50%; height: 50%; border-radius: 10%; padding-top: 3%; padding-bottom: 3%" />
                    </div>
                </div>
                <div style="width: 50%;">
                    <%-- Table --%>
                    <div class="DivTable">
                        <asp:GridView ID="gridseguimiento" runat="server" AutoGenerateColumns="true" CssClass="tabla"></asp:GridView>
                    </div>
                </div>
            </div>
            <%-- Fin row --%>
        </form>
    </div>
</asp:Content>
