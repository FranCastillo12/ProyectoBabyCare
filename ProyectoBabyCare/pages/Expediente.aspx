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
    <div style="font-family: 'Baloo 2', sans-serif; background-color: #F6E0ED; color: mediumblue; margin-top: 1%; margin-bottom: 1%; text-align: center">
        <div>
            <h2>Expediente de mi tesorito</h2>
        </div>
    </div>
    <div class="row">
        <div style="width: 15%; background-image: url('../images/jugueteslat1.jpg'); background-size: cover; border-radius: 10%" class="imgjuguete1">
        </div>
        <div style="width: 70%;">
            <form runat="server" class="Formulario-Expediente">

                <div class="row">
                    <%-- Datos Basicos del expediente --%>
                    <div class="row row1">
                        <div>
                            <asp:Label ID="lblnombre" runat="server" Text="Nombre del bebe"></asp:Label>
                        </div>
                        <div style="width: 50%; margin-left: 20%;">
                            <asp:TextBox ID="txtnombre" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div style="width: 25%; text-align: center; margin-left: 20%">
                            <asp:Label ID="Label4" runat="server" Text="Peso"></asp:Label>
                            <div>
                                <asp:TextBox ID="txtPeso" runat="server" CssClass="txtPeso form-control" MaxLength="5"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 50%;">
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
                        <div style="width: 25%; text-align: center; margin-left: 20%">
                            <asp:Label ID="Label9" runat="server" Text="Estatura"></asp:Label>
                            <div>
                                <asp:TextBox ID="txtestatura" runat="server" CssClass="txtPeso form-control" MaxLength="5"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 50%;">
                            <asp:Label ID="lblfecha" runat="server" Text="FechaNacimiento"></asp:Label>
                            <div>
                                <asp:TextBox ID="txtfecha" ReadOnly="true" runat="server" CssClass="txt2 form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 40%; margin-left: 20%">
                            <asp:Label ID="Label8" runat="server" Text="Cédula"></asp:Label>
                            <div style="text-align: center">
                                <asp:TextBox ID="txtcedula" runat="server" CssClass="form-control" Style="width: 95%"></asp:TextBox>
                            </div>
                        </div>
                        <div style="width: 35%;">
                            <asp:Label ID="Label10" runat="server" Text="Género"></asp:Label>
                            <div>
                                <asp:DropDownList ID="dopgenero" AutoPostBack="true" CssClass="form-controlddl" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div style="width: 40%; margin-left: 20%; margin-top: 2%">
                            <asp:Button ID="btnModificar" class="btn btn-primary profile-button" runat="server" OnClick="btnModificar_Click" Text="Modificar" />
                        </div>

                    </div>


                    <%-- Detalles,Vacunas,padecimientos --%>
                    <div class="row2">

                        <!--Boton-->

                        <label for="btn-modal1" class="btn btn-primary" style="width: 90%; height: 9%; margin-top: 2%">
                            Ver Detalles del embarazo
                        </label>

                        <!--Fin de Boton-->
                        <!--Ventana Modal-->
                        <input type="checkbox" id="btn-modal1">
                        <div class="container-modal1">
                            <div class="content-modal1">
                                <h2 style="color: mediumblue">Detalles del embarazo</h2>
                                <%-- Inicio Body --%>
                                <%-- Detalles del embarazo --%>
                                <div class="DivTableExpediente">
                                    <div style="color: white; background-color: cornflowerblue; font-size: 25px; opacity: 0.9; text-align: center;">
                                        <asp:Label ID="lblMensaje1" runat="server" Text="Sin registros"></asp:Label>
                                    </div>
                                    <asp:GridView ID="griddetalles" runat="server" AutoGenerateColumns="true" CssClass="tabla2"></asp:GridView>
                                </div>
                                <div style="width: 45%; margin-left: 15%;">
                                    <asp:TextBox ID="txtDescripcion" runat="server" placeholder="Descripcion" CssClass="form-controlinterno"></asp:TextBox>
                                </div>
                                <div style="width: 45%; margin-left: 15%; margin-top: 1%">
                                    <asp:TextBox ID="txtFechaDetalle" runat="server" placeholder="Fecha" type="date" CssClass="form-controlinterno"></asp:TextBox>
                                </div>
                                <div style="text-align: center; width: 50%; font-size: 60%; margin-top: 1%">
                                    <asp:Button ID="btnAgregarDetalle" class="btn btn-primary profile-button" runat="server" OnClick="btnAgregarDetalle_Click" Text="Agregar detalle" />
                                </div>


                                <%-- Fin body --%>
                                <div class="btn-cerrar1">
                                    <%--<label  for="btn-modal">Cerrar</label>--%>
                                </div>
                            </div>
                            <label for="btn-modal1" class="cerrar-modal1"></label>
                        </div>
                        <!--Fin de Ventana Modal-->

                        <!--Boton-->

                        <label for="btn-modal2" class="btn btn-primary" style="width: 90%; height: 9%; margin-top: 2%">
                            Ver padecimientos
                        </label>

                        <!--Fin de Boton-->
                        <!--Ventana Modal-->
                        <input type="checkbox" id="btn-modal2">
                        <div class="container-modal2">
                            <div class="content-modal2">
                                <h2 style="color: mediumblue">Padecimientos</h2>
                                <%-- Inicio Body --%>
                                <%-- Padecimientos --%>
                                <div class="DivTableExpediente">
                                    <div style="color: white; background-color: cornflowerblue; font-size: 25px; opacity: 0.9; text-align: center;">
                                        <asp:Label ID="lblMensaje2" runat="server" Text="Sin registros"></asp:Label>
                                    </div>
                                    <asp:GridView ID="gridpadecimientos" runat="server" CssClass="tabla2"></asp:GridView>
                                </div>

                                <div style="width: 90%; margin-left: 10%;">
                                    <asp:DropDownList ID="dpllPadecimientos" runat="server" AutoPostBack="true" CssClass="form-controlinterno form-controlddl"></asp:DropDownList>
                                </div>
                                <div style="text-align: center; width: 60%; font-size: 50%; margin-top: 1%;">
                                    <asp:Button ID="btnagregarpadecimientos" class="btn btn-primary profile-button" runat="server" OnClick="btnagregarpadecimientos_Click" Text="Agregar padecimiento" />
                                </div>
                                <%-- Fin body --%>
                                <div class="btn-cerrar2">
                                    <%--<label  for="btn-modal">Cerrar</label>--%>
                                </div>
                            </div>
                            <label for="btn-modal2" class="cerrar-modal2"></label>
                        </div>
                        <!--Fin de Ventana Modal-->


                        <!--Boton-->

                        <label for="btn-modal3" class="btn btn-primary" style="width: 90%; height: 9%; margin-top: 2%">
                            Ver vacunas
                        </label>

                        <!--Fin de Boton-->
                        <!--Ventana Modal-->
                        <input type="checkbox" id="btn-modal3">
                        <div class="container-modal3">
                            <div class="content-modal3">
                                <h2 style="color: mediumblue">Vacunas</h2>
                                <%-- Inicio Body --%>
                                <%-- Vacunas --%>
                                <div class="DivTableExpediente">
                                    <div style="color: white; background-color: cornflowerblue; font-size: 25px; opacity: 0.9; text-align: center;">
                                        <asp:Label ID="lblMensaje3" runat="server" Text="Sin registros"></asp:Label>
                                    </div>
                                    <asp:GridView ID="gridvacunas" runat="server" AutoGenerateColumns="true" CssClass="tabla2"></asp:GridView>
                                </div>


                                <%-- Fin body --%>
                                <div class="btn-cerrar3">
                                    <%--<label  for="btn-modal">Cerrar</label>--%>
                                </div>
                            </div>
                            <label for="btn-modal3" class="cerrar-modal3"></label>
                        </div>
                        <!--Fin de Ventana Modal-->
                        <div style="margin-top: 2%">
                            <%-- Imagen Ilustrativa --%>
                            <img runat="server" src="~/images/Expediente.gif" style="width: 80%; height: 80%; border-radius: 10%;" />
                        </div>

                    </div>


                </div>
            </form>
        </div>
        <div style="width: 15%; background-image: url('../images/jugueteslat1.jpg'); background-size: cover; border-radius: 10%" class="imgjuguete2">
        </div>
    </div>



</asp:Content>
