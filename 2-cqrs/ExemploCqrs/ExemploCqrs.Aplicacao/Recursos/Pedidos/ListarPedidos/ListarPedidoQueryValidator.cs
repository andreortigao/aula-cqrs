using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ExemploCqrs.Aplicacao.Recursos.Pedidos.ListarPedidos
{
    public class ListarPedidoQueryValidator : AbstractValidator<ListarPedidosQuery>
    {
        public ListarPedidoQueryValidator()
        {
            RuleFor(x => x.PrecoMaximo).GreaterThan(0);
            RuleFor(x => x.PrecoMinimo).GreaterThan(0).LessThan(x => x.PrecoMaximo);
        }
    }
}
