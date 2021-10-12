using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    public class Value : EntityID
    {
        [Required]
        public string Text { get; set; }

        public ICollection<StepResult_Value> StepResult_Values { get; set; }
        public ICollection<Step_Value> Step_Values { get; set; }
    }
}
