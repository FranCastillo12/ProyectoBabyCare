<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegundoFactorAuten.aspx.cs" Inherits="ProyectoBabyCare.pages.SegundoFactorAuten" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=0.8" />
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
    <link href="../styles/generales/Login.css" rel="stylesheet" />
</head>
<body>
            <div class="image-containerleft">
  <div class="image-wrapperleft">
    <img src="../images/ImageLogin1.png" alt="Imagen adicional"/>
  </div>
</div>
   <form id="form1" class="form" runat="server">
    <%--     <div class="logo">
                    <image id="imgIcon" src="Images\logo.png" class="logoo" alt="Imagen"></image>
                  </div>--%>
       <h1 style="color:#3399CC">Código de Autentificación</h1>
       <p style="font-size:20px;color:black">Por favor ingrese el código enviado a su correo electrónico</p>
            <div class="form_container"> 
                <div class="form_group">
                    <asp:TextBox runat="server" type="type" name="Código_Verficación" ID="txtCorreo" class="form_input" placeholder=" "/>
                   
                    <label for="Correo" class="form_label">Código de Verficación</label>
                    <span class="form_line"></span>
                </div>

                 <asp:Button Text="Confirmar" runat="server" CssClass="form_submit" type="submit" ID="btnConfirmar" OnClick="btnConfirmar_Click"/>
             
            </div> 
       <hr style="border-top: 2px dashed #DF599D; margin-top: 20px;color:#A020F0;">
      <p style="margin-top:20px;font-size:20px;color:black">¿No recibiste el código? Haz clic en 'Reenviar' para intentarlo de nuevo.</p>
      <asp:Button style="margin-top:20px;" Text="Reenviar" runat="server" CssClass="form_submit" type="submit" ID="btnReenviar" OnClick="btnReenviar_Click"/>
    </form>
    
        <%-- IMAGEN QUE SE COLOCA A LA IZQUIERDA --%>
            <div class="image-containerRight">
  <div class="image-wrapper">
    <img src="../images/ImageLogin2.png" alt="Imagen adicional"/>
  </div>
</div>

   
</body>
    
</html>
