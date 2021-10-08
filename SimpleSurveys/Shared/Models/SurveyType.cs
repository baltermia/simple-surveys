using System.ComponentModel.DataAnnotations;

namespace SimpleSurveys.Shared.Models
{
    public class SurveyType : IEntity
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}