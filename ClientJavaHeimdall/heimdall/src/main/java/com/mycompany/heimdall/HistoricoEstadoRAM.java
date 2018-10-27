
package com.mycompany.heimdall;

import java.text.DecimalFormat;
import java.text.ParseException;
import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.util.FormatUtil;


public class HistoricoEstadoRAM {

    private double memoriaUtilizada;
    private double memoriaDisponivel;
    private double memoriaTotal;
    private double swapUtilizada;
    private double swapTotal;
    private int porcentagemUtilizacao;
    
        
    HardwareAbstractionLayer hardware = new SystemInfo().getHardware();

    public double getMemoriaTotal() {
        this.memoriaTotal = Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getTotal()).split(" ")[0].replace(",", "."));
        return memoriaTotal;
    }
    
    public double getMemoriaDisponivel() {
        this.memoriaDisponivel = Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getAvailable()).split(" ")[0].replace(",", "."));
        return memoriaDisponivel;
    }
    
    public double getMemoriaUtilizada(){
        this.memoriaUtilizada = getMemoriaTotal() - getMemoriaDisponivel();
        return memoriaUtilizada;
    }
    
    public double getSwapUtilizada() {
        this.swapUtilizada = Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getSwapUsed()).split(" ")[0].replace(",", "."));
        return swapUtilizada;
    }
    
    public double getSwapTotal() {
        this.swapTotal = Double.parseDouble(FormatUtil.formatBytes(hardware.getMemory().getSwapTotal()).split(" ")[0].replace(",", "."));
        return swapTotal;
    }
    
    public int getPorcentagemUtilizacao(){
        this.porcentagemUtilizacao = (int) ((getMemoriaUtilizada() * 100) / getMemoriaTotal());
        return porcentagemUtilizacao;
    }
}
