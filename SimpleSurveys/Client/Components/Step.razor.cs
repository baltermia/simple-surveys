using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class Step
    {
        [Parameter]
        public StepDto StepItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        [Parameter]
        public EventCallback<StepDto> OnUp { get; set; }

        [Parameter]
        public EventCallback<StepDto> OnDown { get; set; }

        [Parameter]
        public EventCallback<StepDto> OnClose { get; set; }

        private string StepIcon
        {
            get => mIcon;
            set
            {
                if (mIcon == value)
                {
                    return;
                }

                mIcon = value;

                StateHasChanged();
            }
        }

        private string mIcon = AntDesign.IconType.Outline.Question;

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
