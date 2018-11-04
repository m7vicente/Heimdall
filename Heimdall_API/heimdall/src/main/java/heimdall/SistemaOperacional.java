package heimdall;

import oshi.SystemInfo;
import oshi.software.os.OperatingSystem;

public class SistemaOperacional {
    
    private String fabricanteSO;
    private String versaoSO;
    private String familiaSO;

    private static OperatingSystem so = new SystemInfo().getOperatingSystem();
    
    public SistemaOperacional() {
    	this.fabricanteSO = this.ObterFabricanteSO();
    	this.versaoSO = this.ObterVersaoSO();
    	this.familiaSO = this.ObterFamiliaSO();
    }

    private String ObterFabricanteSO() {
        return so.getManufacturer(); 
    }
    private String ObterVersaoSO() {
        return ""+so.getVersion();
    }
    private String ObterFamiliaSO() {
        return so.getFamily();
    }
}
