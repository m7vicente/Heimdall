using Heimdall.DataObjects;
using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Heimdall.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioDO banco = new UsuarioDO();

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

        public bool Cadastrar(Usuario novoUsuario)
        {
            Criptografar criptografar = new Criptografar();
            novoUsuario.senha = criptografar.GenerateSHA256String(novoUsuario.senha);

            return banco.Inserir(novoUsuario);
        }

        public bool Login(Usuario usuario)
        {

            Criptografar criptografar = new Criptografar();
            usuario.senha = criptografar.GenerateSHA256String(usuario.senha);

            usuario = banco.buscar(usuario);

            if(usuario.ativo && usuario.nomeCompleto != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
