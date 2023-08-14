<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="ControlPanel2.aspx.cs" Inherits="ProyectoBabyCare.pages.ControlPanel2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/ControlPanel2.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Baloo+2:wght@400;700&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="contenedor1">
                  <div class="tituloIzquierda1">
                        Panel de Control
                    </div> 
                <div class="cabeceraContenedor1">
                                     
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
                    <img class="imagenBebe" id="imagenBebe" alt="" src="../images/bebe7.jpg" />
                </div>                  
                <div class="recuadroDatosBebe">
                    <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
                    <br />
                    <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label>
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
                   <div class="indicador">
                       <asp:Image Height="80%" ID="Image1" src="../images/flechas2.png" runat="server" />
                   </div>
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion4" runat="server" Text="Label"></asp:Label>
                    </div>   
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion5" runat="server" Text="Label"></asp:Label>
                    </div>   
                </div>
            </div>
            
            <div class="piePagina">
                <img style="width:100%; height:100%" alt="" src="../images/Footer.png" />
            </div>
        </div>
    </form>    

</asp:Content>