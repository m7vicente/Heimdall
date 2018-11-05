package heimdall;

import java.util.List;
import oshi.SystemInfo;
import oshi.hardware.ComputerSystem;
import oshi.software.os.OperatingSystem;

public class Computador {
	
	private static OperatingSystem operacao = new SystemInfo().getOperatingSystem();
	private static ComputerSystem computador = new SystemInfo().getHardware().getComputerSystem();
    
	private int codComputador;
    private String nomeComputador;
	private String fabricanteComputador;
	private String modeloComputador;
	private String ipv4Computador;
	private String versaoFirmware;
        
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
	
	
	
	public static ComputerSystem getComputador() {
		return computador;
	}


	public static void setComputador(ComputerSystem computador) {
		Computador.computador = computador;
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
}