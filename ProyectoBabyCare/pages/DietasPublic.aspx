<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="DietasPublic.aspx.cs" Inherits="ProyectoBabyCare.pages.DietasPublic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/DietasPublic.css" rel="stylesheet" />
    
    <%--Hojas de estilos cartas--%>
    <link href="../styles/generales/CartasDietas.css" rel="stylesheet" />    
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@48,400,0,0" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="contenedorSuperior">
                <div class="contenedors1">
                    <div class="cabeceraTitulo">
                        <div class="recuadroTitulo">
                            Dietas
                        </div>
                        <div class="recuadroLogo">
                            <img alt="" src="../images/dietaslogo.png" style="width:90%; height:100%" />
                        </div>
                    </div>
                    <div class="recuadroFiltro">
                        <div class="filtroTitulo">
                            Seleccione una edad para mostrar resultados
                        </div>
                        <div class="filtroCentro">
                            <br />                            
                            <asp:DropDownList CssClass="drpRangos" ID="drpRangos" runat="server" OnSelectedIndexChanged="drpRangos_SelectedIndexChanged"></asp:DropDownList>                           
                        </div>
                        <div class="filtroFooter">
                            <asp:Button CssClass="boton" ID="btnAplicar" runat="server" Text="Aplicar" OnClick="btnAplicar_Click" />
                            <asp:Button CssClass="boton" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                        </div>
                    </div>
                </div>
                <div class="contenedors2">
                    <div style="width:95%; height:95%; margin:2%;">
                        <img style="width:100%; height:100%; border-radius:5%;" alt="" src="../images/comida.jpg" />
                    </div>
                </div>
                <div class="contenedors3">
                    <div class="textoFlotante">
                        <asp:Label ID="lblMensajeFlotante" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="contenedorInferior">
                <div class="carta">
                    <div class = "card">
                        <img src="../images/comida6.jpg" alt="">
                        <div class="card-content">
                          <h2 style="color:#450425">
                            Desayuno
                          </h2>
                          <p>
                              <asp:Label CssClass="label" ID="lblComida1" runat="server" Text="Comida 1"></asp:Label>
                          </p>
                          <a href="#" class="button">
                            <span class="material-symbols-outlined">
                              arrow_right_alt
                            </span>
                          </a>
                        </div>
                    </div>
                </div>        
                <div class="carta">
                    <div class = "card">
                        <img src="../images/comida2.jpg" alt="">
                        <div class="card-content">
                          <h2>
                            Merienda
                          </h2>
                          <p>
                            <asp:Label CssClass="label" ID="lblComida2" runat="server" Text="Comida 2"></asp:Label>                  
                          </p>
                          <a href="#" class="button">
                            <span class="material-symbols-outlined">
                              arrow_right_alt
                            </span>
                          </a>
                        </div>
                    </div>
                </div>        
                <div class="carta">
                    <div class = "card">
                        <img src="../images/comida3.jpg" alt="">
                        <div class="card-content">
                          <h2 style="color:#450425">
                            Medio dia
                          </h2>
                          <p>
                            <asp:Label CssClass="label" ID="lblComida3" runat="server" Text="Comida 3"></asp:Label>
                          </p>
                          <a href="#" class="button">
                            <span class="material-symbols-outlined">
                              arrow_right_alt
                            </span>
                          </a>
                        </div>
                    </div>
                </div>        
                <div class="carta">
                    <div class = "card">
                        <img src="../images/comida1.jpg" alt="">
                        <div class="card-content">
                          <h2>
                            Merienda
                          </h2>
                          <p>
                            <asp:Label CssClass="label" ID="lblComida4" runat="server" Text="Comida 4"></asp:Label>
                          </p>
                          <a href="#" class="button">
                            <span class="material-symbols-outlined">
                              arrow_right_alt
                            </span>
                          </a>
                        </div>
                    </div>
                </div>        
                <div class="carta">
                    <div class = "card">
                        <img src="../images/comida4.jpg" alt="">
                        <div class="card-content">
                          <h2 style="color:#450425">
                            Cena
                          </h2>
                          <p>
                            <asp:Label CssClass="label" ID="lblComida5" runat="server" Text="Comida 5"></asp:Label>
                          </p>
                          <a href="#" class="button">
                            <span class="material-symbols-outlined">
                              arrow_right_alt
                            </span>
                          </a>
                        </div>
                    </div>
                </div>        
                <div class="carta">
                    <div class = "card">
                        <img src="../images/comida5.jpg" alt="">
                        <div class="card-content">
                          <h2>
                            Noche
                          </h2>
                          <p>
                            <asp:Label CssClass="label" ID="lblComida6" runat="server" Text="Comida 6"></asp:Label>
                          </p>
                          <a href="#" class="button">
                            <span class="material-symbols-outlined">
                              arrow_right_alt
                            </span>
                          </a>
                        </div>
                    </div>
                </div>        
            </div>
        </div>
    </form>
</asp:Content>
