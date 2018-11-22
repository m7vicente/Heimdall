using Heimdall.ModelController;
using Heimdall.Models;
using System;
using System.Linq;
using System.Web.UI;

namespace Heimdall
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {

            string nome = txtNome.Text;

            string [] array = nome.Split(' ');

            for (int i = 0; i < array.Length; i++)
            {
                if (!(array[i].Length == 1))
                {
                    array[i] = array[i].Substring(0, 1).ToUpper() + array[i].Substring(1).ToLower();
                }
            }

            nome = string.Join(" ", array);
            

            Usuario novoUsuario = new Usuario();

            novoUsuario.nomeCompleto = nome;
            novoUsuario.cargo = txtCargo.Text;
            novoUsuario.email = txtEmail.Text.ToLower();
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