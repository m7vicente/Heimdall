package heimdall;

import java.text.DecimalFormat;
import oshi.SystemInfo;
import oshi.software.os.OSFileStore;
import oshi.util.FormatUtil;

public class Armazenamento implements Historico{
	
    private String codUUID;
    private String tipoArmazenamento;
    private double capacidadeTotal;
    private double capacidadeUtilizada;
    private String letraLocal;
    
    private static OSFileStore hd;
    private static DecimalFormat df = new DecimalFormat("#0.0");
    
    public Armazenamento(OSFileStore hd) {
    	this.hd = hd;
    	this.codUUID = this.ObtertCodUUID();
    	this.capacidadeTotal = this.ObterCapacidadeTotal();
    }
    
    private double ObterCapacidadeTotal() {
    	return Double.parseDouble(FormatUtil.formatBytes(hd.getTotalSpace()).split(" ")[0].replace(",", "."));        
    }

    private String ObtertCodUUID() {
    	return hd.getUUID();     
    }

    private String ObterTipoArmazenamento() {
    	return hd.getName();	        
    }
    
    private double ObterCapacidadeUtilizada() {       
    	return Double.parseDouble(FormatUtil.formatBytesDecimal(hd.getUsableSpace()).split(" ")[0].replace(",", "."));
    }

    private String ObterLetraLocal() {
    	return hd.getMount();
    }
    
    public void Atualizar() {
    	this.capacidadeUtilizada = this.ObterCapacidadeUtilizada();
    	this.letraLocal = this.ObterLetraLocal();
    }

}