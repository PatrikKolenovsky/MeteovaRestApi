using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Sg1Context Sg1Context { get; set; }

        public RepositoryBase(Sg1Context sg1Context)
        {
            this.Sg1Context = sg1Context;
        }

        public IQueryable<T> FindAll()
        {
            return this.Sg1Context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.Sg1Context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.Sg1Context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.Sg1Context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.Sg1Context.Set<T>().Remove(entity);
        }
    }
}
