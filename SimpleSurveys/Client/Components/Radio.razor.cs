using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Radio
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Radio RadioItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }
    }
}
