using ExemploCqrs.Dominio;
using MediatR;

namespace ExemploCqrs.Aplicacao.Eventos.Clientes
{
    public record ClienteCriadoEvent : INotification
    {
        public Cliente Cliente { get; init; }
    }
}
