namespace SimpleSurveys.Shared.Models
{
    public class Step_Value : EntityID
    {
        public int StepID { get; set; }
        public int ValueID { get; set; }

        public Step Step { get; set; }
        public Value Value { get; set; }
    }
}