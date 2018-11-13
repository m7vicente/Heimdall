google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(drawChart);

function drawChart() {
    var data = google.visualization.arrayToDataTable([
        ['HD total', 'HD usado'],
        ['Capacidade Total', 11],
        ['Capacidade Usada', 2],

    ]);

    var options = {
        title: 'Armazenamento 1',
        pieHole: 0.1,
    };

    var chart = new google.visualization.PieChart(document.getElementById('graficoArm'));
    chart.draw(data, options);
}

google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(drawChart2);
function drawChart2() {
    var data2 = google.visualization.arrayToDataTable([
        ['HD total', 'HD usado'],
        ['Capacidade Total', 11],
        ['Capacidade Usada', 2],

    ]);

    var options2 = {
        title: 'Armazenamento 2',
        pieHole: 0.1,
    };

    var chart2 = new google.visualization.PieChart(document.getElementById('graficoArm2'));
    chart2.draw(data2, options2);
}