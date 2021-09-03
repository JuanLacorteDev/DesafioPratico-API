using PracticalChallenge.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PracticalChallenge.Business.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntidade> : IDisposable where TEntidade : EntidadeBase, new()
    {
        Task Adicionar(TEntidade entidade);
        Task Remover(Guid id);
        Task Atualizar(TEntidade entidade);
        Task<TEntidade> BuscarPorId(Guid id); 
        Task<IEnumerable<TEntidade>> BuscarTodos();
        Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> expression);
        Task SaveChanges();
    }
}
