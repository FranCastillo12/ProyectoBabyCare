<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Creaciondedietas.aspx.cs" Inherits="ProyectoBabyCare.pages.GestorBebes.Creaciondedietas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/Alertillas.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family: 'Baloo 2', sans-serif">
        <div style="text-align: center; background-color: #F6E0ED; color: mediumblue">
            <h1>Creación de dietas</h1>

        </div>
        <form runat="server" style="width: 50%; text-align: center; margin-top: 5%; margin-left: 25%; background-color: #F6E0ED; color: mediumblue; text-align: center; border: dashed; border-color: #FF1493; border-radius: 10%">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Rango de edad"></asp:Label>
                <div>
                    <asp:DropDownList ID="DropRango" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Tipo de comida"></asp:Label>
                <div>
                    <asp:DropDownList ID="DropTipo" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Horario"></asp:Label>
                <div>
                    <asp:DropDownList ID="DropHorario" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div>
                <asp:Label ID="Label4" runat="server" Text="Nombre de la comida"></asp:Label>
                <div>
                    <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="btnIngresar" class="btn btn-success mt-3 mb-3" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        </form>
    </div>

</asp:Content>
