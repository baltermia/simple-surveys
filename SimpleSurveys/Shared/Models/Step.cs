using Newtonsoft.Json;
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

        /// <summary>
        /// The title ('question'), on top of the step
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Whether the step is required
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        /// All submitted steps
        /// </summary>
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Objects)]
        public virtual ICollection<StepResult> Results { get; set; } = new HashSet<StepResult>();

        public virtual Survey Survey { get; set; }
    }
    
    /// <summary>
    /// A Step that can be answered using RadioBoxes
    /// </summary>
    public class Radio : Step
    {
        /// <summary>
        /// The items that can be selected in the radiobox list
        /// </summary>
        public virtual ICollection<Value> Values { get; set; } = new HashSet<Value>();

        public Radio()
        {
            Values = new HashSet<Value>();
        }
    }

    /// <summary>
    /// A step with a range (normally from 0-10)
    /// </summary>
    public class Range : Step
    {
        /// <summary>
        /// The minimum value possible (inclusive, default is 10)
        /// </summary>
        public int Min { get; set; } = 0;

        /// <summary>
        /// The maximum value possible (inclusive, default is 10)
        /// </summary>
        public int Max { get; set; } = 10;
    }

    /// <summary>
    /// A Step that only has a TextBox
    /// </summary>
    public class Text : Step
    {
        /// <summary>
        /// Text that is being displayed on top of the textbox
        /// </summary>
        public string Placeholder { get; set; } = null;
    }

    /// <summary>
    /// A Step that has checkboxes
    /// </summary>
    public class Check : Step
    {
        /// <summary>
        /// The items that can be selected in the checkbox list
        /// </summary>
        public virtual ICollection<Value> Values { get; set; }

        public Check()
        {
            Values = new HashSet<Value>();
        }
    }

    /// <summary>
    /// A Step that can be answered either by yes or no
    /// </summary>
    public class YesNo : Step {  }

    /// <summary>
    /// A Step where the user can input a Date and Time
    /// </summary>
    public class Date : Step
    {
        /// <summary>
        /// Text that is being displayed on top of the datepicker
        /// </summary>
        public string Placeholder { get; set; } = null;

        /// <summary>
        /// The default date (use DateTime.Min or DateTime.Max to use the date/time of the page load)
        /// </summary>
        public DateTime? Default { get; set; } = null;

        /// <summary>
        /// What type the datepicker is
        /// </summary>
        [Required]
        public virtual DatePickerType Type { get; set; }
    }

    /// <summary>
    /// A Step where the user can input a single number
    /// </summary>
    public class Number : Step
    {
        /// <summary>
        /// Text that is being displayed on top of the number input box
        /// </summary>
        public string Placeholder { get; set; } = null;

        /// <summary>
        /// The default number
        /// </summary>
        public int? Default { get; set; } = null;
    }

    /// <summary>
    /// A step showing 5 stars of which the user can select the rating
    /// </summary>
    public class Rate : Step
    {
        /// <summary>
        /// Whether the user can select half starts
        /// </summary>
        public bool AllowHalf { get; set; } = false;
    }

    /// <summary>
    /// A step using a select box
    /// </summary>
    public class DropDown : Step
    {
        /// <summary>
        /// The items that can be selected in the dropdown
        /// </summary>
        public virtual ICollection<Value> Values { get; set; }

        /// <summary>
        /// Index of the default item (notice that if this is set Placeholder has no use)
        /// </summary>
        public int? Default { get; set; } = null;

        /// <summary>
        /// Text that is being displayed on top of the dropdown
        /// </summary>
        public string Placeholder { get; set; } = null;

        /// <summary>
        /// Whether multiple items in the dropdown can be selected
        /// </summary>
        public bool MultiSelect { get; set; } = false;

        public DropDown()
        {
            Values = new HashSet<Value>();
        }
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