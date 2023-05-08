using System.Collections.Generic;

namespace SimpleSurveys.Shared.DataTransferObjects
{
    public class ValueDto : IDataTransferObject
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<RadioDto> Radios { get; set; }
        public virtual ICollection<CheckDto> Checks { get; set; }
        public virtual ICollection<DropDownDto> DropDowns { get; set; }

        public virtual ICollection<CheckResultDto> CheckResults { get; set; }
        public virtual ICollection<DropDownResultDto> DropDownResults { get; set; }
        public virtual ICollection<RadioResultDto> RadioResults { get; set; }

        public ValueDto()
        {
            Radios = new HashSet<RadioDto>();
            Checks = new HashSet<CheckDto>();
            DropDowns = new HashSet<DropDownDto>();
            CheckResults = new HashSet<CheckResultDto>();
            DropDownResults = new HashSet<DropDownResultDto>();
            RadioResults = new HashSet<RadioResultDto>();
        }
    }
}