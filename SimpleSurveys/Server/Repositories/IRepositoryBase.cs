using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SimpleSurveys.Server.Repositories
{
    public interface IRepositoryBase<T>
    {
        T Create(T entity);
        Task<IEnumerable<T>> FindAllAsync();
        IQueryable<T> FindAll();
        Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindByIDAsync(int id);
        T FindByID(int id);
        void Update(T entity);
        void Delete(T entity);
    }
}
