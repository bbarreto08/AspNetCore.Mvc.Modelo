using Microsoft.EntityFrameworkCore;
using Modelo.Business.Interfaces;
using Modelo.Business.Models;
using Modelo.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(ModeloContext modeloContext) : base(modeloContext)
        {

        }

        public async Task<IEnumerable<Fornecedor>> ObterTodos()
        {
            return await db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco).ToListAsync();
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await db.Fornecedores.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await db.Fornecedores.AsNoTracking()
                .Include(c => c.Produtos)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
