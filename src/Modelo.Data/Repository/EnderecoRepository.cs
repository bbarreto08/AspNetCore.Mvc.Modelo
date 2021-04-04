using Microsoft.EntityFrameworkCore;
using Modelo.Business.Interfaces;
using Modelo.Business.Models;
using Modelo.Data.Context;
using System;
using System.Threading.Tasks;

namespace Modelo.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ModeloContext modeloContext) : base(modeloContext)
        {

        }
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await db.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync( f => f.FornecedorId == fornecedorId);
        }
    }
}
