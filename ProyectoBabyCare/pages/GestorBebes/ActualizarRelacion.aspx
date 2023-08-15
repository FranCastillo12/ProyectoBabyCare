<%@ Page Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ActualizarRelacion.aspx.cs" Inherits="ProyectoBabyCare.pages.GestorBebes.ActualizarRelacion" %>


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
            <h2>Modificar relacion</h2>
            <div class="form-group">
                <asp:Label ID="lblId" runat="server">Identificador único del usuario:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblNombre" runat="server">Nombre del usuario:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>              
            </div>
            <div class="form-group">
                <asp:Label ID="lblApellidos" runat="server">Apellidos del usuario:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtApellidos" runat="server" CssClass="form-control"></asp:TextBox>              
            </div>
            <div class="form-group">
                <asp:Label ID="lblIdBebe" runat="server">Identificador único del bebé:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtIdBebe" runat="server" CssClass="form-control"></asp:TextBox>               
            </div>
             <div class="form-group">
                <asp:Label ID="lblNombreBebe" runat="server">Nombre del bebé:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtNombreBebe" runat="server" CssClass="form-control"></asp:TextBox>
            </div>                        
             <div class="form-group">
                <asp:Label ID="lblRol" runat="server">Rol Usuario:</asp:Label>
                 <br />
                 <asp:DropDownList ID="drpRol" runat="server"></asp:DropDownList>             
            </div>
            <div class="form-group">
                <asp:Label ID="lblEncargado" runat="server">Estado de encargado:</asp:Label>
                <asp:TextBox Enabled="false" ID="txtEncargado" runat="server" CssClass="form-control"></asp:TextBox>              
            </div>                                          
        
            <asp:Button type="submit" ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
    </form>
</asp:Content>