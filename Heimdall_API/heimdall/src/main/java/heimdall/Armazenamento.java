package heimdall;

import java.text.DecimalFormat;
import oshi.SystemInfo;
import oshi.software.os.OSFileStore;
import oshi.util.FormatUtil;

public class Armazenamento implements Historico{
	
    private final String codUUID;
    private final String tipoArmazenamento;
    private final double capacidadeTotal;
    private double capacidadeUtilizada;
    private String letraLocal;
    private int codUsuario; 
    private int codComputador;
    
    private transient  OSFileStore hd;
    private transient  DecimalFormat df = new DecimalFormat("#0.0");
    
    public Armazenamento(OSFileStore hd) {
    	this.hd = hd;
    	this.codUUID = this.ObtertCodUUID();
    	this.capacidadeTotal = this.ObterCapacidadeTotal();
    	this.tipoArmazenamento = this.ObterTipoArmazenamento();
    	this.capacidadeUtilizada = this.ObterCapacidadeUtilizada();
    	this.letraLocal = this.ObterLetraLocal();
    }
    
    private double ObterCapacidadeTotal() {
    	return Double.parseDouble(FormatUtil.formatBytes(hd.getTotalSpace()).split(" ")[0].replace(",", "."));        
    }

    private String ObtertCodUUID() {
    	return hd.getUUID();     
    }

    private String ObterTipoArmazenamento() {
    	return hd.getName().replace("í", "i");	        
    }
    
    private double ObterCapacidadeUtilizada() {       
    	return Double.parseDouble(FormatUtil.formatBytesDecimal(hd.getUsableSpace()).split(" ")[0].replace(",", "."));
    }

    private String ObterLetraLocal() {
    	return hd.getMount();
    }
    
    public void setHD(OSFileStore hd) {
    	this.hd = hd;
    }
    
    public void Atualizar() {
    	this.capacidadeUtilizada = this.ObterCapacidadeUtilizada();
    	this.letraLocal = this.ObterLetraLocal();
    }

    
    

}