using servico.notificacao.Infra.Proxy.Gmail.src.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servico.notificacao.Infra.Proxy.Gmail.src.BoasVindas
{
    public class BoasVindasGmail : IBoasVindasGmail
    {
        private readonly IEnviarEmailGmail _enviarEmailGmail;
        public BoasVindasGmail(
            IEnviarEmailGmail enviarEmailGmail
        )
        {
            _enviarEmailGmail = enviarEmailGmail;
        }

        public async Task<bool> Enviar(BoasVindasGmailDto boasVindasGmailDto)
        {
            try
            {
                using (var sr = new StreamReader("./template/boas-vindas.html"))
                {
                    var Html = await sr.ReadToEndAsync();
                    Html = Html.Replace("{{nome}}", boasVindasGmailDto.Nome);

                    return _enviarEmailGmail.Enviar(new EnviarEmailGmailDto()
                    {
                        Nome = boasVindasGmailDto.Nome,
                        Email = boasVindasGmailDto.Email,
                        EmailTitle = "Bem vindo ao Gestor 7!",
                        Html = Html
                    });
                }
            }
            catch(Exception exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
