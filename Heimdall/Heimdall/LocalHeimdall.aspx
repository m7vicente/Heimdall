<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocalHeimdall.aspx.cs" Inherits="Heimdall.LocalHeimdall" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <link rel="stylesheet" href="css/normalize.css" />
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/grid.css" />
    <link rel="stylesheet" href="css/styleHeimdall.css" />
    <link rel="stylesheet" href="css/responsivo.css" />

    <title>Bifrosts</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- menu do site-->
        <header class="header">
            <div>
                <a href="index.html" class="grid-4">
                    <img src="img/heimdall_logo.png" alt="Bifrost" class="header-logo" /><!--logo bifrost-->
                </a>
                <nav class="grid-12 header_menu">
                    <ul>   
                        <li><a href="#integrantes">Integrantes</a></li>
                        <li><a href="Login.aspx">Heimdall</a></li>
                    </ul>
                </nav>
            </div>
        </header>

        <!--home-->
        <section class="introducao" id="sobre">
            <div>
                <h1 class="compre">bridge to the facility</h1>
                <blockquote class="quote-externo">
                    <!--permite citações de texto-->
                    <p>"Um rei sábio nunca almeja guerra, mas deve estar sempre pronto para ela."</p>
                    <br />
                    <cite>Pai de Todos</cite><!--matem o titulo de uma publicação em italico-->
                </blockquote>
                <a href="Login.aspx" class="btn">Heimdall Dashboard</a>
            </div>
        </section>

        <!--divs da home produtos substituido p integrantes-->
        <section class="integrantes container">
            <h2 class="subtitulo" id="integrantes">Integrantes</h2>

            <ul class="integrantes_lista">
                <li class="grid-4">
                    <div class="integrantes_icone">
                        <img src="img/alice.jpg" alt="bifrost passeio" />
                    </div>
                    <h3>Alice</h3>
                    <p>
                        Front End que fica responsável por projetar, construir e otimizar as interfaces de um projeto web.
                    </p>
                </li>

                <li class="grid-4">
                    <div class="integrantes_icone">
                        <img src="img/matheus.png" alt="bifrost integrates" />
                    </div>
                    <h3>Matheus</h3>
                    <p>
                        Back End é fica responsável por dinamizar os sites utilizando linguagens de programação Java e C#, além de organizar todas as informações invisíveis aos olhos do usuário.
                    </p>
                </li>

                <li class="grid-4">
                    <div class="integrantes_icone">
                        <img src="img/pedro.png" alt="bifrost integrates" />
                    </div>
                    <h3>Pedro</h3>
                    <p>
                        Front End que fica responsável por projetar, construir e otimizar as interfaces de um projeto web.
                    </p>
                </li>

                <li class="grid-4">
                    <div class="integrantes_icone">
                        <img src="img/thiago.png" alt="bifrost integrates" />
                    </div>
                    <h3>Thiago</h3>
                    <p>
                        Back End é fica responsável por dinamizar os sites utilizando linguagens de programação Java e C#, além de organizar todas as informações invisíveis aos olhos do usuário.
                    </p>
                </li>

            </ul>

            <!--botão-
                    <div class="call" >
                        <p>Clique aqui e veja o detalhe sobre o produto</p>
                        <a href="produtos.html" class="btn btn-preto">Produtos</a>
            </div-->

        </section>
        <!--fecha produto-->

        <section class="portifolio">
            <div class="container">
                <h2 class="subtitulo">sistema</h2>
                <ul class="portifolio_lista">
                    <li class="grid-8">
                        <img src="img/graficoLine.PNG" style="height:310px;" alt="Grafico" />
                    </li>

                    <li class="grid-8">
                        <img src="img/paginaSist.PNG" alt="Bicicleta Passeio" />
                    </li>

                    <li class="grid-16">
                        <img src="img/graficoPizza2.PNG" alt="Bicicleta Esporte" />
                    </li>


                    <!--li class="grid-16">
                        <img src="img/BPMN ProjetoPreview.png" alt="Bicicleta Esporte" />
                    </li>

                    <li class="grid-16">
                        <img src="img/UseCaseWeb.png" style="width:940px;" alt="Bicicleta Esporte" />
                    </li>

                    <!--botão-->
                    <!--div-- class="call">
                        <p>conheça mais nosso portifolio</p>
                        <a href="portifolio.html" class="btn">Portifolio</a>
                    </!--div-->
                </ul>
            </div>
        </section>

        <!--qualidades-->
        <section class="qualidade container">
            <h2 class="subtitulo">Qualidade</h2>
            <img src="img/heimdall.png" alt="Bikcraft" class="qualidade_bifrost" />
            <ul class="qualidade_lista">
                <li class="grid-1-3">
                    <h3>Facilidade</h3>
                    <p>
                        Crie a sua conta a e baixa a API, ja está funcionando não precisa fazer mais nada
                    </p>
                </li>

                <li class="grid-1-3">
                    <h3>Praticidade</h3>
                    <p>
                        Contém todas informações necessárias para manter um bom desempenho de sua maquina
                    </p>
                </li>

                <li class="grid-1-3">
                    <h3>Inovação</h3>
                    <p>
                        Não presisa nem acessar o site, faça apenas abra o APP e visualize aquilo que é o mais importante para você
                    </p>
                </li>
            </ul>

            <div class="call"></div>
        </section>
        <!--fim da qualidade-->
        <!--FORMULARIO-->

        <footer>
            <div class="copy">
                <div class="container">
                    <p class="grid-16">&copy;Bifrost alguns varios direitos reservados.</p>
                </div>
            </div>
        </footer>
    </form>
</body>
</html>
