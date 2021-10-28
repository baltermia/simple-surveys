using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class DropDown
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.DropDown DropDownItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }
    }
}
