<%@ Page Title="" Language="C#" MasterPageFile="~/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="IndicadoresInformacion.aspx.cs" Inherits="ProyectoBabyCare.styles.PaginasAdmin.IndicadoresInformacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://kit.fontawesome.com/51074424af.js" crossorigin="anonymous"></script>
    <link href="../../styles/PaginasAdmin/IndicadoresInformacion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <form runat="server">


        <div class="container">
            <div class="box" style="background: #bc4e9c; /* fallback for old browsers */
                background: -webkit-linear-gradient(to top, #bc4e9c, #f80759); /* chrome 10-25, safari 5.1-6 */
                background: linear-gradient(to top, #bc4e9c, #f80759); /* w3c, ie 10+/ edge, firefox 16+, chrome 26+, opera 12+, safari 7+ */">

                <div class="name_job">Usuarios Registrados</div>
                <img src="../../images/gestorbebes/usuario.png" style="width: 47px; margin-top: 10px; margin-bottom: 10px" alt="Alternate Text" />

                <h1 id="h1usuarios" runat="server">0</h1>
            </div>
            <div class="box" style="background: #333333; /* fallback for old browsers */
                            background: -webkit-linear-gradient(to bottom, #dd1818, #333333); /* chrome 10-25, safari 5.1-6 */
                            background: linear-gradient(to bottom, #dd1818, #333333); /* w3c, ie 10+/ edge, firefox 16+, chrome 26+, opera 12+, safari 7+ */">

                <div class="name_job">Bebés registrados</div>
                <img src="../../images/gestorbebes/chupete.png" style="width: 47px; margin-top: 10px; margin-bottom: 10px" alt="Alternate Text" />
                <h1 id="h1bebes_registrados" runat="server">0</h1>
            </div>
            <div class="box" style="background: #00F260; /* fallback for old browsers */
                                background: -webkit-linear-gradient(to bottom, #0575E6, #00F260); /* chrome 10-25, safari 5.1-6 */
                                background: linear-gradient(to bottom, #0575E6, #00F260); /* w3c, ie 10+/ edge, firefox 16+, chrome 26+, opera 12+, safari 7+ */">

                <div class="name_job">Bebés Activos</div>
                <img src="../../images/gestorbebes/bebe (1).png" style="width: 47px; margin-top: 10px; margin-bottom: 10px" alt="Alternate Text" />

                <h1 id="h1bebes_activos" runat="server">0</h1>

            </div>



        </div>




        <div class="container">
            <div class="box" style="background: #667db6; /* fallback for old browsers */
                background: -webkit-linear-gradient(to bottom, #667db6, #0082c8, #0082c8, #667db6); /* chrome 10-25, safari 5.1-6 */
                background: linear-gradient(to bottom, #667db6, #0082c8, #0082c8, #667db6); /* w3c, ie 10+/ edge, firefox 16+, chrome 26+, opera 12+, safari 7+ */">

                <div class="name_job">Citas Registradas</div>
                <img src="../../images/gestorbebes/calendario.png" style="width: 47px; margin-top: 10px; margin-bottom: 10px" alt="Alternate Text" />

                <h1 id="h1citas" runat="server">0</h1>

            </div>
            <div class="box" style="background: #1a2a6c; /* fallback for old browsers */
            background: -webkit-linear-gradient(to bottom, #fdbb2d, #b21f1f, #1a2a6c); /* chrome 10-25, safari 5.1-6 */
            background: linear-gradient(to bottom, #fdbb2d, #b21f1f, #1a2a6c); /* w3c, ie 10+/ edge, firefox 16+, chrome 26+, opera 12+, safari 7+ */">

                <div class="name_job">Vacunas registradas</div>
                <img src="../../images/gestorbebes/vacunado (1).png" style="width: 47px; margin-top: 10px; margin-bottom: 10px" alt="Alternate Text" />

                <h1 id="h1vacunas" runat="server">0</h1>

            </div>
            <div class="box" style="background: #396afc; /* fallback for old browsers */
            background: -webkit-linear-gradient(to bottom, #2948ff, #396afc); /* chrome 10-25, safari 5.1-6 */
            background: linear-gradient(to bottom, #2948ff, #396afc); /* w3c, ie 10+/ edge, firefox 16+, chrome 26+, opera 12+, safari 7+ */">

                <div class="name_job">Archivos multimedia</div>
                <img src="../../images/gestorbebes/video.png" style="width: 47px; margin-top: 10px; margin-bottom: 10px" alt="Alternate Text" />

                <h1 id="h1Archivos" runat="server">0</h1>

            </div>
        </div>
    </form>
</asp:Content>
