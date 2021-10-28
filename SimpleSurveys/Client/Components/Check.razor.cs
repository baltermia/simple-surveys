using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Check
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Check CheckItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }
    }
}
