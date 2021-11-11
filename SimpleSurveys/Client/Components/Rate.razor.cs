using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Rate
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Rate RateItem { get; set; }

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
