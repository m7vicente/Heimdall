<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="Heimdall.Relatorio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <link href="css/load.css" type="text/css" rel="stylesheet" />
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/sistema.css" rel="stylesheet" />
    <link href="css/relatorio.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet"/>

    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="js/relatorio.js" type="text/javascript"></script>

    <!--Jquery para gerar PDF (JPDF)-->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.5/jspdf.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.min.js"></script>


    <title>Heimdall | Relatório</title>
    <link rel='shortcut icon' href='img/favicon.ico' type='image/x-icon' />
</head>
<body>
    <form id="form1" runat="server">
        <div id="load" class="page"><img src="img/TSC2.gif"/></div>
        <div id="menuSuperior">

            <a href="#menu-toggle" class="btn btn-secondary" id="menu-toggle">&#9776</a>
            <div id="menuUsuario">
                <div id="infoUser">
                    <label id="lblEmail" runat="server"></label>
                </div>
                <div id="foto">
                    <img src="img/user.png" />
                </div>
            </div>
        </div>

        <div id="wrapper">

            <!-- Sidebar -->
            <div id="sidebar-wrapper">
                <div id="imagemDiv">
                    <img src="img/heimdall.png" id="imgLogo" />

                    <p id="nomeLogo">HEIMDALL </p>

                </div>
                <ul class="sidebar-nav">
                    <li class="sidebar-brand"></li>
                    <li>
                        <a href="Sistema.aspx"><i class="material-icons md-dark md-inactive">computer</i>Computadores</a>
                    </li>
                    <li>
                        <a href="Relatorio.aspx"><i class="material-icons md-dark md-inactive">assessment</i>Emitir Relatórios</a>
                    </li>
                    <li>
                       <a href="/downloads/HeimdallCall.jar"><i class="material-icons md-dark md-inactive">arrow_downward</i>API</a>
                    </li>
                    <li>
                       <a href="/downloads/EyeOfHeimdall.txt" download="EyeOfHeimdall.apk"><i class="material-icons md-dark md-inactive">adb</i>Android APP</a>
                    </li>
                    <li>
                        <i class="material-icons md-dark md-inactive">settings_power</i><asp:LinkButton ID="sair" Text="Sair" OnClick="sair_Click" runat="server" />
                    </li>
                </ul>
            </div>

            <!-- /#sidebar-wrapper -->

            <!-- Page Content -->
            <div id="page-content-wrapper">
                <div id="contComputadores">
                    <div id="relatorioTable" class="hidden">
                        <div id="titulo">
                            <label id="tituloMoni">Gere seu relatório</label>
                        </div>

                        <table id="tableRelatorio">
                            <tr>
                                <th>Computador</th>
                                <th>Modelo</th>
                                <th>Sistema Operacional</th>
                                <th>Processador</th>
                                <th>IPV4</th>
                                <th>Gerar Relatório</th>
                            </tr>
                        </table>
                        <div id="divPDF" style="display: none;"></div>
                    </div>
                </div>
            </div>
        </div>
        <!--conteudo dentro da pagina -->

        <!--fecha todo conteudo dentro da pagina -->


        <!-- /#page-content-wrapper -->
        <!-- /#wrapper -->
        <!-- Bootstrap core JavaScript -->
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- Menu Toggle Script -->
        <script>
            $("#menu-toggle").click(function (e) {
                e.preventDefault();
                $("#wrapper").toggleClass("toggled");
            });
        </script>





    </form>
</body>
</html>
