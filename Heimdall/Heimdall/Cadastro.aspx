<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Heimdall.Cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link rel="stylesheet" type="text/css" href="css/cadastro.css"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <link rel="shortcut icon" href="img/heimdall_icone.ico" type="image/x-icon" />

    <title>Heimdall | Cadastrar</title>
</head>
<body>
    <div class="container"> 
    <form id="form" runat="server">
    
            <asp:TextBox ID="txtNome" runat="server" placeholder="Nome"></asp:TextBox><br/><br/>			
			<asp:TextBox ID="txtEmail" TextMode="Email" runat="server" placeholder="E-mail"></asp:TextBox><br/><br/>
			<asp:TextBox ID="txtCargo" runat="server" placeholder="Cargo"></asp:TextBox><br/><br/>
			<asp:TextBox ID="txtSenha" TextMode="Password" runat="server" placeholder="Senha"></asp:TextBox><br/><br/>
			<asp:Button ID="btnCadastrar" runat="server" Text="CADASTRAR" OnClick="btnCadastrar_Click"/>
            <asp:Label ID="lblError" runat="server" Text=""/>
			<p class="mensagem">Você já é cadastrado? <a href="Login.aspx">Clique aqui para fazer login.</a><br/>
			<a href="#">Recuperação de senha</a></p>    
    </form>
    </div>

    <script type="text/javascript" src="js/cadastro.js"></script>

</body>
</html>