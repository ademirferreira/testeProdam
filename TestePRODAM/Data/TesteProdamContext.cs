using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestePRODAM.Models;

namespace TestePRODAM.Data
{
    public class TesteProdamContext : DbContext
    {
        public TesteProdamContext (DbContextOptions<TesteProdamContext> options) 
            : base(options) { }        
        
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; } 
    }
}
