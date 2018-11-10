package heimdall;

import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.OperatingSystem;
import oshi.util.FormatUtil;


public class Processador implements Historico{
	
	private static HardwareAbstractionLayer processador = new SystemInfo().getHardware();
	private static OperatingSystem operacao = new SystemInfo().getOperatingSystem();
    
	private int CodProcessador;
    public String nomeFabricante;
    private String modelo;
    private double frequenciaBase;
    private int nucleos;
    private String serial;
    private long processosExecucao;
    private int porcentagemUtilizacao;
    private int threadsExecucao;
    private String tempoExecucao;
    private double temperaturaCpu;
    

    public Processador() {
    	this.nomeFabricante = this.ObterNomeFabricante();
    	this.modelo = this.ObterModelo();
    	this.frequenciaBase = this.ObterFrequenciaBase();
    	this.nucleos = this.obterNucleos();
    	this.serial = this.ObterSerial();
    	this.processosExecucao = this.ObterProcessosExecucao();
    	this.threadsExecucao = this.ObterThreadsExecucao();
    	this.tempoExecucao = this.ObterTempoExecucao();
    	this.temperaturaCpu = this.ObterTemperaturaCpu();
    	this.porcentagemUtilizacao = this.ObterPorcentagemUtilizacao();
    }
    
    
    
    public int getCodProcessador() {
		return CodProcessador;
	}



	public void setCodProcessador(int codProcessador) {
		CodProcessador = codProcessador;
	}



	private double ObterFrequenciaBase() {
        return Double.parseDouble(FormatUtil.formatHertz(processador
        		.getProcessor()
        		.getVendorFreq())
        		.split(" ")[0].replace(",", "."));
    }

    private String ObterModelo() {
        return ""+processador.getProcessor();
    }

    private String ObterNomeFabricante() {
        return processador.getProcessor().getVendor();
    }

    private int obterNucleos() {
        return processador.getProcessor().getPhysicalProcessorCount();
    }

    public String ObterSerial() {
        return processador.getProcessor().getSystemSerialNumber();
    }
    
    private int ObterPorcentagemUtilizacao(){
    	return (int) (processador.getProcessor().getSystemCpuLoad() * 100.0);    
    }

    private long ObterProcessosExecucao() {
    	return operacao.getProcessCount();
    }

    private double ObterTemperaturaCpu() {
        return processador.getSensors().getCpuTemperature();
    }

    private String ObterTempoExecucao() {
        return FormatUtil.formatElapsedSecs(processador.getProcessor().getSystemUptime());
    }

    private int ObterThreadsExecucao() {
        return operacao.getThreadCount();
    }

    
	public void Atualizar() {
    	this.processosExecucao = this.ObterProcessosExecucao();
    	this.threadsExecucao = this.ObterThreadsExecucao();
    	this.tempoExecucao = this.ObterTempoExecucao();
    	this.temperaturaCpu = this.ObterTemperaturaCpu();
    	this.porcentagemUtilizacao = this.ObterPorcentagemUtilizacao();		
	}
    
}
