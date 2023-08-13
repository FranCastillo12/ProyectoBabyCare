<%@ Page Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AdminUsuarios.aspx.cs" Inherits="ProyectoBabyCare.pages.AdminUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
  <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-aFq/bzH65dt+w6FI2ooMVUpc+21e0SRygnTpmBvdBgSdnuTN7QbdgL+OapgHtvPp" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" style="margin-top:60px">
     <h3 style="color:#A020F0">Lista de usuarios</h3>      
	 <hr />
     <form runat="server" >
        <!-- Button to Open the Modal -->  
        <a href="#" data-toggle="modal" data-target="#myModal"  class="btn btn-success mb-3"> <i class="fa-solid fa-plus" style="color: #ffffff;"></i> Agregar Etapa de Desarrollo</a>
        <!-- The Modal -->
        <div class="modal fade" id="myModal">
            <div class="modal-dialog">
                <div class="modal-content">      
                    <!-- Modal Header -->
                    <div class="modal-header" id="custom-modal-header">
                        <h4 class="modal-title">Ultrasonidos</h4>
                    </div>        
                    <!-- Modal body -->
                    <div class="modal-body">
                        <div class="mb-3 mt-3 form-control" >                   
                            <asp:DropDownList runat="server">
                                <asp:ListItem Text="text1" />
                                <asp:ListItem Text="text2" />
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3 mt-3">
                        <label class="form_label"  for="Fecha">Descripcion</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="4" ID="message" type="text" placeholder="4" name="message" class="form-control input-box rm-border" ReadOnly="true" style="resize: none;"></asp:TextBox>
                        </div>
                        <div class="mb-3 mt-3">
                            <label class="form_label"  for="Descripcion">URL Imagen</label>
                            <asp:TextBox ID="txtdescrip" runat="server"  placeholder=""></asp:TextBox>
                        </div>           
                        <div class="mb-3 mt-3">
                            <label class="form_label"  for="Descripcion">Link</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                        </div>
                    </div>         
                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button Text="Agregar" runat="server" class="btn btn-primary" type="submit" ID="btnAdministrarFamiliares"  />
                        <asp:Button Text="Cancelar" runat="server" class="btn btn-danger" type="submit" ID="btncerrar"/>
                    </div>        
                </div>
            </div>
        </div>
    </form>
    <table class="table table-bored text-center">
      <thead class="table" style="background:RGBA(170, 32, 240, 0.7)">
        <tr>
          <th scope="col">ID Etapa Desarrollo</th>
          <th scope="col">Categoria</th>
            <th scope="col">Descripcion</th>
          <th scope="col">URL imagen</th>
          <th scope="col">Link</th>
          <th scope="col">Action</th>
        </tr>
      </thead>
      <tbody>
        <?php   
          <tr>
            <td>fdsf</td>
            <td>f</td>
            <td>dsfd</td>
            <td>fds</td>
            <td></td>
            <td>
            <div class="dropdown" >
              <button class="btn btn" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false" style="color:black">
                 <i class="fa-solid fa-user-gear" style="color: #000000;"></i>
                    Opciones
              </button>
              <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                <li><a class="dropdown-item" href="#">Actualizar</a></li>
                <li><a class="dropdown-item" href="#">Eliminar</a></li>
              </ul>
            </div>            
            </td>
          </tr>
      </tbody>
    </table>
  </div>
  <!-- Bootstrap -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.14.3/dist/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.1.3/dist/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>

</asp:Content>
