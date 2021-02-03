namespace servico.notificacao.Infra.CrossCutting.Environment.EnvironmentConfiguration
{
    public class GmailConfiguration
    {
        // var nomeGestao = "Gestao 7 aplicativo";
        // var emailGestao = "gestao7app@gmail.com";
        // var passwordGestao = "G9@genor104";
        // var host = "smtp.gmail.com";
        // var port = 465;
        // var useSsl = true;

        public string NomeEmail { get; set; }
        public string Host { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
    }
}