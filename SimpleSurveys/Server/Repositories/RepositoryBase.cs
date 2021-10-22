using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using SimpleSurveys.Shared.Models;
using SimpleSurveys.Shared.Configuration;

namespace SimpleSurveys.Server.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
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

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
