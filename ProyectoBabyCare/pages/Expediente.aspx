<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="Expediente.aspx.cs" Inherits="ProyectoBabyCare.pages.Expediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div style="font-family: 'Baloo 2', sans-serif;width: 40%; background-color: #F6E0ED; color: black; margin-top: 7%; margin-bottom: 9%;text-align:center">
            <h3>Expediente de mi tesorito</h3>
        </div>
        <div style="width: 60%;">
            <div class="row">

                    <img runat="server" src="~/images/madre.png" class="imagen1" />

                    <img runat="server" src="~/images/expediente.png" class="imagen2" />

            </div>

        </div>
    </div>
    
    <div class="container mt-3" style="width: 100%;">
        <form runat="server" style="margin-bottom: 5%; background-color: #F6E0ED; padding-top: 2%; padding-bottom: 2%; border-radius: 10%">
            <div style="width: 20%; margin-left: 25%">
                <asp:Button ID="Button2" class="btn btn-primary profile-button" runat="server" Text="Modificar" />
            </div>
            <div class="row">
                <div class="row row1">
                    <div>
                        <asp:Label ID="lblnombre" runat="server" Text="Nombre del bebe"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtnombre" runat="server" ></asp:TextBox>
                    </div>
                    <div style="width: 20%; text-align: center; margin-left: 25%">
                        <asp:Label ID="Label4" runat="server" Text="Peso" ></asp:Label>
                        <div>
                            <asp:TextBox ID="txtPeso"  runat="server" CssClass="txtPeso"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 40%;">
                        <asp:Label ID="Label5" runat="server" Text="Tipo de sangre"></asp:Label>
                        <div>
                            <asp:TextBox ID="txtSangre" runat="server"  CssClass="txt2"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="Label6" runat="server" Text="Nombre de papito"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtpapa" runat="server" ></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label7" runat="server" Text="Nombre de mamita"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="txtmama" runat="server" ></asp:TextBox>
                    </div>

                </div>
                <%-- Detalles,Vacunas,padecimientos --%>
                <div class="row row2">

                    <div class="contenedortxtareas">
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Detalles del embarazo"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtDetalles" TextMode="MultiLine" Rows="5" ReadOnly="true" Columns="20" Text="Sin registros" CssClass="textarea custom-textbox" />
                    </div>

                    <div class="contenedortxtareas">
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Padecimientos"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtPadecimientos" TextMode="MultiLine" Rows="5" ReadOnly="true" Columns="20" Text="Sin registros" CssClass="textarea custom-textbox" />
                    </div>
                    <div class="contenedortxtareas">
                        <div>
                            <asp:Label ID="Label3" runat="server" Text="Historial de vacunas"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtVacunas" TextMode="MultiLine" Rows="5" ReadOnly="true" Columns="20" Text="Sin registros" CssClass="textarea custom-textbox" />
                    </div>
                    <div class="contenedortxtareas">
                        <img runat="server" src="~/images/Expediente.gif" style="width: 90%; height: 90%; text-align: center; border-radius: 10%; margin-top: 4%" />
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
