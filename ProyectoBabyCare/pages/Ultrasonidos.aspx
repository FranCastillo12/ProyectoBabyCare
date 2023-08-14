<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="Ultrasonidos.aspx.cs" Inherits="ProyectoBabyCare.pages.Ultrasonidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Ultrasonidos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

     <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" integrity="sha512-iecdLmaskl7CVkqkXNQ/ZH/XLlvWZOJyj7Yy7tcenmpD1ypASozpmT/E0iPtmFIB46ZmdtAc9eNBvH0H/ZpiBw==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <%-- Referencia al archivo de estilos de ultrasonidos --%>
    <link href="../styles/PaginaUsuarios/Ultrasonidos.css" rel="stylesheet" />

    <%-- Referencias a boostrap --%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.4/dist/jquery.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>

    <%-- Referencia para las alertas de ajax  --%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <form runat="server">
        <div class="contenedorr">
            <div class="title">
                Ultrasonidos
            </div>
            <!-- Button to Open the Modal -->
            <button class="profile-buttonddll" type="button" data-toggle="modal" data-target="#myModal" runat="server" id="btnmodal" >
                Agregar
            </button>
            
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

                            <div class="mb-3 mt-3">
                                <label class="form_label" for="Fecha">Fecha</label>
                                <asp:TextBox ID="txtdia" type="date" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                            </div>

                            <div class="mb-3 mt-3">
                                <label class="form_label" for="Descripcion">Descripcion</label>
                                <asp:TextBox ID="txtdescrip" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                            </div>
                            <div class="container">

                                <%--<input type="file" id="file" accept="image/*" hidden>--%>
                                <div class="img-area" id="imgArea" data-img="" runat="server">
                                    <i class='bx bxs-cloud-upload icon'></i>
                                    <h3>Subir imagen</h3>
                                    <p>El tamaño de la imagen no puede superar los <span>2MB</span></p>
                                </div>

                                <%--<asp:FileUpload class="select-image" ClientIDMode="Static"  runat="server" ID="file" accept="image/*"/>--%>
                                <div class="jd">
                                    <label class="mj" style="cursor: pointer;">
                                        Agregar imagen
                        <%--<asp:TextBox type="file" id="file" class="select-image" ClientIDMode="Static" style="display:none" runat="server"/>--%>

                                        <asp:FileUpload ID="file" class="select-image" ClientIDMode="Static" runat="server" Style="display: none;" accept=".jpg,.png" />
                                    </label>
                                </div>
                                <%--<button class="select-image">Select Image</button>--%>
                            </div>
                        </div>

                        <!-- Modal footer -->
                        <div class="modal-footer">
                            <asp:Button Text="Agregar" runat="server" class="profile-buttonddl" type="submit" ID="btnAgrefarUltrasonido" OnClick="btnAgrefarUltrasonido_Click" />
                            <asp:Button Text="Cancelar" runat="server" class="profile-buttonddl" type="button" ID="btncerrar" OnClick="btncerrar_Click" />

                        </div>

                    </div>
                </div>
            </div>

        </div>
        <div id="lstfrmMantenimiento" runat="server" class="contenedor">

            <%--   <div class="card">
            <img src="../images/5-6meses.jpg">
            <h4>Naturaleza</h4>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Vel, excepturi unde?</p>
          
        </div>--%>
        </div>
        <%-- Abrir el modal --%>
        <script type="text/javascript"> 
            function openModal() {
                $('#myModal').modal('show')
            }
        </script>

        <%-- Obtener la imagen --%>
        <script>
            const selectImage = document.querySelector('.select-image');
            const inputFile = document.getElementById('file');
            const imgArea = document.querySelector('.img-area');

            selectImage.addEventListener('click', function () {
                //inputFile.click();
            })
            inputFile.addEventListener('change', function () {
                const image = this.files[0]
                if (image.size < 2000000) {
                    const reader = new FileReader();
                    reader.onload = () => {
                        const allImg = imgArea.querySelectorAll('img');
                        allImg.forEach(item => item.remove());
                        const imgUrl = reader.result;
                        const img = document.createElement('img');
                        img.src = imgUrl;
                        imgArea.appendChild(img);
                        imgArea.classList.add('active');
                        imgArea.dataset.img = image.name;

                    }
                    reader.readAsDataURL(image);
                } else {
                    alert("La imagen no puede ser mayor a 2MB");
                }
            })
        </script>

    </form>
</asp:Content>
