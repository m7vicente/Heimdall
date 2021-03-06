﻿using Heimdall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heimdall
{
    public partial class Relatorio : System.Web.UI.Page
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
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "BuscarComputadores", $"BuscarComputadores({usuario.codUsuario});", true);
            }
        }

        protected void sair_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Inicio.aspx");
        }
    }
}