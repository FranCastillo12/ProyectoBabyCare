<%@ Page Title="" Language="C#" MasterPageFile="~/SitePrivate.Master" AutoEventWireup="true" CodeBehind="PreguntasExpertos.aspx.cs" Inherits="ProyectoBabyCare.pages.PreguntasExpertos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>

    <link href="../styles/PaginaUsuarios/PreguntasExpertos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <form runat="server">

        <div class="title">
            Preguntas
        </div>



        <div class="titlet">
           
        <p id="contenido-cambiante">Estar informado sobre la crianza es esencial para garantizar el bienestar y desarrollo óptimo del bebé en aspectos como salud, alimentación y seguridad.</p>

        </div>






        <div class="bg-light">
            <div class="container">
                <div class="row justify justify-content-center">
                    <div class="col-11 col-md-8 col-lg-6 col-xl-5 contenedor-card">

                        <div class="card">
                            <div class="row mt-0">
                            </div>
                            <div class="form-group row mb-3">
                                <div class="col-md-12 mb-0">
                                    <p class="mb-1 lbl">Pregunta</p>
                                    <asp:TextBox runat="server" ID="txtpregunta" type="text" placeholder="Ingresar tu pregunta" name="pregunta" class="form-control input-box rm-border" />

                                </div>
                            </div>

                            <div class="form-group row justify-content-center mb-0">
                                <div class="col-md-12 px-3">
                                    <asp:Button Text="Preguntar" runat="server" type="submit" class="btn btn-block btn-purple rm-border" ID="btnPreguntar" OnClick="btnPreguntar_Click" />

                                </div>
                            </div>



                            <div class="form-group row">
                                <div class="col-md-12 mb-2">
                                    <p class="mb-1 lbl">Respuesta</p>
                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="4" ID="txtrespuesta" type="text" placeholder="" name="message" class="form-control input-box rm-border" ReadOnly="true" Style="resize: none;"></asp:TextBox>

                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="piePagina">
            <img style="width: 100%; height: 100%" alt="" src="../images/Footer.png" />
        </div>
    </form>


    <%-- Script para estar cambiando el parrafo de forma dinamica --%>

    <script>

        // Lista de contenidos para el párrafo
        const contenidos = [
            "Estar informado sobre la crianza es esencial para garantizar el bienestar y desarrollo óptimo del bebé en aspectos como salud, alimentación y seguridad.",
            "Estar al tanto de la crianza del bebé es vital para su crecimiento saludable y desarrollo, ya que brinda orientación en áreas cruciales como salud, alimentación y estimulación, sentando las bases para un futuro prometedor.",
            "Comprender la crianza del bebé es esencial, ya que proporciona las pautas necesarias para su desarrollo, abarcando áreas como salud, nutrición y atención, lo que sienta las bases para un crecimiento feliz y saludable.",
            "Estar informado sobre crianza infantil es esencial para asegurar un crecimiento saludable y un desarrollo óptimo del bebé, ya que abarca áreas fundamentales como salud, alimentación y cuidados, sentando así las bases de su bienestar a largo plazo.",
            "Comprender la crianza del bebé es esencial para su bienestar, ya que abarca aspectos como salud, nutrición y desarrollo, permitiendo sentar las bases de una infancia sólida y feliz.",
            "Estar bien informado sobre crianza infantil es clave para asegurar un desarrollo saludable del bebé, involucrando áreas como salud, alimentación y afecto, lo que contribuye a sentar las bases de su futuro bienestar.",
            "Saber sobre crianza es vital para el desarrollo del bebé, abarcando salud, alimentación y cuidados, y allanando el camino para un crecimiento feliz y equilibrado."
        ];

        const parrafo = document.getElementById("contenido-cambiante");
        let indiceContenido = 0;

        function cambiarContenido() {
            parrafo.textContent = contenidos[indiceContenido];
            indiceContenido = (indiceContenido + 1) % contenidos.length;
        }

        // Cambiar contenido cada 3 segundos (3000 milisegundos)
        setInterval(cambiarContenido, 20000);
    </script>

</asp:Content>
