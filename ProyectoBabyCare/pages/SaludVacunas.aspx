<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="SaludVacunas.aspx.cs" Inherits="ProyectoBabyCare.pages.SaludVacunas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/SaludVacunas.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Baloo+2:wght@400;700&display=swap" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
     <div class="contenedor">
        <div class="contenedorIzquierdo">
            <div class="cabeceraContenedorIzquierda">
                <div class="tituloIzquierda1" style="font-family: 'Baloo 2', sans-serif">
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
                        <asp:Button CssClass="botonRegistrar" ID="btnRegistrarNueva" runat="server" Text="Registrar una nueva" OnClick="btnRegistrarNueva_Click" />
                    </div>
                </div>
            </div>
            <div class="contenedorVacunas" runat="server" id="contenedorVacunas">
                
                <%--<div class="Vacuna">
                    <div class="VacunaLogo">
                        <img alt="" style="height:100%; width:100%;" src="../images/flecha2.png" />
                    </div>
                    <div class="VacunaTexto">
                        <div class="textoNuevaVacuna">                            
                            <asp:Button CssClass="btnAceptar" ID="btnVacuna" runat="server" Text="Vacuna 1" OnClick="Button1_Click" />
                        </div>                        
                    </div>
                </div>--%>
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
                        <asp:TextBox CssClass="textbox" ID="txtTitulo" runat="server" MaxLength="200"> Vacuna X</asp:TextBox>
                    </div>
                </div>
                <div class="descripcionVacuna">
                    <div class="textoDescripcionVacuna">                        
                        <asp:TextBox TextMode="MultiLine" Rows="10" CssClass="textboxDescripcion" ID="txtDescripcion" runat="server" MaxLength="500">Descripcion x</asp:TextBox>
                    </div>
                </div>              
                <div class="fechaVacuna">
                    <div class="textoFechaVacuna">                        
                        <%--<asp:TextBox CssClass="textbox" ID="txtFecha" runat="server">Fecha x</asp:TextBox>--%>
                        <asp:TextBox CssClass="textbox" ID="txtFecha" runat="server" type="datetime-local" placeholder="Fecha y hora"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="contenedorDerecho">
            <div class="imagenContenedorDerecha">
                <img style="width:100%; height:100%" alt="" src="../images/Vacunacion.png" />
            </div>
            <div class="botonAceptar">
                <asp:Button CssClass="btnAceptar" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            </div>
            <div class="botonAceptar">
                <asp:Button CssClass="btnAceptar" ID="btnEditar" runat="server" Text="Modificar" OnClick="btnEditar_Click" />
            </div>
            <div class="botonAceptar">
                <asp:Button CssClass="btnAceptar" ID="btnBorrar" runat="server" Text="Borrar" OnClick="btnBorrar_Click" />
            </div>
            <div>
                <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="piePagina">
            <img style="width:100%; height:100%" alt="" src="../images/Footer.png" />
        </div>
    </div>
</form>
</asp:Content>