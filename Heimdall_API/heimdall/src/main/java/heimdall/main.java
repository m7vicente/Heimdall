package heimdall;

import java.awt.List;
import java.util.ArrayList;

import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.OSFileStore;
import oshi.software.os.OperatingSystem;

public class main {
	public static void main(String[] args) {
		
		//Sistema Operacional
        SistemaOperacional sistemaOperacional = new SistemaOperacional();
        
        //Processador
        Processador processador = new Processador();	
        
        //Memoria RAM
        HistoricoEstadoRam RAM = new HistoricoEstadoRam();
        
        //Armazenamentos
		OSFileStore[] hds = new SystemInfo().getOperatingSystem().getFileSystem().getFileStores();
		ArrayList<Armazenamento> ListaDeArmazenamentos = new ArrayList<Armazenamento>();
		
		for(int i = 0; i < hds.length ; i++) {
			Armazenamento armazenamento = new Armazenamento(hds[i]);
			
			ListaDeArmazenamentos.add(armazenamento);	
		}
		
		//Maquina como um todo
		Computador pc = new Computador(sistemaOperacional,processador,ListaDeArmazenamentos,RAM);

		
	}
}
