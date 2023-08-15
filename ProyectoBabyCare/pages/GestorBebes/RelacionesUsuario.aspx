<%@ Page Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="RelacionesUsuario.aspx.cs" Inherits="ProyectoBabyCare.pages.GestorBebes.RelacionesUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
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
         <h3 style="color:#A020F0">Relaciones del usuario</h3>      
	     <hr />
         <form runat="server" >           
            <asp:Table ID="tablaUsuarios" runat="server" CssClass="table table-bordered text-center">
                <asp:TableHeaderRow CssClass="table" style="background:RGBA(170, 32, 240, 0.7)">
                    <asp:TableHeaderCell>IdUsuario</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nombre Usuario</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Apellidos Usuario</asp:TableHeaderCell>
                    <asp:TableHeaderCell>IdBebe</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Nombre Bebé</asp:TableHeaderCell>
                    <asp:TableHeaderCell>IdRol</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Rol</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Estado Encargado</asp:TableHeaderCell>            
                    <asp:TableHeaderCell>Acciones</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableFooterRow>
            
                </asp:TableFooterRow>
            </asp:Table>    
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
  <!-- Bootstrap -->
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

</asp:Content>