namespace SimpleSurveys.Shared.Models
{
    public class StepResult_Value : EntityID
    {
        public int StepResultID { get; set; }
        public int ValueID { get; set; }

        public StepResult StepResult { get; set; }
        public Value Value { get; set; }
    }
}
