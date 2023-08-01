<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublic.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoBabyCare.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/PantallaInicio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Titulo,desc,imagen de cabecera --%>
    <div style="width: 100%; height: 70%; background-image: url(../images/juguetesninio.jpg); background-size: cover; background-position: center;">
        <div style="padding-top: 2%; padding-bottom: 2%; padding-left: 6%; padding-right: 6%;">
            <h1 style="font-family: 'Baloo 2', sans-serif; color: white">BIENVENIDO AL SISTEMA
            </h1>
            <h1 style="font-family: 'Baloo 2', sans-serif; color: #F495B6;">BABY CARE
            </h1>
            <h5 style="font-family: 'Baloo 2', sans-serif; color: white; width: 85%">Este sistema está diseñado especialmente para padres que desean hacer su vida más fácil mientras cuidan y crian a sus hijos.
                Sabemos que ser padre puede ser una tarea desafiante y abrumadora,
                pero estamos aquí para brindarte el apoyo para mejorar tu experiencia como padre o madre. 
            </h5>
        </div>

    </div>
    <%-- Fin de la cabecera --%>
    <%-- Resto del contenido de la pagina --%>
    <div class="row">
        <div style="width: 15%;background-image:url('../images/jugueteslat2.jpg');background-size:cover;">
        </div>
        <div class="row" style="width: 68%; margin-top: 1%; margin-bottom: 1%;margin-left:1%;margin-right:1%;border-radius:5%;background-color: #F6E0ED;">
            <div class="row" style="margin-top: 4%">
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/estetoscopio.png" style="width: 30%; height: 30%;" />
                        <h4 style="color: white; font-family: 'Baloo 2', sans-serif">Llevar un control del expediente del bebé
                        </h4>
                    </div>
                </div>
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/jeringa.png" style="width: 30%; height: 30%;" />
                        <h4 style="color: white; font-family: 'Baloo 2', sans-serif">Calendarizar de forma rápida y facil las vacunas
                        </h4>
                    </div>
                </div>
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/cubiertos.png" style="width: 50%; height: 50%;" />
                        <h4 style="color: white; font-family: 'Baloo 2', sans-serif;">Dietas según la edad del bebé
                        </h4>
                    </div>
                </div>
            </div>

            <%-- Segunda linea --%>
            <div class="row" style="margin-top: 1%; margin-bottom: 4%">
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/neuronas.png" style="width: 50%; height: 50%;" />
                        <h4 style="color: white; font-family: 'Baloo 2', sans-serif">Información sobre las etapas de desarrollo
                        </h4>
                    </div>
                </div>
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/interrogacion.png" style="width: 50%; height: 50%;" />
                        <h4 style="color: white; font-family: 'Baloo 2', sans-serif">Fácil acesso a preguntas con expertos
                        </h4>
                    </div>
                </div>

                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/galeria.png" style="width: 50%; height: 50%;" />
                        <h4 style="color: white; font-family: 'Baloo 2', sans-serif;">Poder guadar fotos y audios
                        </h4>
                    </div>
                </div>
            </div>

        </div>
        <div style="width: 15%;background-image:url('../images/jugueteslat1.jpg');background-size:cover;">
        </div>
    </div>

</asp:Content>
