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

        public virtual Step Step { get; set; }
        public virtual SurveyResult SurveyResult { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a Radio step
    /// </summary>
    public class RadioResult : StepResult
    {
        public int ValueID { get; set; }

        /// <summary>
        /// The selected radiobox
        /// </summary>
        [Required]
        public virtual Value Value { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a Range step
    /// </summary>
    public class RangeResult : StepResult
    {
        /// <summary>
        /// The submitted number (whole number, therefore int)
        /// </summary>
        [Required]
        public int Value { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a Text step
    /// </summary>
    public class TextResult : StepResult
    {
        /// <summary>
        /// The submitted text
        /// </summary>
        [Required]
        public string Value { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a Check step
    /// </summary>
    public class CheckResult : StepResult
    {
        /// <summary>
        /// All checked items
        /// </summary>
        [Required]
        public virtual ICollection<Value> Values { get; set; }

        public CheckResult()
        {
            Values = new HashSet<Value>();
        }
    }

    /// <summary>
    /// Holds the submitted data of a YosNo step
    /// </summary>
    public class YesNoResult : StepResult
    {
        /// <summary>
        /// Yes = true, no = false (not quite obvious ha)
        /// </summary>
        [Required]
        public bool Value { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a Date step
    /// </summary>
    public class DateResult : StepResult
    {
        /// <summary>
        /// Selected DateTime
        /// </summary>
        [Required]
        public virtual DateTime Value { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a Number step
    /// </summary>
    public class NumberResult : StepResult
    {
        /// <summary>
        /// Int value
        /// </summary>
        [Required]
        public int Value { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a Rate step
    /// </summary>
    public class RateResult : StepResult
    {
        /// <summary>
        /// The string value (rating is stored as '{number}M', so this has to be a string
        /// </summary>
        [Required]
        public string Value { get; set; }
    }

    /// <summary>
    /// Holds the submitted data of a DropDown step
    /// </summary>
    public class DropDownResult : StepResult
    {
        /// <summary>
        /// What values got selected (can be one or multiple, because of DropDown.MultiSelect)
        /// </summary>
        [Required]
        public virtual ICollection<Value> Values { get; set; }

        public DropDownResult()
        {
            Values = new HashSet<Value>();
        }
    }
}
