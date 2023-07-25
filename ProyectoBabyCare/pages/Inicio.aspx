<%@ Page Title="" Language="C#" MasterPageFile="~/SitePublic.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoBabyCare.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/PaginaUsuarios/PantallaInicio.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Titulo,desc,imagen de cabecera --%>
    <div style="width: 100%; height: 50%; background-image: url(../images/juguetesninio.jpg); background-size: cover; background-position: center;">
        <div style="padding-top: 2%; padding-bottom: 6%; padding-left: 6%; padding-right: 6%;">
            <h1 style="font-family: 'Baloo 2', sans-serif;">BIENVENIDO AL SISTEMA
            </h1>
            <h1 style="font-family: 'Baloo 2', sans-serif; color: #F495B6;">BABY CARE
            </h1>
            <h6 style="font-family: 'Baloo 2', sans-serif; width: 50%">Este sistema está diseñado especialmente para padres que desean hacer su vida más fácil mientras cuidan y crian a sus hijos.
                Sabemos que ser padre puede ser una tarea desafiante y abrumadora,
                pero estamos aquí para brindarte el apoyo para mejorar tu experiencia como padre o madre. 
            </h6>
        </div>

    </div>
    <%-- Fin de la cabecera --%>
    <div class="container">
        <%-- Resto del contenido de la pagina --%>

        <div class="row" style="margin-left: 10%; width: 90%; margin-top: 4%; margin-bottom: 4%">
            <div class="row" style="margin-top:4%">
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/estetoscopio.png" style="width: 30%; height: 30%;" />
                        <h6 style="color: #DF599D; font-family: 'Baloo 2', sans-serif">Llevar un control del expediente del bebé
                        </h6>
                    </div>
                </div>
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/jeringa.png" style="width: 30%; height: 30%;" />
                        <h6 style="color: #A020F0; font-family: 'Baloo 2', sans-serif">Calendarizar de forma rápida y facil las vacinas
                        </h6>
                    </div>
                </div>
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/cubiertos.png" style="width: 50%; height: 50%;" />
                        <h6 style="color: #DF599D; font-family: 'Baloo 2', sans-serif;">Dietas según la edad del bebé
                        </h6>
                    </div>
                </div>
            </div>

            <%-- Segunda linea --%>
            <div class="row" style="margin-top:4%;margin-bottom:4%">
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/neuronas.png" style="width: 50%; height: 50%;" />
                        <h6 style="color: #DF599D; font-family: 'Baloo 2', sans-serif">
                            Información sobre las etapas de desarrollo
                        </h6>
                    </div>
                </div>
                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/interrogacion.png" style="width: 50%; height: 50%;" />
                        <h6 style="color: #A020F0; font-family: 'Baloo 2', sans-serif">Facil acesso a preguntas con expertos
                        </h6>
                    </div>
                </div>

                <div class="Tarjeta1">
                    <div>
                        <img runat="server" src="~/images/galeria.png" style="width: 50%; height: 50%;" />
                        <h6 style="color: #DF599D; font-family: 'Baloo 2', sans-serif;">Poder guadar fotos y audios
                        </h6>
                    </div>
                </div>
            </div>

        </div>

        <%-- Fin contenido de la pagina --%>
    </div>
</asp:Content>
