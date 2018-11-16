package heimdall.BaseAccess;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.lang.reflect.Modifier;
import java.lang.reflect.Type;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import heimdall.Computador;
import heimdall.Usuario;

public class CallService extends ServiceURL {

	private Gson gson = new GsonBuilder().excludeFieldsWithModifiers(Modifier.STATIC).create();

	public Usuario ObterUsuario(Usuario login) {


		String json = gson.toJson(login);

		try {

			URL url = new URL(this.sevicoLogin);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setDoOutput(true);
			conn.setRequestMethod("POST");
			conn.setRequestProperty("Content-Type", "application/json");

			OutputStream os = conn.getOutputStream();
			os.write(json.getBytes());
			os.flush();

			if (conn.getResponseCode() != 200) {
				throw new RuntimeException("Failed : HTTP error code : " + conn.getResponseCode());
			}

			String output = new BufferedReader(new InputStreamReader((conn.getInputStream()))).readLine();

			login = gson.fromJson(output, login.getClass());

			conn.disconnect();

			return login;

		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return login;

	}

	public Usuario CadastrarComputador(Usuario usuario) {

		String json = gson.toJson(usuario);

		//System.out.println(json);

		try {

			URL url = new URL(this.sevicoMonitorar);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setDoOutput(true);
			conn.setRequestMethod("POST");
			conn.setRequestProperty("Content-Type", "application/json");

			OutputStream os = conn.getOutputStream();
			os.write(json.getBytes());
			os.flush();
			System.out.println(conn.getOutputStream().toString());

			if (conn.getResponseCode() != 200) {
				throw new RuntimeException("Failed : HTTP error code : " + conn.getResponseCode());
			}

			String output = new BufferedReader(new InputStreamReader((conn.getInputStream()))).readLine();	
			
			usuario.setComputador(gson.fromJson(output, usuario.getComputador().getClass()));
			//usuario.getComputador().getProcessadores().setCodProcessador(gson.fromJson(output, usuario.getComputador().getProcessadores().getClass()));
						
			//System.out.println(usuario.getComputador().getProcessadores().getCodProcessador());
			
			conn.disconnect();

		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}

		return usuario;
	}

	public void Atualizar(Usuario usuario) {

		String json = gson.toJson(usuario);

		System.out.println("Atualizar JSON("+json);

		try {

			URL url = new URL(this.servicoAtualizar);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setDoOutput(true);
			conn.setRequestMethod("PUT");
			conn.setRequestProperty("Content-Type", "application/json");

			OutputStream os = conn.getOutputStream();
			os.write(json.getBytes());
			os.flush();

			if (conn.getResponseCode() != 200) {
				throw new RuntimeException("Failed : HTTP error code : " + conn.getResponseCode());
			}
			
			String output = new BufferedReader(new InputStreamReader((conn.getInputStream()))).readLine();	
			
			if(output.equals("true")) {
				System.out.println("Atualizado com Sucesso ");
			}else {
				System.out.println("Erro na atulizalção");
			}

			conn.disconnect();

		} catch (MalformedURLException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

}
