<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublic.Master" AutoEventWireup="true" CodeBehind="Consejos.aspx.cs" Inherits="ProyectoBabyCare.pages.Consejos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="image-container2">
        <div style="font-family: 'Baloo 2', sans-serif; color: black; font-size: 14px; width: 450px; margin-left: 40px">
            <h1 style="color: #F495B6">Consejos</h1>
            <asp:Label ID="lblConsejos" runat="server" Text="La crianza de tu bebé es un viaje único y lleno de amor. Aquí encontrarás consejos prácticos para comenzar esta hermosa aventura juntos. ¡Prepárate para brindarle todo el amor y cuidado que necesita!"></asp:Label>
        </div>
    </div>

    <div class="container mt-2 ">
        <form runat="server">
            <div style="text-align: center">
                <div class="row">

                    <div class="form-control" style="width: 50%;">
                        <asp:Button ID="bder" runat="server" class="boton-con-imagen2" OnClick="bder_Click" CommandArgument="atras" />
                    </div>
                    <div class="form-control" style="width: 50%;">
                        <asp:Button ID="bizq" runat="server" class="boton-con-imagen" OnClick="bder_Click" CommandArgument="adelante" />
                    </div>

                </div>

            </div>
            <%--End Form row --%>
            <div class="image-container3 mb-5" style="text-align: center">
                <div style="background-color: #F6E0ED; opacity: 0.9;">
                    <div id="titulo" style="font-family: 'Baloo 2', sans-serif; color: #F495B6; font-size: 30px;">
                        <asp:Label ID="lbltitulo" runat="server" Text="Titulo del consejo"></asp:Label>
                    </div>
                    <div id="desc" style="font-family: 'Baloo 2', sans-serif; font-size: 20px; color: black;">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion del consejo"></asp:Label>
                    </div>
                </div>

            </div>

        </form>


    </div>

</asp:Content>
