using SimpleSurveys.Shared.Models;

namespace SimpleSurveys.Server.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SimpleSurveysContext context;

        private IRepository<Survey>     _survey;
        private IRepository<Step>       _step;
        private IRepository<SurveyType> _surveyType;
        private IRepository<SurveyType> _stepType;

        public IRepository<Survey>      Survey      =>  CreateIfNull(ref _survey);
        public IRepository<Step>        Step        =>  CreateIfNull(ref _step);
        public IRepository<SurveyType>  SurveyType  =>  CreateIfNull(ref _surveyType);
        public IRepository<SurveyType>  StepType    =>  CreateIfNull(ref _stepType);

        public RepositoryWrapper(SimpleSurveysContext context)
        {
            this.context = context;
        }

        public void Save() => context.SaveChanges();

        private IRepository<T> CreateIfNull<T>(ref IRepository<T> repository) where T : class => repository ??= new Repository<T>(context);
    }
}
