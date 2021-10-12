using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleSurveys.Shared.Models
{
    public class Survey : EntityID
    {
        /// <summary>
        /// Displayed name of the survey
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Displayed description of the survey
        /// </summary>
        public string Description { get; set; } = null;

        /// <summary>
        /// When the Survey was created
        /// </summary>
        [Column(TypeName = "datetime"), Editable(false, AllowInitialValue = true)]
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// When the survey got edited the last time (not including initialization)
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? Updated { get; set; } = null;

        /// <summary>
        /// Whether the Survey is open (meaning it can still be answered)
        /// </summary>
        public bool Open { get; set; } = true;

        /// <summary>
        /// Last time the survey got closed
        /// </summary>
        public DateTime? ClosedSince { get; set; } = null;

        /// <summary>
        /// Password which is needed to make changes after creating the survey and access the results data
        /// </summary>
        public string Password = null;

        /// <summary>
        /// The maximum amount of submissions of this survey. The survey is closed when this is reached
        /// </summary>
        public int? MaxSubmissions = null;

        /// <summary>
        /// Whether the results of the survey are public
        /// </summary>
        public bool Public { get; set; } = true;

        public ICollection<Step> Steps { get; set; }
        public ICollection<SurveyResult> SurveyResults { get; set; }
    }
}
