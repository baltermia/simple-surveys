using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    /// <summary>
    /// Holds the results data of a step
    /// </summary>
    public abstract class StepResult : IEntity
    {
        public int ID { get; set; }
        public int StepID { get; set; }

        public Step Step { get; set; }
    }

    public class RadioResult : StepResult
    {
        [Required]
        public string Answer { get; set; }
    }

    public class RangeResult : StepResult
    {
        [Required]
        public int Value { get; set; }
    }

    public class TextResult : StepResult
    {
        [Required]
        public string Answer { get; set; }
    }

    public class CheckResult : StepResult
    {
        [Required]
        public IEnumerable<string> Items { get; set; }
    }

    public class YesNoResult : StepResult
    {
        [Required]
        public bool Result { get; set; }
    }

    public class DateResult : StepResult
    {
        [Required]
        public DateTime DateTime { get; set; }
    }

    public class NumberResult : StepResult
    {
        public int Value { get; set; }
    }

    public class RateResult : StepResult
    {
        [Required]
        public string Answer { get; set; }
    }

    public class DropDownResult : StepResult
    {
        public IEnumerable<string> Items { get; set; }
    }
}
