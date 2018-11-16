using Heimdall.DataObjects;
using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heimdall.ModelController
{
    public class UsuarioC
    {
        UsuarioDO banco = new UsuarioDO();

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

            banco.buscar(usuario);

            if (usuario.ativo && usuario.nomeCompleto != null)
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