function BuscarProcessador() {

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "http://localhost:52121/api/Computador/?id=5&codUsuario=4",
        "method": "GET"
    };

    $.ajax(settings).done(function (response) {
        success(response);
    });

    console.log("rola");
}

function success(obj) {
       
    for (var i = 0; i < obj.length; i++) {

        $('#contComputadores').append('<div id = "computador" >' +
            '<div id="imgPc">' +
            '<img src="img/computador.png">' +
            '</div>' +
            '<div id="informacoesPc">' +
            '<p>' +
            '<label ID="lbIdentificacao">Identificação: ' + obj[i].codComputador + '<label></p>' +
            '<p>' +
            '<label ID="lbNomeComputador"> Nome do computador: ' + obj[i].nomeComputador + '<label></p>' +
            '<p>' +
            '<label ID="lbModeloComputador"> Modelo computador: ' + obj[i].fabricanteComputador + '<label></p>' +
            '<p>' +
            '<label ID="lbIpv4"> IPV4: ' + obj[i].ipv4Computador + ' <label></p>' +
            '</div>' +
            '</div>');
    }
}