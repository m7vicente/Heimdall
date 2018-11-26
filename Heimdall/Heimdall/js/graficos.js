//grafico CPU

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(desenharGraficoCpu);

//Grafico da RAM
google.charts.setOnLoadCallback(desenharGraficoRam);

//Grafico de armazenamentos
google.charts.setOnLoadCallback(desenharGraficosArmazenamento);


var cpuTotal = 0, cpuData = null, cpuGrafico = null;
function desenharGraficoCpu(valor) {

    if (cpuData === null) {
        cpuData = new google.visualization.DataTable();
        cpuData.addColumn('number', 'Valor');
        cpuData.addColumn('number', 'Utilizacao');
    }

    cpuData.addRows([[cpuTotal, valor]]);

    cpuGrafico = new google.visualization.AreaChart(document.getElementById('graficoCpu'));
    cpuGrafico.draw(cpuData, {
        title: 'Desempenho CPU',
        hAxis: { title: '', titleTextStyle: { color: '#ffc738' } },
        vAxis: { minValue: 0 },
        backgroundColor: 'transparent',
        colors: ['#ffc738'],
        height: '700'

    });

    cpuTotal++;
}

var ramTotal = 0, ramData = null, ramGrafico = null;
function desenharGraficoRam(valor) {

    if (ramData === null) {
        ramData = new google.visualization.DataTable();
        ramData.addColumn('number', 'Valor');
        ramData.addColumn('number', 'Utilizacao');
    }
        
    ramData.addRows([[ramTotal, valor]]);

    ramGrafico = new google.visualization.AreaChart(document.getElementById('graficoRam'));
    ramGrafico.draw(ramData, {

        title: 'Desempenho Ram',
        hAxis: { title: '', titleTextStyle: { color: '#ffc738' } },
        vAxis: { minValue: 0 },
        backgroundColor: 'transparent',
        colors: ['#ffc738']

    });

    ramTotal++;
}

var armExist = false;
function desenharGraficosArmazenamento(armazenamentos) { 

    if (!armExist) {        

        $('#tabelaARM').html('');

        for (i = 0; i < armazenamentos.length; i++) {

            console.log(i);

            var disponivel = armazenamentos[i].capacidadeUtilizada;
            var utilizada = armazenamentos[i].capacidadeTotal - armazenamentos[i].capacidadeUtilizada;

            if (utilizada < 0) {
                utilizada = armazenamentos[i].capacidadeUtilizada - armazenamentos[i].capacidadeTotal;
            }
            
            $('#tabelaARM').append('<li><div id = "graficoArm' + i + '" ></div ></li >'
                + '<script>'
                + "var armTotal" + i + " = 0, armData" + i + " = null, armGrafico" + i + " = null;"
                + 'var armData' + i + ' = google.visualization.arrayToDataTable(['
                + "        ['HD total', 'HD usado'],"
                + "    ['Capacidade Disponivel', " + disponivel + "],"
                + "    ['Capacidade Utilizado', " + utilizada + "]]);"

                + "armGrafico" + i + " = new google.visualization.PieChart(document.getElementById('graficoArm" + i + "'));"
                + "armGrafico" + i + ".draw(armData" + i + ", {"
                + "    title: '" + armazenamentos[i].tipoArmazenamento + "',"
                + "    pieHole: 0.1,"
                + "    backgroundColor: 'transparent',"
                + "    colors: ['#ffc738', 'black']"
                + "});"
                + '</script>');
        }
        armExist = true;
    }
}

function desenharGraficoArmazenamentos(capacidadeTotal, capacidadeUltilizada) {

    $('#tabelaARM').append('graficoArm<li><div id = "graficoArm" ></div ></li >'
        + '<script>'
        + "var armTotal = 0, armData = null, armGrafico = null;"
        + 'var armData = google.visualization.arrayToDataTable(['
        + "        ['HD total', 'HD usado'],"
        + "    ['Capacidade Total', " + capacidadeTotal + "],"
        + "    ['Capacidade Usada', " + capacidadeUltilizada + "]]);"

        + "armGrafico = new google.visualization.PieChart(document.getElementById('graficoArm'));"
        + "armGrafico.draw(armData, {"
        + "    title: 'Armazenamento 1',"
        + "    pieHole: 0.1,"
        + "    backgroundColor: 'transparent',"
        + "    colors: ['#ffc738', 'black']"
        + "});"
        + '</script>');
}
/*fecha grafico de armazenamentos*/


$(window).resize(function () {
    desenharGraficoCpu();
    desenharGraficoRam();
    desenharGraficosArmazenamento();
});
