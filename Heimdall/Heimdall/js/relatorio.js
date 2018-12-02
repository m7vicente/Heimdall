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
            + '<td><img src="img/relatorioIcon.png" id="btnPDF" /></td>'
            + "</tr >");
    }

    $('#load').addClass("hidden");
    $('#relatorioTable').removeClass("hidden");

    computadores = obj;
}

// função que gera o PDF ao clicar no icone de relatórios

$(document).ready(function () {
    $('#btnPDF').click(function () {
        savePDF(document.querySelector('#divPDF'));
    });
});

function savePDF(codigoHTML) {
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


