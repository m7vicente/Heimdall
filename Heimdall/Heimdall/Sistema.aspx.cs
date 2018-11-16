using Heimdall.Models;
using System;
using System.Web.UI;

namespace Heimdall
{
    public partial class Sistema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, GetType(), "BuscarProcessador", $"BuscarProcessador({usuario.codUsuario});", true);
            }
        }
    }
}