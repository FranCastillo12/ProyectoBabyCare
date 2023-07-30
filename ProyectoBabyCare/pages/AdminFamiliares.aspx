<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="AdminFamiliares.aspx.cs" Inherits="ProyectoBabyCare.pages.AdminFamiliares" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
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
    Darle click usuario a modificar
  </div>
</div>
            <div class="p-3 py-5" id="divContenedor" runat="server">
              
                                              <div class="image-containerleft">
  <div class="image-wrapperleft">
    <img src="/images/imgAdminfami.png" alt="Imagen adicional">
  </div>
</div>
                

                <div class="row mt-3">
      
                                <%--  <div class="col-md-12" id="divContenedor" runat="server"></div>--%>
               
                
                </div>
             
            
            </div>
        </div>
       
        <div class="col-md-5 custom-div d-flex justify-content-center align-items-center mx-auto" id="cambiorol" runat="server">
        
          


                <div class="col-md-12 text-center">
                      <div class="card">
                    <div class="card-header">Cambio de rol</div>
                        <div class="card-main" stryle="margin-top:-60%;">


                      <asp:Label id="lblnombre" Text="" runat="server" style="margin-top:30px;font-size:200%" />
                     <asp:Label id="lblnumerousuario" Text="" runat="server" Visible="false"/>
                     <asp:DropDownList runat="server" ID="ddlRoles" CssClass="form-controll mx-auto" style="width: 160px;height:50px;margin-top:30px" >     
                     </asp:DropDownList>
                                    <div class="dsd" style="margin-top:30px">
                                        <asp:Button Text="Guardar cambios" runat="server"  type="button" class="btn btn-primary profile-button" ID="btnGuardar" OnClick="btnGuardar_Click" />
                                    </div>
</div>
        </div>













                </div>
          
      
             



 
    </div>
     
</div>


            </div>
            </div>

   

           
    </form>
    
    


</asp:Content>
