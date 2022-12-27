using FluentValidation;

namespace ExemploCqrs.Aplicacao.Recursos.Pedidos.AdicionarPedido
{
    public sealed class AdicionarPedidoCommandValidator : AbstractValidator<AdicionarPedidoCommand>
    {
        public AdicionarPedidoCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.CustomerId).GreaterThanOrEqualTo(1);

            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
