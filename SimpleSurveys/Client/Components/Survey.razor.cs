using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SimpleSurveys.Client.Components
{
    public partial class Survey
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Survey SurveyItem { get; set; } = new();

        [Parameter]
        public Enums.Mode Mode { get; set; }

        [Parameter]
        public EventCallback<SimpleSurveys.Shared.Models.Survey> OnSubmit { get; set; }

        [Parameter]
        public EventCallback<SimpleSurveys.Shared.Models.SurveyResult> OnSubmitResult { get; set; }

        private ushort? submissionsValue
        {
            get
            {
                return (ushort?)SurveyItem.MaxSubmissions;
            }
            set
            {
                SurveyItem.MaxSubmissions = value;
            }
        }

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                SurveyItem = new();
            }

            base.OnParametersSet();
        }

        private async Task OnSubmitClickAsync()
        {
            switch(Mode)
            {
                case Enums.Mode.Create:
                case Enums.Mode.Edit:
                    await OnSubmit.InvokeAsync(SurveyItem);
                    break;
                case Enums.Mode.View:
                    await OnSubmitResult.InvokeAsync(new()/* TOOD: RESULT */);
                    break;
            }
        }

        private void AddStep<T>() where T : SimpleSurveys.Shared.Models.Step, new()
        {
            SurveyItem.Steps.Add(new T()
            {
                Position = int.MaxValue
            });

            FixStepPositions();
        }

        private void OnStepUp(SimpleSurveys.Shared.Models.Step step)
        {
            FixStepPositions();

            int current = step.Position;

            SimpleSurveys.Shared.Models.Step down = SurveyItem.Steps.SingleOrDefault(s => s.Position == current - 1);

            if (down != default(SimpleSurveys.Shared.Models.Step))
            {
                step.Position = down.Position;

                down.Position = current;
            }
        }

        private void OnStepDown(SimpleSurveys.Shared.Models.Step step)
        {
            FixStepPositions();

            int current = step.Position;

            SimpleSurveys.Shared.Models.Step up = SurveyItem.Steps.SingleOrDefault(s => s.Position == current + 1);

            if (up != default(SimpleSurveys.Shared.Models.Step))
            {
                step.Position = up.Position;

                up.Position = current;
            }
        }

        private void OnStepClose(SimpleSurveys.Shared.Models.Step step)
        {
            SurveyItem.Steps.Remove(step);

            FixStepPositions();
        }

        private void FixStepPositions()
        {
            List<SimpleSurveys.Shared.Models.Step> ordered = SurveyItem.Steps.OrderBy(s => s.Position).ToList();

            for (int i = 0; i < ordered.Count; i++)
            {
                SimpleSurveys.Shared.Models.Step step = SurveyItem.Steps.Single(s => s == ordered.ElementAt(i));

                step.Position = i;
            }
        }
    }
}
