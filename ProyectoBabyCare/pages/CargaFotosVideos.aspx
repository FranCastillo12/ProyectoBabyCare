<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="CargaFotosVideos.aspx.cs" Inherits="ProyectoBabyCare.pages.CargaFotosVideos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">  
     <link href="https://fonts.googleapis.com/css2?family=Baloo+2:wght@400;700&display=swap" rel="stylesheet">
    <link href="../styles/PaginaUsuarios/CargaFotosVideos.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/3042a3f9c6.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.1/dist/js/bootstrap.min.js" integrity="sha384-Rx+T1VzGupg4BHQYs2gCW9It+akI2MM/mndMCy36UVfodzcJcF0GGLxZIzObiEfa" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">     
    <form id="form1" runat="server">            
        <div class="contenedor">
            <div class="contenedorSuperior">
                <div class="contenedorSuperiorIzquierda">
                    <div class="csi1">
                        Carga de fotos y videos
                    </div>
                </div>
                <div class="contenedorSuperiorDerecha">
                    <div class="btnContent">
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />                     
                        <br />
                        <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Cargar archivo" OnClick="Button1_Click" />                        
                    </div>
                    <div style="border-left:solid; border-left-color:#F495B6" class="lblContent">
                        <br />
                        <asp:Label ID="lblNombre" runat="server" Text="No tienes un bebé seleccionado"></asp:Label>   
                        <br />
                        <asp:Label ID="lblEdad" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="imgContent">
                        <div class="imgPerfil">
                            <asp:Image ID="fotoPerfi" ImageUrl="../images/Bebe.jpg" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="contenedorInferior">               
                <span class="linea"></span>

                 <section class="galeria">
                     <div id="galleryContainer" runat="server"></div>
                 </section>

                <div id="lightboxContainer" runat="server"></div>
                
                <article class="light-box" id="image6">
                   <%-- <a href="#image5" class="next"><i class="fa-solid fa-arrow-left"></i></a>
                    <img src="../images/bebe6.png" alt="" />
                    <a href="#image1" class="next"><i class="fa-solid fa-arrow-right"></i></a>
                    <a href="#" class="close">X</a>--%>
                </article>
            </div>
        </div>
     </form>   
</asp:Content>