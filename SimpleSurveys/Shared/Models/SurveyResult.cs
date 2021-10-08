using System;
using System.Collections.Generic;

namespace SimpleSurveys.Shared.Models
{
    /// <summary>
    /// Holds the results data of a survey
    /// </summary>
    public class SurveyResult : IEntity
    {
        public int ID { get; set; }
        public int SurveyID { get; set; }

        /// <summary>
        /// DateTime when the survey got submitted (default value is DateTime.Now)
        /// </summary>
        public DateTime Submitted { get; set; } = DateTime.Now;

        /// <summary>
        /// The name of the submitter (optional at the start of survey)
        /// </summary>
        public string Name { get; set; } = null;

        public ICollection<StepResult> Results { get; set; }

        public Survey Survey { get; set; }
    }
}