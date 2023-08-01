<%@ Page Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="PerfilesSistema.aspx.cs" Inherits="ProyectoBabyCare.pages.GestorBebes.PerfilesSistema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="styles/PaginasAdmin/PerfilesSistema.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <form runat="server">
            <div class="container">
               <%-- <asp:GridView ID="gvUsuarios" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:ButtonField CommandName="Edit" HeaderText="Editar" ShowHeader="True" Text="Editar" />
                        <asp:ButtonField CommandName="Select" HeaderText="Ver Bebés" ShowHeader="True" Text="Ver Bebés" />
                        <asp:ButtonField CommandName="Delete" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar" />
                    </Columns>
                </asp:GridView>--%>
                
            </div>
            
        </form>
    </div>
</asp:Content>
