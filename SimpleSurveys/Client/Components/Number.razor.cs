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

        public int? NumberValue { get; set; }

        protected override void OnParametersSet()
        {
            switch (Mode) 
            {
                case Enums.Mode.Create:
                    NumberItem = new();
                    break;
                case Enums.Mode.View:
                    NumberValue = NumberItem.Default;
                    break;
            }
        }
    }
}
