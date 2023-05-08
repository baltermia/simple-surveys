using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class Check
    {
        [Parameter]
        public CheckDto CheckItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                CheckItem = new();
            }
        }
    }
}
