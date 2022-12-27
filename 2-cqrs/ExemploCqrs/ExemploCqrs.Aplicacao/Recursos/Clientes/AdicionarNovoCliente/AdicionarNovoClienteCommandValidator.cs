using FluentValidation;

namespace ExemploCqrs.Aplicacao.Recursos.Clientes.AdicionarNovoCliente
{
    public sealed class AdicionarNovoClienteCommandValidator : AbstractValidator<AdicionarNovoClienteCommand>
    {
        public AdicionarNovoClienteCommandValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(128);

            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().MaximumLength(255);
        }
    }
}
