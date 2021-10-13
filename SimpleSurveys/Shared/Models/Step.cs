using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    /// <summary>
    /// The main Step class
    /// </summary>
    public abstract class Step : EntityID
    {
        public int SurveyID { get; set; }

        [Required]
        public string Title { get; set; }

        public bool Required { get; set; } = false;

        public virtual ICollection<StepResult> Results { get; set; }

        public Survey Survey { get; set; }
    }

    /// <summary>
    /// A Step that can be answered using RadioBoxes
    /// </summary>
    public class Radio : Step
    {
        public virtual ICollection<Value> Values { get; set; }
    }

    /// <summary>
    /// A step with a range (normally from 0-10)
    /// </summary>
    public class Range : Step
    {
        public int Min { get; set; } = 0;
        public int Max { get; set; } = 10;
    }

    /// <summary>
    /// A Step that only has a TextBox
    /// </summary>
    public class Text : Step
    {
        public string Placeholder { get; set; } = null;
    }

    /// <summary>
    /// A Step that has ComboBoxes
    /// </summary>
    public class Check : Step
    {
        public virtual ICollection<Value> Values { get; set; }
    }

    /// <summary>
    /// A Step that can be answered either by yes or no
    /// </summary>
    public class YesNo : Step
    {

    }

    /// <summary>
    /// A Step where the user can input a Date and Time
    /// </summary>
    public class Date : Step
    {
        public string Placeholder { get; set; } = null;
        public DateTime? Default { get; set; } = null;

        [Required]
        public DatePickerType Type { get; set; }
    }

    /// <summary>
    /// A Step where the user can input a single number
    /// </summary>
    public class Number : Step
    {
        public string Placeholder { get; set; } = null;
        public int? Default { get; set; } = null;
    }

    /// <summary>
    /// A step showing 5 stars of which the user can select the rating
    /// </summary>
    public class Rate : Step
    {
        public bool AllowHalf { get; set; } = false;
    }

    /// <summary>
    /// A step using a select box
    /// </summary>
    public class DropDown : Step
    {
        public virtual ICollection<Value> Values{ get; set; }
        public int? Default { get; set; } = null;
        public string Placeholder { get; set; } = null;
        public bool MultiSelect { get; set; } = false;
    }

    /// <summary>
    /// What type a DateTime picker is
    /// </summary>
    public enum DatePickerType
    {
        DateTime,   // Both date and time
        Date,       // Only Date
        Week,
        Month,
        Quarter,
        Year,
        Time        // Only Time
    }
}