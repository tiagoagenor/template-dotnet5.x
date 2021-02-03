namespace servico.notificacao.Infra.Proxy.Gmail.src.Dtos
{
    public class EnviarEmailGmailDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string EmailTitle { get; set; }
        public string Html { get; set; }
    }
}