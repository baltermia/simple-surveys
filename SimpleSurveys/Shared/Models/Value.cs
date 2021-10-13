using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    public class Value : EntityID
    {
        [Required]
        public string Text { get; set; }

        public virtual ICollection<Step> Steps { get; set; }
        public virtual ICollection<StepResult> StepResults { get; set; }
    }
}
