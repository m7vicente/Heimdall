package com.mycompany.heimdall;

import oshi.SystemInfo;
import oshi.software.os.OperatingSystem;

public class SistemaOperacional {
    
    private String fabricanteSO;
    private String versaoSO;
    private String familiaSO;

    OperatingSystem so = new SystemInfo().getOperatingSystem();

    public String getFabricanteSO() {
        this.fabricanteSO = so.getManufacturer();
        return fabricanteSO; 
    }
    public String getVersaoSO() {
        this.versaoSO = ""+so.getVersion();
        return versaoSO;
    }
    public String getFamiliaSO() {
        this.familiaSO = so.getFamily();
        return familiaSO;
    }
}
