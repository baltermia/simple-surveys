using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using SimpleSurveys.Shared.Models;
using SimpleSurveys.Shared.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleSurveys.Server.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityID
    {
        private readonly SimpleSurveysContext context;

        public RepositoryBase(SimpleSurveysContext context)
        {
            this.context = context;
        }

        public T Create(T entity)
        {
            return context.Set<T>().Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await FindAll().ToListAsync();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return FindAll().Where(expression);
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await FindByCondition(expression).ToListAsync();
        }

        public T FindByID(int id)
        {
            return FindByCondition(e => e.ID == id).FirstOrDefault();
        }

        public async Task<T> FindByIDAsync(int id)
        {
            return await FindByCondition(e => e.ID == id).FirstOrDefaultAsync();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
