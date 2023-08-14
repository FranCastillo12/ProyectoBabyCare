<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Configuraciones.aspx.cs" Inherits="ProyectoBabyCare.pages.WebForm1" %>

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
            <h1>Configuracion de parámetros del sistema</h1>
        </div>
        <form class="jumbotron" runat="server">
            <div class="row">
                <div style="width: 40%; margin-left: 5%; margin-top: 5%; background-color: #F6E0ED; color: mediumblue; text-align: center; border: dashed; border-color: #FF1493; border-radius: 10%">

                    <h3>Configuraciones del grupo familiar</h3>
                    <div class="row" style="margin-left: 15%">
                        <div style="width: 40%;">
                            <asp:Label ID="Label1" runat="server" Text="Cantidad de padres"></asp:Label>
                            <asp:TextBox ID="txtPadres" runat="server" onkeypress="return soloNumeros(event)" Style="width: 70px" MaxLength="2"></asp:TextBox>
                        </div>
                        <div style="width: 40%; margin-left: 5%">
                            <asp:Label ID="Label2" runat="server" Text="Cantidad de madres"></asp:Label>
                            <asp:TextBox ID="txtMadres" runat="server" onkeypress="return soloNumeros(event)" Style="width: 70px" MaxLength="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 15%">
                        <div style="width: 40%;">
                            <asp:Label ID="Label5" runat="server" Text="Cantidad de abuelos"></asp:Label>
                            <asp:TextBox ID="txtAbuelos" runat="server" onkeypress="return soloNumeros(event)" Style="width: 70px" MaxLength="2"></asp:TextBox>
                        </div>
                        <div style="width: 40%; margin-left: 5%">
                            <div>
                                <asp:Label ID="Label6" runat="server" Text="Cantidad de babysisters"></asp:Label>
                            </div>

                            <asp:TextBox ID="txtBabysisters" onkeypress="return soloNumeros(event)" runat="server" Style="width: 70px" MaxLength="2"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row" style="margin-left: 15%;">
                        <div style="width: 40%;">
                            <asp:Label ID="Label7" runat="server" Text="Cantidad de invitados"></asp:Label>
                            <asp:TextBox ID="txtInvitados" runat="server" onkeypress="return soloNumeros(event)" Style="width: 70px" MaxLength="2"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 40%; margin-left: 30%; margin-bottom: 5%">

                        <asp:Button ID="btnModificarGrupoFamiliar" class="btn btn-primary mt-3" Style="color: white" runat="server" Text="Modificar" OnClick="btnModificarGrupoFamiliar_Click" />
                    </div>
                </div>
                <div style="width: 40%; margin-left: 5%; margin-top: 5%; background-color: #F6E0ED; color: mediumblue; text-align: center; border: dashed; border-color: #FF1493; border-radius: 10%">
                    <h3>Configuraciones del sistema</h3>
                    <div class="row" style="margin-left: 15%">
                        <div style="width: 40%;">
                            <asp:Label ID="Label8" runat="server" Text="Cantidad de ultrasonidos"></asp:Label>
                            <div>
                                <asp:TextBox ID="txtUltrasonidos" runat="server" onkeypress="return soloNumeros(event)" Style="width: 70px" MaxLength="2"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 40%; margin-left: 5%">
                            <asp:Label ID="Label9" runat="server" Text="Cantidad de alertas"></asp:Label>
                            <asp:TextBox ID="txtAlertas" runat="server" onkeypress="return soloNumeros(event)" Style="width: 70px" MaxLength="2"></asp:TextBox>
                        </div>
                    </div>
                <div class="row" style="margin-left: 15%">
                    <div style="width: 40%;">
                        <div>
                            <asp:Label ID="Label10" runat="server" Text="Cantidad de fotos"></asp:Label>
                        </div>

                        <asp:TextBox ID="txtFotos" runat="server" onkeypress="return soloNumeros(event)" Style="width: 70px" MaxLength="2"></asp:TextBox>
                    </div>
                    <div style="width: 40%; margin-left: 5%">
                        <div>
                            <asp:Label ID="Label11" runat="server" Text="Cantidad de videos"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtVideos" runat="server" Style="width: 70px" onkeypress="return soloNumeros(event)" MaxLength="2"></asp:TextBox>
                    </div>
                    <div style="width: 40%; margin-left: 20%; margin-bottom: 5%">
                        <asp:Button ID="btnModificarSistema" class="btn btn-primary mt-3" Style="color: white" runat="server" Text="Modificar" OnClick="btnModificarSistema_Click" />
                    </div>
                </div>
            </div>
    </div>
    </form>
        <script type="text/javascript">
            function soloNumeros(e) {
                var charCode = (e.which) ? e.which : event.keyCode;
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
        </script>
    </div>
</asp:Content>
