package heimdall;

import java.text.DecimalFormat;
import java.text.ParseException;
import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.util.FormatUtil;

public class HistoricoEstadoRam implements Historico {

	private transient HardwareAbstractionLayer hardware = new SystemInfo().getHardware();

	private double memoriaUtilizada;
	private double memoriaDisponivel;
	private double memoriaTotal;
	private double swapUtilizada;
	private double swapTotal;
	private int porcentagemUtilizacao;
    private int codUsuario; 
    private int codComputador;

	public HistoricoEstadoRam() {
		this.memoriaTotal = this.ObterMemoriaTotal();
		setMemoriaDisponivel(this.ObterMemoriaDisponivel());
		this.memoriaUtilizada = this.ObterMemoriaUtilizada();
		this.swapUtilizada = this.ObterSwapUtilizada();
		this.swapTotal = this.ObterSwapTotal();
		this.porcentagemUtilizacao = this.ObterPorcentagemUtilizacao();
	}

	public double ObterMemoriaTotal() {
		return Double
				.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getTotal()).split(" ")[0].replace(",", "."));
	}

	public double ObterMemoriaDisponivel() {
		return Double.parseDouble(
				FormatUtil.formatBytes(hardware.getMemory().getAvailable()).split(" ")[0].replace(",", "."));

	}

	public double ObterMemoriaUtilizada() {		
		if(this.memoriaTotal < 10.0) {
			return (this.getMemoriaTotal() * 1000) - this.getMemoriaDisponivel();
		}else {			
			return (this.getMemoriaTotal() - this.getMemoriaDisponivel());
		}
	}

	public double ObterSwapUtilizada() {
		return Double.parseDouble(
				FormatUtil.formatBytes(hardware.getMemory().getSwapUsed()).split(" ")[0].replace(",", "."));

	}

	public double ObterSwapTotal() {
		return Double.parseDouble(
				FormatUtil.formatBytes(hardware.getMemory().getSwapTotal()).split(" ")[0].replace(",", "."));

	}

	public int ObterPorcentagemUtilizacao() {
		if(this.memoriaTotal < 10.0) {
			return (int) ((getMemoriaUtilizada() * 0.1) / getMemoriaTotal());
		}else {
			return (int) (getMemoriaUtilizada() / getMemoriaTotal() * 100);
		}
		
	}

	public double getMemoriaUtilizada() {
		return memoriaUtilizada;
	}

	public double getMemoriaDisponivel() {
		return memoriaDisponivel;
	}

	public double getMemoriaTotal() {
		return memoriaTotal;
	}

	@Override
	public String toString() {
		return "HistoricoEstadoRam [memoriaUtilizada=" + memoriaUtilizada + ", memoriaDisponivel=" + memoriaDisponivel
				+ ", memoriaTotal=" + memoriaTotal + ", swapUtilizada=" + swapUtilizada + ", swapTotal=" + swapTotal
				+ ", porcentagemUtilizacao=" + porcentagemUtilizacao + "]";
	}

	public void Atualizar() {
		setMemoriaDisponivel(this.ObterMemoriaDisponivel());
		this.memoriaUtilizada = this.ObterMemoriaUtilizada();
		this.swapUtilizada = this.ObterSwapUtilizada();
		this.swapTotal = this.ObterSwapTotal();
		this.porcentagemUtilizacao = this.ObterPorcentagemUtilizacao();
	}
	
	private void setMemoriaDisponivel(double disponivel) {
		if (disponivel < 10.0) {
			this.memoriaDisponivel = (disponivel * 1000);
		}else {
			this.memoriaDisponivel = disponivel;
		}
	}

}
