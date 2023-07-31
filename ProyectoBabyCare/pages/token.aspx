<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="token.aspx.cs" Inherits="ProyectoBabyCare.pages.token" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblTitulo" runat="server" Text="Ingrese el token enviado a su correo"></asp:Label>
            <asp:TextBox ID="txtToken" runat="server"></asp:TextBox>
            <asp:Button ID="btnToken" runat="server" Text="Validar" OnClick="btnToken_Click" />
            <br />
        </div>
        <div>
            <asp:Label ID="lblReenviar" runat="server" Text="¿No ha recibido el codigo?"></asp:Label>
            <asp:Button ID="btnReenviar" runat="server" Text="Volver a enviar" OnClick="btnReenviar_Click" />
            <br />
        </div>       
        <div>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </form>
</asp:Content>
