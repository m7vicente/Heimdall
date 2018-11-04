package heimdall;

import java.awt.List;
import java.lang.reflect.Modifier;
import java.util.ArrayList;

import javax.swing.Box;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPasswordField;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;

import heimdall.BaseAccess.CallService;
import oshi.SystemInfo;
import oshi.hardware.HardwareAbstractionLayer;
import oshi.software.os.OSFileStore;
import oshi.software.os.OperatingSystem;

public class main {
		
	public static void main(String[] args) {
		
		Usuario login = new Usuario("","");
		CallService service = new CallService();
		
		do {
			login.setEmail(JOptionPane.showInputDialog("Insira seu Email: "));
			
			while(login.getEmail().equals("")) {
				 login.setEmail(JOptionPane.showInputDialog("Insira seu Email: ").toLowerCase());
			}
					
			while(login.getSenha().equals("")) {
			
				JPasswordField jpf = new JPasswordField(24);
				JLabel jl = new JLabel("Insira sua senha: ");
				Box box = Box.createHorizontalBox();
				box.add(jl);
				box.add(jpf);
				int x = JOptionPane.showConfirmDialog(null, box, "Senha", JOptionPane.OK_CANCEL_OPTION);
				    
				if (x == JOptionPane.OK_OPTION) {
				    login.setSenha(jpf.getText());
				}else {
					System.exit(0);
				}
			}
		}while(service.ObterUsuario(login) == false);

		System.out.println("erro");
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
		
		login.setComputador(pc);
		
	    }

	}
