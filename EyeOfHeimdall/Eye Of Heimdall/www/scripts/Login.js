$(document).ready(function () {

    usuario = $.parseJSON($.cookie("user"));

    if (usuario.nomeCompleto !== null && usuario.codUsuario > 0) {
        document.location = "Sistema.html";
    }
});

var email = $('#txtEmail');
var senha = $('#txtSenha');

function user() {
    this.codUsuario;
    this.nomeCompleto;
    this.email;
    this.cargo;
    this.senha;
    this.ativo;
}


$('#btnLogar').click(function () {
    usuario = new user();
    usuario.email = email.val();
    usuario.senha = senha.val();
    usuario = login(usuario);

    if (usuario.nomeCompleto !== null && usuario.codUsuario > 0) {
        $.cookie('user', JSON.stringify(usuario));
        document.location = "Sistema.html";
    } else {
        alert("Usuario Incorreto");
    }
});

function login(user) {
        
    var URL = "https://heimdallview.azurewebsites.net/api/Usuario/";

    var settings = {
        "async": false,
        "crossDomain": true,
        "url": URL,
        "method": "POST",
        "data": user,
        "Content-Type": "application/json"        
    };
     $.ajax(settings).done(function (response) {
        user = response;
    });
     return user;
}