using System.Collections.Generic;

namespace SimpleSurveys.Shared.DataTransferObjects
{
    public class ValueDto : IDataTransferObject
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Radio> Radios { get; set; }
        public virtual ICollection<Check> Checks { get; set; }
        public virtual ICollection<DropDown> DropDowns { get; set; }

        public virtual ICollection<CheckResult> CheckResults { get; set; }
        public virtual ICollection<DropDownResult> DropDownResults { get; set; }
        public virtual ICollection<RadioResult> RadioResults { get; set; }

        public ValueDto()
        {
            Radios = new HashSet<Radio>();
            Checks = new HashSet<Check>();
            DropDowns = new HashSet<DropDown>();
            CheckResults = new HashSet<CheckResult>();
            DropDownResults = new HashSet<DropDownResult>();
            RadioResults = new HashSet<RadioResult>();
        }
    }
}