using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class YesNo
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.YesNo YesNoItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }
    }
}
