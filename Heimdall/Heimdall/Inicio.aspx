<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Heimdall.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <link rel="stylesheet" href="css/normalize.css" />
    <link rel="stylesheet" href="css/reset.css" />
    <link rel="stylesheet" href="css/grid.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/responsivo.css" />
    <link rel="shortcut icon" href="img/bifrost_ico.ico" type="image/x-icon" />

    <title>Bifrosts</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- menu do site-->
        <header class="header">
            <div>
                <a href="index.html" class="grid-4">
                    <img src="img/bifrost.png" alt="Bifrost" class="header-logo" /><!--logo bifrost-->
                </a>
                <nav class="grid-12 header_menu">
                    <ul>
                        <li><a href="#sobre">Sobre</a></li>
                        <li><a href="#integrantes">Integrantes</a></li>
                        <li><a href="#contato">Contato</a></li>
                        <li><a href="Login.aspx">Heimdall</a></li>
                    </ul>
                </nav>
            </div>
        </header>

        <!--home-->
        <section class="introducao">
            <div>
                <h1 class="compre">bridge to the facility</h1>
                <blockquote class="quote-externo">
                    <!--permite citações de texto-->
                    <!--p>"buscamos oferecer"</p-->
                    <br />
                    <!--cite>Pai de Todos</!--cite><matem o titulo de uma publicação em italico-->
                </blockquote>
                <a href="Login.aspx" class="btn">Heimdall  Dashboard</a>
            </div>
        </section>

        <!--divs da home produtos substituido p integrantes-->
        <section class="integrantes container">
            <h2 class="subtitulo" id="integrantes">Integrantes</h2>

            <ul class="integrantes_lista">
                <li class="grid-5">
                    <div class="integrantes_icone">
                        <img src="img/alice.jpg" alt="bifrost passeio" />
                    </div>
                    <h3>Alice</h3>
                    <p>
                        Front End que fica responsável por projetar, construir e otimizar as interfaces de um projeto web.
                    </p>
                </li>

                <li class="grid-5">
                    <div class="integrantes_icone">
                        <img src="img/matheus.png" alt="bifrost integrates" />
                    </div>
                    <h3>Matheus</h3>
                    <p>
                        Back End é fica responsável por dinamizar os sites utilizando linguagens de programação Java e C#, além de organizar todas as informações invisíveis aos olhos do usuário.
                    </p>
                </li>


                <li class="grid-5">
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
                        <img src="img/graficoLine.PNG" alt="Grafico" style="height:300px;"/></li>

                    <li class="grid-8">
                        <img src="img/paginaSist.PNG" alt="Bicicleta Passeio" style="height:300px;"/></li>

                    <li class="grid-16">
                        <img src="img/graficoPizza2.PNG" alt="Bicicleta Esporte"/></li>

                    <!--botão-->
                    <!--div-- class="call">
                        <p>conheça mais nosso portifolio</p>
                        <a href="portifolio.html" class="btn">Portifolio</a>
                    </!--div-->
                </ul>
            </div>
        </section>

        <!--qualidades-->
        <section class="qualidade container" id="sobre">
            <h2 class="subtitulo">Qualidade</h2>
            <img src="img/heimdall.png" alt="Bikcraft" class="qualidade_bifrost" />
            <ul class="qualidade_lista">
                <li class="grid-1-3">
                    <h3>Facilidade</h3>
                    <p>
                        Crie sua conta agora mesmo e baixe nossa API que coletará os dados das especificações de seu computador para a monitoração
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
                        Para mais eficiência, criamos uma aplicativo para você, basta entrar no sistema e baixar o app, visualize na palma de sua mão aquilo que é mais importante para você
                    </p>
                </li>
            </ul>

            <!--botão-->
            <div class="call">
                
                <!--a href="LocalHeimdall.aspx" class="btn btn-preto">Local Heimdall</a-->
            </div>
        </section>
        <!--fim da qualidade-->

        <!--FORMULARIO-->


        <section class="contato" id="contato">
            <div class="container contato_form">
                <h2 class="subtitulo">fale conosco</h2>
                <div id="form_orcamento" class="contato_form grid-16">
                    <!--label for="nome">nome</!--label-->
                    <asp:TextBox runat="server" ID="txtNome" class="input" placeholder="Nome" />>
                    <!--input type="text" id="nome"/-->
                    <asp:TextBox runat="server" ID="txtEmail" class="input" placeholder="E-mail" TextMode="Email" />>
                    <!--label for="email">email</label>
                    <input type="text" id="email"/-->
                    <asp:TextBox runat="server" ID="txtTel" class="input" placeholder="Telefone" TextMode="Phone" />>
                    <!--label for="telefone">teefone</!--label>
                    <input type="text" id="telefone"/-->
                    <asp:TextBox runat="server" TextMode="multiline" ID="txtEspec" class="input" placeholder="Mensagem" />>
                    <!--label for="espec">especificação</!--label>
                    <textarea id="espec"></textarea-->
                    <!--button type="submit" class="btn">enviar</!--button-->
                    <asp:Button runat="server" ID="btnEnviar" class="btn btn-branco" Text="enviar" OnClick="btnEnviar_Click" />
                </div>
                <div class="contato_dados grid-8">
                    <h3>dados</h3>
                    <span>+55 11 40028922</span>
                    <span class="dados_email">suporte@bifrost.com</span>
                    <h3>redes sociais</h3>
                    <ul>
                        <li><a href="http://facebok.com" target="_blank">
                            <img src="img/facebook.png" alt="Facebook bifrost" /></a></li>
                        <li><a href="http://instagram.com" target="_blank">
                            <img src="img/instagram.png" alt="Instagran bifrost" /></a></li>
                        <li><a href="http://twitter.com" target="_blank">
                            <img src="img/twitter.png" alt="Twitter bifrost" /></a></li>
                    </ul>
                </div>
            </div>
        </section>

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
