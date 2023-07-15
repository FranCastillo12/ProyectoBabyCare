<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="AdminFamiliares.aspx.cs" Inherits="ProyectoBabyCare.pages.AdminFamiliares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/css/bootstrap.min.css"/>
      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <link href="../styles/PaginaUsuarios/AdminFamiliares.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">
              <div class="title">Administración Familiar</div>


        <div class="contenedor" style="margin-top:150px">
<div class="container rounded bg-white mt-5 mb-5 d-flex justify-content-center align-items-center" >
    <div class="row">
        
        <div class="col-md-5 border-right">
            <div class="container">
  <div class="sub">
    Selecciona el usuario a modificar
  </div>
</div>
            <div class="p-3 py-5" id="divContenedor" runat="server">
              
               
                

                <div class="row mt-3">
      
                                <%--  <div class="col-md-12" id="divContenedor" runat="server"></div>--%>
               
                
                </div>
             
            
            </div>
        </div>
       
        <div class="col-md-5 custom-div d-flex justify-content-center align-items-center mx-auto" id="cambiorol" runat="server">
        
          


                <div class="col-md-12 text-center">
                      <div class="card">
                    <div class="card-header">Cambio de rol</div>
                        <div class="card-main" stryle="margin-top:-30px;">


                      <asp:Label id="lblnombre" Text="text" runat="server" style="margin-top:30px" />
                     <asp:Label id="lblnumerousuario" Text="text" runat="server" Visible="false"/>
                     <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-controll mx-auto" style="width: 160px;height:50px;margin-top:30px" >     
                     </asp:DropDownList>
                                    <div class="dsd" style="margin-top:30px">
                                        <asp:Button Text="Guardar cambios" runat="server" id="btnGuardarCambios" type="button" class="btn btn-primary profile-button" OnClick="btnGuardarCambios_Click" />
                                    </div>
</div>
        </div>
                </div>
    </div>
                 <div class="imagen-dino">   
                <img src="Images/Dinosaurio.png" alt="dino" class="dino" />
            </div>
         <div class="imagen-estrellla">   
                <img src="Images/Estrella.png" alt="estella" class="estella" />
            </div>
</div>
            </div>
            </div>
    </form>
</asp:Content>
