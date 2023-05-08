using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SimpleSurveys.Shared.DataTransferObjects
{
    public class SurveyDto : IDataTransferObject
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; } = null;

        public virtual DateTime Created { get; set; } = DateTime.Now;

        public virtual DateTime? Updated { get; set; } = null;

        public bool Open { get; set; } = true;

        public virtual DateTime? ClosedSince { get; set; } = null;

        public string Password { get; set; } = null;

        public int? MaxSubmissions { get; set; } = null;

        public bool Public { get; set; } = true;

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Objects)]
        public virtual ICollection<StepDto> Steps { get; set; }

        public virtual ICollection<SurveyResultDto> SurveyResults { get; set; }

        public SurveyDto()
        {
            Steps = new HashSet<StepDto>();
            SurveyResults = new HashSet<SurveyResultDto>();
        }
    }
}
