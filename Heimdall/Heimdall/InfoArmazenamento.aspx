﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoArmazenamento.aspx.cs" Inherits="Heimdall.InfoArmazenamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/sistema.css" rel="stylesheet" />
    <link href="css/infoArmazenamento.css" rel="stylesheet" />

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="js/graficoArmazenamento.js"></script>

    <title>Heimdall | System</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="menuSuperior">

            <a href="#menu-toggle" class="btn btn-secondary" id="menu-toggle">&#9776</a>

        </div>

        <div id="wrapper">

            <!-- Sidebar -->
            <div id="sidebar-wrapper">
                <div id="imagemDiv">
                    <img src="img/heimdall.png" id="imgLogo"/>

                    <p id="nomeLogo">HEIMDALL </p>

                </div>
                <ul class="sidebar-nav">
                    <li class="sidebar-brand"></li>
                    <li>
                        <a href="#">Computadores</a>
                    </li>
                    <li>
                        <a href="#">Componentes</a>
                    </li>
                    <li>
                        <a href="#">Histórico</a>
                    </li>
                    <li>
                        <a href="#">Emitir Relatórios</a>
                    </li>
                    <li>
                        <a href="#">Configurações</a>
                    </li>
                    <li>
                        <a href="#">Sair</a>
                    </li>

                </ul>
            </div>
            <!-- /#sidebar-wrapper -->

            <!-- Page Content -->
            <div id="page-content-wrapper">
                <div class="container-fluid">
                    <h1>Armazenamentos</h1>
                </div>
            </div>

            <div id="contComputadores">

                <div id="graficoArm"></div>
                <div id="informacoesArm">
                    <h3>Disco (C:)</h3>
                    <ul style="list-style: none">
                        <li>Tipo armazenamento</li>
                        <li style="font-weight: bold;">valor</li>
                        <li>Capacidade Total</li>
                        <li style="font-weight: bold;">valor</li>
                        <li>Capacidade Utilizada</li>
                        <li style="font-weight: bold;">valor</li>
                    </ul>
                </div>

                <div id="graficoArm2"></div>
                <div id="informacoesArm">
                    <h3>Disco (D:)</h3>
                    <ul style="list-style: none">
                        <li>Tipo armazenamento</li>
                        <li style="font-weight: bold;">valor</li>
                        <li>Capacidade Total</li>
                        <li style="font-weight: bold;">valor</li>
                        <li>Capacidade Utilizada</li>
                        <li style="font-weight: bold;">valor</li>
                    </ul>
                </div>
            </div>
        </div>
        <!-- /#page-content-wrapper -->
        <!-- /#wrapper -->
        <!-- Bootstrap core JavaScript -->
        <script src="vendor/jquery/jquery.min.js"></script>
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
