using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heimdall
{
    public partial class Sistema : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario usuario = (Usuario)Session["usuario"];

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "BuscarProcessador", $"BuscarProcessador({usuario.codUsuario});", true);
        }
    }
}