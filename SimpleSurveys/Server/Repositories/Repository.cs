using SimpleSurveys.Shared.Models;

namespace SimpleSurveys.Server.Repositories
{
    public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class 
    {
        public Repository(SimpleSurveysContext context) : base(context) {  }
    }
}
