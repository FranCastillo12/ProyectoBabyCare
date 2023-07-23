<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="SaludVacunas.aspx.cs" Inherits="ProyectoBabyCare.pages.SaludVacunas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/SaludVacunas.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <div class="contenedor">
        <div class="contenedorIzquierdo">
            <div class="cabeceraContenedorIzquierda">
                <div class="tituloIzquierda1">
                    Registro de Vacunación
                </div>
                <div class="tituloIzquierda2">
                    <img alt="" style="height:100%; width:100%;" src="../images/Vacuna.png" />
                </div>
            </div>
            <div class="listaVacunas">
                Lista de vacunas
            </div>
            <div class="registrarVacuna">
                <div class="registrarVacunaLogo">
                        <img alt="" style="height:100%; width:100%;" src="../images/flecha1.png" />
                </div>
                <div class="registrarVacunaTexto">
                    <div class="textoRegistrarVacuna">
                        Registrar una nueva
                    </div>
                </div>
            </div>
            <div class="contenedorVacunas">
                <div class="Vacuna">
                    <div class="VacunaLogo">
                        <img alt="" style="height:100%; width:100%;" src="../images/flecha2.png" />
                    </div>
                    <div class="VacunaTexto">
                        <div class="textoNuevaVacuna">
                            <asp:Label ID="lblNuevaVacuna" runat="server" Text="Vacuna 1"></asp:Label>
                        </div>                        
                    </div>
                </div>
            </div>
        </div>
        <div class="contenedorCentro">
            <div class="cabeceraContenedorCentro">
                <div class="tituloCentro">
                    Descripción
                </div>                     
            </div>
            <div class="cuadroVacuna">
                <div class="tituloVacuna">
                    <div class="textoTituloVacuna">
                        <asp:Label ID="lblVacuna" runat="server" Text="Vacuna x"></asp:Label>
                    </div>
                </div>
                <div class="descripcionVacuna">
                    <div class="textoDescripcionVacuna">
                        <asp:Label ID="lblDescripcionVacuna" runat="server" Text="Descripcion x"></asp:Label>
                    </div>
                </div>
                <div class="fechaVacuna">
                    <div class="textoFechaVacuna">
                        <asp:Label ID="lblFechaVacuna" runat="server" Text="Fecha x"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="contenedorDerecho">
            <div class="imagenContenedorDerecha">
                <img style="width:100%; height:100%" alt="" src="../images/Vacunacion.png" />
            </div>
        </div>
        <div class="piePagina">
            <img style="width:100%; height:100%" alt="" src="../images/Footer.png" />
        </div>
    </div>
</asp:Content>