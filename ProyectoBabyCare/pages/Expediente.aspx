<%@ Page Title="Expediente y medicacion" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="Expediente.aspx.cs" Inherits="ProyectoBabyCare.pages.Expediente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/NombresSignificados.css" rel="stylesheet" />
         <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div style="font-family: 'Baloo 2', sans-serif; width: 40%; background-color: #F6E0ED; color: black; margin-top: 7%; margin-bottom: 9%; text-align: center">
            <h3>Expediente de mi tesorito</h3>
        </div>
        <div style="width: 60%;">
            <div class="row">

                <img runat="server" src="~/images/madre.png" class="imagen1" />

                <img runat="server" src="~/images/expediente.png" class="imagen2" />

            </div>

        </div>
    </div>

        <form runat="server" style="margin-bottom: 5%; background-color: #F6E0ED; padding-top: 2%; padding-bottom: 2%; border-radius: 10%">

            <div class="row">
                <div class="row row1">
                    <div>
                        <asp:Label ID="lblnombre" runat="server" Text="Nombre del bebe"></asp:Label>
                    </div>
                    <div style="width: 50%; margin-left: 20%;">
                        <asp:TextBox ID="txtnombre" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div style="width: 20%; text-align: center; margin-left: 25%">
                        <asp:Label ID="Label4" runat="server" Text="Peso"></asp:Label>
                        <div>
                            <asp:TextBox ID="txtPeso" runat="server" CssClass="txtPeso form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 40%;">
                        <asp:Label ID="Label5" runat="server" Text="Tipo de sangre"></asp:Label>
                        <div>
                            <asp:TextBox ID="txtSangre" runat="server" CssClass="txt2 form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="Label6" runat="server" Text="Nombre de papito"></asp:Label>
                    </div>
                    <div style="width: 50%; margin-left: 20%;">
                        <asp:TextBox ID="txtpapa" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label7" runat="server" Text="Nombre de mamita"></asp:Label>
                    </div>
                    <div style="width: 50%; margin-left: 20%;">
                        <asp:TextBox ID="txtmama" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div style="width: 20%; text-align: center; margin-left: 20%">
                        <asp:Label ID="Label9" runat="server" Text="Estatura"></asp:Label>
                        <div>
                            <asp:TextBox ID="txtestatura" runat="server" CssClass="txtPeso form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 60%;">
                        <asp:Label ID="lblfecha" runat="server" Text="FechaNacimiento"></asp:Label>
                        <div>
                            <asp:TextBox ID="txtfecha" ReadOnly="true" runat="server" CssClass="txt2 form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 40%;margin-left:20%">
                        <asp:Label ID="Label8" runat="server" Text="Cédula"></asp:Label>
                        <div style="text-align:center">
                            <asp:TextBox ID="txtcedula" runat="server" CssClass="form-control" style="width:90%"></asp:TextBox>
                        </div>
                    </div>
                    <div style="width: 25%;">
                        <asp:Label ID="Label10" runat="server" Text="Género"></asp:Label>
                        <div>
                            <asp:DropDownList ID="dopgenero" AutoPostBack="true" CssClass="form-controlddl" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div style="width: 30%; margin-left: 25%;margin-top:2%">
                        <asp:Button ID="btnModificar" class="btn btn-primary profile-button" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                    </div>

                </div>
                <%-- Detalles,Vacunas,padecimientos --%>
                <div class="row row2">

                    <div class="contenedortxtareas">
                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Detalles del embarazo"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtDetalles" TextMode="MultiLine" Rows="5" ReadOnly="true" Columns="20" Text="Sin registros" CssClass="textarea custom-textbox" />
                        <%-- Agregar detalle --%>
                        <div style="width: 45%; margin-left: 15%;">
                            <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripcion" CssClass="form-controlinterno"></asp:TextBox>
                        </div>
                        <div style="width: 45%; margin-left: 15%; margin-top: 1%">
                            <asp:TextBox ID="txtFechaDetalle" runat="server" placeholder="Fecha" type="date" CssClass="form-controlinterno"></asp:TextBox>
                        </div>
                        <div style="text-align: center; width: 50%; font-size: 60%; margin-top: 1%">
                            <asp:Button ID="btnAgregarDetalle" class="btn btn-primary profile-button" runat="server" OnClick="btnAgregarDetalle_Click" Text="Agregar detalle" />
                        </div>
                    </div>

                    <div class="contenedortxtareas">
                        <div>
                            <asp:Label ID="Label1" runat="server" Text="Padecimientos"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtPadecimientos" TextMode="MultiLine" Rows="5" ReadOnly="true" Columns="20" Text="Sin registros" CssClass="textarea custom-textbox" />
                        <%-- Padecimientos --%>
                        <div style="width: 90%; margin-left: 10%;">
                            <asp:DropDownList ID="dpllPadecimientos" runat="server" AutoPostBack="true" CssClass="form-controlinterno form-controlddl"></asp:DropDownList>
                        </div>
                        <div style="text-align: center; width: 60%; font-size: 50%; margin-top: 1%;">
                            <asp:Button ID="btnagregarpadecimientos" class="btn btn-primary profile-button" runat="server" OnClick="btnagregarpadecimientos_Click" Text="Agregar padecimiento" />
                        </div>
                    </div>
                    <div class="contenedortxtareas">
                        <div>
                            <asp:Label ID="Label3" runat="server" Text="Historial de vacunas"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="txtVacunas" TextMode="MultiLine" Rows="5" ReadOnly="true" Columns="20" Text="Sin registros" CssClass="textarea custom-textbox" />

                    </div>
                    <div class="contenedortxtareas">
                        <img runat="server" src="~/images/Expediente.gif" style="width: 100%; height: 95%; text-align: center; border-radius: 10%; margin-top: 4%" />
                    </div>
                </div>
            </div>
        </form>
</asp:Content>
