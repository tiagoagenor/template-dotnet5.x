using servico.notificacao.Infra.Proxy.Gmail.src.Dtos;

namespace servico.notificacao.Infra.Proxy.Gmail.src
{
    public interface IEnviarEmailGmail
    {
        bool Enviar(EnviarEmailGmailDto enviarEmailGmailDto);
    }
}