package heimdall.Log;

import java.text.SimpleDateFormat;
import java.util.Date;

public class AdicionarLog {
    
        
    SimpleDateFormat df = new SimpleDateFormat("dd MMM yyyy HH:mm");
    
    
    public void EscreverLog(String Escrever){
       
    	Date d = new Date ();
        Escrever +=" "+df.format(d);
        new ArquivoLog(Escrever);
        
        
    }
    
    
}
