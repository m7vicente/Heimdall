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

       // public void mensagemEviou()
        //{
           // txtEspec.Text = "mensagem enviada";
        //}

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            SmtpClient cliente = new SmtpClient();
            MailMessage msg = new MailMessage();
            System.Net.NetworkCredential smtp = new System.Net.NetworkCredential("associacaobifrost@gmail.com", "bifrost@10");
           

            // Especifica o servidor SMTP e a porta
            try
            {
                cliente.Host = "smtp.gmail.com";
                cliente.Port = 587;
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = smtp;
                cliente.EnableSsl = true;

                string body = string.Concat("nome: ", txtNome.Text, "\n E-mail: ", txtEmail.Text, "\n telefone: ", txtTel.Text, "\n mensagem: ", txtEspec.Text);
                msg.Subject = "fale conosco";
                msg.Body = body;
                //msg.From = new MailAddress("associacaobifrost@gmail.com");
                msg.From = new MailAddress(txtEmail.Text);
                
                msg.To.Add(new MailAddress("associacaobifrost@gmail.com"));//adicionar email de usuario
                //msg.To.Add(new MailAddress(txtEmail.Text));

                // Envia a mensagem
                cliente.Send(msg);

                txtEspec.Text = "mensagem enviada com sucesso";


            }
            catch (Exception ex)
            {
                // Exceções devem ser tratadas aqui!
               
                txtEspec.Text = "Ocorreu um erro ao enviar mensagem ";
            }
        }
    }
}
