using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SimpleSurveys.Shared.DataTransferObjects
{
    public class SurveyResultDto : IDataTransferObject
    {
        public int Id { get; set; }

        public int SurveyID { get; set; }

        public virtual DateTime Submitted { get; set; } = DateTime.Now;

        public string Name { get; set; } = null;

        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Objects)]
        public virtual ICollection<StepResultDto> StepResults { get; set; }

        public virtual SurveyDto Survey { get; set; }

        public SurveyResultDto()
        {
            StepResults = new HashSet<StepResultDto>();
        }
    }
}