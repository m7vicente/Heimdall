using Heimdall.ModelController;
using Heimdall.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace Heimdall.Controllers
{
    public class UsuarioController : ApiController
    {

        private UsuarioC usuarioController = new UsuarioC();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //public Usuario Get(JObject jsonResult)
        //{
        //    Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonResult.ToString());
        //    Login(usuario);

        //    return usuario;
        //}

        public Usuario Post(JObject jsonResult)
        {
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonResult.ToString());

            if (usuarioController.Login(usuario)){
                return usuario;
            }
            else
            {
                usuario.email = "";
                usuario.senha = "";
                return usuario;
            }
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
