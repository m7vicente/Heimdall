using Heimdall.ModelController;
using Heimdall.Models;
using System;


namespace Heimdall
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
           
            usuario.email = txtEmail.Text;
            usuario.senha = txtSenha.Text;

            UsuarioC controller = new UsuarioC();
            if (controller.Login(usuario))
            {
                Session["usuario"] = usuario;
                Response.Redirect("Sistema.aspx");
            }
        }
    }
}