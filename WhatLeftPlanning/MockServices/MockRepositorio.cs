using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatLeftPlanning.Services;

namespace WhatLeftPlanning.MockServices
{
    public class MockRepositorio<TEntity> : IRepositorio<TEntity>
        where TEntity : class
    {
        protected readonly Dictionary<Type, object> Context;
        internal List<TEntity> dbSet;

        public MockRepositorio(Dictionary<Type, object> context)
        {
            Context = context;            
            dbSet = context[typeof(TEntity)] as List<TEntity>;
        }

        public async Task<TEntity> GetByID(int id)
        {
            await Task.Run(() => Thread.Sleep(100));
            foreach (var item in dbSet)
            {
                if (item.GetType().GetProperty("ID").GetValue(item, null).Equals(id))
                    return item;
            }
            return null;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            await Task.Run(() => Thread.Sleep(100));
            return  dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            await Task.Run(() => Thread.Sleep(100));
            return  dbSet.Where(predicate.Compile()).ToList();
        }

        public void Add(TEntity entity) =>  dbSet.Add(entity);
        public void AddRange(IEnumerable<TEntity> entities) => dbSet.AddRange(entities);

        public void Remove(TEntity entity) => dbSet.Remove(entity);
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                Remove(item);
            }
        }
    }

}
