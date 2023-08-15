<%@ Page Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="ProyectoBabyCare.pages.ControlPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/ControlPanel.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Baloo+2:wght@400;700&display=swap" rel="stylesheet">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="contenedor">
            <div class="contenedor1">
                <div class="cabeceraContenedor1">
                    <div class="tituloIzquierda1" style="font-family: 'Baloo 2', sans-serif">
                        Panel de Control
                    </div>                    
                </div>
                <div class="notificacion1">
                    <asp:Label ID="lblNotificacion1" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="notificacion1">
                    <asp:Label ID="lblNotificacion2" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="notificacion1">
                    <asp:Label ID="lblNotificacion3" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="contenedor2">
                <div class="recuadroBebe">
                    <img class="imagenBebe" id="imagenBebe" alt="" src="../images/bebe1.jpg" />
                    <%--<asp:Image CssClass="imagenBebe" ID="fotoBebes" runat="server" />--%>
                </div>
                <script>                                                            
                    var imageUrls = <%= ImageUrlsArray %>;                    
                    let indiceImagen = 0;
                    const intervaloTiempo = 7000; //7 segundos para cambiar

                    // Función para cambiar la imagen
                    function cambiarImagen() {
                        console.log("Cambiando imagen...");
                        const imagenBebe = document.getElementById("imagenBebe");
                        imagenBebe.src = imageUrls[indiceImagen];

                        // Incrementa el índice para mostrar la siguiente imagen
                        indiceImagen = (indiceImagen + 1) % imageUrls.length;
                    }

                    // Iniciar el intervalo cuando la página se carga
                    window.onload = function () {
                        cambiarImagen(); // Mostrar la primera imagen inmediatamente
                        setInterval(cambiarImagen, intervaloTiempo);
                    };
                </script>
                <%--   <script type="text/javascript">
                      // Arreglo con las URLs de las imágenes a mostrar
                    const imagenes = [
                          "../images/bebe1.jpg",
                          "../images/bebe2.jpg",                                                                              
                          "../images/bebe6.png",
                          "../images/bebe7.jpg",                                                    
                      ];

                      let indiceImagen = 0;
                      const intervaloTiempo = 7000; //7 segundos para cambiar

                      // Función para cambiar la imagen
                      function cambiarImagen() {
                          const imagenBebe = document.getElementById("imagenBebe");
                          imagenBebe.src = imagenes[indiceImagen];

                          // Incrementa el índice para mostrar la siguiente imagen
                          indiceImagen = (indiceImagen + 1) % imagenes.length;
                      }

                      // Iniciar el intervalo cuando la página se carga
                      window.onload = function () {
                          cambiarImagen(); // Mostrar la primera imagen inmediatamente
                          setInterval(cambiarImagen, intervaloTiempo);
                      };
                </script>--%>
                <div class="recuadroDatosBebe">
                    <asp:Label ID="lblNombre" runat="server" Text="Josias Madriz Calderón"></asp:Label>
                    <br />
                    <asp:Label ID="lblEdad" runat="server" Text="   1 año y 7 meses"></asp:Label>
                </div>
            </div>
            <div class="contenedorTransparente">
                <div class="contenedor3">
                    <div class="recuadroConsejo">
                        <asp:Label CssClass="textoConsejo" ID="lblConsejo" runat="server" Text="
                            ¿Sabías que el cuidado amoroso y adecuado es esencial para el desarrollo 
                            saludable de tu bebé?">
                        </asp:Label>                        
                    </div>
                </div>
                <div class="contenedor4">
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion4" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion5" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="notificacion2">
                        <asp:Label ID="lblNotificacion6" runat="server" Text="Label"></asp:Label>
                    </div>
                   <div class="perfil">
                       <asp:Label ID="lblPerfil" runat="server" Text="Perfil de Padre"></asp:Label>
                   </div>
                </div>
            </div>
            
            <div class="piePagina">
                <img style="width:100%; height:100%" alt="" src="../images/Footer.png" />
            </div>
        </div>
    </form>
</asp:Content>