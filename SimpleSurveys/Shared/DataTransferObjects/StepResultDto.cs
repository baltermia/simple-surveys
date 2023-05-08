using System;
using System.Collections.Generic;

namespace SimpleSurveys.Shared.DataTransferObjects
{
    public abstract class StepResultDto : IDataTransferObject
    {
        public int Id { get; set; }

        public int StepID { get; set; }
        public int SurveyResultID { get; set; }

        public virtual StepDto Step { get; set; }
        public virtual SurveyResultDto SurveyResult { get; set; }
    }

    public class RadioResultDto : StepResultDto
    {
        public int ValueID { get; set; }

        public virtual ValueDto Value { get; set; }
    }

    public class RangeResultDto : StepResultDto
    {
        public int Value { get; set; }
    }

    public class TextResultDto : StepResultDto
    {
        public string Value { get; set; }
    }

    public class CheckResultDto : StepResultDto
    {
        public virtual ICollection<ValueDto> Values { get; set; }

        public CheckResultDto()
        {
            Values = new HashSet<ValueDto>();
        }
    }

    public class YesNoResultDto : StepResultDto
    {
        public bool Value { get; set; }
    }

    public class DateResultDto : StepResultDto
    {
        public virtual DateTime Value { get; set; }
    }

    public class NumberResultDto : StepResultDto
    {
        public int Value { get; set; }
    }

    public class RateResultDto : StepResultDto
    {
        public string Value { get; set; }
    }

    public class DropDownResultDto : StepResultDto
    {
        public virtual ICollection<ValueDto> Values { get; set; }

        public DropDownResultDto()
        {
            Values = new HashSet<ValueDto>();
        }
    }
}
