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
            + '<td><img src="img/relatorioIcon.png" onclick="savePDF(objComputer'+ obj[i].codComputador+')"/></td>'
            + "</tr >");

        gravarInforRelatorio(obj[i]);
    }

    $('#load').addClass("hidden");
    $('#relatorioTable').removeClass("hidden");

    computadores = obj;
}

// função que gera o PDF ao clicar no icone de relatórios


function savePDF(codigoHTML) {
    document.querySelector('#divPDF')
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
        "<h1>Informações do computador</h1>" +
        '<div id="risco"></div>' +
        '<div id="infoPcomputador">'+
        '<ul style="list-style: none;">' +
        '<li>Codigo do computador: <label id="codComp">' + computador.codComputador + '</label></li>' +
        '<li>Fabricante do computador: <label id="faComp">' + computador.fabricanteComputador + '</label></li>' +
        '<li>Nome do computador: <label id="nomeComp">' + computador.nomeComputador + '</label></li>' +
        '<li>IPV4: <label id="ipv4Comp">' + computador.ipv4Computador + '</label></li>' +
        '<li>Versão Firmware: <label id="verfirm">' + computador.versaoFirmware + '</label></li>' +
        '<li>Modelo do computador: <label id="verfirm">' + computador.modeloComputador + '</label></li>' +
        '</ul>'+
        '</div >'+
        '<div id="risco"></div>' +
        "<h1>Sistema Operacional</h1>" +
        '<div id="risco"></div>' +
        '<div id="infoPcomputador">' +
        '<ul style="list-style: none;">' +
        '<li><label id="sistemaOperacional">' + computador.OS.fabricanteSO + ' ' + computador.OS.familiaSO + ' ' + computador.OS.versaoSO + '</label></li>' +
        '</ul>' +
        '</div >' +
        '<div id="risco"></div>' +
        "<h1>Sistema</h1>" +
        '<div id="risco"></div>' +
        '<div id="infoPcomputador">' +
        '<ul style="list-style: none;">' +
        '<li>Processador: <label id="processador">' + computador.processadores.modelo + '</label></li>' +
        '<li>Memória RAM: <label id="memoriaRam">' + computador.RAM.memoriaTotal + '</label></li>' +
        '<li>Memória Swap: <label id="memoriaSwap">' + computador.RAM.swapTotal + '</label></li>' +
        '<li>Quantidade de Núcleos: <label id="nucleo">' + computador.processadores.nucleos + '</label></li>' +
        '<li>Serial: <label id="nucleo">' + computador.processadores.serial + '</label></li>' +
        '</ul>' +
        '</div >' +
        +"</div>");
        
        
}