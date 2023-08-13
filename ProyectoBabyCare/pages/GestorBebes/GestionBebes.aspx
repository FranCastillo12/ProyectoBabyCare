<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="GestionBebes.aspx.cs" Inherits="ProyectoBabyCare.pages.GestorBebes.GestionBebes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Gestión Bebés
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <!-- DATATABLES -->
    <!--  <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/jquery.dataTables.min.css"> -->
    <!-- BOOTSTRAP -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css"/>
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.20/css/dataTables.bootstrap4.min.css"/>
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


     <form runat="server">
     <div class="container" style="margin-top:20px">
   
     <h3 style="color:#A020F0">Bebés</h3>
      
			<hr />
  
     <table id="tablax" class="table table-striped table-bordered" >
        <thead style="background:RGBA(170, 32, 240, 0.6)">
          <th>Nombre</th>
          <th>Fecha registro</th>
          <th>Estado</th>
          <th>Acciones</th>
        </thead>
        <tbody id="lstfrmMantenimiento" runat="server">
            <tr>
                 <td><a></a> href="frmMantenimiento.aspx" </td>
            </tr>
        </tbody>
    </table>



         <asp:Button ID="hiddenBtnActivar" ClientIDMode="Static" runat="server" OnClick="hiddenBtnActivar_Click" style="display: none;" />
              <asp:Button ID="hiddenBtnInactivar" ClientIDMode="Static" runat="server" OnClick="hiddenBtnInactivar_Click" style="display: none;" />
         <input type="hidden" id="hiddenBtnId" runat="server" />
</div>

</form>
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

    <%-- Scripts para manejar los eventos de la tabla --%>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var btnActualizarElements = document.getElementsByClassName('btnActivarClass');

            for (var i = 0; i < btnActualizarElements.length; i++) {
                btnActualizarElements[i].addEventListener('click', function (e) {
                    e.preventDefault();
                    var clickedButtonId = e.target.id; // Recuperar el ID del botón que se hizo clic
                    document.getElementById('<%= hiddenBtnId.ClientID %>').value = clickedButtonId;
                    document.getElementById('<%= hiddenBtnActivar.ClientID %>').click();



               <%-- <%= hiddenBtnEliminar.ClientID %>.click();--%>
                });
            }
        });
    </script>

    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            var btnEliminarElements = document.getElementsByClassName('btnInactivarClass');

            for (var i = 0; i < btnEliminarElements.length; i++) {
                btnEliminarElements[i].addEventListener('click', function (e) {
                    e.preventDefault();

                    var clickedButtonId = e.target.id; // Recuperar el ID del botón que se hizo clic
                    document.getElementById('<%= hiddenBtnId.ClientID %>').value = clickedButtonId;
                    document.getElementById('<%= hiddenBtnInactivar.ClientID %>').click();

               <%-- <%= hiddenBtnEliminar.ClientID %>.click();--%>
                });
            }
        });
    </script>
</asp:Content>
