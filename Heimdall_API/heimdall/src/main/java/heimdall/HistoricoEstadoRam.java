package heimdall;

import java.text.DecimalFormat;
import java.text.ParseException;
import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.util.FormatUtil;


public class HistoricoEstadoRam implements Historico{

    private static  HardwareAbstractionLayer hardware = new SystemInfo().getHardware();
	
    private double memoriaUtilizada;
    private double memoriaDisponivel;
    private double memoriaTotal;
    private double swapUtilizada;
    private double swapTotal;
    private int porcentagemUtilizacao;
    
    public HistoricoEstadoRam() {
    	this.memoriaTotal = this.ObterMemoriaTotal();
    	this.memoriaDisponivel = this.ObterMemoriaDisponivel();
    	this.memoriaUtilizada = this.ObterMemoriaUtilizada();
    	this.swapUtilizada = this.ObterSwapUtilizada();
    	this.swapTotal = this.ObterSwapTotal();
    	this.porcentagemUtilizacao = this.ObterPorcentagemUtilizacao();
    }
    
        
    public double ObterMemoriaTotal() {
        return Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getTotal()).split(" ")[0].replace(",", "."));
    }
    
    public double ObterMemoriaDisponivel() {
        return Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getAvailable()).split(" ")[0].replace(",", "."));
        
    }
    
    public double ObterMemoriaUtilizada(){
        return ((this.getMemoriaTotal()*1000) - this.getMemoriaDisponivel());
    }
    
    public double ObterSwapUtilizada() {
        return Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getSwapUsed()).split(" ")[0].replace(",", "."));
        
    }
    
    public double ObterSwapTotal() {
        return Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getSwapTotal()).split(" ")[0].replace(",", "."));
        
    }
    
    public int ObterPorcentagemUtilizacao(){
        return (int) ((getMemoriaUtilizada() * 0.1) / getMemoriaTotal());
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
    	this.memoriaDisponivel = this.ObterMemoriaDisponivel();
    	this.memoriaUtilizada = this.ObterMemoriaUtilizada();
    	this.swapUtilizada = this.ObterSwapUtilizada();
    	this.swapTotal = this.ObterSwapTotal();
    	this.porcentagemUtilizacao = this.ObterPorcentagemUtilizacao();
	}
    
    
}
