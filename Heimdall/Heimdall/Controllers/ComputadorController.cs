using Heimdall.ModelController;
using Heimdall.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Heimdall.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComputadorController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Computador> Get(int codUsuario)
        {
            List<Computador> computadores = new List<Computador>();
            ComputadorC c1 = new ComputadorC();
            
            foreach(Computador computador in c1.MontarVisualizacao(codUsuario))
            {
                computadores.Add(new MonitorarC().GetComputador(computador.codComputador)); 
            }

            return computadores;
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