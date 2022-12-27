using ExemploHexagonal.AdapterOutRepository.postgreSql.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploHexagonal.AdapterOutRepository.postgreSql
{
    public class AppDbContext : DbContext
    {
        private IDbContextTransaction contextTransaction;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<ClienteEntidade> Products { get; set; }
    }
}
