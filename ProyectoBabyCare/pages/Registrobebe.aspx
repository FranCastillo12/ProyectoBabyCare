<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrobebe.aspx.cs" Inherits="ProyectoBabyCare.pages.Registrobebe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width"/>
    <title>Registro bebé</title>
    <link href="../styles/generales/Registro.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
                <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</head>
<body>
              <div class="image-containerleft">
                   <div class="image-wrapperleft">
    &nbsp;<img src="../images/ImageRegistro2.png" alt="Imagen adicional" class="auto-style1">


  </div>
</div>

    <form id="form1" class="form" runat="server" style="margin-top:10px">
        <%--<h2 class="form_title">Iniciar Sesion</h2>
        <p class="form_paragraph">aun no tienes cuenta<a href="#" class="form_link">content</a></p>--%>
         <div class="logo">
                    <image id="imgIcon" src="../Images/logo.png" class="logoo" alt="Imagen"></image>
                  </div>

            <div class="form_container"> 
                <div class="form_group">
                    <asp:TextBox runat="server" type="type" ID="txtNombre" name="nombre" class="form_input" placeholder=" "/>
                   
                    <label for="nombre" class="form_label">Nombre</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server"  type="type" ID="TxtApellidos" name="Apellidos" class="form_input" placeholder=" "/>    
                    <label for="Apellidos" class="form_label">Apellidos</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server" type="date" name="fecha" ID="txtfechadenacimiento" class="form_input" placeholder=" " />
                    <label for="fecha" class="form_label">fecha</label>
                    <span class="form_line"></span>
                </div>
                   <div class="form_group">
                          <asp:DropDownList runat="server" id="ddl_departamentos" CssClass="form_input" AutoPostBack="True">
                              <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                             <asp:ListItem Value="3">Padre</asp:ListItem>
                             <asp:ListItem Value="2">Madre</asp:ListItem>
                        </asp:DropDownList>
                    <label for="Contrasena" class="form_label">Parentezco</label>
                    <span class="form_line"></span>
                </div> 
                 <asp:Button Text="Crear Cuenta" runat="server" CssClass="form_submit" type="submit" ID="btnCrearCuentabebe" OnClick="btnCrearCuentabebe_Click"/>
            </div>
        <hr style="border-top: 2px dashed #DF599D; margin-top: 50px;color:#000000;">
        <div class="contenedor" style="margin-top:20px;">
          <label class="label-codigo">Unirse mediante un código</label>
     </div>
         <div class="form_group" style="margin-top:20px;">
            <asp:TextBox runat="server" ID="txtCodigo" CssClass="normal_input" type="text"  placeholder="Ingrese un código" />
   </div>
       <div class="form_container">
     <asp:Button Text="Unirse" runat="server" CssClass="form_submit1" type="submit" ID="btnUnirseCodigo" OnClick="btnUnirseCodigo_Click"/>

           </div>
    </form>
           <div class="image-containerRight">
            <div class="image-wrapper">
                <img   src="../images/ImageRegistro1.png" alt="Imagen adicional" class="auto-style2">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
             </div>
        </div>

</body>

</html>
