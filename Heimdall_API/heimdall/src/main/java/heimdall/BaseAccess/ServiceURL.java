package heimdall.BaseAccess;

public abstract class ServiceURL {
	
	//DEV
	protected final String sevicoLogin = "http://localhost:52121/api/Usuario/";
	
	protected final String sevicoMonitorar = "http://localhost:52121/api/Monitorar/";
	
	protected final String servicoAtualizar = "http://localhost:52121/api/Monitorar/?atualizar=5";
	
	//PROD
	//protected final String sevicoLogin = "https://heimdallview.azurewebsites.net/api/Usuario/";
	
	//protected final String sevicoMonitorar = "https://heimdallview.azurewebsites.net/api/Monitorar/";
	
	//protected final String servicoAtualizar = "https://heimdallview.azurewebsites.net/api/Monitorar/?atualizar=5";

	
}
