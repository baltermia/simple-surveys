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
    }
}
