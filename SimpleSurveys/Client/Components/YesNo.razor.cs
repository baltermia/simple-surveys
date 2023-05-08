using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using AntDesign;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class YesNo
    {
        [Parameter]
        public YesNoDto YesNoItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        public bool? Result { get; private set; } = null;

        private string yesType = ButtonType.Default;
        private string noType = ButtonType.Default;

        protected override void OnParametersSet()
        {
            if (Mode == Enums.Mode.Create)
            {
                YesNoItem = new();
            }
        }

        private void YesClick()
        {
            if (Result == true)
            {
                Result = null;
            }
            else
            {
                Result = true;
            }

            ChangeButtonTypes();
        }

        private void NoClick()
        {
            if (Result == false)
            {
                Result = null;
            }
            else
            {
                Result = false;
            }

            ChangeButtonTypes();
        }

        private void ChangeButtonTypes()
        {
            if (Result == true)
            {
                yesType = ButtonType.Primary;
                noType = ButtonType.Default;
            }
            else if (Result == false)
            {
                yesType = ButtonType.Default;
                noType = ButtonType.Primary;
            }
            else
            {
                yesType = ButtonType.Default;
                noType = ButtonType.Default;
            }
        }
    }
}
