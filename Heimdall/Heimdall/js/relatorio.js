var computadores;

function BuscarComputadores(codUsuario) {

    var URL = "http://localhost:52121/api/Computador/?codUsuario=" + codUsuario + "";

    //var URL = "https://heimdallview.azurewebsites.net/api/Computador/?codUsuario=" + codUsuario + "";


    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URL,
        "method": "GET",
        "origin": "https://heimdallview.azurewebsites.net"
    };

    $.ajax(settings).done(function (response) {
        success(response);
    });
}

function success(obj) {

    for (var i = 0; i < obj.length; i++) {

        $('#tableRelatorio').append("<tr>"
            + "<td>" + obj[i].nomeComputador + "</td>"
            + "<td>" + obj[i].modeloComputador + "</td>"
            + '<td>' + obj[i].OS.familiaSO+ '</td>'
            + "<td>" + obj[i].processadores.modelo + "</td>"
            + "<td>"+ obj[i].ipv4Computador + "</td>"
            + '<td><img src="img/relatorioIcon.png" /></td>'
            + "</tr >");
    }

    $('#load').addClass("hidden");
    $('#relatorioTable').removeClass("hidden");

    computadores = obj;
}
