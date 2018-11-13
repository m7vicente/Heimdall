using Heimdall.ModelController;
using Heimdall.Models;
using System;


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

            UsuarioC c1 = new UsuarioC();

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