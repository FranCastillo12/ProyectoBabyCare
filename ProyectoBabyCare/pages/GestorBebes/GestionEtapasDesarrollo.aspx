<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="GestionEtapasDesarrollo.aspx.cs" Inherits="ProyectoBabyCare.pages.GestorBebes.GestionEtapasDesarrollo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Gestión Etapas de Desarrollo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>



 <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <!-- DATATABLES -->
    <!--  <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css"> -->
    <!-- BOOTSTRAP -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css"/>
    






</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
<div class="container" style="margin-top:60px">

    <h3 style="color: #A020F0">Lista de Etapas de desarrollo</h3>

    <hr />
    <%-- <a href="#" class="btn btn-success mb-3"> <i class="fa-solid fa-plus" style="color: #ffffff;"></i> Agregar Etapa de Desarrollo</a>--%>



    <form runat="server">
        <asp:Label Text="1" ID="lblopcion" runat="server" Style="display: none" />

        <!-- Button to Open the Modal -->

        <a href="#" id="btnOpenModal" runat="server" data-toggle="modal" data-target="#myModal" class="btn btn-success mb-3"><i class="fa-solid fa-plus" style="color: #ffffff;"></i>Agregar Etapa de Desarrollo</a>

        <asp:LinkButton class="fa-solid fa-plus" Style="color: #ffffff;" runat="server" />
        <!-- The Modal -->
        <div class="modal fade" id="myModal">
            <div class="modal-dialog">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header" id="custom-modal-header">
                        <h4 class="modal-title">
                            <asp:Label Text="Ingresar Etapa" ID="lblmodal" runat="server" />
                        </h4>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">

                        <div class="mb-3 mt-3 form-control">

                            <asp:DropDownList runat="server" ID="ddlCategoriasEtapas" OnSelectedIndexChanged="ddlCategoriasEtapas_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3 mt-3">
                            <label class="form_label" for="Fecha">Descripcion</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="4" ID="message" type="text" placeholder="" name="message" class="form-control input-box rm-border" Style="resize: none;"></asp:TextBox>

                        </div>

                        <div class="mb-3 mt-3">
                            <label class="form_label" for="Descripcion">URL Imagen</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" ID="urlimagen" type="text" placeholder="" name="message" class="form-control input-box rm-border" Style="resize: none;"></asp:TextBox>


                        </div>


                        <div class="mb-3 mt-3">
                            <label class="form_label" for="Descripcion">Link</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" ID="txtlink" type="text" placeholder="" name="message" class="form-control input-box rm-border" Style="resize: none;"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button Text="Confirmar" runat="server" class="btn btn-primary" type="submit" ID="btnAceptar" OnClick="btnAceptar_Click"/>
                        <asp:Button Text="Cancelar" runat="server" class="btn btn-danger" type="submit" ID="btncerrar" OnClick="btncerrar_Click"/>





                    </div>

                </div>
            </div>
        </div>

        <table id="tablax" class="table table-striped table-bordered">
            <thead style="background: RGBA(170, 32, 240, 0.7)">
                    <th>ID Etapa Desarrollo</th>
                    <th>Categoria</th>
                    <th scope="col">Acciones</th>     
            </thead>
            <tbody id="lstfrmMantenimiento" runat="server">
                <tr>
                    <td><a></a>href="frmMantenimiento.aspx" </td>
                </tr>
            </tbody>
        </table>

        <asp:Button ID="hiddenBtnActualizar" ClientIDMode="Static" runat="server" OnClick="hiddenBtnActualizar_Click" Style="display: none;" />
        <asp:Button ID="hiddenBtnEliminar" ClientIDMode="Static" runat="server"  OnClick="hiddenBtnEliminar_Click" Style="display: none;" />
        <input type="hidden" id="hiddenBtnId" runat="server" />
    </form>
    </div>
    <!-- JQUERY -->
    <script src="https://code.jquery.com/jquery-3.4.1.js"
        integrity="sha256-WpOohJOqMqqyKL9FccASB9O0KwACQJpFTUBLTYOVvVU=" crossorigin="anonymous">
        </script>
    <!-- DATATABLES -->
    <script src="https://cdn.datatables.net/1.10.20/js/jquery.dataTables.min.js">
    </script>
    <!-- BOOTSTRAP -->
    <script src="https://cdn.datatables.net/1.10.20/js/dataTables.bootstrap4.min.js">
    </script>
    <script>
        $(document).ready(function () {
            $('#tablax').DataTable({

                language: {


                    processing: "Tratamiento en curso...",
                    search: "Buscar&nbsp;:",

                    info: "Mostrando del item _START_ al _END_ de un total de _TOTAL_ items",
                    infoEmpty: "No existen datos.",

                    infoFiltered: "(filtrado de _MAX_ elementos en total)",
                    infoPostFix: "",
                    loadingRecords: "Cargando...",
                    zeroRecords: "No se encontraron datos con tu busqueda",
                    emptyTable: "No hay datos disponibles en la tabla.",

                    paginate: {
                        first: "Primero",
                        previous: "Anterior",
                        next: "Siguiente",
                        last: "Ultimo"
                    },
                    aria: {
                        sortAscending: ": active para ordenar la columna en orden ascendente",
                        sortDescending: ": active para ordenar la columna en orden descendente"
                    }

                },
                scrollY: 400,
                lengthChange: false,
                searching: true, // Mantén la búsqueda activada


            });
        });
    </script>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var btnActualizarElements = document.getElementsByClassName('btnActualizarClass');

            for (var i = 0; i < btnActualizarElements.length; i++) {
                btnActualizarElements[i].addEventListener('click', function (e) {
                    e.preventDefault();

                    var clickedButtonId = e.target.id; // Recuperar el ID del botón que se hizo clic
                    document.getElementById('<%= hiddenBtnId.ClientID %>').value = clickedButtonId;
                    document.getElementById('<%= hiddenBtnActualizar.ClientID %>').click();



               <%-- <%= hiddenBtnEliminar.ClientID %>.click();--%>
                });
            }
        });
    </script>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var btnEliminarElements = document.getElementsByClassName('btnEliminarClass');

            for (var i = 0; i < btnEliminarElements.length; i++) {
                btnEliminarElements[i].addEventListener('click', function (e) {
                    e.preventDefault();

                    var clickedButtonId = e.target.id; // Recuperar el ID del botón que se hizo clic
                    document.getElementById('<%= hiddenBtnId.ClientID %>').value = clickedButtonId;
                    document.getElementById('<%= hiddenBtnEliminar.ClientID %>').click();



               <%-- <%= hiddenBtnEliminar.ClientID %>.click();--%>
                });
            }
        });
    </script>


    <!-- Bootstrap -->
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

</asp:Content>