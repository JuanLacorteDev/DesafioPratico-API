using PracticalChallenge.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PracticalChallenge.Business.Interfaces.Repositorio
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        Task<bool> ExisteProduto(Guid id);
    }
}
