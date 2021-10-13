using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    /// <summary>
    /// Holds the results data of a step
    /// </summary>
    public abstract class StepResult : EntityID
    {
        public int StepID { get; set; }
        public int SurveyResultID { get; set; }

        public Step Step { get; set; }
        public SurveyResult SurveyResult { get; set; }
    }

    public class RadioResult : StepResult
    {
        [Required]
        public string Value { get; set; }
    }

    public class RangeResult : StepResult
    {
        [Required]
        public int Value { get; set; }
    }

    public class TextResult : StepResult
    {
        [Required]
        public string Value { get; set; }
    }

    public class CheckResult : StepResult
    {
        [Required]
        public virtual ICollection<StepResult_Value> StepResult_Value { get; set; }
    }

    public class YesNoResult : StepResult
    {
        [Required]
        public bool Value { get; set; }
    }

    public class DateResult : StepResult
    {
        [Required]
        public DateTime Value { get; set; }
    }

    public class NumberResult : StepResult
    {
        [Required]
        public int Value { get; set; }
    }

    public class RateResult : StepResult
    {
        [Required]
        public string Value { get; set; }
    }

    public class DropDownResult : StepResult
    {
        [Required]
        public virtual ICollection<StepResult_Value> StepResult_Value { get; set; }
    }
}
