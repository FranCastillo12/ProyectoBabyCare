<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="SeguimientoActividades.aspx.cs" Inherits="ProyectoBabyCare.pages.SeguimientoActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

        <div class="row" style="font-family: 'Baloo 2', sans-serif; margin-top: 4%;">
            <div style="width: 40%;margin-left:10%">
                <h1>Seguimiento de actividades</h1>
            </div>

            <div style="width: 20%;">
                <a runat="server" href="AgregarSeguimiento.aspx" class="btn btn-success">
                    <h2>+ Actividad</h2>
                </a>
            </div>
        </div>
        <form runat="server" style="font-family: 'Baloo 2', sans-serif;">
            <div class="row">
                <%-- Fin boton --%>
                <div style="width: 30%; margin-left: 10%;">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Categoría"></asp:Label>
                    </div>
                    <asp:DropDownList ID="dropCategoria" CssClass="form-controlddl" runat="server"></asp:DropDownList>
                </div>
                <%-- Fin categoria --%>
                <div style="width: 30%; margin-left: 2%;">
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Fecha actividad"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtFechaSeguimiento" runat="server" type="date" placeholder="Fecha" CssClass="form-control"></asp:TextBox>
                </div>
                <%-- Fin fecha --%>
            </div>
            <%-- Fin row --%>
            <div>
                <div class="botonesSeguimiento mt-3" style="width:30%;margin-left:20%">
                    <asp:Button ID="btnFiltrar" class="btn btn-primary profile-button" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
                </div>
            </div>

    <div class="row" style="margin-top: 2%;">
        <div class="DivTable1">
            <%-- Imagen --%>
            <img runat="server" src="~/images/agenda.jpg" style="width: 100%; border-radius: 10%; padding-top: 3%; padding-bottom: 3%" />
        </div>

        <%-- Table --%>
        <div class="DivTable">
            <asp:GridView ID="gridseguimiento" runat="server" AutoGenerateColumns="true" CssClass="tabla"></asp:GridView>
        </div>

    </div>
    <%-- Fin row --%>
        </form>
</asp:Content>
