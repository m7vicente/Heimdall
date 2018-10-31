using Heimdall.Controllers;
using Heimdall.DataObjects;
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

            UsuarioController controller = new UsuarioController();
            if (controller.Login(usuario))
            {
                Session["usuario"] = usuario;
                //Response.Redirect("Login.aspx");
            }
        }
    }
}