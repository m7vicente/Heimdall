<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monitoracao.aspx.cs" Inherits="Heimdall.Monitoracao" %>

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
    <link href="css/monitoracao.css" rel="stylesheet" />


    <!--Jquery abaixo permite deixar os graficos do google charts 100% resonsivos-->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="js/graficos.js"></script>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script type="text/javascript" src="js/monitoracao.js"></script>

    <title>Heimdall | Monitoração</title>

</head>

<body>
    <form id="form1" runat="server">
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
                    <img src="img/heimdall.png" id="imgLogo"/>

                    <p id="nomeLogo"> HEIMDALL </p>

                </div>
                <ul class="sidebar-nav">
                    <li class="sidebar-brand">
                    </li>
                    <li>
                        <a href="#">Computadores</a>
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
                    <div id="contComputadores">
                        <div id="conteudoComputador">
                            <div id="titulo">
                                <label id="tituloMoni">Monitoração</label>
                            </div>
                            <div id="infoComputador">
                                <div id="infoComputadorT">
                                    <label id="infoPC">Computador</label>
                                </div>
                                <div id="computadorInfo">
                                    <ul style="list-style: none;">
                                        <li>Nome Personalizado
                                            <p>
                                                <label id="nomePersonalizado">Valor</label>
                                            </p>
                                        </li>

                                        <li>Nome do Computador
                                            <p>
                                                <label id="nomeComputador">Valor</label>
                                            </p>
                                        </li>

                                        <li>Fabricante
                                            <p>
                                                <label id="fabricantePc">Valor</label>
                                            </p>
                                        </li>

                                        <li>IPV4
                                            <p>
                                                <label id="ipv4">Valor</label>
                                            </p>
                                        </li>

                                        <li>Firmware
                                            <p>
                                                <label id="firmware">Valor</label>
                                            </p>
                                        </li>

                                        <li>Fabricante S.O
                                            <p>
                                                <label id="fabricanteSO">Valor</label>
                                            </p>
                                        </li>

                                        <li>Familia S.O
                                            <p>
                                                <label id="familiaSO">Valor</label>
                                            </p>
                                        </li>

                                        <li>Versão S.O
                                            <p>
                                                <label id="versaoSO">Valor</label>
                                            </p>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div id="conteudoCpu">
                            <div id="titulo">
                                <label id="tituloMoni">Cpu</label>
                            </div>
                            <div id="infoCpu">
                                <ul style="list-style: none;">
                                    <li>Fabricante
                                        <p>
                                            <label id="nomeFabricanteCpu">Valor</label>
                                        </p>
                                    </li>

                                    <li>Modelo
                                        <p>
                                            <label id="modeloCpu">Valor</label>
                                        </p>
                                    </li>

                                    <li>Frequência Base
                                        <p>
                                            <label id="frequenciaBase">Valor</label>
                                        </p>
                                    </li>

                                    <li>Núcleos
                                        <p>
                                            <label id="nucleosCpu">Valor</label>
                                        </p>
                                    </li>

                                    <li>Serial
                                        <p>
                                            <label id="serialCpu">Valor</label>
                                        </p>
                                    </li>
                                </ul>
                            </div>

                        </div>

                        <div id="conteudoUsoCpu">
                            <div id="titulo">
                                <label id="tituloMoni">Uso da Cpu</label>
                            </div>

                            <div id="graficoCpu"></div>

                            <div id="infoCpuAtt">
                                <ul style="list-style: none;">
                                    <li>Processos
                                        <p>
                                            <label id="processosExecucao">Valor</label>
                                        </p>
                                    </li>

                                    <li>Frequência
                                        <p>
                                            <label id="frequenciaAtual">Valor</label>
                                        </p>
                                    </li>

                                    <li>Utilizado
                                        <p>
                                            <label id="porcenUtiizacao">Valor</label>
                                        </p>
                                    </li>

                                    <li>Threads
                                        <p>
                                            <label id="threadsExec">Valor</label>
                                        </p>
                                    </li>

                                    <li>Tempo uso
                                        <p>
                                            <label id="tempoExec">Valor</label>
                                        </p>
                                    </li>

                                    <li>Temperatura
                                        <p>
                                            <label id="temperaturaCpu">Valor</label>
                                        </p>
                                    </li>
                                </ul>
                            </div>


                            
                        </div>

                        <div id="conteudoRam">
                            <div id="titulo">
                                <label id="tituloMoni">Ram</label>
                            </div>
                            <div id="infoRam">
                                <ul style="list-style: none;">

                                    <li>Porcentagem Utilizada
                                        <p>
                                            <label id="porcentagemRam">Valor</label>
                                        </p>
                                    </li>

                                    <li>Memória Total
                                        <p>
                                            <label id="memTotal">Valor</label>
                                        </p>
                                    </li>

                                    <li>Memória Utilizada
                                        <p>
                                            <label id="memUtilizada">Valor</label>
                                        </p>
                                    </li>

                                    <li>Memória Disponivel
                                        <p>
                                            <label id="memDisponivel">Valor</label>
                                        </p>
                                    </li>

                                    <li>Memória Swap Total
                                        <p>
                                            <label id="swapTotal">Valor</label>
                                        </p>
                                    </li>

                                    <li>Memória Swap Disponivel
                                        <p>
                                            <label id="swapDisponivel">Valor</label>
                                        </p>
                                    </li>
                                </ul>
                            </div>
                        </div>

                        <div id="conteudoUsoRam">
                            <div id="titulo">
                                <label id="tituloMoni">Uso da Ram</label>
                            </div>
                            <div id="graficoRam"></div>
                        </div>

                        <div id="conteudoArmazenamento">
                            <div id="titulo">
                                <label id="tituloMoni">Armazenamentos</label>
                            </div>
                            <div id="listaGraficoArm">
                                <ul id="tabelaARM" style="list-style: none">
                                    <li>
                                        <div id="graficoArm"></div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
           
            <!--fecha todo conteudo dentro da pagina -->

            <!-- /#page-content-wrapper -->
            <!-- /#wrapper -->
            <!-- Bootstrap core JavaScript -->
            <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
            <script type="text/javascript" src="js/graficos.js"></script>
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