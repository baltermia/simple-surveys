using AntDesign;
using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;

namespace SimpleSurveys.Client.Components
{
    public partial class Range
    {
        [Parameter]
        public SimpleSurveys.Shared.Models.Range RangeItem { get; set; }

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
