using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;

namespace SimpleSurveys.Client.Components
{
    public partial class Range
    {
        [Parameter]
        public RangeDto RangeItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        private double rangeDouble { get; set; }

        private bool paramsSet = false;

        public int RangeValue
        {
            get => (int)rangeDouble;
            set => rangeDouble = value;
        }

        protected override void OnParametersSet()
        {
            switch (Mode)
            {
                case Enums.Mode.Create:
                    RangeItem = new();
                    break;
            }

            paramsSet = true;
        }
    }
}
