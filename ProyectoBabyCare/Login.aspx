<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoBabyCare.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width/>
    <title>Inicio Sesión</title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
    <link href="styles/generales/Login.css" rel="stylesheet" />
</head>
<body>
            <div class="image-containerleft">
  <div class="image-wrapperleft">
    <img src="images/ImageLogin1.png" alt="Imagen adicional"/>
  </div>
</div>
   <form id="form1" class="form" runat="server">
         <div class="logo">
                    <image id="imgIcon" src="Images\logo.png" class="logoo" alt="Imagen"></image>
                  </div>

            <div class="form_container"> 
                <div class="form_group" style=" margin-top:20px;">
                    <asp:TextBox runat="server" type="type" name="Correo" ID="txtCorreo" class="form_input" placeholder=" "/>
                   
                    <label for="Correo" class="form_label">Correo</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server"  type="type" name="Contrasena" ID="txtContra" class="form_input" placeholder=" "/>    
                    <label for="Contrasena" class="form_label">Contraseña</label>
                    <span class="form_line"></span>
                </div>
                 <asp:Button Text="Iniciar Sesión" runat="server" CssClass="form_submit" type="submit" ID="btnIniciarSesion" OnClick="btnIniciarSesion_Click"/>
                 <asp:Button Text="Crear Cuenta" runat="server" CssClass="form_submit" type="submit" ID="btnCrearCuenta" OnClick="btnCrearCuenta_Click"/>
            </div>  
       <p class="warnings" id="warnings" runat="server"></p>
  
    </form>
    
        <%-- IMAGEN QUE SE COLOCA A LA IZQUIERDA --%>
            <div class="image-containerRight">
  <div class="image-wrapper">
    <img src="images/ImageLogin2.png" alt="Imagen adicional"/>
  </div>
</div>


</body>

</html>
