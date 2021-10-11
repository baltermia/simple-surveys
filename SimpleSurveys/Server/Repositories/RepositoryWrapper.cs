using SimpleSurveys.Shared.Models;

namespace SimpleSurveys.Server.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SimpleSurveysContext context;

        private IRepositoryBase<Survey>     _survey;
        private IRepositoryBase<Step>       _step;
        private IRepositoryBase<SurveyType> _surveyType;
        private IRepositoryBase<SurveyType> _stepType;

        public IRepositoryBase<Survey>      Survey      =>  CreateBase(ref _survey);
        public IRepositoryBase<Step>        Step        =>  CreateBase(ref _step);
        public IRepositoryBase<SurveyType>  SurveyType  =>  CreateBase(ref _surveyType);
        public IRepositoryBase<SurveyType>  StepType    =>  CreateBase(ref _stepType);

        public RepositoryWrapper(SimpleSurveysContext context)
        {
            this.context = context;
        }

        public void Save() => context.SaveChanges();

        private IRepositoryBase<T> CreateBase<T>(ref IRepositoryBase<T> repository) where T : class => repository ??= new RepositoryBase<T>(context);
    }
}
