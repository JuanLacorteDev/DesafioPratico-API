using Microsoft.EntityFrameworkCore;
using PracticalChallenge.Business.Entidades;
using PracticalChallenge.Business.Interfaces.Repositorio;
using PracticalChallenge.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticalChallenge.Data.Repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(PracticalChallengeContexto contexto) : base(contexto) { }

        public async Task<bool> ExisteProduto(Guid id)
        {
            return await Contexto.Produtos.AsNoTracking().AnyAsync(p => p.Id == id);
        }
    }
}
