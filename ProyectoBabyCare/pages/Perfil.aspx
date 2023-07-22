<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="ProyectoBabyCare.pages.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
        <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
    <link href="../styles/PaginaUsuarios/Perfil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <form runat="server">

         <div class="title">
             <h2>Mi perfil</h2>
         </div>
        <div class="contendor" style="margin-top:200px"> 


        
      <div class="container rounded bg-white mt-5 mb-5 container-con-borde">
    <div class="row">
    
        <div class="col-md-5 border-right contenedor2">
            <div class="p-3 py-5">
              




       <div class="mb-3 mt-3">
           <label class="form_label"  style="color:#3399CC" for="Nombre">Nombre</label>
      <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>

      
            
    </div>


      <div class="mb-3 mt-3">
          <label class="form_label"style="color:#3399CC" for="Apellidos">Apellidos</label>
       <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
      

    </div>


      <div class="mb-3 mt-3">
           <label class="form_label"style="color:#3399CC" for="Correo">Correo</label>
      <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="" ReadOnly="true"></asp:TextBox>
     
    </div>


                <div class="mt-2 text-center">
                    <asp:Button Text="Modificar" runat="server" class="btn btn-primary profile-button" type="button" ID="btnModificarDatos" OnClick="btnModificarDatos_Click"/>
                </div>
            </div>

        </div>
        <div class="col-md-4 conetedor-bebes">
            <div class="p-3 py-5">
                <div style="color:#3399CC" class="d-flex justify-content-between align-items-center experience"><span class="title-bebes">Bebés resgistrados</span><a href="Registrobebe.aspx"  class="border px-1 p-1 add-experience"><i style=""  class="fa fa-plus"></i>&nbsp; Bebé</a></div><br>
                <div class="col-md-12">
                    <asp:DropDownList ID="dropbebes" runat="server" CssClass="form-controlddl" AutoPostBack="true" OnSelectedIndexChanged="dropbebes_SelectedIndexChanged">

                    </asp:DropDownList>

                </div> <br>
                <div class="mt-5 text-center">
                    <asp:Button Text="Administrar Familiares" runat="server" class="btn btn-primary profile-buttonddl" type="submit" ID="btnAdministrarFamiliares" OnClick="btnAdministrarFamiliares_Click"/>
                   
                </div>

                <div class="mt-2 text-center">



                           <!--Boton-->
    <div class="btn btn-primary profile-buttonddl boton-modal" runat="server" id="boton">
     
        <label for="btn-modal">
            Código Bebé
        </label>
    </div>
<!--Fin de Boton-->
<!--Ventana Modal-->
    <input type="checkbox" id="btn-modal">
    <div class="container-modal">
        <div class="content-modal">
            <h2>Código Bébe</h2>
       
            <p>
                
                <asp:Label Text="" runat="server" class="label-codigo" ID="lblcodigo" />
            

            </p>
            <div class="btn-cerrar">
                <label  for="btn-modal">Cerrar</label>
            </div>
        </div>
        <label for="btn-modal" class="cerrar-modal"></label>
    </div>
<!--Fin de Ventana Modal-->

                </div>
         

            </div>
        </div>
        



    </div>

                    <div class="image-containerRight">
  <div class="image-wrapper">
    <img src="/images/imgperfil1.png" alt="Imagen adicional">
  </div>
</div>






</div>
            

</div>






    </form>
    
            
</asp:Content>
