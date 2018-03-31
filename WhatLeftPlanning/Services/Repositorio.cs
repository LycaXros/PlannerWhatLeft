using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WhatLeftPlanning.Services
{
    public class Repositorio<TEntity> : IRepositorio<TEntity>
        where TEntity : class
    {
        protected readonly DbContext Context;
        internal DbSet<TEntity> dbSet;

        public Repositorio(DbContext context)
        {
            Context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByID(int id)
        {
            return  await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll() => await dbSet.ToListAsync();
        

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
         => await dbSet.Where(predicate).ToListAsync();
        

        public void Add(TEntity entity) =>  dbSet.Add(entity);
        public void AddRange(IEnumerable<TEntity> entities) => dbSet.AddRange(entities);

        public void Remove(TEntity entity) => dbSet.Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities) => dbSet.RemoveRange(entities);


    }

}
