using Heimdall.ModelController;
using Heimdall.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Computador Post(JObject jsonResult)
        {
            Usuario user = new Usuario();
            
            user = JsonConvert.DeserializeObject<Usuario>(jsonResult.ToString());

            MonitorarC monitorarC = new MonitorarC(user);

            monitorarC.VerificarComputador(user);

            return user.computador;
           
           // monitorarC.Monitorar(Usuario);

        }

        // PUT api/<controller>/5
        public void Put(JObject jsonResult)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}