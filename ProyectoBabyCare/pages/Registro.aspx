<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoBabyCare.pages.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registro</title>
    <link href="../styles/generales/registroU.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css" integrity="sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.4.1.slim.min.js" integrity="sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/js/bootstrap.min.js" integrity="sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6" crossorigin="anonymous"></script>
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
  <form id="form1" class="needs-validation form" runat="server" style="margin-top:30px">
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
                      <asp:TextBox runat="server" ID="TxtApellidos"  type="type" name="Apellidos" class="form_input" placeholder=" " required/>    
                    <label for="Apellidos" class="form_label">Apellidos</label>
                    <span class="form_line"></span>
                     
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server" ID="txtCorreo" type="text" name="Correo" class="form_input" placeholder=" " />
                    <label for="Correo" class="form_label">Correo</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server" ID="TxtContra" type="text" name="Contrasena" class="form_input" placeholder=" " />
                    <label for="Contrasena" class="form_label">Contraseña</label>
                    <span class="form_line"></span>
                </div>
                <asp:Button Text="Crear Cuenta" runat="server" CssClass="form_submit" type="submit" ID="btnCrearCuenta" OnClick="btnCrearCuenta_Click"/>
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
