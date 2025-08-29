using System.Collections.Specialized;
using System.Net.Mail;
using System.Net;
using System.Runtime.Intrinsics.X86;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EmailServices.Repository
{
    public class EmailService
    {
        
        private readonly IConfiguration _config;
        private IHostingEnvironment _env;
        private SmtpClient smtpClient;
        private HttpClientHandler clientHandler;
        private HttpClient client;
        private static string emailuser = "";
        private static string emailpass = "";
        private static string emailfrom = "";
        private static SmtpClient emailClient = new SmtpClient("mail.businessemailhost.com");

        private static System.Net.NetworkCredential SMTPUserInfo;
        private static decimal MinimumAmount = 1.00M;
        private static bool SSL = true;
        private static int PORT = 587;
        public string adminmail = "";
        public EmailService( IConfiguration config,  IHostingEnvironment environment, SmtpClient smtpClient)
        {
            this.smtpClient = smtpClient;
            _config = config;
            _env = environment;
            emailuser = _config.GetValue<string>("SmtpSettings:Username");
            emailpass = _config.GetValue<string>("SmtpSettings:Password");
            emailfrom = _config.GetValue<string>("SmtpSettings:Emailfrom");
            adminmail = _config.GetValue<string>("SmtpSettings:AdminMail");
            SMTPUserInfo = new System.Net.NetworkCredential(emailuser, emailpass);
        }
        public bool SendEmailWOTs(string emailfrom, string adminmail,int Port ,string emailuser,string emailpass, bool SSl,string to, string subject, string body, NameValueCollection? Parameters = null, string? attachedFilePath = null)
        {
            SMTPUserInfo = new System.Net.NetworkCredential(emailuser, emailpass);
            if (Parameters != null)
            {
                foreach (string item in Parameters.AllKeys)
                {
                    body = body.Replace(item, Parameters[item]);
                }
            }
            MailMessage message = new MailMessage(emailfrom, to, subject, body);
            message.Bcc.Add(adminmail);

            if (!string.IsNullOrWhiteSpace(attachedFilePath))
            {
                var attachment = new Attachment(attachedFilePath.ToString());
                message.Attachments.Add(attachment);
            }
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            message.IsBodyHtml = true;

            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = SMTPUserInfo;
            emailClient.EnableSsl = SSl;
            emailClient.Port = Port;
            emailClient.Send(message);
            return true;
        }


    }
}
