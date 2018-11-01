package heimdall;

import java.text.DecimalFormat;
import oshi.SystemInfo;
import oshi.software.os.OSFileStore;
import oshi.util.FormatUtil;

public class HistoricoArmazenamento {
    
    private double capacidadeUtilizada[];
    private String letraLocal[];
    
    OSFileStore[] hds = new SystemInfo().getOperatingSystem().getFileSystem().getFileStores();
    DecimalFormat df = new DecimalFormat("#0.0");
    
    
    public double[] getCapacidadeUtilizada() {
        
        capacidadeUtilizada = new double[hds.length];
        
        for(int i = 0; i < capacidadeUtilizada.length; i++){
        capacidadeUtilizada[i] = Double.parseDouble(FormatUtil.formatBytesDecimal(hds[i].getUsableSpace()).split(" ")[0].replace(",", "."));
        }
        
        return capacidadeUtilizada;
    }

    public String[] getLetraLocal() {
     
        letraLocal = new String[hds.length];
		
        for (int i = 0; i < letraLocal.length; i++) {
                letraLocal[i] = hds[i].getMount();
        }
        return letraLocal;
    }
}