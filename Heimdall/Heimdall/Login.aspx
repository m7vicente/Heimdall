<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Heimdall.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
<meta http-equiv="X-UA-Compatible" content="ie=edge"/>   
<link rel="stylesheet" type="text/css" href="css/login.css"/>
    <title>Heimdall | Login</title>
</head>
<body>
      <div class="container">
         <form id="form" runat="server">
            <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" placeholder="E-mail"></asp:TextBox><br/><br/>
            <asp:TextBox ID="txtSenha" TextMode="Password" runat="server" placeholder="Senha"></asp:TextBox><br/><br/>
            <asp:Button ID="btnLogar" runat="server" Text="LOGAR" onclick="btnLogar_Click" />
			<p class="mensagem">Não é registrado ? <a href="Cadastro.aspx">Crie sua Conta.</a><br/>
			<a href="#">Recuperação de senha</a></p>
    	</form>
      </div>
</body>
</html>