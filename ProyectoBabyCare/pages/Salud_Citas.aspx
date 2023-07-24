<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="Salud_Citas.aspx.cs" Inherits="ProyectoBabyCare.pages.Salud_Citas" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/SaludCitas.css" rel="stylesheet" />
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
                Agregar una nueva
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
                <div class="contenedorCitas">
                    <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
                            <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="EditarRegistro" CommandArgument='<%# Container.DataItemIndex %>' />
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="EliminarRegistro" CommandArgument='<%# Container.DataItemIndex %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
                            <asp:Button style="background-color:transparent; border:none; color:white;" ID="btnAgrear" runat="server" Text="Agregar" />
                        </div>                        
                    </div>
                    <div class="cd2Falso">

                    </div>
                </div>
            </div>           
        </div>
        <div class="piePagina">
            <img style="width:100%; height:100%" alt="" src="../images/Footer.png" />
        </div>
    </div>
</form>    
</asp:Content>