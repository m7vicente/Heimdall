using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heimdall
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
            //string codComputador = Request.QueryString["codComputador"].ToString();
            //Usuario usuario = (Usuario)Session["usuario"];
            //lblLaranja.Text = codComputador;
        }
    }
}