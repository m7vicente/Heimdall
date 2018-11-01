package heimdall;

import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.OperatingSystem;
import oshi.util.FormatUtil;

public class HistoricoEstadoProcessador {
    
    private long processosExecucao;
    private double velocidade;
    private int porcentagemUtilizacao;
    private int threadsExecucao;
    private String tempoExecucao;
    private double temperaturaCpu;
    
    HardwareAbstractionLayer processador = new SystemInfo().getHardware();
    OperatingSystem operacao = new SystemInfo().getOperatingSystem();
    
    public int getPorcentagemUtilizacao() {
        this.porcentagemUtilizacao = (int) (processador.getProcessor().getSystemCpuLoad() * 100.0);
        return porcentagemUtilizacao;
    }

    public long getProcessosExecucao() {
        this.processosExecucao = operacao.getProcessCount();
        return processosExecucao;
    }

    public double getTemperaturaCpu() {
        this.temperaturaCpu = processador.getSensors().getCpuTemperature();
        return temperaturaCpu;
    }

    public String getTempoExecucao() {
        this.tempoExecucao = FormatUtil.formatElapsedSecs(processador.getProcessor().getSystemUptime());
        return tempoExecucao;
    }

    public int getThreadsExecucao() {
        this.threadsExecucao = operacao.getThreadCount();
        return threadsExecucao;
    }

    public double getVelocidade() {
        return velocidade;
    }
}