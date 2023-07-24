<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="AgregarSeguimiento.aspx.cs" Inherits="ProyectoBabyCare.pages.AgregarSeguimiento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <form runat="server" style="font-family: 'Baloo 2', sans-serif; border-radius: 10%; background-color: #F6E0ED; color: black; margin-left: 10%; margin-right: 10%; margin-top: 4%;">
            <div style="text-align: center;">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Categoria"></asp:Label>
                </div>
                <div style="width: 50%; margin-left: 20%;">
                    <asp:DropDownList ID="dropcategorias" AutoPostBack="true" CssClass="form-controlddl" runat="server" Style="text-align: center;"></asp:DropDownList>
                </div>

            </div>
            <div style="text-align: center; padding-left: 10%; padding-right: 10%; padding-bottom: 4%">
                <asp:TextBox runat="server" ID="txtdescripcionseguimiento" TextMode="MultiLine" Rows="5" Columns="15" CssClass="textareaNombres custom-textbox" Style="width: 100%" />
            </div>
            <div class="row">
                <div class="divBoton1">
                    <div class="botonesSeguimiento">
                        <asp:Button ID="btnAgregar" class="btn btn-primary profile-button" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
                    </div>

                </div>
                <div class="divBoton2">
                    <div class="botonesSeguimiento">
                        <a runat="server" class="btn btn-primary profile-button" href="SeguimientoActividades.aspx">Cancelar</a>
                    </div>

                </div>
            </div>
        </form>
    </div>
</asp:Content>
