using Heimdall.ModelController;
using Heimdall.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace Heimdall.Controllers
{
    public class MonitorarController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Computador Get(int id, int codComputador)
        {
            if (id == 5)
            {
                return new MonitorarC().GetComputador(codComputador);
            }
            else{
                return null;
            }
        }

        // POST api/<controller>
        public Computador Post(JObject jsonResult)
        {
            Usuario user = new Usuario();
            
            user = JsonConvert.DeserializeObject<Usuario>(jsonResult.ToString());

            MonitorarC monitorarC = new MonitorarC();

            monitorarC.VerificarComputador(user);

            return user.computador;       

        }

        // PUT api/<controller>/5
        public bool Put(JObject jsonResult,int atualizar)
            {
            if(atualizar == 5)
            {
                Usuario user = new Usuario();

                user = JsonConvert.DeserializeObject<Usuario>(jsonResult.ToString());

                MonitorarC monitorarC = new MonitorarC();

                monitorarC.AtualizarComputador(user);

                return true;

            }
            else
            {
                return false;
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}