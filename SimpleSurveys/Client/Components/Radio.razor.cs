using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class Radio
    {
        [Parameter]
        public RadioDto RadioItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                RadioItem = new();
            }
        }
    }
}
