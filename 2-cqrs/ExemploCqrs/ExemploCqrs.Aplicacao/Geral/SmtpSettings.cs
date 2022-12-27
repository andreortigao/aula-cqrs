namespace ExemploCqrs.Aplicacao.Geral
{
    public class SmtpSettings
    {
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
    }
}
