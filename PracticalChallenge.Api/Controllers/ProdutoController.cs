using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PracticalChallenge.Api.EntidadesDto;
using PracticalChallenge.Business.Entidades;
using PracticalChallenge.Business.Interfaces.Notificacoes;
using PracticalChallenge.Business.Interfaces.Repositorio;
using PracticalChallenge.Business.Interfaces.Servico;
using PracticalChallenge.Business.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalChallenge.Api.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepositorio produtoRepositorio,
                                 IProdutoService produtoService,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _produtoRepositorio = produtoRepositorio;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        //[Route("Listar")]
        public async Task<ActionResult<IEnumerable<ProdutoDto>>> ObterProdutos()
        {
            //por ser apenas consulta acredito não haver necessidade de levar à complexidade de um serviço, então faço uso direto do repositorio.
            return Ok(_mapper.Map<IEnumerable<ProdutoDto>>(await _produtoRepositorio.BuscarTodos()));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProdutoDto>> ObterProduto(Guid id)
        {
            var retorno = _mapper.Map<ProdutoDto>(await _produtoRepositorio.BuscarPorId(id));
            if (retorno != null) return CustomResponse(retorno);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDto>> Adicionar(ProdutoDto produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var novoProduto = _mapper.Map<Produto>(produto);
            await _produtoService.Adicionar(novoProduto);

            return CustomResponse(novoProduto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> AtualizarProduto(Guid id, ProdutoDto produto)
        {
            if (id != produto.Id)
            {
                NotificarErro(MensagensNotificacao.MN002);
                return CustomResponse();
            }
            else if (!await _produtoRepositorio.ExisteProduto(id))
            {
                return NoContent();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produtoAtualizar = _mapper.Map<ProdutoDto>(await _produtoRepositorio.BuscarPorId(id));
            produtoAtualizar.Nome = produto.Nome;
            produtoAtualizar.ValorUnitario = produto.ValorUnitario;
            produtoAtualizar.Quantidade = produto.Quantidade;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizar));
            return CustomResponse(produtoAtualizar);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> RemoverProduto(Guid id)
        {
            if (!await _produtoRepositorio.ExisteProduto(id))
            {
                //NotificarErro(MensagensNotificacao.MN001);
                return NoContent();
            }

            await _produtoService.Remover(id);
            return CustomResponse();
        }


    }
}
