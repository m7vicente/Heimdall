package heimdall.BaseAccess;

public abstract class ServiceURL {
	
	//DEV
	protected final String sevicoLogin = "http://localhost:52121/api/Usuario/";
	
	protected final String sevicoMonitorar = "http://localhost:52121/api/Monitorar/";
	
	protected final String servicoAtualizar = "http://localhost:52121/api/Monitorar/?atualizar=5";
	
	//PROD
	//private String sevicoLogin = "http://heimdallview.azurewebsite.net/api/Usuario/";

	
}
