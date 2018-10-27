
package com.mycompany.heimdall;

import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.OperatingSystem;
import oshi.util.FormatUtil;


public class Processador {
    
    private String nomeFabricante;
    private String modelo;
    private double frequenciaBase;
    private int nucleos;
    private String serial;

    HardwareAbstractionLayer processador = new SystemInfo().getHardware();	
    OperatingSystem operacao = new SystemInfo().getOperatingSystem();
    
    public double getFrequenciaBase() {
       this.frequenciaBase = Double.parseDouble(FormatUtil.formatHertz(processador.getProcessor().getVendorFreq()).split(" ")[0].replace(",", "."));
       return frequenciaBase;
    }

    public String getModelo() {
        this.modelo = ""+processador.getProcessor();
        return modelo;
    }

    public String getNomeFabricante() {
        this.nomeFabricante = processador.getProcessor().getVendor();
        return nomeFabricante;
    }

    public int getNucleos() {
        this.nucleos = processador.getProcessor().getPhysicalProcessorCount();
        return nucleos;
    }

    public String getSerial() {
        this.serial = processador.getProcessor().getSystemSerialNumber();
        return serial;
    }
}
