using SimpleSurveys.Shared.Models;

namespace SimpleSurveys.Server.Repositories
{
    public interface IRepositoryWrapper
    {
        IRepository<Survey> Survey { get; }
        IRepository<Step> Step { get; }
        IRepository<SurveyType> StepType{ get; }
        IRepository<SurveyType> SurveyType { get; }
        void Save();
    }
}
