$(document).ready(function () {

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
    login(usuario);
});

function login(user) {

    var URL = "http://localhost:52121/api/Usuario/";
    //var URL = "https://heimdallview.azurewebsites.net/api/Usuario/";

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URL,
        "method": "POST",
        "data": user,
        "Content-Type": "application/json"        
    };
    $.ajax(settings).done(function (response) {
        alert(response.d);
    });
}