<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sistema.aspx.cs" Inherits="Heimdall.Sistema" %>

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
    <script type="text/javascript" src="js/computadores.js"></script>
    <script type="text/javascript" src="vendor/jquery/jquery.js"></script>
    <title>Heimdall | System</title>
</head>
<body>
    <form id="form1" runat="server">
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
                    <img src="img/heimdall.png" id="imgLogo" />
                    <p id="nomeLogo">HEIMDALL </p>
                </div>
                <ul class="sidebar-nav">
                    <li class="sidebar-brand">
                    </li>
                    <li>
                        <a href="Sistema.aspx">Computadores</a>
                    </li>
                    <li>
                        <a href="Relatorio.aspx">Emitir Relatórios</a>
                    </li>
                    <li>
                        <a href="#">Configurações</a>
                    </li>
                    <li>
                        <asp:LinkButton ID="sair" Text="Sair" OnClick="sair_Click" runat="server" />
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

            <div id="contComputadores">
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
