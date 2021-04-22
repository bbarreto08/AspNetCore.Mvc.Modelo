using Modelo.Business.Interfaces;
using Modelo.Business.Models;
using System;
using System.Threading.Tasks;

namespace Modelo.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public Task Adicionar(Produto fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Produto fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
