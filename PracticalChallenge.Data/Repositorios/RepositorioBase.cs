using Microsoft.EntityFrameworkCore;
using PracticalChallenge.Business.Entidades;
using PracticalChallenge.Business.Interfaces.Repositorio;
using PracticalChallenge.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PracticalChallenge.Data.Repositorios
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade> where TEntidade : EntidadeBase, new()
    {
        protected readonly PracticalChallengeContexto Contexto;
        protected readonly DbSet<TEntidade> DbSet;

        public RepositorioBase(PracticalChallengeContexto contexto)
        {
            Contexto = contexto;
            DbSet = contexto.Set<TEntidade>();
        }

        public virtual async Task Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntidade { Id = id });
            await SaveChanges();
        }

        public virtual async Task<TEntidade> BuscarPorId(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
        }

        public virtual async Task<IEnumerable<TEntidade>> BuscarTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> expression)
        {
            return await DbSet.AsNoTracking().Where(expression).ToListAsync();
        }

        public void Dispose()
        {
            Contexto?.Dispose();
        }

        public async Task SaveChanges()
        {
            await Contexto.SaveChangesAsync();
        }

        
    }
}
