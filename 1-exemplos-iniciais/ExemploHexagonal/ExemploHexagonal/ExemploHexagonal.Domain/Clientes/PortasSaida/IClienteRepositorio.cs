using ExemploHexagonal.Domain.Clientes.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHexagonal.Domain.Clientes.PortasSaida
{
    public interface IClienteRepositorio
    {
        void Inserir(Cliente cliente);
        Cliente? Ler(int id);
    }
}
