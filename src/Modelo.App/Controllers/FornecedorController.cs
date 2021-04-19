using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Modelo.App.ViewModels;
using Modelo.Business.Interfaces;
using Modelo.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Modelo.App.Controllers
{
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorRepository fornecedorRepository,
                                    IMapper mapper,
                                    IEnderecoRepository enderecoRepository)
        {
            this._fornecedorRepository = fornecedorRepository;
            this._mapper = mapper;
            this._enderecoRepository = enderecoRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            FornecedorViewModel fornecedorViewModel = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
                await _fornecedorRepository.Adicionar(fornecedor);
                
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }
            return View(fornecedorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
                await _fornecedorRepository.Atualizar(fornecedor);

                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorViewModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);
          
            if(fornecedorViewModel == null)
            {
                return NotFound();
            }

            await _fornecedorRepository.Remover(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ObterEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if(fornecedor == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesEndereco", fornecedor);
        }

        public async Task<IActionResult> AtualizarEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if(fornecedor == null)
            {
                return NotFound();
            }

            return PartialView("_AtualizarEndereco", new FornecedorViewModel { Endereco = fornecedor.Endereco });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtualizarEndereco(FornecedorViewModel fornecedorViewModel)
        {
            ModelState.Remove("Nome");
            ModelState.Remove("Documento");

            if (!ModelState.IsValid)
            {
                return PartialView("_AtualizarEndereco", fornecedorViewModel);
            }

            await _enderecoRepository.Atualizar(_mapper.Map<Endereco>(fornecedorViewModel.Endereco));

            var url = Url.Action("ObterEndereco", "Fornecedor", new { id = fornecedorViewModel.Endereco.FornecedorId });

            return Json(new { success = true, url });
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}
