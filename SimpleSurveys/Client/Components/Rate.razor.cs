using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class Rate
    {
        [Parameter]
        public RateDto RateItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        public decimal RateValue { get; private set; }

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                RateItem = new();
            }
        }
    }
}
