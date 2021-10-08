using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    public class SurveyType : Entity
    {
        [Required]
        public string Name { get; set; }
    }
}