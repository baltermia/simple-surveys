using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Number
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Number NumberItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }
    }
}
