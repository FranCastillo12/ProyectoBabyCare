<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublic.Master" AutoEventWireup="true" CodeBehind="Consejos.aspx.cs" Inherits="ProyectoBabyCare.pages.Consejos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 100%; height: 70%; background-image: url(../images/fondobotones.jpg); background-size: cover; background-position: center;">
        <div style="padding-top: 2%; padding-bottom: 6%; padding-left: 6%; padding-right: 6%;">
            <h1 style="font-family: 'Baloo 2', sans-serif; color: white; width: 100%">Consejos
            </h1>
            <div style="width: 80%">
                <h5 style="font-family: 'Baloo 2', sans-serif; color: white;">
                    La crianza de tu bebé es un viaje único y lleno de amor. Aquí encontrarás consejos prácticos para comenzar esta hermosa aventura juntos. ¡Prepárate para brindarle todo el amor y cuidado que necesita!
                </h5>
            </div>

        </div>
    </div>

    <div class="">
        <form runat="server">
            <div style="text-align: center">
                <div class="row">

                    <div style="width: 29%;">
                        <asp:Button ID="bder" runat="server" class="boton-con-imagen2" OnClick="bder_Click" CommandArgument="atras" />
                    </div>
                    <div style="width: 30%; margin-top: 1%">
                        <asp:Label ID="numconsejo" runat="server" CssClass="EnumeradorConsejo" Text="Consejo:1"></asp:Label>
                    </div>
                    <div style="width: 30%;">
                        <asp:Button ID="bizq" runat="server" class="boton-con-imagen" OnClick="bder_Click" CommandArgument="adelante" />
                    </div>

                </div>
            </div>
            <%--End Form row --%>
            <div class="image-container3 mb-5 mt-1" style="text-align: center">
                <div style="background-color: black; opacity: 0.6;">
                    <div id="titulo" style="font-family: 'Baloo 2', sans-serif; color: white; font-size: 30px;">
                        <asp:Label ID="lbltitulo" runat="server" Text="Titulo del consejo"></asp:Label>
                    </div>
                    <div id="desc" style="font-family: 'Baloo 2', sans-serif; font-size: 20px; color: white;">
                        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion del consejo"></asp:Label>
                    </div>
                </div>

            </div>

        </form>


    </div>
</asp:Content>
