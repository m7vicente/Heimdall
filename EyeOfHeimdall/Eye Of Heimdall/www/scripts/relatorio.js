var computadores;



function BuscarComputadores() {

    usuario = $.parseJSON($.cookie("user"));

    //var URL = "http://localhost:52121/api/Computador/?codUsuario=" + codUsuario + "";

    var URL = "https://heimdallview.azurewebsites.net/api/Computador/?codUsuario=" + usuario.codUsuario + "";


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
            + '<td><img src="images/relatorioIcon.png" onclick="savePDF(objComputer' + obj[i].codComputador + ')"/></td>'
            + "</tr >");

        gravarInforRelatorio(obj[i]);
    }

    $('#load').addClass("hidden");
    $('#relatorioTable').removeClass("hidden");

    computadores = obj;
}

// função que gera o PDF ao clicar no icone de relatórios


function savePDF(codigoHTML) {
    document.querySelector('#divPDF');
    var doc = new jsPDF('portrait', 'pt', 'a4'),
        data = new Date();
    margins = {
        top: 40,
        bottom: 60,
        left: 40,
        width: 1000
    };
    doc.fromHTML(codigoHTML,
        margins.left, // x coord
        margins.top, { pagesplit: true },
        function (dispose) {
            doc.save("Relatorio - " + data.getDate() + "/" + (data.getMonth() + 1) + "/" + data.getFullYear() + ".pdf");
        });
}


function gravarInforRelatorio(computador) {
    $('#divPDF').append('<div id="objComputer' + computador.codComputador + '">' +
        '<img src="images/bifrost_branco_rela.png"/>' +
        "<h1>INFORMAÇÕES DO COMPUTADOR</h1>" +
        '<img src="images/risco.png" id="risco"/>' +
        '<div id="infoPcomputador">' +
        '<ul style="list-style: none;">' +
        "<li>Fabricante do computador:  " + computador.fabricanteComputador + "</li>" +
        "<li>Nome do computador: " + computador.nomeComputador + "</label></li>" +
        "<li>IPV4: " + computador.ipv4Computador + "</label></li>" +
        "<li>Versão Firmware: " + computador.versaoFirmware + "</label></li>" +
        "<li>Modelo do computador: " + computador.modeloComputador + "</label></li>" +
        '</ul>' +
        '</div >' +
        "<h1>SISTEMA OPERACIONAL</h1>" +
        '<img src="images/risco.png" id="risco"/>' +
        '<div id="infoPcomputador">' +
        "<ul>" +
        '<li> ' + computador.OS.fabricanteSO + ' ' + computador.OS.familiaSO + ' ' + computador.OS.versaoSO + '</li>' +
        "</ul>" +
        "</div >" +
        "<h1>SISTEMA</h1>" +
        '<img src="images/risco.png" id="risco"/>' +
        '<div id="infoPcomputador">' +
        '<ul style="list-style: none;">' +
        "<li>Processador: " + computador.processadores.modelo + "</li>" +
        "<li>Memória RAM: " + computador.RAM.memoriaTotal + " GB</li>" +
        "<li>Memória Swap: " + computador.RAM.swapTotal + " GB</li>" +
        "<li>Quantidade de Núcleos: " + computador.processadores.nucleos + "</li>" +
        "<li>Serial: " + computador.processadores.serial + "</li>" +
        "</ul>" +
        "</div>"
        + "</div>");

}
BuscarComputadores();