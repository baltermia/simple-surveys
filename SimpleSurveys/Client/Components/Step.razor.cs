using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Step
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Step StepItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        [Parameter]
        public EventCallback<SimpleSurveys.Shared.Models.Step> OnUp { get; set; }

        [Parameter]
        public EventCallback<SimpleSurveys.Shared.Models.Step> OnDown { get; set; }

        [Parameter]
        public EventCallback<SimpleSurveys.Shared.Models.Step> OnClose { get; set; }

        private async void OnUpClick()
        {
            await OnUp.InvokeAsync(StepItem);
        }

        private async void OnDownClick()
        {
            await OnDown.InvokeAsync(StepItem);
        }

        private async void OnCloseClick()
        {
            await OnClose.InvokeAsync(StepItem);
        }
    }
}
