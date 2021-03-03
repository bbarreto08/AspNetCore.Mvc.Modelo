using Microsoft.EntityFrameworkCore;
using Modelo.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            {
                property.Relational().ColumnType = "VARCHAR(100)";
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModeloContext).Assembly);

            foreach (var relationShip in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationShip.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

    }
}
