<%@ Page Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ActualizarUsuario.aspx.cs" Inherits="ProyectoBabyCare.pages.GestorBebes.ActualizarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../../styles/PaginasAdmin/Formulario.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">   
    <form runat="server">    
        <div class="edit-form-container">
            <h2>Editar Usuario</h2>
            <div class="form-group">
                <asp:Label ID="lblId" runat="server">Identificador único:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server">Nombre:</asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>              
            </div>
            <div class="form-group">
                <asp:Label ID="lblApellidos" runat="server">Apellidos:</asp:Label>
                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>               
            </div>
            <div class="form-group">
                <asp:Label ID="lblFecha" runat="server">Fecha registro:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtFecha" runat="server" CssClass="form-control"></asp:TextBox>                 
            </div>            
             <div class="form-group">
                <asp:Label ID="lblEmail" runat="server">Correo electronico:</asp:Label>
                <asp:TextBox TextMode="Email" ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>               
            </div>
            <div class="form-group">
                <asp:Label ID="lblPass" runat="server">Contraseña:</asp:Label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="form-control"></asp:TextBox>              
            </div>           
            <div class="form-group">
                <asp:Label ID="lblBebes" runat="server">Bebes Asociados:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtBebes" runat="server" CssClass="form-control"></asp:TextBox>
            </div>                        
        
            <asp:Button type="submit" ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </form>
</asp:Content>
