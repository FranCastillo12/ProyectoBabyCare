<%@ Page Title="Alertas" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="AlertasUsuario.aspx.cs" Inherits="ProyectoBabyCare.pages.AlertasUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/Alertillas.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="background-color: #F6E0ED; color: mediumblue; margin-top: 1%; text-align: center;font-family: 'Baloo 2', sans-serif">Alertitas</h1>

    <div class="row">
        <div class="ImagenBorde1">
        </div>
        <form id="form1" class="Datagrid" runat="server">
            <!--Boton-->

            <div class="row" style="font-family: 'Baloo 2', sans-serif; width: 90%; margin-left: 5%; text-align: center">
                <label for="btn-modal2" class="btn btn-success" style="width: 100px; height: 9%; margin-top: 1%; margin-bottom: 1%; font-size: 15px;">
                    + Alerta
                </label>
                <div style="width: 40%">
                    <asp:DropDownList ID="dropCategorias1" runat="server"></asp:DropDownList>
                </div>
                <div class="botonesSeguimiento">
                    <asp:Button ID="btnFiltrar" class="btn profile-button" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
                </div>

            </div>

            <!--Fin de Boton-->
            <!--Ventana Modal-->
            <input type="checkbox" id="btn-modal2">
            <div class="container-modal2">
                <div class="content-modal2">
                    <div style="text-align: center;">
                        <%--<h2 style="color: mediumblue">Agregar actividad</h2>--%>
                    </div>

                    <%-- Inicio Body --%>
                    <div style="text-align: center;">
                        <div>
                            <h3 style="color: mediumblue">Categoría</h3>
                        </div>
                        <div style="width: 40%; margin-left: 30%;">
                            <asp:DropDownList ID="dropcategorias" AutoPostBack="false" CssClass="form-controlddl" runat="server" Style="text-align: center;"></asp:DropDownList>
                        </div>
                        <div class="row">
                            <div style="width: 40%; margin-left: 5%; background-image: url(../images/relojes1.png); background-size: cover; border-radius: 10%">
                            </div>
                            <div id="Formulario" style="width: 50%">
                                <div style="text-align: center; padding-left: 10%; padding-right: 10%; padding-bottom: 2%; padding-top: 2%">
                                    <asp:TextBox runat="server" ID="txtDescripcionAlerta" TextMode="MultiLine" Rows="5" Columns="15" Style="width: 100%; resize: none;" MaxLength="100" />
                                </div>
                                <div>
                                    <asp:TextBox ID="txthora" type="time" runat="server"></asp:TextBox>
                                </div>
                                <div class="mt-2">
                                    <asp:Button ID="btnAgregar" runat="server" class="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
                                </div>
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
            <div style="text-align: center">
                <div>
                    <asp:GridView ID="GridViewAlertas" runat="server" AutoGenerateColumns="False" DataKeyNames="idAlerta" Style="background-image: url('../images/relojes2.png'); background-size: cover;">
                        <Columns>
                            <asp:BoundField DataField="HoraAlerta" HeaderText="Hora" HeaderStyle-CssClass="header-style" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" HeaderStyle-CssClass="header-style" />
                            <asp:TemplateField HeaderText="Estado" HeaderStyle-CssClass="header-style">
                                <ItemTemplate>
                                    <div style='background-color: <%# Convert.ToBoolean(Eval("Estado")) ? "#63fa34" : "#f8324f" %>; color: <%# Convert.ToBoolean(Eval("Estado")) ? "black" : "white" %>; text-align: center; border-radius: 0%; border: 1px solid black;'>
                                        <asp:CheckBox Style="" ID="CheckBox1" runat="server" Checked='<%# Convert.ToBoolean(Eval("Estado")) %>'
                                            OnCheckedChanged="CheckBoxEstado_CheckedChanged" Width="90%" Text='<%# Convert.ToBoolean(Eval("Estado")) ? "Activa." : "Inactiva" %>' AutoPostBack="true" />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Categoria" HeaderText="Categoría" HeaderStyle-CssClass="header-style" />
                            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="header-style">
                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" Text="Eliminar" class="btn btn-danger" OnClick="Eliminar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="header-style" />
                        <RowStyle CssClass="grid-row-style" />
                    </asp:GridView>
                </div>
            </div>
        </form>
        <div class="ImagenBorde2">
        </div>

    </div>
    <div class="footer">
    </div>
</asp:Content>





