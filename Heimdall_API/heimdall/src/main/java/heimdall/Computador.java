package heimdall;

import java.util.List;
import oshi.SystemInfo;
import oshi.hardware.ComputerSystem;
import oshi.software.os.OperatingSystem;

public class Computador {
	
	private transient OperatingSystem operacao = new SystemInfo().getOperatingSystem();
	private transient  ComputerSystem computador = new SystemInfo().getHardware().getComputerSystem();
    
	private int codComputador;
    private final String nomeComputador;
	private final String fabricanteComputador;
	private final String modeloComputador;
	private final String ipv4Computador;
	private final String versaoFirmware;
        
    private Processador processadores;
    private List<Armazenamento> armazenamentos;
	private SistemaOperacional OS;
	private HistoricoEstadoRam RAM;

        
	public Computador(SistemaOperacional OS,Processador processadores,List<Armazenamento> armazenamentos,HistoricoEstadoRam RAM) {
		this.processadores = processadores;
		this.armazenamentos = armazenamentos;
		this.OS = OS;
		
		this.nomeComputador = this.ObterNomeComputador();
		this.fabricanteComputador = this.ObterMarcaComputador();
		this.modeloComputador = this.ObterModeloComputador();
		this.ipv4Computador = this.ObterIpv4Computador();
		this.versaoFirmware = this.ObterVersaoFinware();
		this.RAM = RAM;
	}
	
	
	


	public int getCodComputador() {
		return codComputador;
	}



	public void setCodComputador(int codComputador) {
		this.codComputador = codComputador;
	}



	private String ObterNomeComputador() {
		return operacao.getNetworkParams().getDomainName();
	}
	
	private String ObterMarcaComputador() {
		return computador.getManufacturer();
	}
	
	private String ObterModeloComputador() {
		return computador.getModel();
	}
	
	private String ObterIpv4Computador() {
		return operacao.getNetworkParams().getIpv4DefaultGateway();
	}
	
	private String ObterVersaoFinware() {
		return computador.getFirmware().getVersion();
	}



	public Processador getProcessadores() {
		return processadores;
	}
	
	public void setProcessadores(Processador processador) {
		this.processadores = processador;
	}



	public SistemaOperacional getOS() {
		return OS;
	}



	public HistoricoEstadoRam getRAM() {
		return RAM;
	}



	public List<Armazenamento> getArmazenamentos() {
		return armazenamentos;
	}



	public void setArmazenamentos(List<Armazenamento> armazenamentos) {
		this.armazenamentos = armazenamentos;
	}



	public void setOS(SistemaOperacional oS) {
		OS = oS;
	}



	public void setRAM(HistoricoEstadoRam rAM) {
		RAM = rAM;
	}     
	
	
	
	
}