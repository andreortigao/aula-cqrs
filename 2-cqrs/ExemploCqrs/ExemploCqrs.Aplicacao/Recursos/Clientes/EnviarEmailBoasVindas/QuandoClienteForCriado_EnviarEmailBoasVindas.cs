using ExemploCqrs.Aplicacao.Eventos.Clientes;
using ExemploCqrs.Aplicacao.Geral;
using MediatR;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;

namespace ExemploCqrs.Aplicacao.Recursos.Clientes.EnviarEmailBoasVindas
{
    public class QuandoClienteForCriado_EnviarEmailBoasVindas : INotificationHandler<ClienteCriadoEvent>
    {
        private readonly SmtpSettings _smtpSettings;

        public QuandoClienteForCriado_EnviarEmailBoasVindas(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task Handle(ClienteCriadoEvent notification, CancellationToken cancellationToken)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_smtpSettings.FromName, _smtpSettings.FromEmail));
            message.To.Add(new MailboxAddress(notification.Cliente.Nome, notification.Cliente.Email));
            message.Subject = "Welcome";

            message.Body = new TextPart("plain")
            {
                Text = "Thanks for joining!"
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, _smtpSettings.UseSsl, cancellationToken);

                if (!string.IsNullOrEmpty(_smtpSettings.UserName) && !string.IsNullOrEmpty(_smtpSettings.Password))
                {
                    await client.AuthenticateAsync(_smtpSettings.UserName, _smtpSettings.Password, cancellationToken);
                }

                await client.SendAsync(message, cancellationToken);
                await client.DisconnectAsync(true, cancellationToken);
            }
        }
    }
}
