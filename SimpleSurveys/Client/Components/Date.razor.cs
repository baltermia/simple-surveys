using Microsoft.AspNetCore.Components;
using SimpleSurveys.Client.Utils;
using SimpleSurveys.Shared.DataTransferObjects;
using System;

namespace SimpleSurveys.Client.Components
{
    public partial class Date
    {
        [Parameter]
        public DateDto DateItem { get; set; }

        [Parameter]
        public Enums.Mode Mode { get; set; }

        public DateTime? DateValue { get; set; }

        private DatePickerType dateType
        {
            get => DateItem.Type;
            set
            {
                DateItem.Default = null;
                DateItem.Type = value;
            }
        }

        protected override void OnParametersSet()
        {
            switch (Mode)
            {
                case Enums.Mode.Create:
                    DateItem = new();
                    break;
                case Enums.Mode.View:
                    DateValue = DateItem.Default;
                    break;
            }
        }
    }
}
