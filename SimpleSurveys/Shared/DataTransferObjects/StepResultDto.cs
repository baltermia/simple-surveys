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

    public class RadioResult : StepResultDto
    {
        public int ValueID { get; set; }

        public virtual ValueDto Value { get; set; }
    }

    public class RangeResult : StepResultDto
    {
        public int Value { get; set; }
    }

    public class TextResult : StepResultDto
    {
        public string Value { get; set; }
    }

    public class CheckResult : StepResultDto
    {
        public virtual ICollection<ValueDto> Values { get; set; }

        public CheckResult()
        {
            Values = new HashSet<ValueDto>();
        }
    }

    public class YesNoResult : StepResultDto
    {
        public bool Value { get; set; }
    }

    public class DateResult : StepResultDto
    {
        public virtual DateTime Value { get; set; }
    }

    public class NumberResult : StepResultDto
    {
        public int Value { get; set; }
    }

    public class RateResult : StepResultDto
    {
        public string Value { get; set; }
    }

    public class DropDownResult : StepResultDto
    {
        public virtual ICollection<ValueDto> Values { get; set; }

        public DropDownResult()
        {
            Values = new HashSet<ValueDto>();
        }
    }
}
