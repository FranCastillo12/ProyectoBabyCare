<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublic.Master" AutoEventWireup="true" CodeBehind="NombresSignificados.aspx.cs" Inherits="ProyectoBabyCare.NombresSignificados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div style="width: 100%; height: 40%; background-image: url(../images/fondoletras.jpg); background-size: cover; background-position: center;">
        <div style="padding-top: 2%; padding-bottom: 6%; padding-left: 6%; padding-right: 6%;">
            <h1 style="font-family: 'Baloo 2', sans-serif; color: white;">Nombres y Significados
            </h1>
            <h7 style="font-family: 'Baloo 2', sans-serif; color: white; width: 40%">
            ¡La llegada de un bebé es un momento emocionante! Elegir el nombre perfecto es una decisión importante y personal. Aquí encontrarás opciones populares y significativas para inspirarte en esta hermosa elección. ¡Descubre los mejores nombres para tu bebé y déjate llevar por la emoción de darle la bienvenida a tu pequeño tesoro!
            </h7>
        </div>

    </div>

    <div class="container mt-2 ">
        <form runat="server">
            <div class="row" style="">
                <%-- Controles --%>
                <div class="row" style="width: 500px; margin-top: 5%; margin-bottom: 5%">
                    <div style="background-color: white; width: 90px; border-radius: 10%; margin-left: 15%; text-align: center; border: 2.5px solid black;">
                        <div>
                            <img runat="server" src="~/images/gen3.png" style="width: 70px; height: 60px" />
                        </div>
                        <div style="font-size: 20px; font-family: 'Baloo 2', sans-serif;">
                            <asp:Label ID="lbl1" runat="server" Text="Todos"></asp:Label>
                        </div>
                        <div>
                            <asp:RadioButton ID="radioBtn1" runat="server" GroupName="grupoRadios" />
                        </div>
                    </div>
                    <div style="background-color: white; width: 90px; border-radius: 10%; margin-left: 5%; text-align: center; border: 2.5px solid black;">
                        <div>
                            <img runat="server" src="~/images/gen1.png" style="width: 70px; height: 60px" />
                        </div>
                        <div style="font-size: 20px; font-family: 'Baloo 2', sans-serif;">
                            <asp:Label ID="lbl2" runat="server" Text="Niño"></asp:Label>
                        </div>
                        <div>
                            <asp:RadioButton ID="radioBtn2" runat="server" GroupName="grupoRadios" />
                        </div>

                    </div>
                    <div style="background-color: white; width: 90px; border-radius: 10%; margin-left: 5%; text-align: center; border: 2.5px solid black;">
                        <div>
                            <img runat="server" src="~/images/gen2.png" style="width: 70px; height: 60px" />
                        </div>
                        <div style="font-size: 20px; font-family: 'Baloo 2', sans-serif;">
                            <asp:Label ID="lbl3" runat="server" Text="Niña"></asp:Label>
                        </div>
                        <div>
                            <asp:RadioButton ID="radioBtn3" runat="server" GroupName="grupoRadios" />
                        </div>

                    </div>
                    <div style="text-align: center">
                        <div style="margin-top: 5px">
                            <asp:TextBox ID="txtLetra" runat="server" Style="width: 350px" onkeypress="soloLetras(event)" MaxLength="1"></asp:TextBox>
                        </div>
                        <div style="margin-top: 5px; width: 100px; margin-left: 30%">
                            <asp:Button ID="btnBuscar" class="btn btn-primary profile-button" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                        </div>
                    </div>
                </div>
                <%-- Fin row interno --%>


                <%-- Fin controles --%>

                <div class="row" style="width: 60%;">
                    <div style="width: 30%; z-index: 2;">
                        <asp:TextBox runat="server" ID="txtArea" TextMode="MultiLine" Rows="5" Columns="20" ReadOnly="true" CssClass="textareaNombres custom-textbox" />

                    </div>
                    <div style="width: 30%; margin-left: 35%; margin-top: 5%">
                        <img runat="server" src="~/images/osito.png" style="width: 200px; height: 200px" />
                    </div>
                </div>

            </div>

            <%--End Form row --%>
        </form>
        <script type="text/javascript">
            function soloLetras(e) {
                var key = e.keyCode || e.which;
                var tecla = String.fromCharCode(key).toLowerCase();
                var letras = "abcdefghijklmnñopqrstuvwxyz";
                var especiales = "8-37-39-46";

                var tecla_especial = false;
                for (var i in especiales) {
                    if (key == especiales[i]) {
                        tecla_especial = true;
                        break;
                    }
                }

                if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                    e.preventDefault();
                }
            }
        </script>


    </div>

</asp:Content>
