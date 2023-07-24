<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="ProyectoBabyCare.pages.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/ControlPanel.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="contenedor1">
                <div class="cabeceraContenedor1">
                    <div class="tituloIzquierda1">
                        Panel de Control
                    </div>                    
                </div>
                <div class="notificacion1">
                    <asp:Label ID="lblNotificacion1" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="notificacion1">
                    <asp:Label ID="lblNotificacion2" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="notificacion1">
                    <asp:Label ID="lblNotificacion3" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="contenedor2">
                <div class="recuadroBebe">
                    <img class="imagenBebe" alt="" src="../images/bebeAnimado.jpg" />
                </div>
                <div class="recuadroDatosBebe">
                    <asp:Label ID="lblNombre" runat="server" Text="Josias Madriz Calderón"></asp:Label>
                    <br />
                    <asp:Label ID="lblEdad" runat="server" Text="   1 año y 7 meses"></asp:Label>
                </div>
            </div>
            <div class="contenedorTransparente">
                <div class="contenedor3">
                    <div class="recuadroConsejo">
                        <asp:Label CssClass="textoConsejo" ID="lblConsejo" runat="server" Text="
                            ¿Sabías que el cuidado amoroso y adecuado es esencial para el desarrollo 
                            saludable de tu bebé?">
                        </asp:Label>                        
                    </div>
                </div>
                <div class="contenedor4">
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion4" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion5" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion6" runat="server" Text="Label"></asp:Label>
                    </div>
                   <div class="perfil">
                       <asp:Label ID="lblPerfil" runat="server" Text="Perfil de Padre"></asp:Label>
                   </div>
                </div>
            </div>
            
            <div class="piePagina">
                <img style="width:100%; height:100%" alt="" src="../images/Footer.png" />
            </div>
        </div>
    </form>
</asp:Content>
