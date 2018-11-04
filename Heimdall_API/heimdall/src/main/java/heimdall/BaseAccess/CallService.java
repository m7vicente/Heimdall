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

public class CallService extends ServiceURL{
	
	public Usuario ObterUsuario(Usuario login) {
		
		//login = new Usuario("Pedro@bifrost.com.br","12345");
		
		Gson gson = new GsonBuilder().excludeFieldsWithModifiers(Modifier.STATIC).create();
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
  			throw new RuntimeException("Failed : HTTP error code : "
  				+ conn.getResponseCode());
  		}

  		String output = new BufferedReader(new InputStreamReader((conn.getInputStream()))).readLine();
  		  		
  		login = gson.fromJson(output, login.getClass());
  		
  		conn.disconnect();
  		
  		return login;

  	  } 
  	  catch (MalformedURLException e) {
  		e.printStackTrace();
  	  } 
  	  catch (IOException e) {
  		e.printStackTrace();
  	  }
  	  return login;

	}
	
	public void CadastrarComputador(Usuario usuario) {
		
		Gson gson = new GsonBuilder().excludeFieldsWithModifiers(Modifier.STATIC).create();
        String json = gson.toJson(usuario);
        
        System.out.println(json);
		
		
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
    			throw new RuntimeException("Failed : HTTP error code : "
    				+ conn.getResponseCode());
    		}
    		
    		

    		//String output = new BufferedReader(new InputStreamReader((conn.getInputStream()))).readLine();
    		  		
    		//login = gson.fromJson(output, login.getClass());
    		
    		conn.disconnect();

    	  } catch (MalformedURLException e) {
    		e.printStackTrace();
    	  } catch (IOException e) {
    		e.printStackTrace();
    	  }
	}

}
