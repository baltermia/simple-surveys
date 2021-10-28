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
    }
}
