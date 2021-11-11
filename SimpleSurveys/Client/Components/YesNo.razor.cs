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

        public bool? Result { get; private set; }

        private string yesType = AntDesign.ButtonType.Primary;
        private string noType = AntDesign.ButtonType.Default;

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                YesNoItem = new();
            }
        }
    }
}
