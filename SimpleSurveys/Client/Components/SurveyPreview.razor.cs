using Microsoft.AspNetCore.Components;

namespace SimpleSurveys.Client.Components
{
    public partial class SurveyPreview
    {
        [Inject]
        public NavigationManager NavManager { get; set; }

        [Parameter]
        public SimpleSurveys.Shared.Models.Survey SurveyItem { get; set; }
    }
}
