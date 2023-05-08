using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class Survey
    {
        [Parameter]
        public SurveyDto SurveyItem { get; set; } = new();

        [Parameter]
        public Enums.Mode Mode { get; set; }

        [Parameter]
        public EventCallback<SurveyDto> OnSubmit { get; set; }

        [Parameter]
        public EventCallback<SurveyResultDto> OnSubmitResult { get; set; }

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

        private void AddStep<T>() where T : StepDto, new()
        {
            SurveyItem.Steps.Add(new T()
            {
                Position = int.MaxValue
            });

            FixStepPositions();
        }

        private void OnStepUp(StepDto step)
        {
            FixStepPositions();

            int current = step.Position;

            StepDto down = SurveyItem.Steps.SingleOrDefault(s => s.Position == current - 1);

            if (down != default(StepDto))
            {
                step.Position = down.Position;

                down.Position = current;
            }
        }

        private void OnStepDown(StepDto step)
        {
            FixStepPositions();

            int current = step.Position;

            StepDto up = SurveyItem.Steps.SingleOrDefault(s => s.Position == current + 1);

            if (up != default(StepDto))
            {
                step.Position = up.Position;

                up.Position = current;
            }
        }

        private void OnStepClose(StepDto step)
        {
            SurveyItem.Steps.Remove(step);

            FixStepPositions();
        }

        private void FixStepPositions()
        {
            List<StepDto> ordered = SurveyItem.Steps.OrderBy(s => s.Position).ToList();

            for (int i = 0; i < ordered.Count; i++)
            {
                StepDto step = SurveyItem.Steps.Single(s => s == ordered.ElementAt(i));

                step.Position = i;
            }
        }
    }
}
