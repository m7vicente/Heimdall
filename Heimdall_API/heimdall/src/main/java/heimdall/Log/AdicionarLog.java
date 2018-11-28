package heimdall.Log;

import java.text.SimpleDateFormat;
import java.util.Date;

public class AdicionarLog {
    
        
    SimpleDateFormat df = new SimpleDateFormat("dd MMM yyyy HH:mm");
    Date d = new Date ();
    
    public void EscreverLog(String Escrever){
       
        Escrever +=" "+df.format(d);
        new ArquivoLog(Escrever);
        
        
    }
    
    
}
