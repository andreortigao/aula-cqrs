using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExemploCamadas.Modelo;

namespace ExemploCamadas.Apresentacao.Data
{
    public class ExemploCamadasApresentacaoContext : DbContext
    {
        public ExemploCamadasApresentacaoContext (DbContextOptions<ExemploCamadasApresentacaoContext> options)
            : base(options)
        {
        }

        public DbSet<ExemploCamadas.Modelo.Cliente> Cliente { get; set; } = default!;
    }
}
