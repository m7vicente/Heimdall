using Heimdall.ModelController;
using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Heimdall.Controllers
{
    public class ComputadorController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public List<Computador> Get(int id,int codUsuario)
        {
            List<Computador> computadores = new List<Computador>();
            ComputadorC c1 = new ComputadorC();
            computadores = c1.MontarVisualizacao(codUsuario);
            
            return computadores;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}