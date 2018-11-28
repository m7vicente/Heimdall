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
import heimdall.Log.AdicionarLog;
import heimdall.Log.ArquivoLog;;

public class main {
		
	static final AdicionarLog Log = new AdicionarLog();

	public static void main(String[] args) throws InterruptedException {

		// Usuario login = new Usuario("Pedro@bifrost.com.br","12345");
		Usuario user = new Usuario("", "");
		CallService service = new CallService();


		while (true) {
			user.setEmail(JOptionPane.showInputDialog("Insira seu Email: "));

			while (user.getEmail().equals("")) {
				user.setEmail(JOptionPane.showInputDialog("Insira seu Email: ").toLowerCase());
			}

			while (user.getSenha().equals("")) {

				JPasswordField jpf = new JPasswordField(24);
				JLabel jl = new JLabel("Insira sua senha: ");
				Box box = Box.createHorizontalBox();
				box.add(jl);
				box.add(jpf);
				int x = JOptionPane.showConfirmDialog(null, box, "Senha", JOptionPane.OK_CANCEL_OPTION);

				if (x == JOptionPane.OK_OPTION) {
					user.setSenha(jpf.getText());
				} else {
					System.exit(0);
				}
			}

			user = service.ObterUsuario(user);

			if (user.getCodUsuario() > 0 && !user.getNomeCompleto().equals("")) {
				Log.EscreverLog("Usuario logado: ");
				break;
			}
			
			Log.EscreverLog("Usuario não validado: ");

		}

		// Sistema Operacional
		SistemaOperacional sistemaOperacional = new SistemaOperacional();

		// Processador
		Processador processador = new Processador();

		// Memoria RAM
		HistoricoEstadoRam RAM = new HistoricoEstadoRam();

		// Armazenamentos
		OSFileStore[] hds = new SystemInfo().getOperatingSystem().getFileSystem().getFileStores();
		ArrayList<Armazenamento> ListaDeArmazenamentos = new ArrayList<Armazenamento>();

		for (int i = 0; i < hds.length; i++) {
			Armazenamento armazenamento = new Armazenamento(hds[i]);

			ListaDeArmazenamentos.add(armazenamento);

		}
		// Maquina como um todo
		Computador pc = new Computador(sistemaOperacional, processador, ListaDeArmazenamentos, RAM);

		user.setComputador(pc);

		user = service.CadastrarComputador(user);
		
		while (true) {
			Thread.sleep(5000);

			user.getComputador().getProcessadores().Atualizar();
			user.getComputador().getRAM().Atualizar();
			
			for(int i = 0; i < user.getComputador().getArmazenamentos().size(); i++ ) {
				user.getComputador().getArmazenamentos().get(i).setHD(hds[i]);
				user.getComputador().getArmazenamentos().get(i).Atualizar();
			}

			service.Atualizar(user);
		}

	}

}
