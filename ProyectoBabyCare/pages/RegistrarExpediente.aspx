<%@ Page Title="Registro expediente" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="RegistrarExpediente.aspx.cs" Inherits="ProyectoBabyCare.RegistrarExpediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/RegistroExpediente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="" style="text-align: center;">
        <div style="text-align: center; font-family: 'Baloo 2', sans-serif;margin-top:1%;margin-bottom:1%;width:70%">
            <h1 style="background-color: #F6E0ED;align-content:center">Registro del expediente
            </h1>
        </div>
        <div class="row">
            <div style="width: 25%; background-image: url(../images/reg1.png); background-size: cover; background-position: center;">
            </div>
            <form runat="server" class="Formulario" style="padding-top:10%;padding-bottom:10%">
                <div>
                    <div style="text-align: center">
                        <asp:Label ID="Label1" runat="server" Text="Cedula del bebe"></asp:Label>
                    </div>
                    <div style="align-items: center; text-align: center;">
                        <div>
                            <asp:TextBox ID="txtCedula" CssClass="TEXTO" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="text-align: center">
                        <asp:Label ID="Label6" runat="server" Text="Genero"></asp:Label>
                    </div>
                    <div>
                        <div class="row Linea">
                            <div style="width: 10%">
                                <asp:RadioButton ID="R1" runat="server" Text="Niño" GroupName="grupoRadios" />
                            </div>
                            <div class="rb2">
                                <asp:RadioButton ID="R2" runat="server" Text="Niña" GroupName="grupoRadios" />
                            </div>
                        </div>

                    </div>
                </div>
                <div>
                    <div style="text-align: center">
                        <asp:Label ID="Label2" runat="server" Text="Peso"></asp:Label>
                    </div>
                    <div style="align-items: center; text-align: center;">
                        <div style="">
                            <asp:TextBox ID="txtpeso" CssClass="TEXTO" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="text-align: center">
                        <asp:Label ID="Label3" runat="server" Text="Estatura"></asp:Label>
                    </div>
                    <div style="align-items: center; text-align: center;">
                        <div style="">
                            <asp:TextBox ID="txtestatura" CssClass="TEXTO" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="text-align: center">
                        <asp:Label ID="Label4" runat="server" Text="Tipo de sangre"></asp:Label>
                    </div>
                    <div style="align-items: center; text-align: center;">
                        <div style="">
                            <asp:TextBox ID="txtTiposangre" CssClass="TEXTO" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>
                    <div style="text-align: center">
                        <asp:Label ID="Label5" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    </div>
                    <div style="align-items: center; text-align: center;">
                        <div style="">
                            <asp:TextBox ID="txtfecha" type="date" CssClass="TEXTO" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%-- BOTON DE REGISTRAR --%>
                <div style="align-items: center; text-align: center; margin-top: 4%">
                    <div style="width:50%">
                        <asp:Button ID="btnRegistrar" class="btn btn-primary profile-button" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                    </div>
                </div>
        </form>
            <div style="width: 25%; background-image: url(../images/reg2.jpg); background-size: cover; background-position: center;">
            </div>

    </div>

    </div>
</asp:Content>
