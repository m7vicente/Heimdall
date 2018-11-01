package heimdall;

import java.util.List;
import oshi.SystemInfo;
import oshi.hardware.ComputerSystem;
import oshi.software.os.OperatingSystem;

public class Computador {
    
        private String nomeComputador;
	private String marcaComputador;
	private String modeloComputador;
	private String ipv4Computador;
	private String versaoFirmware;
        
        private List<Processador> processadores;
        private List<Armazenamento> armazenamentos;
	private SistemaOperacional OS;
        //private GPU gpu
        
        
	OperatingSystem operacao = new SystemInfo().getOperatingSystem();
	ComputerSystem computador = new SystemInfo().getHardware().getComputerSystem();
	
	public String getNomeComputador() {
		this.nomeComputador = operacao.getNetworkParams().getDomainName();
		return nomeComputador;
	}
	
	public String getMarcaComputador() {
		this.marcaComputador = computador.getManufacturer();
		return marcaComputador;
	}
	
	public String getModeloComputador() {
		this.modeloComputador = computador.getModel();
		return modeloComputador;
	}
	
	public String getIpv4Computador() {
		this.ipv4Computador = operacao.getNetworkParams().getIpv4DefaultGateway();
		return ipv4Computador;
	}
	
	public String getVersaoFinware() {
		this.versaoFirmware = computador.getFirmware().getVersion();
		return versaoFirmware;
	}        
}