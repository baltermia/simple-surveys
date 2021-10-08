using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSurveys.Shared.Models
{
    public class Survey : Entity
    {
        public int SurveyID { get; set; }

        /// <summary>
        /// Displayed name of the survey
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Displayed description of the survey
        /// </summary>
        [Required, Editable(false, AllowInitialValue = true)]
        public string Description { get; set; }

        /// <summary>
        /// DateTime when 
        /// </summary>
        [Required, Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        /// <summary>
        /// What type this survey is
        /// </summary>
        [Required]
        public SurveyType SurveyType { get; set; }

        /// <summary>
        /// How many times the survey has been completed (probably the same as entries in Results)
        /// </summary>
        public int TimesCompleted { get; set; } = 0;

        /// <summary>
        /// Whether the Survey is closed (meaning it can't be answered anymore)
        /// </summary>
        public bool Closed { get; set; } = false;

        /// <summary>
        /// Last time the survey got closed
        /// </summary>
        public DateTime? ClosedSince { get; set; } = null;

        /// <summary>
        /// Password which is needed to make changes after creating the survey and access the results data
        /// </summary>
        public string Password = null;

        /// <summary>
        /// Whether the results of the survey are public
        /// </summary>
        public bool Public { get; set; } = true;

        public ICollection<Step> Steps { get; set; }
        public ICollection<SurveyResult> Results { get; set; }
    }
}
