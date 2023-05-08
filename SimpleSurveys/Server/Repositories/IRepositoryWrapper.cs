using SimpleSurveys.Data.Models;
using System.Threading.Tasks;

namespace SimpleSurveys.Server.Repositories
{
    public interface IRepositoryWrapper
    {
        IRepositoryBase<Survey> Survey { get; }
        IRepositoryBase<Step> Step { get; }
        IRepositoryBase<SurveyResult> SurveyResult { get; }
        IRepositoryBase<StepResult> StepResult { get; }
        IRepositoryBase<Value> Value { get; }
        Task SaveAsync();
    }
}
