package com.mycompany.heimdall;

import java.text.DecimalFormat;
import oshi.SystemInfo;
import oshi.software.os.OSFileStore;
import oshi.util.FormatUtil;

public class Armazenamento {
    private String codUUID[];
    private String tipoArmazenamento[];
    private double capacidadeTotal[];
    
    OSFileStore[] hds = new SystemInfo().getOperatingSystem().getFileSystem().getFileStores();
    DecimalFormat df = new DecimalFormat("#0.0");
    
    public double[] getCapacidadeTotal() {
        
        capacidadeTotal = new double[hds.length];

        for (int i = 0; i < capacidadeTotal.length; i++) {
          capacidadeTotal[i] = Double.parseDouble(FormatUtil.formatBytes(hds[i].getTotalSpace()).split(" ")[0].replace(",", "."));
        }

        return capacidadeTotal;
    }

    public String[] getCodUUID() {
        
        codUUID = new String[hds.length];
		
        for (int i = 0; i < codUUID.length; i++) {
	codUUID[i] = hds[i].getUUID();
        }
        
        return codUUID;
    }

    public String[] getTipoArmazenamento() {
        
        tipoArmazenamento = new String[hds.length];
		
        for (int i = 0; i < tipoArmazenamento.length; i++) {
                tipoArmazenamento[i] = hds[i].getName();	
        }

        return tipoArmazenamento;
    }
}
