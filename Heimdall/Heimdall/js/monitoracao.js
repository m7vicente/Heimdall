﻿var Computador;
var lblNomePersonalizado;
var lblNomeComputador;
var lblFabricantePc;
var lblIpv4;
var lblFirmware;
var lblFabricanteSO;
var lblFamiliaSO;
var lblVersaoSO;
var lblNomeFabricanteCpu;
var lblModeloCpu;
var lblFrequenciaBase;
var lblNucleosCpu;
var lblSerialCpu;
var lblProcessosExecucao;
var lblFrequenciaAtual;
var lblPorcenUtiizacao;
var lblThreadsExec;
var lblTempoExec;
var lblTemperaturaCpu;
var lblPorcentagemRam;
var lblMemTotal;
var lblMemUtilizada;
var lblMemDisponivel;
var lblSwapTotal;
var lblSwapDisponivel;


function MostarComponentes(computador) {

    lblNomePersonalizado.text(computador.modeloComputador);
    lblNomeComputador.text(computador.nomeComputador);
    lblFabricantePc.text(computador.fabricanteComputador);
    lblIpv4.text(computador.ipv4Computador);
    lblFirmware.text(computador.versaoFirmware);
    lblFabricanteSO.text(computador.OS.fabricanteSO);
    lblFamiliaSO.text(computador.OS.familiaSO);
    lblVersaoSO.text(computador.OS.versaoSO);
    lblNomeFabricanteCpu.text(computador.processadores.nomeFabricante);
    lblModeloCpu.text(computador.processadores.modelo);
    lblFrequenciaBase.text(computador.processadores.frequenciaBase.toFixed(1) + " GHz");
    lblNucleosCpu.text(computador.processadores.nucleos);
    lblSerialCpu.text(computador.processadores.serial);
    lblProcessosExecucao.text(computador.processadores.processosExecucao);
    lblFrequenciaAtual.text(computador.processadores.velocidade + " GHz");
    lblPorcenUtiizacao.text(computador.processadores.porcentagemUtilizacao + " %");
    lblThreadsExec.text(computador.processadores.threadsExecucao);
    lblTempoExec.text(computador.processadores.tempoExecucao.replace("days", "dias"));
    lblTemperaturaCpu.text(computador.processadores.temperaturaCpu + "ºC");
    lblPorcentagemRam.text(computador.RAM.porcentagemUtilizacao + " %");
    lblMemTotal.text(computador.RAM.memoriaTotal + " GB");
    lblMemUtilizada.text(computador.RAM.memoriaUtilizada + " MB");
    lblMemDisponivel.text(computador.RAM.memoriaDisponivel + " MB");
    lblSwapTotal.text(computador.RAM.swapTotal + " GB");
    lblSwapDisponivel.text(computador.RAM.swapUtilizada + " GB");
    
    desenharGraficoCpu(parseInt(computador.processadores.porcentagemUtilizacao));
    desenharGraficoRam(parseInt(computador.RAM.porcentagemUtilizacao));
    desenharGraficosArmazenamento(computador.armazenamentos);
    //desenharGraficoArmazenamentos(computador.armazenamentos[2].capacidadeTotal, computador.armazenamentos[2].capacidadeUtilizada);

}

function BuscarComputador(codComputador) {

    computador = codComputador;

    //var URL = "http://localhost:52121/api/Monitorar/?id=5&codComputador=" + codComputador + "";

    var URL = "https://heimdallview.azurewebsites.net/api/Monitorar/?id=5&codComputador=" + codComputador + "";

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URL,
        "method": "GET"
    };

    $.ajax(settings).done(function (response) {
        populate();
        MostarComponentes(response);
    });
}

function populate() {
    lblNomePersonalizado = $('#nomePersonalizado');
    lblNomeComputador = $('#nomeComputador');
    lblFabricantePc = $('#fabricantePc');
    lblIpv4 = $('#ipv4');
    lblFirmware = $('#firmware');
    lblFabricanteSO = $('#fabricanteSO');
    lblFamiliaSO = $('#familiaSO');
    lblVersaoSO = $('#versaoSO');
    lblNomeFabricanteCpu = $('#nomeFabricanteCpu');
    lblModeloCpu = $('#modeloCpu');
    lblFrequenciaBase = $('#frequenciaBase');
    lblNucleosCpu = $('#nucleosCpu');
    lblSerialCpu = $('#serialCpu');
    lblProcessosExecucao = $('#processosExecucao');
    lblFrequenciaAtual = $('#frequenciaAtual');
    lblPorcenUtiizacao = $('#porcenUtiizacao');
    lblThreadsExec = $('#threadsExec');
    lblTempoExec = $('#tempoExec');
    lblTemperaturaCpu = $('#temperaturaCpu');
    lblPorcentagemRam = $('#porcentagemRam');
    lblMemTotal = $('#memTotal');
    lblMemUtilizada = $('#memUtilizada');
    lblMemDisponivel = $('#memDisponivel');
    lblSwapTotal = $('#swapTotal');
    lblSwapDisponivel = $('#swapDisponivel');
}

setInterval(function BuscarComputador() {

    var URL = "https://heimdallview.azurewebsites.net/api/Monitorar/?id=5&codComputador=" + computador + "";

    //var URL = "http://localhost:52121/api/Monitorar/?id=5&codComputador=" + codComputador + "";

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": URL,
        "method": "GET"
    };

    $.ajax(settings).done(function (response) {
        populate();
        MostarComponentes(response);
    });
}, 1000);