using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    public class Value : EntityID
    {
        [Required]
        public string Text { get; set; }

        public ICollection<Step> Steps { get; set; }
        public ICollection<StepResult> StepResults { get; set; }
    }
}
