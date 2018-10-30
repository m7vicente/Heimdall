using Heimdall.Controllers;
using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heimdall
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Usuario novoUsuario = new Usuario();

            novoUsuario.nomeCompleto = txtNome.Text;
            novoUsuario.cargo = txtCargo.Text;
            novoUsuario.email = txtEmail.Text;
            novoUsuario.senha = txtSenha.Text;
            //using (MD5 md5 = MD5.Create())
            //{
            //    novoUsuario.senha = (md5.ComputeHash(Encoding.UTF8.GetBytes(txtSenha.Text))).ToString();
            //}                

            UsuarioController c1 = new UsuarioController();

            if (c1.Cadastrar(novoUsuario))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                lblError.Text = "USUARIO NÃO CADASTRADO";
            }
        }
    }
}