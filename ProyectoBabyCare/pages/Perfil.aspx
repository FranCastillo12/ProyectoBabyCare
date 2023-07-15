<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProyectoBabyCare.pages.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../styles/PaginaUsuarios/Perfil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <form runat="server">

         <div class="title">Mi pzzzzzzzzzzzzzerfil</div>
        <div class="contendor" style="margin-top:200px"> 


        
      <div class="container rounded bg-white mt-5 mb-5 container-con-borde">
    <div class="row">
    
        <div class="col-md-5 border-right contenedor2">
            <div class="p-3 py-5">
              

       <div class="form-floating mb-3 mt-3">

      <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>

      <label class="form_label"  style="color:#3399CC" for="Nombre">Nombre</label>
            <span class="form_line"></span>
    </div>


      <div class="form-floating mb-3 mt-3">
       <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
      <label class="form_label"style="color:#3399CC" for="Apellidos">Apellidos</label>
          <span class="form_line"></span>
    </div>


      <div class="form-floating mb-3 mt-3">
      <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Enter email" ReadOnly="true"></asp:TextBox>
      <label class="form_label"style="color:#3399CC" for="Correo">Correo</label>
          <span class="form_line"></span>
    </div>


                <div class="mt-3 text-center">
                    <button class="btn btn-primary profile-button" type="button">Modificar</button>

                </div>
            </div>
        </div>
        <div class="col-md-4 conetedor-bebes">
            <div class="p-3 py-5">
                <div style="color:#3399CC" class="d-flex justify-content-between align-items-center experience"><span class="title-bebes">Bebés resgistrados</span><span class="border px-3 p-1 add-experience"><i class="fa fa-plus"></i>&nbsp; Bebé</span></div><br>
                <div class="col-md-12">
                    <asp:DropDownList ID="dropbebes" runat="server" CssClass="form-controlddl">

                    </asp:DropDownList>

                </div> <br>
                <div class="mt-5 text-center"><button class="btn btn-primary profile-buttonddl" type="button">Administrar Familiares</button>
                </div>
                <div class="mt-2 text-center"><button class="btn btn-primary profile-buttonddl" type="button">Código Bebé</button></div>
         

            </div>
        </div>
    </div>
</div>
</div>
    </form>
</asp:Content>
