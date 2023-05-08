using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class DropDown
    {
        [Parameter]
        public DropDownDto DropDownItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                DropDownItem = new();
            }
        }
    }
}
