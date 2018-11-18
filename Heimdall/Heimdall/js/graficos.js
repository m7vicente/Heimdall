/*Grafico da CPU*/
google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(desenharGraficoCpu);

function desenharGraficoCpu() {
    var data = google.visualization.arrayToDataTable([
        ['', 'Porcentagem'],
        ['', 1000],
        ['', 117],
        ['', 660],
        ['', 1030]
    ]);

    var options = {
        isStacked: 'relative',
        title: 'Desempenho CPU',
        hAxis: { title: '', titleTextStyle: { color: '#ff9933' } },
        vAxis: { minValue: 0 },
        backgroundColor: 'transparent',
        /*chartArea: {left:20,top:0,width:'50%',height:'75%'},*/
        colors: ['#ff9933'],
        height: '300',
    };

    var chart = new google.visualization.AreaChart(document.getElementById('graficoCpu'));
    chart.draw(data, options);
}

/*fecha grafico da CPU*/


/*Grafico da RAM*/
google.charts.load('current', { 'packages': ['corechart'] });
google.charts.setOnLoadCallback(desenharGraficoRam);

function desenharGraficoRam() {
    var data = google.visualization.arrayToDataTable([
        ['', 'Porcentagem'],
        ['', 1000],
        ['', 117],
        ['', 660],
        ['', 1030]
    ]);

    var options = {
        isStacked: 'relative',
        title: 'Desempenho Ram',
        hAxis: { title: '', titleTextStyle: { color: '#ff9933' } },
        vAxis: { minValue: 0 },
        backgroundColor: 'transparent',
        /*chartArea: {left:20,top:0,width:'50%',height:'75%'},*/
        colors: ['#ff9933'],
    };

    var chart = new google.visualization.AreaChart(document.getElementById('graficoRam'));
    chart.draw(data, options);
}
/*fecha grafico da RAM*/


/*Grafico de armazenamentos*/
google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(desenharGraficoArmazenamentos);

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
