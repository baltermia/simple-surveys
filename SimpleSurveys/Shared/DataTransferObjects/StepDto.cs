using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SimpleSurveys.Shared.DataTransferObjects
{
    public abstract class StepDto : IDataTransferObject
    {
        public int Id { get; set; }

        public int SurveyID { get; set; }

        public string Title { get; set; }

        public bool Required { get; set; } = false;

        public int Position { get; set; }

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Objects)]
        public virtual ICollection<StepResultDto> Results { get; set; } = new HashSet<StepResultDto>();

        public virtual SurveyDto Survey { get; set; }
    }
    
    public class RadioDto : StepDto
    {
        public virtual ICollection<ValueDto> Values { get; set; } = new HashSet<ValueDto>();

        public RadioDto()
        {
            Values = new HashSet<ValueDto>();
        }
    }

    public class RangeDto : StepDto
    {
        public int Min { get; set; } = 0;

        public int Max { get; set; } = 10;
    }

    public class TextDto : StepDto
    {
        public string Placeholder { get; set; } = null;
    }

    public class CheckDto : StepDto
    {
        public virtual ICollection<ValueDto> Values { get; set; }

        public CheckDto()
        {
            Values = new HashSet<ValueDto>();
        }
    }

    public class YesNoDto : StepDto {  }

    public class DateDto : StepDto
    {
        public string Placeholder { get; set; } = null;

        public DateTime? Default { get; set; } = null;

        public virtual DatePickerType Type { get; set; }
    }

    public class NumberDto : StepDto
    {
        public string Placeholder { get; set; } = null;

        public int? Default { get; set; } = null;
    }

    public class RateDto : StepDto
    {
        public bool AllowHalf { get; set; } = false;
    }

    public class DropDownDto : StepDto
    {
        public virtual ICollection<ValueDto> Values { get; set; }

        public int? Default { get; set; } = null;

        public string Placeholder { get; set; } = null;

        public bool MultiSelect { get; set; } = false;

        public DropDownDto()
        {
            Values = new HashSet<ValueDto>();
        }
    }

    public enum DatePickerType
    {
        DateTime = 0,   // Both date and time
        Date = 1,        // Only Date
        Week = 2,
        Month = 3,
        Quarter = 4,
        Year = 5,
        Time = 6        // Only Time
    }
}