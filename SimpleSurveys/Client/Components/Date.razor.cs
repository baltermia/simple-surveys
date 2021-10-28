using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Date
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Date DateItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }
    }
}
