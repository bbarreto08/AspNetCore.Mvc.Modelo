using Microsoft.EntityFrameworkCore;
using Modelo.Business.Interfaces;
using Modelo.Business.Models;
using Modelo.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Modelo.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly ModeloContext db;
        protected readonly DbSet<TEntity> dbSet;

        protected Repository(ModeloContext db)
        {
            this.db = db;
            this.dbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObeterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObeterTodos(Guid id)
        {
            return await dbSet.ToListAsync();
        }
        public async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {            
            dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }

        public async void Dispose()
        {
            db?.Dispose();
        }

    }
}
