using Microsoft.EntityFrameworkCore;
using Modelo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Data.Context
{
    public class ModeloContext : DbContext
    {
        public ModeloContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }


    }
}
