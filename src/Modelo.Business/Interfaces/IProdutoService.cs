﻿using Modelo.Business.Models;
using System;
using System.Threading.Tasks;

namespace Modelo.Business.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        Task Adicionar(Produto fornecedor);
        Task Atualizar(Produto fornecedor);
        Task Remover(Guid id);
    }
}
