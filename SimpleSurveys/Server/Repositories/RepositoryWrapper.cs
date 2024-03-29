﻿using SimpleSurveys.Shared.Configuration;
using SimpleSurveys.Shared.Models;
using System.Threading.Tasks;

namespace SimpleSurveys.Server.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SimpleSurveysContext context;

        private IRepositoryBase<Survey> _survey;
        private IRepositoryBase<Step> _step;
        private IRepositoryBase<SurveyResult> _surveyResult;
        private IRepositoryBase<StepResult> _stepResult;
        private IRepositoryBase<Value> _value;

        public IRepositoryBase<Survey> Survey => CreateBase(ref _survey);
        public IRepositoryBase<Step> Step => CreateBase(ref _step);
        public IRepositoryBase<SurveyResult> SurveyResult => CreateBase(ref _surveyResult);
        public IRepositoryBase<StepResult> StepResult => CreateBase(ref _stepResult);
        public IRepositoryBase<Value> Value => CreateBase(ref _value);

        public RepositoryWrapper(SimpleSurveysContext context)
        {
            this.context = context;
        }

        public async Task SaveAsync() => await context.SaveChangesAsync();

        private IRepositoryBase<T> CreateBase<T>(ref IRepositoryBase<T> repository) where T : EntityID => repository ??= new RepositoryBase<T>(context);
    }
}
