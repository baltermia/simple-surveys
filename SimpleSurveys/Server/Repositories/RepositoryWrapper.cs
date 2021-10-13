using SimpleSurveys.Shared.Models;

namespace SimpleSurveys.Server.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SimpleSurveysContext context;

        private IRepositoryBase<Survey> _survey;
        private IRepositoryBase<Step> _step;
        private IRepositoryBase<SurveyResult> _surveyResult;
        private IRepositoryBase<StepResult> _stepResult;
        private IRepositoryBase<Step_Value> _step_Value;
        private IRepositoryBase<StepResult_Value> _stepResult_Value;
        private IRepositoryBase<Value> _value;

        public IRepositoryBase<Survey> Survey => CreateBase(ref _survey);
        public IRepositoryBase<Step> Step => CreateBase(ref _step);
        public IRepositoryBase<SurveyResult> SurveyResult => CreateBase(ref _surveyResult);
        public IRepositoryBase<StepResult> StepResult => CreateBase(ref _stepResult);
        public IRepositoryBase<Step_Value> Step_Value => CreateBase(ref _step_Value);
        public IRepositoryBase<StepResult_Value> StepResult_Value => CreateBase(ref _stepResult_Value);
        public IRepositoryBase<Value> Value => CreateBase(ref _value);

        public RepositoryWrapper(SimpleSurveysContext context)
        {
            this.context = context;
        }

        public void Save() => context.SaveChanges();

        private IRepositoryBase<T> CreateBase<T>(ref IRepositoryBase<T> repository) where T : class => repository ??= new RepositoryBase<T>(context);
    }
}
