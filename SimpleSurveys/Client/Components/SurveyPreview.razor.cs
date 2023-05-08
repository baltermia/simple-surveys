using Microsoft.AspNetCore.Components;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class SurveyPreview
    {
        [Parameter]
        public SurveyDto SurveyItem { get; set; }
    }
}
