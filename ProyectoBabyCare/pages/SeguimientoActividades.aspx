<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="SeguimientoActividades.aspx.cs" Inherits="ProyectoBabyCare.pages.SeguimientoActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="font-family: 'Baloo 2', sans-serif; margin-top: 1%;">
        <div style="background-color: #F6E0ED; color: mediumblue; text-align: center">
            <h2>Seguimiento de actividades</h2>
        </div>
    </div>

    <form runat="server" style="font-family: 'Baloo 2', sans-serif;">

        <!--Boton-->
        <label for="btn-modal2" class="btn btn-success" style="margin-left: 60%; width: 30%; height: 9%; margin-top: 1%; font-size: 25px;">
            + Actividad
        </label>
        <!--Fin de Boton-->
        <!--Ventana Modal-->
        <input type="checkbox" id="btn-modal2">
        <div class="container-modal2">
            <div class="content-modal2">
                <div style="text-align: center;">
                    <h2 style="color: mediumblue">Agregar actividad</h2>
                </div>

                <%-- Inicio Body --%>
                <div style="text-align: center;">
                    <div>
                        <h3 style="color: mediumblue">Categoría</h3>
                    </div>
                    <div style="width: 40%; margin-left: 30%;">
                        <asp:DropDownList ID="dropcategorias" AutoPostBack="false" CssClass="form-controlddl" runat="server" Style="text-align: center;"></asp:DropDownList>
                    </div>

                </div>
                <div style="text-align: center; padding-left: 10%; padding-right: 10%; padding-bottom: 4%">
                    <asp:TextBox runat="server" ID="txtdescripcionseguimiento" TextMode="MultiLine" Rows="5" Columns="15" CssClass="textareaNombres" Style="width: 100%" />
                </div>
                <div class="row">
                    <div class="divBoton1">
                        <div class="botonesSeguimiento">
                            <asp:Button ID="btnAgregar" class="btn btn-primary profile-button" OnClick="btnAgregar_Click" runat="server" Text="Agregar" />
                        </div>
                    </div>
                </div>
                <%-- Fin body --%>
                <div class="btn-cerrar2">
                    <%--<label  for="btn-modal">Cerrar</label>--%>
                </div>
            </div>
            <label for="btn-modal2" class="cerrar-modal2"></label>
        </div>
        <!--Fin de Ventana Modal-->
        <div class="row">
            <%-- Inicio Categoria --%>
            <div style="width: 30%; margin-left: 10%;">
                <div style="text-align:center">
                    <asp:Label ID="Label1" runat="server" Text="Categoría"></asp:Label>
                </div>
                <asp:DropDownList ID="dropCategoria" CssClass="form-controlddl" runat="server" style="text-align:center"></asp:DropDownList>
            </div>
            <%-- Fin categoria --%>


            <%-- Inicio Fecha1 --%>
            <div style="width: 15%; margin-left: 2%;">
                <div style="text-align:center">
                    <asp:Label ID="Label2" runat="server" Text="Fecha 1"></asp:Label>
                </div>
                <asp:TextBox ID="txtFechaSeguimiento1" runat="server" type="date" placeholder="Fecha" CssClass="form-control"></asp:TextBox>
            </div>
            <%-- Fin fecha1 --%>

            <%-- Inicio Fecha2 --%>
            <div style="width: 15%; margin-left: 8%;">
                <div style="text-align:center">
                    <asp:Label ID="Label3" runat="server" Text="Fecha 2"></asp:Label>
                </div>
                <asp:TextBox ID="txtFechaSeguimiento2" runat="server" type="date" placeholder="Fecha" CssClass="form-control"></asp:TextBox>
            </div>
            <%-- Fin fecha2 --%>


        </div>
        <%-- Fin row --%>
        <div>
            <div class="botonesSeguimiento mt-3" style="width: 30%; margin-left: 20%">
                <asp:Button ID="btnFiltrar" class="btn btn-primary profile-button" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
            </div>
        </div>

        <div class="row" style="margin-top: 1%;">
            <div class="DivTable1">
                <%-- Imagen --%>
                <img runat="server" src="~/images/agenda.jpg" style="width: 100%; border-radius: 10%; padding-top: 1%; padding-bottom: 3%" />
            </div>

            <%-- Table --%>
            <div class="DivTable">
                <div style="color: white; background-color: darkorange; font-size: 25px; opacity: 0.9; text-align: center;">
                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </div>

                <asp:GridView ID="gridseguimiento" runat="server" AutoGenerateColumns="true" CssClass="tabla"></asp:GridView>
            </div>
        </div>
        <%-- Fin row --%>
    </form>
</asp:Content>
