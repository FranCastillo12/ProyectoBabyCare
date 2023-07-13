<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoBabyCare.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Inicio Sesión</title>
    <link href="styles/generales/Login.css" rel="stylesheet" />
</head>
<body>
            <div class="image-containerleft">
  <div class="image-wrapperleft">
    <img src="images/ImageLogin1.png" alt="Imagen adicional">
  </div>
</div>
   <form id="form1" class="form" runat="server">
         <div class="logo">
                    <image id="imgIcon" src="..\..\Images\logo.png" class="logoo" alt="Imagen"></image>
                  </div>

            <div class="form_container"> 
                <div class="form_group">
                    <asp:TextBox runat="server" type="type" name="Correo" class="form_input" placeholder=" "/>
                   
                    <label for="Correo" class="form_label">Correo</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server"  type="type" name="Contrasena" class="form_input" placeholder=" "/>    
                    <label for="Contrasena" class="form_label">Contraseña</label>
                    <span class="form_line"></span>
                </div>
                 <asp:Button Text="Iniciar Sesión" runat="server" CssClass="form_submit" type="submit" ID="Button2"/>
                 <asp:Button Text="Crear Cuenta" runat="server" CssClass="form_submit" type="submit" ID="Button3"/>
            </div>    
    </form>
        <%-- IMAGEN QUE SE COLOCA A LA IZQUIERDA --%>
            <div class="image-containerRight">
  <div class="image-wrapper">
    <img src="images/ImageLogin2.png" alt="Imagen adicional">
  </div>
</div>
</body>
</html>
