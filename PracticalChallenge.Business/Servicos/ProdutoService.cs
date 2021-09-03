using PracticalChallenge.Business.Entidades;
using PracticalChallenge.Business.Entidades.Validacao;
using PracticalChallenge.Business.Interfaces.Notificacoes;
using PracticalChallenge.Business.Interfaces.Repositorio;
using PracticalChallenge.Business.Interfaces.Servico;
using PracticalChallenge.Business.Mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalChallenge.Business.Servicos
{
    public class ProdutoService : ServicoBase, IProdutoService
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoService(IProdutoRepositorio produtoRepositorio,
                              INotificador notificador) : base(notificador)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task Adicionar(Produto produto)
        {
            if(!ExecutarValidacao(new ProdutoValidator(), produto)) return;
            var result = await _produtoRepositorio.Buscar(p => p.Nome.ToUpper() == produto.Nome.ToUpper());
            if (result.Count() > 0)
            {
                Notificar(MensagensNotificacao.MN003);
                return;
            }
            await _produtoRepositorio.Adicionar(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidator(), produto)) return;

            await _produtoRepositorio.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            await _produtoRepositorio.Remover(id);
        }
    }
}
