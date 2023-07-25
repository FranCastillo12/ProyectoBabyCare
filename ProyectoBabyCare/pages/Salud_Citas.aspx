<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="Salud_Citas.aspx.cs" Inherits="ProyectoBabyCare.pages.Salud_Citas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/SaludCitas.css" rel="stylesheet" />
             <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>         <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">    
    <div class="contenedor">
        <div class ="contenedorTitulo">
            <div class="tituloPrincipal">
                <div class="textoTituloPrincipal">
                    Calendarización de citas
                </div>
            </div>
            <div class="logoPrincipal">
                <img style="width:100%; height:100%;" alt="" src="../images/calen.png" />
            </div>
        </div>
        <div class="contenedorSubtitulos">
            <div class="subTitulo1">
                <div class="textoSubTitulo">
                    Lista de citas
                </div>
            </div>
            <div class="textoSubTitulo">
                <asp:Button CssClass="btnNuevaCita" ID="btnAgregarNueva" runat="server" Text="Agregar una nueva" OnClick="btnAgregarNueva_Click" />                
            </div>
        </div>
        <div class="contenedorCentro">
            <div class="contenedorIzquierda">
                <div class="cabeceraCitas">
                    <div class="cabeceraColumna">
                        <div class="cabeceraColumnaTitulo">
                            <div class="cabeceraTexto">
                                Lugar
                            </div>
                        </div>                       
                    </div>
                    <div class="cabeceraColumna">
                        <div class="cabeceraColumnaTitulo">
                            <div class="cabeceraTexto">
                                Titulo
                            </div>
                        </div>                       
                    </div>
                    <div class="cabeceraColumna">
                        <div class="cabeceraColumnaTitulo">
                            <div class="cabeceraTexto">
                                Fecha
                            </div>
                        </div>                       
                    </div>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Editar - Borrar
                </div>                
                <div runat="server" class="contenedorCitas" id="contenedorCitas">
                                       
                </div>                                                     
            </div>
            <div class="contenedorDerecha">
                <div class="contenedorDerecha1">
                    <div class="cd1Recuadro">
                        <div class="cd1Label">
                            <asp:Label ID="lblLugar" runat="server" Text="Lugar"></asp:Label>
                        </div>
                        <div class="cd1TextBox">
                            <asp:TextBox ID="txtLugar" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cd1Recuadro">
                        <div class="cd1Label">
                            <asp:Label ID="lblTitulo" runat="server" Text="Titulo"></asp:Label>
                        </div>
                        <div class="cd1TextBox">
                            <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="cd1Recuadro">
                        <div class="cd1Label">
                            <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
                        </div>
                        <div class="cd1TextBox">
                            <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>            
                <div class="contenedorDerecha2">
                    <div class="cd2Falso">

                    </div>
                    <div class="cd2Recuadro">
                        <div class="cd2Boton">
                            <asp:Button style="background-color:transparent; border:none; color:white;" ID="btnAgrear" runat="server" Text="Agregar" OnClick="btnAgrear_Click" />
                        </div>                        
                    </div>
                    <div class="cd2Falso">

                    </div>
                </div>
            </div>           
        </div>
        <asp:Label CssClass="btnNuevaCita" ID="lblMensaje" runat="server" Text=""></asp:Label>
        <div class="piePagina">
            <img style="width:100%; height:100%" alt="" src="../images/Footer.png" />
        </div>
    </div>
</form>    
</asp:Content>