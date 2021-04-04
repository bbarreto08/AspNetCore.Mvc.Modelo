﻿using Microsoft.EntityFrameworkCore;
using Modelo.Business.Interfaces;
using Modelo.Business.Models;
using Modelo.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ModeloContext modeloContext) : base(modeloContext)
        {

        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
                            .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(p => p.FornecedorId == fornecedorId);
        }
    }
}
