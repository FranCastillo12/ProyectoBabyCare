﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrobebe.aspx.cs" Inherits="ProyectoBabyCare.pages.Registrobebe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registro bebé</title>
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
                      <asp:TextBox runat="server" type="date" name="fecha" class="form_input" placeholder=" " />
                    <label for="fecha" class="form_label">fecha</label>
                    <span class="form_line"></span>
                </div>
                 <asp:Button Text="Crear Cuenta" runat="server" CssClass="form_submit" type="submit" ID="btnCrearCuentabebe" OnClick="btnCrearCuentabebe_Click"/>
            </div>
        <hr style="border-top: 4px dashed #DF599D; margin-top: 50px;color:">
        <div class="contenedor" style="margin-top:20px;">
          <label class="label-codigo">Unirse mediante un código</label>
     </div>
         <div class="form_group" style="margin-top:20px;">
            <asp:TextBox runat="server" ID="TextBox2" CssClass="normal_input" type="text"  placeholder="Ingrese un código" />
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
