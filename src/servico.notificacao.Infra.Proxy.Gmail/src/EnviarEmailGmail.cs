using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using servico.notificacao.Infra.CrossCutting.Environment.EnvironmentConfiguration;
using servico.notificacao.Infra.Proxy.Gmail.src.Dtos;
using System;

namespace servico.notificacao.Infra.Proxy.Gmail.src
{
    public class EnviarEmailGmail : IEnviarEmailGmail
    {
        private readonly GmailConfiguration _gmailConfiguration;
        public EnviarEmailGmail(GmailConfiguration gmailConfiguration)
        {
            _gmailConfiguration = gmailConfiguration;
        }

        public bool Enviar(EnviarEmailGmailDto enviarEmailGmailDto)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_gmailConfiguration.NomeEmail, _gmailConfiguration.Email));
                message.To.Add(new MailboxAddress(enviarEmailGmailDto.Nome, enviarEmailGmailDto.Email));
                message.Subject = enviarEmailGmailDto.EmailTitle;

                message.Body = new TextPart(TextFormat.Html)
                {
                    Text = enviarEmailGmailDto.Html
                };

                using (var client = new SmtpClient())
                {
                    client.Connect(_gmailConfiguration.Host, _gmailConfiguration.Port, _gmailConfiguration.UseSsl);
                    client.Authenticate(_gmailConfiguration.Email, _gmailConfiguration.Password);

                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }

        }
    }
}