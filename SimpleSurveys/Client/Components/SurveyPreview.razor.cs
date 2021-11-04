using Microsoft.AspNetCore.Components;

namespace SimpleSurveys.Client.Components
{
    public partial class SurveyPreview
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Survey SurveyItem { get; set; }
    }
}
