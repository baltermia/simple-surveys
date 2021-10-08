using System;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleSurveys.Server.Repositories
{
    public interface IRepositoryBase<T>
    {
        T Create(T entity);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
    }
}
