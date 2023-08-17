<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="AlbumFotos.aspx.cs" Inherits="ProyectoBabyCare.pages.AlbumFotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/AlbumFotos.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background-color: #F6E0ED";>
        <form runat="server">
            <div id="filtro" class="row" style="color: mediumblue;font-family: 'Baloo 2', sans-serif">
                <div style="width: 20%;margin-left:20%;text-align:center;margin-top:10px;">
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Fecha 1"></asp:Label>
                    </div>

                    <asp:TextBox ID="txtfecha1" type="date" runat="server" style="width:100%"></asp:TextBox>
                </div>
                <div style="width: 20%;margin-left:5%;text-align:center;margin-top:10px;">
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Fecha 2"></asp:Label>
                    </div>

                    <asp:TextBox ID="txtfecha2" type="date" runat="server" style="width:100%"></asp:TextBox>
                </div>
                <div style="width: 30%">
                    <asp:Button ID="btnFiltrar" class="btn btn-primary profile-button" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" style="margin-top:20px" />
                </div>
            </div>

            <div id="ContenedorAlbum" runat="server">
            </div>
        </form>

        <div class="footer">
        </div>
    </div>
</asp:Content>
