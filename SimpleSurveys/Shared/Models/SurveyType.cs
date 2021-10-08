using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    public class SurveyType : EntityID
    {
        [Required]
        public string Name { get; set; }
    }
}