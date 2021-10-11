using SimpleSurveys.Shared.Models;

namespace SimpleSurveys.Server.Repositories
{
    public interface IRepositoryWrapper
    {
        IRepositoryBase<Survey> Survey { get; }
        IRepositoryBase<Step> Step { get; }
        IRepositoryBase<SurveyType> StepType{ get; }
        IRepositoryBase<SurveyType> SurveyType { get; }
        void Save();
    }
}
