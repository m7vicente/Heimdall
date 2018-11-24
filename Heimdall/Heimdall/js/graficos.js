//grafico CPU

google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(desenharGraficoCpu);

//Grafico da RAM
google.charts.setOnLoadCallback(desenharGraficoRam);

//Grafico de armazenamentos
google.charts.setOnLoadCallback(desenharGraficoArmazenamentos);


var cpuTotal = 0, cpuData = null, cpuGrafico = null;
function desenharGraficoCpu(valor) {

    if (cpuData === null) {
        cpuData = new google.visualization.DataTable();
        cpuData.addColumn('number', 'Valor');
        cpuData.addColumn('number', 'Utilizacao');
    }

    console.log(valor);
    cpuData.addRows([[cpuTotal, valor]]);
         
    cpuGrafico = new google.visualization.AreaChart(document.getElementById('graficoCpu'));
    cpuGrafico.draw(cpuData, {
        title: 'Desempenho CPU',
        hAxis: { title: '', titleTextStyle: { color: '#ff9933' } },
        vAxis: { minValue: 0 },
        backgroundColor: 'transparent',
        colors: ['#ff9933'],
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

    console.log(valor);
    ramData.addRows([[ramTotal, valor]]);

    cpuGrafico = new google.visualization.AreaChart(document.getElementById('graficoRam'));
    cpuGrafico.draw(ramData, {
        isStacked: 'relative',
        title: 'Desempenho Ram',
        hAxis: { title: '', titleTextStyle: { color: '#ff9933' } },
        vAxis: { minValue: 0 },
        backgroundColor: 'transparent',
        colors: ['#ff9933']

    });

    ramTotal++;
}



function desenharGraficoArmazenamentos() {
    var data = google.visualization.arrayToDataTable([
        ['HD total', 'HD usado'],
        ['Capacidade Total', 11],
        ['Capacidade Usada', 2],

    ]);

    var options = {
        title: 'Armazenamento 1',
        pieHole: 0.1,
        backgroundColor: 'transparent',
        colors: ['#ff9933', 'black'],

    };

    var chart = new google.visualization.PieChart(document.getElementById('graficoArm'));
    chart.draw(data, options);
}

/*fecha grafico de armazenamentos*/

$(window).resize(function () {
    desenharGraficoCpu();
    desenharGraficoRam();
    desenharGraficoArmazenamentos();
});
