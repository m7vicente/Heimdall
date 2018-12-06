
package heimdall.Log;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Vector;

/**
 *
 * @author Alice Coelho
 */
public final class ArquivoLog {
    
    File arquivo;
    FileReader fileReader;
    BufferedReader bufferedReader;
    FileWriter fileWriter;
    BufferedWriter bufferedWriter;
    
    
    public ArquivoLog(String erros)
    {
        escreverLog(erros);
    }

	private void escreverLog (String erros)
    {
        
        SimpleDateFormat df = new SimpleDateFormat("dd MMM yyyy");
        Date d = new Date ();
        //+df.format(d);
        try {
            
            arquivo = new File("Exceptions"+df.format(d)+".txt"); //qual arquivo
            fileReader = new FileReader(arquivo);
            bufferedReader = new BufferedReader(fileReader);
            Vector texto = new Vector();
            
            while(bufferedReader.ready())//enquanto tiver algo p ler...
            {
                
                texto.add(bufferedReader.readLine());//...vai adicionar em "texto"
            }
            fileWriter = new FileWriter(arquivo);
            bufferedWriter = new BufferedWriter(fileWriter);
            for(int i=0; i<texto.size(); i++)//estrutura de repetição|
                                             // enquanto i for menor que texto, adiciona mais 1
                                               
            {
                //armazenadentro do texto | recebe cada linha
                //o .toString é porque a variavel não é uma String
                //df.format(d);
                
                bufferedWriter.write(texto.get(i).toString());
                
                //pula linha | nva linha
                bufferedWriter.newLine();
                
            }
            //escrever os erros
            bufferedWriter.write(erros);
            //fechar cada um fecha uma coisa diferente, por isso tem dois
            bufferedWriter.close();
            bufferedWriter.close();
            
            
        }
        catch (FileNotFoundException ex)
        {
            try 
            {
                //caso não tiver um arquivo, ira criar um
                arquivo.createNewFile();
                escreverLog(erros);
            }
            catch (IOException ex1)
            {
                System.exit(0);//parar
            }   
        }
        
        catch (IOException er)
            {
                System.exit(0);
            }
    
    
 
    }
    
    
}
