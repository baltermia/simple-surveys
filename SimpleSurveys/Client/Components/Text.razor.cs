using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class Text : ComponentBase
    {
        [Parameter]
        public TextDto TextItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        public string TextValue { get; private set; }

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                TextItem = new();
            }
        }
    }
}
