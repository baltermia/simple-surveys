﻿using System;
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
        public DateTime Submitted { get; set; } = DateTime.Now;

        /// <summary>
        /// The name of the submitter (optional at the start of survey)
        /// </summary>
        public string Name { get; set; } = null;

        public ICollection<StepResult> StepResults { get; set; }

        public Survey Survey { get; set; }
    }
}