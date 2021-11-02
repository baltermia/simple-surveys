using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SimpleSurveys.Shared.Models
{
    /// <summary>
    /// Holds the results data of a survey
    /// </summary>
    public class SurveyResult : EntityID
    {
        public int SurveyID { get; set; }

        /// <summary>
        /// DateTime when the survey got submitted (default value is DateTime.Now)
        /// </summary>
        public virtual DateTime Submitted { get; set; } = DateTime.Now;

        /// <summary>
        /// The name of the submitter (optional at the start of survey)
        /// </summary>
        public string Name { get; set; } = null;

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)]
        public virtual ICollection<StepResult> StepResults { get; set; }

        public virtual Survey Survey { get; set; }

        public SurveyResult()
        {
            StepResults = new HashSet<StepResult>();
        }
    }
}