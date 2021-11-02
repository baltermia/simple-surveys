using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Survey
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Survey SurveyItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        protected override void OnParametersSet()
        {
            SurveyItem = new();

            base.OnParametersSet();
        }

        private void OnSubmit()
        {

        }

        private void AddStep<T>() where T : SimpleSurveys.Shared.Models.Step, new()
        {
            SurveyItem.Steps.Add(new T());
        }
    }
}
