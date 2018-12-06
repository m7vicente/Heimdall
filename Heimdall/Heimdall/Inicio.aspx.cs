using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;


namespace Heimdall
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            SmtpClient cliente = new SmtpClient();

            MailMessage msg = new MailMessage();

            System.Net.NetworkCredential smtp = new NetworkCredential("alice.964sousa@gmail.com", "15975300@ab");

           


        }
    }
}