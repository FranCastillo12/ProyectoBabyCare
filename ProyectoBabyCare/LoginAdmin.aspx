<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="ProyectoBabyCare.LoginAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="styles/generales/LoginAdmin.css" rel="stylesheet" />
      <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" />
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</head>
<body class="main-bg" >
    <form id="form1" runat="server">
         <!-- Login Form -->
  <div class="container">
    <div class="row justify-content-center mt-5">
      <div class="col-lg-4 col-md-6 col-sm-6">
        <div class="card shadow">
          <div class="card-title text-center border-bottom">
            <h2 class="p-3">Gestor de Bebés</h2>
          </div>
          <div class="card-body">
            <form>
              <div class="mb-4">
                <label for="username" class="form-label">Correo</label>
                  <asp:TextBox runat="server" type="text" class="form-control" id="username"  />
              </div>
              <div class="mb-4">
                <label for="password" class="form-label">Contraseña</label>
                  <asp:TextBox runat="server" type="password" class="form-control" id="password"  />
              </div>
              <div class="d-grid">
                  <asp:Button Text="Iniciar Sesión" runat="server" type="submit" class="btn text-light main-bg" ID="btnIniciarSesion" OnClick="btnIniciarSesion_Click" />
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
    </form>
</body>
</html>
