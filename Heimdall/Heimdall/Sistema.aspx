﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sistema.aspx.cs" Inherits="Heimdall.Sistema" %>

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
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet"/>
    <link rel="shortcut icon" href="img/heimdall_icone.ico" type="image/x-icon" />
    <script src="https://wchat.freshchat.com/js/widget.js"></script>
    <script type="text/javascript" src="js/computadores.js"></script>
    <script type="text/javascript" src="vendor/jquery/jquery.js"></script>
    <title>Heimdall | Computadores</title>
    <link rel='shortcut icon' href='img/favicon.ico' type='image/x-icon' />
</head>
<body>

    <!--Propriedade que deve ser escrita no body para gerar freshChat na tela-->
    <script>
        window.fcWidget.init({
            token: "2ddae1e4-25e7-42a4-9b4f-d8d83fe569e1",
            host: "https://wchat.freshchat.com"
        });
    </script>

    <form id="form1" runat="server">
        <div id="load" class="page"><img src="img/TSC2.gif"/></div>
        <div id="menuSuperior">
            <a href="#menu-toggle" class="btn btn-secondary" id="menu-toggle">&#9776</a>
            
            <div id="menuUsuario">
                <div id ="infoUser">
                <label id="lblEmail" runat="server"></label>
                </div>
                <div id="foto">
                    <img src="img/user.png"/>
                </div>
            </div>
        </div>

        <div id="wrapper">

            <!-- Sidebar -->
            <div id="sidebar-wrapper">
                <div id="imagemDiv">
                    <img src="img/heimdall_logo.png" id="imgLogo" />
                    <p id="nomeLogo">HEIMDALL </p>
                </div>
                <ul class="sidebar-nav">
                    <li class="sidebar-brand">
                    </li>
                    <li>
                        <a href="Sistema.aspx"><i class="material-icons md-dark md-inactive">computer</i>Computadores</a>
                    </li>
                    <li>
                        <a href="Relatorio.aspx"><i class="material-icons md-dark md-inactive">assessment</i>Emitir Relatórios</a>
                    </li>
                    <li>
                       <a href="downloads/HeimdallCall.txt" download="HeimdallCall.jar"><i class="material-icons md-dark md-inactive">arrow_downward</i>API</a>
                    </li>
                    <li>
                       <a href="downloads/EyeOfHeimdall.txt" download="EyeOfHeimdall.apk"><i class="material-icons md-dark md-inactive">adb</i>Android APP</a>
                    </li>
                    <li>
                       <i class="material-icons md-dark md-inactive">settings_power</i><asp:LinkButton ID="sair" Text="Sair" OnClick="sair_Click" runat="server" />
                    </li>
                </ul>
            </div>

            <!-- /#sidebar-wrapper -->

            <!-- Page Content -->
            <div id="page-content-wrapper">
                <div class="container-fluid">
                    <h1>Bem vindo 
                        <asp:Label runat="server" Text="Usuario" ID="lblUsuario"></asp:Label></h1>
                </div>                
            </div>             
            <div id="contComputadores" class="hidden">
            </div>
        </div>
        <script src="vendor/jquery/jquery.min.js"></script>
        <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

        <script>
            $("#menu-toggle").click(function (e) {
                e.preventDefault();
                $("#wrapper").toggleClass("toggled");
            });
        </script>
    </form>
</body>
</html>
