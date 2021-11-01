using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Text
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Text TextItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        public string TextValue { get; private set; }

        protected override void OnInitialized()
        {
            if (Mode == Enums.Mode.Create)
            {
                TextItem = new();
            }
        }
    }
}
