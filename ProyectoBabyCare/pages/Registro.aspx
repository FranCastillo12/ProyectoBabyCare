<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="ProyectoBabyCare.pages.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registro</title>
    <link href="../styles/generales/Registro.css" rel="stylesheet" />
</head>
<body>

              <div class="image-containerleft">
                   <div class="image-wrapperleft">
    &nbsp;<img src="../images/ImageRegistro2.png" alt="Imagen adicional" class="auto-style1">


  </div>
</div>
  <form id="form1" class="form" runat="server">
        <%--<h2 class="form_title">Iniciar Sesion</h2>
        <p class="form_paragraph">aun no tienes cuenta<a href="#" class="form_link">content</a></p>--%>
         <div class="logo">
                    <image id="imgIcon" src="..\..\Images\logo.png" class="logoo" alt="Imagen"></image>
                  </div>

            <div class="form_container"> 
                <div class="form_group">
                    <asp:TextBox runat="server" type="type" name="nombre" class="form_input" placeholder=" "/>
                   
                    <label for="nombre" class="form_label">Nombre</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server"  type="type" name="Apellidos" class="form_input" placeholder=" "/>    
                    <label for="Apellidos" class="form_label">Apellidos</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server" type="text" name="Correo" class="form_input" placeholder=" " />
                    <label for="Correo" class="form_label">Correo</label>
                    <span class="form_line"></span>
                </div>
                  <div class="form_group">
                      <asp:TextBox runat="server" type="text" name="Contrasena" class="form_input" placeholder=" " />
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
